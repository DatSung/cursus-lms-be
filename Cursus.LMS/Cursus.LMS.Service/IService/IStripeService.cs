using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.Service;

public interface IStripeService
{
    Task<ResponseDTO> CreatePaymentSession
    (
        CreateStripeSessionDTO createStripeSessionDto
    );

    Task<ResponseDTO> ValidatePaymentSession
    (
        ValidateStripeSessionDTO validateStripeSessionDto
    );

    Task<ResponseDTO> CreateConnectedAccount
    (
        CreateStripeConnectedAccountDTO createStripeConnectedAccountDto
    );

    Task<ResponseDTO> AddCard
    (
        AddStripeCardDTO addStripeCardDto
    );

    Task<ResponseDTO> CreateTransfer
    (
        CreateStripeTransferDTO createStripeTransferDto
    );

    Task<ResponseDTO> CreatePayout
    (
        CreateStripePayoutDTO createStripePayoutDto
    );

    Task<ResponseDTO> GetStripeBalance();
}