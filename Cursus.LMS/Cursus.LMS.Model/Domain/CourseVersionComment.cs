using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain;

public class CourseVersionComment : BaseEntity<string, string, int>
{
    [Key] public Guid Id { get; set; }
    public Guid CourseVersionId { get; set; }
    [ForeignKey("CourseVersionId")] public CourseVersion? CourseVersion { get; set; }
    public string Comment { get; set; }
}