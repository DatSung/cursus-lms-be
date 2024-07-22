using System.ComponentModel.DataAnnotations;

namespace Cursus.LMS.Model.DTO;

public class CreateCourseBookmarkDTO
{
    [Required]
    public Guid CourseId { get; set; }
    [Required]
    public Guid StudentId { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
    public string CreatedBy { get; set; }
    public string UpdatedBy { get; set; }
    public string Status { get; set; }
}