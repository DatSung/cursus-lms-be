using System.Security.Claims;
using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface ICourseVersionService
{
    /// <summary>
    /// This method will get all CourseVersion belong to Course.
    /// Base on courseId of the Course
    /// </summary>
    /// <param name="User"></param>
    /// <param name="courseId"></param>
    /// <param name="instructorId"></param>
    /// <param name="filterOn"></param>
    /// <param name="filterQuery"></param>
    /// <param name="sortBy"></param>
    /// <param name="isAscending"></param>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    Task<ResponseDTO> GetCourseVersions
    (
        ClaimsPrincipal User,
        Guid? courseId,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber,
        int pageSize
    );

    /// <summary>
    /// This method 
    /// </summary>
    /// <param name="User"></param>
    /// <param name="courseVersionId"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    Task<ResponseDTO> GetCourseVersion
    (
        ClaimsPrincipal User,
        Guid courseVersionId
    );

    /// <summary>
    /// Create a new course and a version 1 of that course
    /// </summary>
    /// <param name="User"></param>
    /// <param name="createNewCourseAndVersionDto"></param>
    /// <returns></returns>
    Task<ResponseDTO> CreateCourseAndVersion
    (
        ClaimsPrincipal User,
        CreateNewCourseAndVersionDTO createNewCourseAndVersionDto
    );


    /// <summary>
    /// Clone new course version from exist course version
    /// </summary>
    /// <param name="User"></param>
    /// <param name="cloneCourseVersionDto"></param>
    /// <returns></returns>
    Task<ResponseDTO> CloneCourseVersion
    (
        ClaimsPrincipal User,
        CloneCourseVersionDTO cloneCourseVersionDto
    );

    Task<ResponseDTO> RemoveCourseVersion(ClaimsPrincipal User, Guid courseVersionId);
    Task<ResponseDTO> EditCourseVersion(ClaimsPrincipal User, EditCourseVersionDTO editCourseVersionDto);
    Task<ResponseDTO> AcceptCourseVersion(ClaimsPrincipal User, Guid courseVersionId);
    Task<ResponseDTO> RejectCourseVersion(ClaimsPrincipal User, Guid courseVersionId);
    Task<ResponseDTO> SubmitCourseVersion(ClaimsPrincipal User, Guid courseVersionId);
    Task<ResponseDTO> MergeCourseVersion(ClaimsPrincipal User, Guid courseVersionId);

    Task<ResponseDTO> GetCourseVersionsComments
    (
        ClaimsPrincipal User,
        Guid? courseVersionId,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        int pageNumber,
        int pageSize
    );

    Task<ResponseDTO> GetCourseVersionComment
    (
        ClaimsPrincipal User,
        Guid courseVersionCommentId
    );

    Task<ResponseDTO> CreateCourseVersionComment
    (
        ClaimsPrincipal User,
        CreateCourseVersionCommentsDTO createCourseVersionCommentsDTO
    );

    Task<ResponseDTO> EditCourseVersionComment
    (
        ClaimsPrincipal User,
        EditCourseVersionCommentsDTO editCourseVersionCommentsDTO
    );

    Task<ResponseDTO> RemoveCourseVersionComment
    (
        ClaimsPrincipal User,
        Guid commentId
    );

    Task<ResponseDTO> UploadCourseVersionBackgroundImg
    (
        ClaimsPrincipal User,
        Guid courseVersionId,
        UploadCourseVersionBackgroundImg uploadCourseVersionBackgroundImg
    );
    
    Task<MemoryStream> DisplayCourseVersionBackgroundImg
    (
        ClaimsPrincipal User,
        Guid courseVersionId
    );
}