using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain;

public class CourseReport : BaseEntity<string, string, int>
{
    [Key] public Guid Id { get; set; }

    public Guid StudentId { get; set; }

    public Guid CourseId { get; set; }
    
    [ForeignKey("CourseId")] public virtual Course Course { get; set; }

    public string Message { get; set; }
}