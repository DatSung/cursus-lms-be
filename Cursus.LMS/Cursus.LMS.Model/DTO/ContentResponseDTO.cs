namespace Cursus.LMS.Model.DTO;

public class ContentResponseDTO
{
    public string? ContentType { get; set; }
    public MemoryStream? Stream { get; set; }
    public string? Message { get; set; }
    public string? FileName { get; set; }
}