using System.Security.Claims;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;
using Microsoft.IdentityModel.Tokens;
using Stripe;

namespace Cursus.LMS.Service.Service;

public class PaymentService : IPaymentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBalanceService _balanceService;
    private readonly ITransactionService _transactionService;
    private readonly IStripeService _stripeService;
    private readonly IEmailService _emailService;

    public PaymentService
    (
        IUnitOfWork unitOfWork,
        IBalanceService balanceService,
        ITransactionService transactionService,
        IStripeService stripeService, IEmailService emailService)
    {
        _unitOfWork = unitOfWork;
        _balanceService = balanceService;
        _transactionService = transactionService;
        _stripeService = stripeService;
        _emailService = emailService;
    }

    public async Task<ResponseDTO> CreateStripeConnectedAccount
    (
        ClaimsPrincipal User,
        CreateStripeConnectedAccountDTO createStripeConnectedAccountDto
    )
    {
        try
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = await _unitOfWork.UserManagerRepository.FindByIdAsync(userId);

            var instructor = await _unitOfWork.InstructorRepository.GetAsync(x => x.UserId == user.Id);

            if (instructor is null)
            {
                return new ResponseDTO()
                {
                    Message = "Instructor was not found",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null
                };
            }

            if (instructor.IsAccepted is false or null)
            {
                return new ResponseDTO()
                {
                    IsSuccess = false,
                    StatusCode = 403,
                    Result = null,
                    Message = "Instructor was not allow to create stripe account"
                };
            }

            if (!instructor.StripeAccountId.IsNullOrEmpty())
            {
                return new ResponseDTO()
                {
                    Message = "Instructor already has a stripe account",
                    IsSuccess = false,
                    StatusCode = 400,
                    Result = null
                };
            }

            createStripeConnectedAccountDto.Email = user.Email;

            var responseDto = await _stripeService.CreateConnectedAccount(createStripeConnectedAccountDto);

            if (responseDto.StatusCode == 500)
            {
                return responseDto;
            }

            var result = (ResponseStripeConnectedAccountDTO)responseDto.Result!;
            instructor.StripeAccountId = result.AccountId;
            await _unitOfWork.SaveAsync();

            return responseDto;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ResponseDTO> CreateStripeTransfer(CreateStripeTransferDTO createStripeTransferDto)
    {
        try
        {
            var instructor =
                await _unitOfWork.InstructorRepository.GetAsync(x => x.UserId == createStripeTransferDto.UserId);

            if (instructor is null)
            {
                return new ResponseDTO()
                {
                    Message = "Instructor was not found",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = createStripeTransferDto
                };
            }

            createStripeTransferDto.ConnectedAccountId = instructor?.StripeAccountId;

            var responseDto = await _stripeService.CreateTransfer(createStripeTransferDto);

            if (responseDto.StatusCode != 200) return responseDto;

            await _balanceService.UpsertBalance(new UpsertBalanceDTO()
                {
                    Currency = "usd",
                    AvailableBalance = createStripeTransferDto.Amount,
                    PayoutBalance = 0,
                    UserId = createStripeTransferDto.UserId
                }
            );

            await _transactionService.CreateTransaction
            (
                new CreateTransactionDTO()
                {
                    UserId = createStripeTransferDto.UserId,
                    Amount = createStripeTransferDto.Amount,
                    Type = StaticEnum.TransactionType.Income
                }
            );

            return responseDto;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ResponseDTO> AddStripeCard(AddStripeCardDTO addStripeCardDto)
    {
        return await _stripeService.AddCard(addStripeCardDto);
    }

    public async Task<ResponseDTO> CreateStripePayout
    (
        ClaimsPrincipal User,
        CreateStripePayoutDTO createStripePayoutDto
    )
    {
        try
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId is null)
            {
                return new ResponseDTO()
                {
                    Message = "User was not found",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = createStripePayoutDto
                };
            }

            var instructor = await _unitOfWork.InstructorRepository.GetAsync(x => x.UserId == userId);

            if (instructor is null)
            {
                return new ResponseDTO()
                {
                    Message = "Instructor was not found",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = createStripePayoutDto
                };
            }

            createStripePayoutDto.ConnectedAccountId = instructor?.StripeAccountId;

            var responseDto = await _stripeService.CreatePayout(createStripePayoutDto);

            if (responseDto.StatusCode == 500)
            {
                return responseDto;
            }

            var payout = (Payout)responseDto.Result!;

            if (payout.Status != "pending")
            {
                return responseDto;
            }

            await _transactionService.CreateTransaction
            (
                new CreateTransactionDTO()
                {
                    Amount = createStripePayoutDto.Amount,
                    Type = StaticEnum.TransactionType.Payout,
                    UserId = userId
                }
            );

            await _balanceService.UpsertBalance
            (
                new UpsertBalanceDTO()
                {
                    Currency = "usd",
                    AvailableBalance = -createStripePayoutDto.Amount,
                    PayoutBalance = createStripePayoutDto.Amount,
                    UserId = userId
                }
            );

            var userEmail = _unitOfWork.UserManagerRepository.FindByIdAsync(userId).GetAwaiter().GetResult().Email;
            if (userEmail != null)
            {
                await _emailService.SendEmailToInstructorAfterPayout
                (
                    userEmail,
                    createStripePayoutDto.Amount,
                    DateTime.Now
                );
            }

            return responseDto;
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = e.Message,
                StatusCode = 500,
                Result = null,
                IsSuccess = false
            };
        }
    }

    public async Task<ResponseDTO> GetTopInstructorsByPayout
    (
        int topN = 5,
        int? filterYear = null,
        int? filterMonth = null,
        int? filterQuarter = null
    )
    {
        try
        {
            // Kiểm tra tham số topN để đảm bảo nó hợp lệ
            if (topN <= 0)
            {
                throw new ArgumentException("The number of top instructors must be greater than zero.");
            }

            var currentYear = DateTime.UtcNow.Year;
            var startDate = DateTime.UtcNow;
            var endDate = DateTime.UtcNow;

            // Xác định khoảng thời gian dựa trên các bộ lọc
            if (filterYear.HasValue)
            {
                startDate = new DateTime(filterYear.Value, 1, 1);
                endDate = new DateTime(filterYear.Value, 12, 31, 23, 59, 59);
            }
            else
            {
                startDate = new DateTime(currentYear, 1, 1);
                endDate = new DateTime(currentYear, 12, 31, 23, 59, 59);
            }

            if (filterMonth.HasValue)
            {
                startDate = new DateTime(startDate.Year, filterMonth.Value, 1);
                endDate = startDate.AddMonths(1).AddSeconds(-1);
            }

            if (filterQuarter.HasValue)
            {
                int startMonth = (filterQuarter.Value - 1) * 3 + 1;
                startDate = new DateTime(startDate.Year, startMonth, 1);
                endDate = startDate.AddMonths(3).AddSeconds(-1);
            }

            var transactions = await _unitOfWork.TransactionRepository
                .GetAllAsync(
                    filter: x => x.Type == StaticEnum.TransactionType.Payout &&
                                 x.CreatedTime >= startDate && x.CreatedTime <= endDate,
                    includeProperties: "ApplicationUser"
                );

            var instructorPayouts = transactions
                .GroupBy(x => x.UserId)
                .Select(group => new
                {
                    InstructorId = group.First().ApplicationUser.Id,
                    FullName = group.First().ApplicationUser.FullName,
                    TotalPayout = group.Sum(x => x.Amount)
                })
                .OrderByDescending(x => x.TotalPayout)
                .Take(topN)
                .ToList();

            return new ResponseDTO()
            {
                Result = instructorPayouts,
                Message = "Get top instructors by payout successfully",
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = e.Message,
                StatusCode = 500,
                Result = null,
                IsSuccess = false
            };
        }
    }

    public async Task<ResponseDTO> GetLeastInstructorsByPayout(
        int topN = 5,
        int? filterYear = null,
        int? filterMonth = null,
        int? filterQuarter = null
    )
    {
        try
        {
            // Kiểm tra tham số topN để đảm bảo nó hợp lệ
            if (topN <= 0)
            {
                throw new ArgumentException("The number of least instructors must be greater than zero.");
            }

            var currentYear = DateTime.UtcNow.Year;
            var startDate = DateTime.UtcNow;
            var endDate = DateTime.UtcNow;

            // Xác định khoảng thời gian dựa trên các bộ lọc
            if (filterYear.HasValue)
            {
                startDate = new DateTime(filterYear.Value, 1, 1);
                endDate = new DateTime(filterYear.Value, 12, 31, 23, 59, 59);
            }
            else
            {
                startDate = new DateTime(currentYear, 1, 1);
                endDate = new DateTime(currentYear, 12, 31, 23, 59, 59);
            }

            if (filterMonth.HasValue)
            {
                startDate = new DateTime(startDate.Year, filterMonth.Value, 1);
                endDate = startDate.AddMonths(1).AddSeconds(-1);
            }

            if (filterQuarter.HasValue)
            {
                int startMonth = (filterQuarter.Value - 1) * 3 + 1;
                startDate = new DateTime(startDate.Year, startMonth, 1);
                endDate = startDate.AddMonths(3).AddSeconds(-1);
            }

            var transactions = await _unitOfWork.TransactionRepository
                .GetAllAsync(
                    filter: x => x.Type == StaticEnum.TransactionType.Payout &&
                                 x.CreatedTime >= startDate && x.CreatedTime <= endDate,
                    includeProperties: "ApplicationUser"
                );

            var instructorPayouts = transactions
                .GroupBy(x => x.UserId)
                .Select(group => new
                {
                    InstructorId = group.First().ApplicationUser.Id,
                    FullName = group.First().ApplicationUser.FullName,
                    TotalPayout = group.Sum(x => x.Amount)
                })
                .OrderBy(x => x.TotalPayout)
                .Take(topN)
                .ToList();

            return new ResponseDTO()
            {
                Result = instructorPayouts,
                Message = "Get least instructors by payout successfully",
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = e.Message,
                StatusCode = 500,
                Result = null,
                IsSuccess = false
            };
        }
    }
}