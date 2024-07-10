using Cursus.LMS.Utility.Constants;

namespace Cursus.LMS.Model.DTO;

public class GetCourseVersionDTO
{
    public Guid Id { get; set; }
    public Guid? CourseId { get; set; }
    public string? Title { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
    public int LearningTime { get; set; } = 0;
    public double Price { get; set; } = 0;
    public double? OldPrice { get; set; }
    public string? CourseImgUrl { get; set; }
    public Guid? InstructorId { get; set; }
    public string? InstructorEmail { get; set; }
    public Guid? CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public Guid? LevelId { get; set; }
    public string? LevelName { get; set; }
    public string? Version { get; set; }
    public int? CurrentStatus { get; set; }

    public string CurrentStatusDescription
    {
        get
        {
            switch (CurrentStatus)
            {
                case StaticCourseVersionStatus.New:
                {
                    return "New";
                }
                case StaticCourseVersionStatus.Submitted:
                {
                    return "Submitted";
                }
                case StaticCourseVersionStatus.Accepted:
                {
                    return "Accepted";
                }
                case StaticCourseVersionStatus.Rejected:
                {
                    return "Rejected";
                }
                case StaticCourseVersionStatus.Merged:
                {
                    return "Merged";
                }
                case StaticCourseVersionStatus.Removed:
                {
                    return "Removed";
                }
                default:
                {
                    return "New";
                }
            }
        }
    }
}