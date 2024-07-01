using System.Security.Claims;
using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface ICourseSectionVersionService
{
    Task<ResponseDTO> CloneCourseSectionVersion
    (
        ClaimsPrincipal User,
        CloneCourseSectionVersionDTO cloneCourseSectionVersionDto
    );

    Task<ResponseDTO> GetCourseSections
    (
        ClaimsPrincipal User,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber,
        int pageSize
    );

    Task<ResponseDTO> GetCourseSection(ClaimsPrincipal User);
    Task<ResponseDTO> CreateCourseSection(ClaimsPrincipal User);
    Task<ResponseDTO> EditCourseSection(ClaimsPrincipal User);
    Task<ResponseDTO> RemoveCourseSection(ClaimsPrincipal User);
}