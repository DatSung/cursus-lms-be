namespace Cursus.LMS.Model.DTO;

public class InstructorInfoLiteDTO
{
    public string? InstructorId { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Gender { get; set; }
    public DateTime? BirthDate { get; set; }
    public bool? IsAccepted { get; set; }
}