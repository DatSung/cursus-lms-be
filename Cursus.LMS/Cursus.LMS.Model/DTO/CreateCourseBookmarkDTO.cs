using System.ComponentModel.DataAnnotations;

namespace Cursus.LMS.Model.DTO;

public class CreateCourseBookmarkDTO
{
    [Required]
    public Guid CourseId { get; set; }
    [Required]
    public Guid StudentId { get; set; }

}