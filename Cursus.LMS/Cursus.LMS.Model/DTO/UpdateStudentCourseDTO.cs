namespace Cursus.LMS.Model.DTO;

public class UpdateStudentCourseDTO
{
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    public int Status { get; set; }
}