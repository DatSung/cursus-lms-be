namespace Cursus.LMS.Model.DTO;

public class DegreeResponseDTO
{
    public string? ContentType { get; set; }
    public MemoryStream? Stream { get; set; }
    public string? Message { get; set; }
    public string? FileName { get; set; }
}