using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain;

public class Course : StateEntity<string, string, string, string, int>
{
    [Key] public Guid Id { get; set; }

    public Guid? InstructorId { get; set; }
    [ForeignKey("InstructorId")] public virtual Instructor? Instructor { get; set; }
    public string? Code { get; set; }
    public int? StudentSlots { get; set; }
    public float? TotalRate { get; set; }
    public int? Version { get; set; } = 1;
    public Guid? CourseVersionId { get; set; }
}