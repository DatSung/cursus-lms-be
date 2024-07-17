using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;

namespace Cursus.LMS.Service.Service;

public class TransactionService : ITransactionService
{
    private readonly IUnitOfWork _unitOfWork;

    public TransactionService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
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