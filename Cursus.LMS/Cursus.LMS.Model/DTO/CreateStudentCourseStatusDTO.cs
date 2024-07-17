namespace Cursus.LMS.Model.DTO;

public class CreateStudentCourseStatusDTO
{
    public Guid StudentCourseId { get; set; }
    public int Status { get; set; }
    public string? CreatedBy { get; set; }
}