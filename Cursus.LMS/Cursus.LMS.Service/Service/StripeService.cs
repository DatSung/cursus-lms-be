using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.Service;

public class StripeService : IStripeService
{
    public Task<ResponseDTO> CreateStripeSession(CreateStripeSessionDTO createStripeSessionDto)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> ValidateStripeSession(ValidateStripeSessionDTO validateStripeSessionDto)
    {
        throw new NotImplementedException();
    }
}