namespace Cursus.LMS.Model.DTO;

public class CreateStripePayoutDTO
{
    public string? ConnectedAccountId { get; set; }
    public long Amount { get; set; }
    public string Currency { get; set; }
}