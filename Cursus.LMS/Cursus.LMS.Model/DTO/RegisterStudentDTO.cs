using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.DTO;

public class RegisterStudentDTO
{
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address format.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*[!@#$%^&*(),.?""{}|<>])(?=.*\d).{6,}$",
        ErrorMessage = "Password must be at least 6 characters long, at least 1 number and contain at least one uppercase letter, one special character, and one number.")]
    public string Password { get; set; }

    [Required(ErrorMessage = "ConfirmPassword is required.")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    [NotMapped]
    public string ConfirmPassword { get; set; }

    [Required(ErrorMessage = "FullName is required")]
    public string FullName { get; set; }


    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; }

    [Required(ErrorMessage = "Country is required")]
    public string Country { get; set; }

    [Required(ErrorMessage = "Address is required")]
    public string Gender { get; set; }

    [Required(ErrorMessage = "University is required")]
    public string University { get; set; }

    [Required(ErrorMessage = "Birth date is required.")]
    [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
    public DateTime BirthDate { get; set; }

    [Required]
    [DataType(DataType.PhoneNumber)]
    [Phone]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "CardNumber number is required.")] 
    public string CardNumber { get; set; }
    [Required(ErrorMessage = "CardName number is required.")] 
    public string CardName { get; set; }
    [Required(ErrorMessage = "CardProvider number is required.")] 
    public string CardProvider { get; set; }
}