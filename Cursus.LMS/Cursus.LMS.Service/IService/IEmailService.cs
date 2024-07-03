using System.Security.Claims;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.Service.IService;

public interface IEmailService
{
    Task<ResponseDTO> GetAll
    (
        ClaimsPrincipal User,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber,
        int pageSize
    );
    Task<bool> SendEmailAsync(string toEmail, string subject, string body);
    Task<bool> SendEmailInactiveCourseAsync(string instructorEmail, string studentEmail, string subject, string body);
    Task<bool> SendEmailResetAsync(string toEmail, string subject, ApplicationUser user, string currentDate,
        string resetLink,
        string operatingSystem, string browser, string ip, string region, string city, string country);
}
