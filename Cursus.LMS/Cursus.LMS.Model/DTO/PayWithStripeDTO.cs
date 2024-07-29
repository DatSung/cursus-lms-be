namespace Cursus.LMS.Model.DTO;

public class PayWithStripeDTO
{
    public string ApprovedUrl { get; set; }
    public string CancelUrl { get; set; }
    public Guid OrderHeaderId { get; set; }
}