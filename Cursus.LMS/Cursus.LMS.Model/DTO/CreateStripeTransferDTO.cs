using System.Text.Json.Serialization;

namespace Cursus.LMS.Model.DTO;

public class CreateStripeTransferDTO
{
    public string UserId { get; set; }
    [JsonIgnore] public string? ConnectedAccountId { get; set; }
    public long Amount { get; set; }
    public string Currency { get; set; }
}