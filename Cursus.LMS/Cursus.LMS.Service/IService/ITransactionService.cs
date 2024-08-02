using System.Security.Claims;
using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface ITransactionService
{
    Task<ResponseDTO> GetTransactions
    (
        ClaimsPrincipal User,
        string? userId,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber = 1,
        int pageSize = 5
    );

    Task<ResponseDTO> CreateTransaction(CreateTransactionDTO createTransactionDto);
}