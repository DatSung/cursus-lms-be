﻿using Cursus.LMS.Model.DTO;
using Cursus.LMS.Utility.Constants;
using Stripe;
using Stripe.Checkout;

namespace Cursus.LMS.Service.Service;

public class StripeService : IStripeService
{
    public async Task<ResponseDTO> CreatePaymentSession(CreateStripeSessionDTO createStripeSessionDto)
    {
        try
        {
            var options = new SessionCreateOptions
            {
                SuccessUrl = createStripeSessionDto.ApprovedUrl,
                CancelUrl = createStripeSessionDto.CancelUrl,
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
            };

            if (createStripeSessionDto.OrdersDetails is null)
            {
                throw new NullReferenceException();
            }

            foreach (var orderDetail in createStripeSessionDto.OrdersDetails)
            {
                var sessionLineItem = new SessionLineItemOptions()
                {
                    PriceData = new SessionLineItemPriceDataOptions()
                    {
                        UnitAmount = (long)(orderDetail.CoursePrice * 100),
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions()
                        {
                            Name = orderDetail.CourseTitle,
                        }
                    },
                    Quantity = 1
                };
                options.LineItems.Add(sessionLineItem);
            }

            var service = new SessionService();
            var session = await service.CreateAsync(options);

            createStripeSessionDto.StripeSessionId = session.Id;
            createStripeSessionDto.StripeSessionUrl = session.Url;

            return new ResponseDTO()
            {
                Result = createStripeSessionDto,
                Message = "Create stripe session successfully",
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ResponseDTO> ValidatePaymentSession(ValidateStripeSessionDTO validateStripeSessionDto)
    {
        try
        {
            var service = new SessionService();
            var session = await service.GetAsync(validateStripeSessionDto.StripeSessionId);

            var paymentIntentService = new PaymentIntentService();
            var paymentIntent = await paymentIntentService.GetAsync(session.PaymentIntentId);

            validateStripeSessionDto.PaymentIntentId = paymentIntent.Id;
            validateStripeSessionDto.Status = paymentIntent.Status;

            return new ResponseDTO()
            {
                Result = validateStripeSessionDto,
                Message = "Validate stripe session successfully",
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ResponseDTO> CreateConnectedAccount
    (
        CreateStripeConnectedAccountDTO createStripeConnectedAccountDto
    )
    {
        // Create the stripe connected account
        var options = new AccountCreateOptions
        {
            Type = StaticEnum.StripeAccountType.express.ToString(),
            Email = createStripeConnectedAccountDto.Email,
            Country = createStripeConnectedAccountDto.Country,

            Capabilities = new AccountCapabilitiesOptions
            {
                CardPayments = new AccountCapabilitiesCardPaymentsOptions { Requested = true },
                Transfers = new AccountCapabilitiesTransfersOptions { Requested = true },
            },

            BusinessType = "individual",
        };

        var service = new AccountService();
        var account = await service.CreateAsync(options);

        // Get the setup link for the stripe connected account
        var accountLinkOptions = new AccountLinkCreateOptions
        {
            Account = account.Id,
            RefreshUrl = createStripeConnectedAccountDto.RefreshUrl,
            ReturnUrl = createStripeConnectedAccountDto.ReturnUrl,
            Type = StaticEnum.StripeAccountLinkType.account_onboarding.ToString(),
        };

        var accountLinkService = new AccountLinkService();
        var accountLink = await accountLinkService.CreateAsync(accountLinkOptions);

        return new ResponseDTO()
        {
            Result = accountLink.Url,
            IsSuccess = true,
            StatusCode = 200,
            Message = "Create stripe connected account successfully"
        };
    }

    public async Task<ResponseDTO> AddCard(AddStripeCardDTO addStripeCardDto)
    {
        var options = new ExternalAccountCreateOptions
        {
            ExternalAccount = addStripeCardDto.CardToken,
        };

        var service = new ExternalAccountService();
        var externalAccount = await service.CreateAsync(addStripeCardDto.ConnectedAccountId, options);

        return new ResponseDTO()
        {
            Result = externalAccount,
            IsSuccess = true,
            StatusCode = 200,
            Message = "Add card successfully"
        };
    }

    public async Task<ResponseDTO> CreateTransfer(CreateStripeTransferDTO createStripeTransferDto)
    {
        var options = new TransferCreateOptions
        {
            Amount = createStripeTransferDto.Amount * 100,
            Currency = createStripeTransferDto.Currency,
            Destination = createStripeTransferDto.ConnectedAccountId,
        };

        var transferService = new TransferService();
        var transfer = await transferService.CreateAsync(options);

        return new ResponseDTO()
        {
            Result = transfer,
            IsSuccess = true,
            StatusCode = 200,
            Message = "Create transfer successfully"
        };
    }
}