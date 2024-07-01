namespace Cursus.LMS.Model.DTO;

public class ClosedXMLResponseDTO
{
    public MemoryStream? Stream { get; set; }
    public string? ContentType { get; set; }
    public string? FileName { get; set; }
    public int? StatusCode { get; set; }
    public string? Message { get; set; }
    public bool IsSuccess { get; set; }
}