using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain;

public class CourseProgress
{
    [Key] public Guid Id { get; set; }

    public Guid StudentCourseId { get; set; }
    [ForeignKey("StudentCourseId")] public StudentCourse? StudentCourse { get; set; }

    public Guid CourseId { get; set; }
    public Guid SectionId { get; set; }
    public Guid DetailsId { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? CompletedTime { get; set; }
}