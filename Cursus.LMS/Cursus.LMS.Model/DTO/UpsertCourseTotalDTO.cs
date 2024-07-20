namespace Cursus.LMS.Model.DTO;

public class UpsertCourseTotalDTO
{
    public Guid CourseId { get; set; }
    public int? TotalStudent { get; set; } = 0;
    public bool UpdateTotalRate { get; set; } = false;
    public double? TotalEarned { get; set; } = 0;
}