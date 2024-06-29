using System.ComponentModel.DataAnnotations;

namespace Cursus.LMS.Model.DTO;

public class CloneNewCourseVersionDTO
{
    [Required] public Guid CourseVersionId { get; set; }
}