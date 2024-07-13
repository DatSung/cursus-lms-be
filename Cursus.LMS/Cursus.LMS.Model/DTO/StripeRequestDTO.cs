namespace Cursus.LMS.Model.DTO;

public class StripeRequestDTO
{
    public string? StripeSessionUrl { get; set; }
    public string? StripeSessionId { get; set; }
    public string ApprovedUrl { get; set; }
    public string CancelUrl { get; set; }
    public Guid OrderHeaderId { get; set; }
}