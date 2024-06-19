using System.ComponentModel.DataAnnotations;

namespace Cursus.LMS.Model.DTO;

public class UpdateInstructorComment
{
    [Required] public Guid Id { get; set; }
    [Required] public string Comment { get; set; }
}