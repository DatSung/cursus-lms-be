using System.Security.Claims;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;

namespace Cursus.LMS.Service.Service;

public class OrderService : IOrderService
{
    public Task<ResponseDTO> CreateOrder(ClaimsPrincipal User)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> GetOrder(ClaimsPrincipal User, Guid orderHeaderId)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> CreateStripeSession(ClaimsPrincipal User, StripeRequestDTO stripeRequestDto)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> ValidateStripeSession(ClaimsPrincipal User, Guid orderHeaderId)
    {
        throw new NotImplementedException();
    }
}