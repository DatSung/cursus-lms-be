using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain;

public class Instructor
{
    [Key] public Guid InstructorId { get; set; }
    public string UserId { get; set; }
    [ForeignKey("UserId")] public virtual ApplicationUser ApplicationUser { get; set; }
    public string Degree { get; set; }
    public string Industry { get; set; }
    public string Introduction { get; set; }

    [NotMapped] public virtual IEnumerable<Course> Courses { get; set; }
}