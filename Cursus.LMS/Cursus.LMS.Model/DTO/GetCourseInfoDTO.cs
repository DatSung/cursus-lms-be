namespace Cursus.LMS.Model.DTO;

public class GetCourseInfoDTO
{
    public Guid Id { get; set; }
    public Guid? InstructorId { get; set; }
    public string? Code { get; set; }
    public int? StudentSlots { get; set; }
    public float? TotalRate { get; set; }
    public int? Version { get; set; }
    public Guid? CourseVersionId { get; set; }
}