using System.Security.Claims;
using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface IOrderService
{
    Task<ResponseDTO> CreateOrder
    (
        ClaimsPrincipal User
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
}