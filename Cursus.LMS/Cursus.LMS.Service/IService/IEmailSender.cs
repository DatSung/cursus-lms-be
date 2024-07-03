namespace Cursus.LMS.Service.IService;

public interface IEmailSender
{
    Task<bool> SendEmailForAdminAboutNewCourse(string toMail);
    Task<bool> SendVerifyEmail(string toMail, string confirmationLink);
    
}