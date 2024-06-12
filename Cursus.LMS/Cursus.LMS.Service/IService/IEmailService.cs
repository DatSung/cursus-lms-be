using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.Service.IService;

public interface IEmailService
{
    Task<bool> SendEmailAsync(string toEmail, string subject, string body);
    Task<bool> SendEmailResetAsync(string toEmail, string subject, ApplicationUser user, string currentDate,
        string resetLink,
        string operatingSystem, string browser, string ip, string region, string city, string country);
}
