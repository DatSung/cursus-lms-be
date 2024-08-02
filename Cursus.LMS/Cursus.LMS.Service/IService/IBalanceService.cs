using System.Security.Claims;
using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface IBalanceService
{
    Task<ResponseDTO> GetBalance(ClaimsPrincipal User, string? userId);
    Task<ResponseDTO> UpsertBalance(UpsertBalanceDTO upsertBalanceDto);
}