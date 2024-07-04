namespace Cursus.LMS.Service.IService;

public interface IEmailSender
{
    Task SendSubmittedCourseEmailForAdmins();
    Task SendRejectedCourseEmailForInstructor(Guid courseVersionId);
    Task SendAcceptedCourseEmailForInstructor(Guid courseVersionId);
    Task SendDeactivatedCourseEmailForStudents(Guid courseId);
}