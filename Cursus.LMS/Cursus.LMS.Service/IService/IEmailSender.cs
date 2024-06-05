namespace Cursus.LMS.Service.IService;

public interface IEmailSender
{
    Task<bool> SendEmailForInstructorApproval(string toMail, string token);
    Task<bool> SendVerifyEmail(string toMail, string confirmationLink);
    
}