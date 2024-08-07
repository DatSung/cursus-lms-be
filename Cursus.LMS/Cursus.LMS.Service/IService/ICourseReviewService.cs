using System.Security.Claims;
using Cursus.LMS.Model.DTO;
using Microsoft.AspNetCore.Http;

namespace Cursus.LMS.Service.IService;

public interface ICourseReviewService
{
    Task<ResponseDTO> CreateCourseReview(ClaimsPrincipal User, CreateCourseReviewDTO createCourseReviewDTO);
    Task<ResponseDTO> UpdateCourseReview(ClaimsPrincipal User,UpdateCourseReviewDTO updateCourseReviewDTO);
    Task<ResponseDTO> DeleteCourseReview(Guid id);
    Task<ResponseDTO> MarkCourseReview(Guid id);
    Task<ResponseDTO> GetCourseReviewById(Guid id);
    Task<ResponseDTO> GetCourseReviews
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
}


