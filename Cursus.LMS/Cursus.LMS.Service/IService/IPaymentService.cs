using System.Security.Claims;
using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface IPaymentService
{
    Task<ResponseDTO> CreateStripeConnectedAccount
    (
        ClaimsPrincipal User,
        CreateStripeConnectedAccountDTO createStripeConnectedAccountDto
    );
    
    Task<ResponseDTO> CreateStripeTransfer(CreateStripeTransferDTO createStripeTransferDto);
    Task<ResponseDTO> AddStripeCard(AddStripeCardDTO addStripeCardDto);
    Task<ResponseDTO> CreateStripePayout(ClaimsPrincipal User, CreateStripePayoutDTO createStripePayoutDto);
    Task<ResponseDTO> GetLeastInstructorsByPayout(int topN, int? filterYear, int? filterMonth, int? filterQuarter);
    Task<ResponseDTO> GetTopInstructorsByPayout(int topN, int? filterYear, int? filterMonth, int? filterQuarter);
}