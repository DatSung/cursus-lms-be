using System.Security.Claims;
using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface IStudentCourseService
{
    Task<ResponseDTO> EnrollCourse(ClaimsPrincipal User, EnrollCourseDTO enrollCourseDto);
}