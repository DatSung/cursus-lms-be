using System.ComponentModel.DataAnnotations;

namespace Cursus.LMS.Model.DTO;

public class UpdateIntructorProfileDTO
{

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

    public string? CardNumber { get; set; }
    public string? CardName { get; set; }
    public string? CardProvider { get; set; }
}

