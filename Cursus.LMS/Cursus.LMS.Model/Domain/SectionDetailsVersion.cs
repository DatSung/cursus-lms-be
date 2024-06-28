using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain;

public class SectionDetailsVersion
{
    [Key] public Guid Id { get; set; }

    public Guid? CourseSectionVersionId { get; set; }
    [ForeignKey("CourseSectionVersionId")] public CourseSectionVersion? CourseSectionVersions { get; set; }

    public Guid SectionDetailsId { get; set; }
    [ForeignKey("SectionDetailsId")] public SectionDetails? SectionDetails { get; set; }

    public string? Name { get; set; }
    public string? VideoUrl { get; set; }
    public string? SlideUrk { get; set; }
    public string? DocsUrl { get; set; }
    public int? CurrentStatus { get; set; }
    public int? Type { get; set; } = 0;

    public string TypeDescription
    {
        get
        {
            switch (Type)
            {
                case 0:
                {
                    return "Video";
                }
                case 1:
                {
                    return "Slide";
                }
                case 2:
                {
                    return "Docs";
                }
                default:
                {
                    return "Video";
                }
            }
        }
    }
}