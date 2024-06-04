using Microsoft.AspNetCore.Identity;

namespace Cursus.LMS.Model.Domain;

public class ApplicationUser : IdentityUser
{
    public string Gender { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public string? AvatarUrl { get; set; }
    public string Country { get; set; }
    public string Address { get; set; }
}