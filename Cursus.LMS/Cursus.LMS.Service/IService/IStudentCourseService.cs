using System.Security.Claims;
using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface IStudentCourseService
{
    Task<ResponseDTO> CreateStudentCourse(ClaimsPrincipal User, EnrollCourseDTO enrollCourseDto);
    Task<ResponseDTO> UpdateStudentCourse(ClaimsPrincipal User, UpdateStudentCourseDTO updateStudentCourseDto);
}