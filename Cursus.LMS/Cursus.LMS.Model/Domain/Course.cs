using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain;

public class Course : StateEntity<string, string, string, string, int>
{
    [Key] public Guid Id { get; set; }

    public Guid InstructorId { get; set; }
    [ForeignKey("InstructorId")] public virtual Instructor Instructor { get; set; }

    public Guid CategoryId { get; set; }
    [ForeignKey("CategoryId")] public virtual Category Category { get; set; }

    public Guid LevelId { get; set; }
    [ForeignKey("LevelId")] public virtual Level Level { get; set; }

    public string Code { get; set; }
    public int StudentSlot { get; set; }
    public int LearningTime { get; set; }
    public double Price { get; set; }
    public string? CourseImgUrl { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public float TotalRate { get; set; }
}