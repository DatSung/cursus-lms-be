using System.ComponentModel.DataAnnotations;

namespace Cursus.LMS.Model.DTO;

public class InstructorInfoDTO
{
    public Guid? InstructorId { get; set; }
    public string UserId { get; set; }
    public string? AvatarUrl { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Gender { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Country { get; set; }
    public string? Address { get; set; }
    public string? Degree { get; set; }
    public string? Industry { get; set; }
    public string? Introduction { get; set; }
    public string? TaxNumber { get; set; }
    public bool? IsAccepted { get; set; }
}