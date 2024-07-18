using System.Security.Claims;
using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface IPaymentService
{
    Task<ResponseDTO> UpdateBalanceByOrderId(Guid orderHeaderId);
    Task<ResponseDTO> CreateStripeConnectedAccount(CreateStripeConnectedAccountDTO createStripeConnectedAccountDto);
    Task<ResponseDTO> CreateStripeTransfer(CreateStripeTransferDTO createStripeTransferDto);
    Task<ResponseDTO> AddStripeCard(AddStripeCardDTO addStripeCardDto);
}