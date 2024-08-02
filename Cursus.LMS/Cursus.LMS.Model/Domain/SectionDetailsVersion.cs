using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain
{
    public class SectionDetailsVersion
    {
        [Key] public Guid Id { get; set; }

        public Guid CourseSectionVersionId { get; set; }
        [ForeignKey("CourseSectionVersionId")] public CourseSectionVersion? CourseSectionVersions { get; set; }

        public string? Name { get; set; }
        public string? VideoUrl { get; set; }
        public string? SlideUrl { get; set; }
        public string? DocsUrl { get; set; }
        public int? CurrentStatus { get; set; }
        public int? Type { get; set; } = 0;

        [NotMapped]
        public string TypeDescription
        {
            get
            {
                return Type switch
                {

                    0 => "Video",
                    1 => "Slide",
                    2 => "Docs",
                    3 => "Video Slide",
                    4 => "Video Docs",
                    5 => "Slide Docs",
                    6 => "Video Slide Docs",
                    _ => "Unknown"
                };
            }
        }

        public void UpdateTypeDescription()
        {
            bool hasVideo = !string.IsNullOrEmpty(VideoUrl);
            bool hasSlide = !string.IsNullOrEmpty(SlideUrl);
            bool hasDocs = !string.IsNullOrEmpty(DocsUrl);

            if (hasVideo && hasSlide && hasDocs)
            {
                Type = 6; // Video Slide Docs
            }
            else if (hasVideo && hasSlide)
            {
                Type = 3; // Video Slide
            }
            else if (hasVideo && hasDocs)
            {
                Type = 4; // Video Docs
            }
            else if (hasSlide && hasDocs)
            {
                Type = 5; // Slide Docs
            }
            else if (hasVideo)
            {
                Type = 0; // Video
            }
            else if (hasSlide)
            {
                Type = 1; // Slide
            }
            else if (hasDocs)
            {
                Type = 2; // Docs
            }
            else
            {
                Type = null; // None
            }
        }
    }
}
