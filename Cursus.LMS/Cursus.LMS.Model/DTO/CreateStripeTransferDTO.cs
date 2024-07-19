namespace Cursus.LMS.Model.DTO;

public class CreateStripeTransferDTO
{
    public string? UserId { get; set; }
    public string? ConnectedAccountId { get; set; }
    public long Amount { get; set; }
    public string Currency { get; set; }
}