namespace Cursus.LMS.Model.DTO;

public class CreateNewCourseAndVersionDTO
{
    public string? Title { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
    public int LearningTime { get; set; } = 0;
    public double Price { get; set; } = 0;
    public string? CourseImgUrl { get; set; }
    public Guid CategoryId { get; set; }
    public Guid LevelId { get; set; }
}