using System.Data.SqlTypes;

namespace Cursus.LMS.Model.DTO;

public class DisplaySectionDetailsVersionContentDTO
{
    public Guid? SectionDetailsVersionId { get; set; }
    public string? Type { get; set; }
}