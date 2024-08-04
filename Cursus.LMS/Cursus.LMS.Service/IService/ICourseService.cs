using System.Security.Claims;
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
    Task<ResponseDTO> CreateFrameCourse(ClaimsPrincipal User, Guid courseVersionId);

    Task<ResponseDTO> GetCourses
    (
        ClaimsPrincipal User,
        Guid? instructorId,
        string? filterOn,
        string? filterQuery,
        double? fromPrice,
        double? toPrice,
        string? sortBy,
        bool? isAscending,
        int pageNumber,
        int pageSize
    );

    Task<ResponseDTO> GetCourse
    (
        ClaimsPrincipal User,
        Guid courseId
    );

    Task<ResponseDTO> GetCourseInfo
    (
        ClaimsPrincipal User,
        Guid courseId
    );

    Task<ResponseDTO> ActivateCourse
    (
        ClaimsPrincipal User,
        Guid courseId
    );

    Task<ResponseDTO> DeactivateCourse
    (
        ClaimsPrincipal User,
        Guid courseId
    );

    Task<ResponseDTO> EnrollCourse
    (
        ClaimsPrincipal User,
        EnrollCourseDTO enrollCourseDto
    );

    Task<ResponseDTO> GetTopPurchasedCourses
    (
        int? year,
        int? month,
        int? quarter,
        int top,
        int pageNumber,
        int pageSize,
        string? byCategoryName
    );

    Task<ResponseDTO> GetLeastPurchasedCourses
    (
        int? year,
        int? month,
        int? quarter,
        int top,
        int pageNumber,
        int pageSize,
        string? byCategoryName
    );

    Task<ResponseDTO> SuggestCourse(Guid studentId);
    Task<ResponseDTO> UpsertCourseTotal(UpsertCourseTotalDTO upsertCourseTotalDto);
    Task<ResponseDTO> GetAllBookMarkedCoursesById(Guid studentId, string sortOrder = "desc");
    Task<ResponseDTO> CreateBookMarkedCourse(ClaimsPrincipal User, CreateCourseBookmarkDTO createCourseBookmarkDto);
    Task<ResponseDTO> DeleteBookMarkedCourse(Guid id);
    Task<ResponseDTO> GetBestCoursesSuggestion();
    Task<ResponseDTO> GetTopCoursesByTrendingCategories();
    Task<ResponseDTO> GetTopRatedCourses();
    Task<ResponseDTO> GetCourseRateTotal(Guid courseId);
    Task<ResponseDTO> GetCourseSlotTotal(Guid courseId);
}