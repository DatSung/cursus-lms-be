using System.ComponentModel.DataAnnotations;

namespace Cursus.LMS.Model.DTO;

public class SendVerifyEmailDTO
{
    [EmailAddress]
    public string Email { get; set; }
}