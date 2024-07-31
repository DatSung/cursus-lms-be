using System.Text.Json.Serialization;
using Cursus.LMS.Utility.Constants;

namespace Cursus.LMS.Model.DTO;

public class CreateStripeConnectedAccountDTO
{
    public string RefreshUrl { get; set; }
    public string ReturnUrl { get; set; }
    [JsonIgnore] public string? Email { get; set; }
}