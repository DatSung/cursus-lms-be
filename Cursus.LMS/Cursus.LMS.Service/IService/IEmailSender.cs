namespace Cursus.LMS.Service.IService;

public interface IEmailSender
{
    Task<bool> SendEmailForInstructorApproval(string toMail, string token);
    Task<bool> SendVerifyEmail(string toMail, string confirmationLink);
    Task<bool> SendEmailInactiveCourse(string instructorEmail, string instructorName, string courseTitle, List<string> studentEmails);
}