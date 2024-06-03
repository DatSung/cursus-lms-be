using System.ComponentModel.DataAnnotations;
using Cursus.LMS.Utility.ValidationAttribute;

namespace Cursus.LMS.Model.DTO;

public class ChangePasswordDTO
{
    [Required(ErrorMessage = "Old password is required")]
    [DataType(DataType.Password)]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Old password must be at least 8 characters long.")]
    [Password]
    public string OldPassword { get; set; }
    
    [Required(ErrorMessage = "New Password is required")]
    [DataType(DataType.Password)]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "New Password must be at least 8 characters long.")]
    [Password]
    public string NewPassword { get; set; }
    
    [Required(ErrorMessage = "Confirm new password is required")]
    [DataType(DataType.Password)]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Confirm new password must be at least 8 characters long.")]
    [Password]
    public string ConfirmNewPassword { get; set; }
    
}