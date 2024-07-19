using Cursus.LMS.Utility.Constants;

namespace Cursus.LMS.Model.DTO;

public class CreateStripeConnectedAccountDTO
{
    public string RefreshUrl { get; set; }
    public string ReturnUrl { get; set; }
    public string Email { get; set; }
    public string Country { get; set; }
    public string? AccountId { get; set; }
    public string? AccountLinkUrl { get; set; }
}