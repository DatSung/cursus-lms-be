using System.ComponentModel.DataAnnotations;

namespace Cursus.LMS.Model.DTO;

public class UpdateStudentProfileDTO
{

    [Required] public string? Gender { get; set; }
    [Required] public string? FullName { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime? BirthDate { get; set; }

    [Required] 
    public string? Country { get; set; }

    [Required] 
    public string? Address { get; set; }

    [Required]
    public string? University { get; set; }

    public string? CardNumber { get; set; }
    public string? CardName { get; set; }
    public string? CardProvider { get; set; }
}

