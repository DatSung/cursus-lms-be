namespace Cursus.LMS.Model.DTO;

public class CreateCourseSectionVersionDTO
{
    public Guid CourseVersionId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
}

