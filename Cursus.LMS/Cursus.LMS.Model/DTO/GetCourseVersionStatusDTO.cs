namespace Cursus.LMS.Model.DTO;

public class GetCourseVersionStatusDTO
{
    public Guid? Id { get; set; }
    public Guid? CourseVersionId { get; set; }
    public int? Status { get; set; }
    public string? StatusDescription { get; set; }
    public DateTime? CreateTime { get; set; } = DateTime.UtcNow;
}