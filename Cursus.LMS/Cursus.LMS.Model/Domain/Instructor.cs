using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain;

public class Instructor
{
    [Key] public Guid InstructorId { get; set; }
    public string UserId { get; set; }
    [ForeignKey("UserId")] public virtual ApplicationUser ApplicationUser { get; set; }
    public string Degree { get; set; }
    public string? DegreeImageUrl { get; set; }
    public string Industry { get; set; }
    public string Introduction { get; set; }
    public string? StripeAccountId { get; set; }
    public bool? IsAccepted { get; set; } = false;
    public DateTime? AcceptedTime { get; set; }
    public string? AcceptedBy { get; set; }
    public DateTime? RejectedTime { get; set; }
    public string? RejectedBy { get; set; }

    [NotMapped] public virtual IEnumerable<Course> Courses { get; set; }
}