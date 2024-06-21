using Cursus.LMS.Model.Domain;
using System.ComponentModel.DataAnnotations;

namespace Cursus.LMS.Model.DTO;

public class UpdateInstructorCommentDTO : BaseEntity<string, string, int>
{
    [Required] public Guid Id { get; set; }
    [Required] public string comment { get; set; }
}