using Cursus.LMS.Model.Domain;
using System.ComponentModel.DataAnnotations;

namespace Cursus.LMS.Model.DTO;

public class CreateInstructorCommentDTO : BaseEntity<string, string, int>
{
    [Required] public string Comment { get; set; }
    public Guid instructorId { get; set; }
}