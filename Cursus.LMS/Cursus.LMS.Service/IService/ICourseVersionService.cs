using System.Security.Claims;
using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface ICourseVersionService
{
    Task<ResponseDTO> GetCourseVersions
    (
        ClaimsPrincipal User,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber,
        int pageSize
    );

    Task<ResponseDTO> GetCourseVersion(ClaimsPrincipal User, Guid courseId);
    Task<ResponseDTO> CreateCourseVersion(ClaimsPrincipal User);
    Task<ResponseDTO> RemoveCourseVersion(ClaimsPrincipal User);
    Task<ResponseDTO> EditCourseVersion(ClaimsPrincipal User);
    Task<ResponseDTO> AcceptCourseVersion(ClaimsPrincipal User);
    Task<ResponseDTO> RejectCourseVersion(ClaimsPrincipal User);

    Task<ResponseDTO> GetCourseVersionsComments(ClaimsPrincipal User);
    Task<ResponseDTO> GetCourseVersionComment(ClaimsPrincipal User);
    Task<ResponseDTO> CreateCourseVersionComment(ClaimsPrincipal User);
    Task<ResponseDTO> EditCourseVersionComment(ClaimsPrincipal User);
    Task<ResponseDTO> RemoveCourseVersionComment(ClaimsPrincipal User);
}