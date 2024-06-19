using System.ComponentModel.DataAnnotations;

namespace Cursus.LMS.Model.DTO;

public class CreateInstructorComment
{
    [Required] public string Comment { get; set; }
}