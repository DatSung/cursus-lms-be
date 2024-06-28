using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain;

public class CourseSection
{
    [Key] public Guid Id { get; set; }

    public Guid CourseId { get; set; }
    [ForeignKey("CourseId")] public virtual Course Course { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }

    [NotMapped] public virtual IEnumerable<SectionDetails>? SectionDetails { get; set; }
}