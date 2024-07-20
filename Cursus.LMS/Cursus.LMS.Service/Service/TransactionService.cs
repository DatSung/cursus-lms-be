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
            if (userId.IsNullOrEmpty())
            {
                userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            }

            var transactions = await _unitOfWork.TransactionRepository.GetAllAsync(x => x.UserId == userId);


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