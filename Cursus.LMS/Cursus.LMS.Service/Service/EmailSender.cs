using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;
using Microsoft.IdentityModel.Tokens;

namespace Cursus.LMS.Service.Service;

public class EmailSender : IEmailSender
{
    private readonly IEmailService _emailService;
    private readonly IUnitOfWork _unitOfWork;

    public EmailSender(IEmailService emailService, IUnitOfWork unitOfWork)
    {
        _emailService = emailService;
        _unitOfWork = unitOfWork;
    }

    public async Task SendSubmittedCourseEmailForAdmins()
    {
        var admins = await _unitOfWork.UserManagerRepository.GetUsersInRoleAsync(StaticUserRoles.Admin);
        foreach (var admin in admins)
        {
            if (admin.Email != null)
            {
                await _emailService.SendEmailForAdminAboutNewCourse(admin.Email);
            }
        }
    }

    public async Task SendCompletedCoursForStudent()
    {
        var students = await _unitOfWork.UserManagerRepository.GetUsersInRoleAsync(StaticUserRoles.Student);
        //get student mail
        foreach (var user in students)
        {
            if (user.Email != null)
            {
                await _emailService.SendEmailForStudentAboutCompleteCourse(user.Email);
            }
        }
    }

    public async Task SendRejectedCourseEmailForInstructor(Guid courseVersionId)
    {
        try
        {
            var courseVersion = await _unitOfWork.CourseVersionRepository.GetAsync(x => x.Id == courseVersionId);
            var instructor =
                await _unitOfWork.InstructorRepository.GetAsync
                (
                    filter: x => x.InstructorId == courseVersion.InstructorId,
                    includeProperties: "ApplicationUser"
                );
            await _emailService.SendRejectEmailForInstructorAboutNewCourse(instructor.ApplicationUser.Email);
        }
        catch (Exception e)
        {
            // ignored
        }
    }

    public async Task SendAcceptedCourseEmailForInstructor(Guid courseVersionId)
    {
        try
        {
            var courseVersion = await _unitOfWork.CourseVersionRepository.GetAsync(x => x.Id == courseVersionId);
            var instructor =
                await _unitOfWork.InstructorRepository.GetAsync
                (
                    filter: x => x.InstructorId == courseVersion.InstructorId,
                    includeProperties: "ApplicationUser"
                );
            await _emailService.SendApproveEmailForInstructorAboutNewCourse(instructor.ApplicationUser.Email);
        }
        catch (Exception e)
        {
            // ignored
        }
    }

    public async Task SendDeactivatedCourseEmailForStudents(Guid courseId)
    {
        try
        {
            var studentCourses = await _unitOfWork.StudentCourseRepository.GetAllAsync(x => x.CourseId == courseId);

            var course = await _unitOfWork.CourseRepository.GetAsync(x => x.Id == courseId);

            var courseVersions =
                await _unitOfWork.CourseVersionRepository.GetAsync(x => x.Id == course.CourseVersionId);

            var instructor = await _unitOfWork.InstructorRepository.GetAsync(
                filter: x => course != null && x.InstructorId == course.InstructorId,
                includeProperties: "ApplicationUser"
            );

            var studentEmails = new List<string>();

            foreach (var studentCourse in studentCourses)
            {
                var student = await _unitOfWork.StudentRepository.GetAsync
                (
                    filter: x => x.StudentId == studentCourse.StudentId,
                    includeProperties: "ApplicationUser"
                );
                if (student?.ApplicationUser.Email != null)
                {
                    studentEmails.Add(student.ApplicationUser.Email);
                }
            }

            if (instructor?.ApplicationUser is { Email: not null, FullName: not null })
            {
                if (courseVersions?.Title != null)
                {
                    await _emailService.SendEmailInactiveCourse(instructor.ApplicationUser.Email,
                        instructor.ApplicationUser.FullName, courseVersions.Title, studentEmails);
                }
            }
        }
        catch (Exception e)
        {
            // ignored
        }
    }
}