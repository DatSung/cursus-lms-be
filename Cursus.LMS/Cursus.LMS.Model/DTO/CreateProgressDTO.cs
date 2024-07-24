namespace Cursus.LMS.Model.DTO;

public class CreateProgressDTO
{
    public Guid StudentCourseId { get; set; }
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
}