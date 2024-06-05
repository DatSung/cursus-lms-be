using System.ComponentModel.DataAnnotations;

namespace Cursus.LMS.Model.DTO;

public class ForgotPasswordDTO
{
    [Required(ErrorMessage = "Please enter email or phone number.")]
    public string EmailOrPhone { get; set; }
}