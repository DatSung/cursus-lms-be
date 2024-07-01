using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain;

public class CourseVersionStatus
{
    [Key] public Guid Id { get; set; }
    public Guid? CourseVersionId { get; set; }
    [ForeignKey("CourseVersionId")] public CourseVersion? CourseVersion { get; set; }
    public int Status { get; set; }
    public DateTime CreateTime { get; set; } = DateTime.UtcNow;

    public string StatusDescription
    {
        get
        {
            switch (Status)
            {
                case 0:
                {
                    return "New"; // Can edit
                }
                case 1:
                {
                    return "Submitted"; // Clone new version to edit
                }
                case 2:
                {
                    return "Accepted"; // Clone new version to edit
                }
                case 3:
                {
                    return "Rejected"; // Can edit
                }
                case 4:
                {
                    return "Merged"; // Clone new version to edit
                }
                case 5:
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