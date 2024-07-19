using System.Security.Claims;
using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface IPaymentService
{
    Task<ResponseDTO> CreateStripeConnectedAccount(CreateStripeConnectedAccountDTO createStripeConnectedAccountDto);
    Task<ResponseDTO> CreateStripeTransfer(CreateStripeTransferDTO createStripeTransferDto);
    Task<ResponseDTO> AddStripeCard(AddStripeCardDTO addStripeCardDto);
    Task<ResponseDTO> CreateStripePayout(ClaimsPrincipal User, CreateStripePayoutDTO createStripePayoutDto);
}