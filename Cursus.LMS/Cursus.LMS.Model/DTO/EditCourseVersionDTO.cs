namespace Cursus.LMS.Model.DTO;

public class EditCourseVersionDTO
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public Guid LevelId { get; set; }
    public string? Title { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
    public int LearningTime { get; set; } = 0;
    public double Price { get; set; } = 0;
    public string? CourseImgUrl { get; set; }
}