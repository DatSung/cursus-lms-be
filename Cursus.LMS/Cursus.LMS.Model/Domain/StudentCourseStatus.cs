using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain;

public class StudentCourseStatus
{
    [Key] public Guid Id { get; set; }
    public Guid? StudentCourseId { get; set; }
    [ForeignKey("StudentCourseId")] public StudentCourse? StudentCourse { get; set; }
    public int Status { get; set; }
    public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
    public string? CreatedBy { get; set; }

    public string StatusDescription
    {
        get
        {
            switch (Status)
            {
                case 0:
                {
                    return "Pending";
                }
                case 1:
                {
                    return "Enrolled";
                }
                case 2:
                {
                    return "Learning";
                }
                case 3:
                {
                    return "Completed";
                }
                case 4:
                {
                    return "Canceled";
                }
                default:
                {
                    return "Pending";
                }
            }
        }
    }
}