using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.Service;

public interface IStripeService
{
    Task<ResponseDTO> CreateStripeSession
    (
        CreateStripeSessionDTO createStripeSessionDto
    );
    Task<ResponseDTO> ValidateStripeSession
    (
        ValidateStripeSessionDTO validateStripeSessionDto
    );
}