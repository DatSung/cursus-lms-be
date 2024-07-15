using System.Security.Claims;
using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface IOrderStatusService
{
    Task<ResponseDTO> GetOrdersStatus(Guid orderHeaderId);
    Task<ResponseDTO> GetOrderStatus(Guid orderStatusId);
    Task<ResponseDTO> CreateOrderStatus(ClaimsPrincipal User, CreateOrderStatusDTO createOrderStatusDto);
}