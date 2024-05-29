using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain;

public class CourseReview
{
    [Key] public Guid Id { get; set; }

    public Guid StudentId { get; set; }

    public Guid CourseId { get; set; }
    [ForeignKey("CourseId")] public virtual Course Course { get; set; }

    public float Rate { get; set; }
    public string Message { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.Now;
    public bool IsDelete { get; set; }
}