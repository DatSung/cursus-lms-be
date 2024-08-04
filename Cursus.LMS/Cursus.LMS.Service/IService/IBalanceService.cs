using System.Security.Claims;
using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface IBalanceService
{
    Task<ResponseDTO> GetSystemBalance(ClaimsPrincipal User);
    Task<ResponseDTO> GetInstructorBalance(ClaimsPrincipal User, string? userId);
    Task<ResponseDTO> UpsertBalance(UpsertBalanceDTO upsertBalanceDto);
    Task<ResponseDTO> UpdateAvailableBalanceByOrderId(Guid orderHeaderId);
}