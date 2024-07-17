using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface ITransactionService
{
    Task<ResponseDTO> CreateTransaction(CreateTransactionDTO createTransactionDto);
}