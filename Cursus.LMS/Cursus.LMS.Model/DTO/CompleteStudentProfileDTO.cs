using System.ComponentModel.DataAnnotations;

namespace Cursus.LMS.Model.DTO;

public class CompleteStudentProfileDTO
{
    [Required] public string Country { get; set; }

    [Required]
    [Phone]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }

    [Required] public string Address { get; set; }
    [Required] [DataType(DataType.Date)] public DateTime BirthDate { get; set; }
    [Required] public string Gender { get; set; }
    [Required] public string University { get; set; }
    [Required] public string CardNumber { get; set; }
    [Required] public string CardProvider { get; set; }
    [Required] public string CardName { get; set; }
}