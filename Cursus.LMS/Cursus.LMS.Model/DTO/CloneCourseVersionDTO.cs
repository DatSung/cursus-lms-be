using System.ComponentModel.DataAnnotations;

namespace Cursus.LMS.Model.DTO;

public class CloneCourseVersionDTO
{
    [Required] public Guid CourseVersionId { get; set; }
}