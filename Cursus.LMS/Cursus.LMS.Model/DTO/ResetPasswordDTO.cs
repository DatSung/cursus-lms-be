using System.ComponentModel.DataAnnotations;
using Cursus.LMS.Utility.ValidationAttribute;

namespace Cursus.LMS.Model.DTO;

public class ResetPasswordDTO
{
    //[Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }

    //[Required(ErrorMessage = "Token is required")]
    public string Token { get; set; }

    /*[Required(ErrorMessage = "New Password is required")]
    [DataType(DataType.Password)]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "New password must be at least 8 characters long.")]
    [Password]*/
    public string Password { get; set; }
    /*[Required(ErrorMessage = "New Password is required")]
    [DataType(DataType.Password)]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "New password must be at least 8 characters long.")]
    [Password]*/
    //public string ConfirmPassword { get; set; }
}