using Cursus.LMS.Model.DTO;
using Stripe;
using Stripe.Checkout;

namespace Cursus.LMS.Service.Service;

public class StripeService : IStripeService
{
    public async Task<ResponseDTO> CreateStripeSession(CreateStripeSessionDTO createStripeSessionDto)
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

    public async Task<ResponseDTO> ValidateStripeSession(ValidateStripeSessionDTO validateStripeSessionDto)
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
}