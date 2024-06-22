using Cursus.LMS.Model.Domain;
using System.ComponentModel.DataAnnotations;

namespace Cursus.LMS.Model.DTO;

public class CreateInstructorCommentDTO 
{
    [Required] public string Comment { get; set; }
    public Guid instructorId { get; set; }
}