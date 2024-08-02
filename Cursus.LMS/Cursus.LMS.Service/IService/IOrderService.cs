using System.Security.Claims;
using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface IOrderService
{
    Task<ResponseDTO> CreateOrder
    (
        ClaimsPrincipal User
    );

    Task<ResponseDTO> GetOrders
    (
        ClaimsPrincipal User,
        Guid? studentId,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber = 1,
        int pageSize = 5
    );

    Task<ResponseDTO> GetOrder
    (
        ClaimsPrincipal User,
        Guid orderHeaderId
    );

    Task<ResponseDTO> PayWithStripe
    (
        ClaimsPrincipal User,
        PayWithStripeDTO payWithStripeDto
    );

    Task<ResponseDTO> ValidateWithStripe
    (
        ClaimsPrincipal User,
        ValidateWithStripeDTO validateWithStripeDto
    );

    Task<ResponseDTO> ConfirmOrder(ClaimsPrincipal User, Guid orderHeaderId);
}