using System.Globalization;
using System.Security.Claims;
using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;
using Microsoft.IdentityModel.Tokens;

namespace Cursus.LMS.Service.Service;

public class TransactionService : ITransactionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TransactionService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseDTO> GetTransactions(
        ClaimsPrincipal User,
        string? userId,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber = 1,
        int pageSize = 5
    )
    {
        try
        {
            var transactions = new List<Transaction>();
            var role = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)!.Value;

            if (role.Contains(StaticUserRoles.Instructor) || role.Contains(StaticUserRoles.Student))
            {
                userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                transactions = _unitOfWork.TransactionRepository.GetAllAsync(x => x.UserId == userId).GetAwaiter()
                    .GetResult().ToList();
            }

            if (role.Contains(StaticUserRoles.Admin))
            {
                if (userId.IsNullOrEmpty())
                {
                    transactions = _unitOfWork.TransactionRepository
                        .GetAllAsync()
                        .GetAwaiter()
                        .GetResult()
                        .ToList();
                }
                else
                {
                    transactions = _unitOfWork.TransactionRepository
                        .GetAllAsync(x => x.UserId == userId)
                        .GetAwaiter()
                        .GetResult()
                        .ToList();
                }
            }

            // Filter Query
            if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterQuery))
            {
                switch (filterOn.Trim().ToLower())
                {
                    case "type":
                    {
                        transactions = transactions.Where
                            (
                                x => x.Type.ToString().Contains(filterQuery, StringComparison.CurrentCultureIgnoreCase))
                            .ToList();
                        break;
                    }
                    case "amount":
                    {
                        transactions = transactions.Where
                        (
                            x => x.Amount.ToString(CultureInfo.InvariantCulture).Contains(filterQuery,
                                StringComparison.CurrentCultureIgnoreCase)).ToList();
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy.Trim().ToLower())
                {
                    case "type":
                    {
                        transactions = isAscending == true
                            ? [.. transactions.OrderBy(x => x.Type)]
                            : [.. transactions.OrderByDescending(x => x.Type)];
                        break;
                    }
                    case "amount":
                    {
                        transactions = isAscending == true
                            ? [.. transactions.OrderBy(x => x.Amount)]
                            : [.. transactions.OrderByDescending(x => x.Amount)];
                        break;
                    }
                    case "time":
                    {
                        transactions = isAscending == true
                            ? [.. transactions.OrderBy(x => x.CreatedTime)]
                            : [.. transactions.OrderByDescending(x => x.CreatedTime)];
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }

            // Pagination
            if (pageNumber > 0 && pageSize > 0)
            {
                var skipResult = (pageNumber - 1) * pageSize;
                transactions = transactions.Skip(skipResult).Take(pageSize).ToList();
            }

            var transactionsDto = _mapper.Map<IEnumerable<GetTransactionDTO>>(transactions);

            return new ResponseDTO()
            {
                IsSuccess = true,
                Message = "Get transactions successfully",
                StatusCode = 200,
                Result = transactionsDto
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                IsSuccess = false,
                Message = e.Message,
                Result = null,
                StatusCode = 500
            };
        }
    }

    public async Task<ResponseDTO> CreateTransaction(CreateTransactionDTO createTransactionDto)
    {
        try
        {
            var transaction = new Transaction()
            {
                Id = Guid.NewGuid(),
                Amount = createTransactionDto.Amount,
                Currency = "usd",
                UserId = createTransactionDto.UserId,
                CreatedTime = DateTime.UtcNow,
                Type = createTransactionDto.Type
            };

            if (transaction.Type == StaticEnum.TransactionType.Purchase)
            {
                transaction.Amount *= 1.1;
            }

            await _unitOfWork.TransactionRepository.AddAsync(transaction);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                IsSuccess = true,
                Message = "Create transaction successfully",
                Result = transaction,
                StatusCode = 200
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                IsSuccess = false,
                Message = e.Message,
                Result = null,
                StatusCode = 500
            };
        }
    }
}