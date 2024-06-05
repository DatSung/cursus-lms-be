namespace Cursus.LMS.Service.IService;

public interface IEmailService
{
    Task<bool> SendEmailAsync(string toEmail, string subject, string body);
}
