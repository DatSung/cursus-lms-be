namespace Cursus.LMS.Model.DTO;

public class EditSectionDetailsVersionDTO
{
    public Guid sectionDetailId { get; set; }
    public Guid courseSectionId { get; set; }
    public string? name { get; set; }
}