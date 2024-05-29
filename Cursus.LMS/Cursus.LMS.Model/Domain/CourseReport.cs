using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain;

public class CourseReport
{
    [Key] public Guid Id { get; set; }

    public Guid StudentId { get; set; }

    public Guid CourseId { get; set; }
    [ForeignKey("CourseId")] public virtual Course Course { get; set; }

    public DateTime CreateAt { get; set; } = DateTime.Now;

    public string Message { get; set; }
    public bool IsSent { get; set; }
    public bool IsAccepted { get; set; }
}