using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cursus.LMS.Utility.ValidationAttribute;

namespace Cursus.LMS.Model.DTO;

public class SignUpInstructorDTO
{
    [Required]
    [DataType(DataType.Password)]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
    [Password]
    public string? Password { get; set; }
    
    [Required(ErrorMessage = "ConfirmPassword is required.")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    [NotMapped]
    public string ConfirmPassword { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [DataType(DataType.PhoneNumber)]
    [Phone]
    public string? PhoneNumber { get; set; }

    [Required] public string? Gender { get; set; }
    [Required] public string? FullName { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime BirthDate { get; set; }

    [Required] public string? Country { get; set; }
    [Required] public string? Address { get; set; }
    [Required] public string Degree { get; set; }
    [Required] public string Industry { get; set; }
    [Required] public string Introduction { get; set; }
    [Required] public string TaxNumber { get; set; }
}