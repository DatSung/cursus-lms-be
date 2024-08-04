namespace Cursus.LMS.Model.DTO;

public class GetCourseDTO
{
    public Guid Id { get; set; }
    public Guid? CourseId { get; set; }
    public string? Title { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
    public int LearningTime { get; set; } = 0;
    public double Price { get; set; } = 0;
    public double? OldPrice { get; set; }
    public Guid? InstructorId { get; set; }
    public Guid? CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public Guid? LevelId { get; set; }
    public string? LevelName { get; set; }
}