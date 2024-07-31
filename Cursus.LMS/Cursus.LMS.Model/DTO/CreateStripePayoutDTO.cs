using System.Text.Json.Serialization;

namespace Cursus.LMS.Model.DTO;

public class CreateStripePayoutDTO
{
    [JsonIgnore]
    public string? ConnectedAccountId { get; set; }
    public long Amount { get; set; }
    public string Currency { get; set; }
}