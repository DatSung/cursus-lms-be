using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain;

public class Course : StateEntity<string, string, string, string, int>
{
    [Key] public Guid Id { get; set; }
    public Guid? InstructorId { get; set; }
    [ForeignKey("InstructorId")] public virtual Instructor? Instructor { get; set; }
    public string? Code { get; set; }
    public int? TotalStudent { get; set; } = 0;
    public float? TotalRate { get; set; } = 0;
    public int? Version { get; set; } = 1;
    public double? TotalEarned { get; set; } = 0;
    public Guid? CourseVersionId { get; set; }
}