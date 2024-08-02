using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain;

public class CourseReview : BaseEntity<string, string, int>
{
    [Key] public Guid Id { get; set; }

    public Guid StudentId { get; set; }

    public Guid CourseId { get; set; }

    [ForeignKey("CourseId")] public virtual Course Course { get; set; }

    public float Rate { get; set; }

    public string Message { get; set; }

    public bool IsMarked { get; set; } = false;
}