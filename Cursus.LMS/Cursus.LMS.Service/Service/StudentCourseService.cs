using System.Security.Claims;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;

namespace Cursus.LMS.Service.Service;

public class StudentCourseService : IStudentCourseService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStudentCourseStatusService _studentCourseStatusService;

    public StudentCourseService(IUnitOfWork unitOfWork, IStudentCourseStatusService studentCourseStatusService)
    {
        _unitOfWork = unitOfWork;
        _studentCourseStatusService = studentCourseStatusService;
    }

    public async Task<ResponseDTO> CreateStudentCourse(ClaimsPrincipal User, EnrollCourseDTO enrollCourseDto)
    {
        try
        {
            var userEmail = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;

            var student = await _unitOfWork.StudentRepository.GetAsync(x => x.StudentId == enrollCourseDto.studentId);
            if (student is null)
            {
                return new ResponseDTO()
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Message = "Student was not found",
                    Result = null
                };
            }

            var course = await _unitOfWork.CourseRepository.GetAsync(x => x.Id == enrollCourseDto.courseId);
            if (course is null)
            {
                return new ResponseDTO()
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Message = "Course was not found",
                    Result = null
                };
            }

            var studentCourse = new StudentCourse()
            {
                Id = Guid.NewGuid(),
                StudentId = student.StudentId,
                CourseId = course.Id,
                CreatedBy = userEmail,
                CreatedTime = DateTime.UtcNow,
                Status = StaticStatus.StudentCourse.Enrolled,
            };

            await _unitOfWork.StudentCourseRepository.AddAsync(studentCourse);
            await _unitOfWork.SaveAsync();

            var studentCourseStatus = new CreateStudentCourseStatusDTO()
            {
                CreatedBy = userEmail,
                Status = StaticStatus.StudentCourse.Enrolled,
                StudentCourseId = studentCourse.Id
            };

            await _studentCourseStatusService.CreateStudentCourseStatus(studentCourseStatus);

            return new ResponseDTO()
            {
                IsSuccess = true,
                StatusCode = 200,
                Message = "Enroll student to course successfully",
                Result = studentCourse
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                IsSuccess = false,
                StatusCode = 500,
                Message = e.Message,
                Result = null
            };
        }
    }
}