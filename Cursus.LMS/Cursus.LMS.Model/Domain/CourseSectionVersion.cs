using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain;

public class CourseSectionVersion
{
    [Key] public Guid Id { get; set; }

    public Guid? CourseVersionId { get; set; }
    [ForeignKey("CourseVersionId")] public CourseVersion? CourseVersions { get; set; }

    public string? Title { get; set; }
    public string? Description { get; set; }
    public int? CurrentStatus { get; set; }

    [NotMapped] public IEnumerable<SectionDetailsVersion>? SectionDetailsVersions { get; set; }
}