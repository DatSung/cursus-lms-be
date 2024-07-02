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
        Guid? courseVersionId,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        int pageNumber,
        int pageSize
    );

    Task<ResponseDTO> GetCourseSection
    (
        ClaimsPrincipal User, 
        Guid courseVersionId
    );
    Task<ResponseDTO> CreateCourseSection
    (
        ClaimsPrincipal User,
        CreateCourseSectionVersionDTO createCourseSectionVersionDTO
    );
    Task<ResponseDTO> EditCourseSection
    (
        ClaimsPrincipal User,
        EditCourseSectionVersionDTO editCourseSectionVersionDTO
    );
    Task<ResponseDTO> RemoveCourseSection
    (
        ClaimsPrincipal User,
        Guid sectionVersionId
    );
}