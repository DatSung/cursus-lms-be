using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain;

public class SectionDetails
{
    public Guid Id { get; set; }
    public Guid CourseSectionId { get; set; }
    [ForeignKey("CourseSectionId")] public virtual CourseSection CourseSection { get; set; }
    public string Name { get; set; }
    public string VideoUrl { get; set; }
}