using System.ComponentModel.DataAnnotations;
using Cursus.LMS.Utility.ValidationAttribute;

namespace Cursus.LMS.Model.DTO;

public class InstructorDTO
{
    [Required]
    [DataType(DataType.Password)]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
    [Password]
    public string? Password { get; set; }

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

    public string? AvatarUrl { get; set; }
}