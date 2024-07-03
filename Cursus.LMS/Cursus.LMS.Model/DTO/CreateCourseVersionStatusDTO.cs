namespace Cursus.LMS.Model.DTO;

public class CreateCourseVersionStatusDTO
{
    public Guid? CourseVersionId { get; set; }
    public int Status { get; set; }
}