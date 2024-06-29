using System.Security.Claims;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface ICourseService
{
    /// <summary>
    /// This method to create a Course before.
    /// Then use that Course to create new CourseService
    /// </summary>
    /// <param name="User"></param>
    /// <returns></returns>
    Task<ResponseDTO> CreateFrameCourse(ClaimsPrincipal User);


    /// <summary>
    /// This method for admin.
    /// This method will merge the CourseVersion to Course
    /// </summary>
    /// <param name="User"></param>
    /// <param name="courseVersion"></param>
    /// <returns></returns>
    Task<ResponseDTO> MergeCourseFromCourseVersion
    (
        ClaimsPrincipal User,
        CourseVersion courseVersion
    );
}