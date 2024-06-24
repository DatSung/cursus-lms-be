using Cursus.LMS.Model.Domain;
using System.ComponentModel.DataAnnotations;

namespace Cursus.LMS.Model.DTO;

public class UpdateInstructorCommentDTO
{
    [Required] public Guid Id { get; set; }
    [Required] public string comment { get; set; }
}