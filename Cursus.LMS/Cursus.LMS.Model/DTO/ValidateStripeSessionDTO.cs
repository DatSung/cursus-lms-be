namespace Cursus.LMS.Model.DTO;

public class ValidateStripeSessionDTO
{
    public string? StripeSessionId { get; set; }
    public string? PaymentIntentId { get; set; }
    public string? Status { get; set; }
}