using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.Model.DTO;

public class CreateStripeSessionDTO
{
    public IEnumerable<OrderDetails>? OrdersDetails { get; set; }
    public string? ApprovedUrl { get; set; }
    public string? CancelUrl { get; set; }
    public string? StripeSessionId { get; set; }
    public string? StripeSessionUrl { get; set; }
}