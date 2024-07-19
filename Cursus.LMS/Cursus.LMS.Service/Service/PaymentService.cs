using System.Security.Claims;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;

namespace Cursus.LMS.Service.Service;

public class PaymentService : IPaymentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBalanceService _balanceService;
    private readonly ITransactionService _transactionService;
    private readonly IStripeService _stripeService;

    public PaymentService
    (
        IUnitOfWork unitOfWork,
        IBalanceService balanceService,
        ITransactionService transactionService,
        IStripeService stripeService
    )
    {
        _unitOfWork = unitOfWork;
        _balanceService = balanceService;
        _transactionService = transactionService;
        _stripeService = stripeService;
    }

    public async Task<ResponseDTO> UpdateAvailableBalanceByOrderId(Guid orderHeaderId)
    {
        try
        {
            var ordersDetails =
                await _unitOfWork.OrderDetailsRepository.GetAllAsync(x => x.OrderHeaderId == orderHeaderId);

            foreach (var orderDetails in ordersDetails)
            {
                var course = await _unitOfWork.CourseRepository.GetAsync
                (
                    x => x.Id == orderDetails.CourseId
                );

                var instructor = await _unitOfWork.InstructorRepository.GetAsync
                (
                    x => x.InstructorId == course.InstructorId
                );

                await _balanceService.UpsertBalance(
                    new UpsertBalanceDTO()
                    {
                        Currency = "usd",
                        AvailableBalance = orderDetails.CoursePrice,
                        PayoutBalance = 0,
                        UserId = instructor.UserId
                    }
                );

                await _transactionService.CreateTransaction
                (
                    new CreateTransactionDTO()
                    {
                        UserId = instructor.UserId,
                        Amount = orderDetails.CoursePrice,
                        Type = StaticEnum.TransactionType.Income,
                    }
                );
            }

            return new ResponseDTO()
            {
                Message = "Update balance successfully",
                IsSuccess = true,
                StatusCode = 200,
                Result = null
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = e.Message,
                IsSuccess = false,
                StatusCode = 500,
                Result = null
            };
        }
    }

    public async Task<ResponseDTO> CreateStripeConnectedAccount
    (
        CreateStripeConnectedAccountDTO createStripeConnectedAccountDto)
    {
        var user = await _unitOfWork.UserManagerRepository.FindByEmailAsync(createStripeConnectedAccountDto.Email);
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

        var responseDto = await _stripeService.CreateConnectedAccount(createStripeConnectedAccountDto);

        if (responseDto.StatusCode == 500)
        {
            return responseDto;
        }

        var result = (CreateStripeConnectedAccountDTO)responseDto.Result!;
        instructor.StripeAccountId = result.AccountId;
        await _unitOfWork.SaveAsync();

        return responseDto;
    }

    public async Task<ResponseDTO> CreateStripeTransfer(CreateStripeTransferDTO createStripeTransferDto)
    {
        if (createStripeTransferDto.UserId is null && createStripeTransferDto.ConnectedAccountId is null)
        {
            return new ResponseDTO()
            {
                Message = "User was not found",
                IsSuccess = false,
                StatusCode = 404,
                Result = createStripeTransferDto
            };
        }

        var user = await _unitOfWork.UserManagerRepository.FindByIdAsync(createStripeTransferDto.UserId);

        if (user is null)
        {
            return new ResponseDTO()
            {
                Message = "User was not found",
                IsSuccess = false,
                StatusCode = 404,
                Result = createStripeTransferDto
            };
        }

        var instructor = await _unitOfWork.InstructorRepository.GetAsync(x => x.UserId == user.Id);

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
                UserId = user.Id
            }
        );

        await _transactionService.CreateTransaction
        (
            new CreateTransactionDTO()
            {
                UserId = user.Id,
                Amount = createStripeTransferDto.Amount,
                Type = StaticEnum.TransactionType.Income
            }
        );

        return responseDto;
    }

    public async Task<ResponseDTO> AddStripeCard(AddStripeCardDTO addStripeCardDto)
    {
        return await _stripeService.AddCard(addStripeCardDto);
    }
}