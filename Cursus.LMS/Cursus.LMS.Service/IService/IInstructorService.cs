using System.Security.Claims;
using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface IInstructorService
{
    Task<ResponseDTO> GetAll
    (
        ClaimsPrincipal User,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber,
        int pageSize
    );

    Task<ResponseDTO> GetById(Guid id);
    Task<ResponseDTO> UpdateById(UpdateInstructorDTO updateInstructorDto);
    Task<ResponseDTO> AcceptInstructor(ClaimsPrincipal User, Guid id);
    Task<ResponseDTO> RejectInstructor(ClaimsPrincipal User, Guid id);

    Task<ResponseDTO> GetInstructorTotalCourses(Guid instructorId);
    Task<ResponseDTO> GetInstructorTotalRating(Guid instructorId);
    Task<ResponseDTO> GetInstructorEarnedMoney(Guid instructorId);
    Task<ResponseDTO> GetInstructorPayoutMoney(Guid instructorId);

    Task<ResponseDTO> GetAllInstructorComment(Guid instructorId);
    Task<ResponseDTO> CreateInstructorComment(ClaimsPrincipal User, CreateInstructorComment createInstructorComment);
    Task<ResponseDTO> UpdateInstructorComment(ClaimsPrincipal User, UpdateInstructorComment createInstructorComment);
    Task<ResponseDTO> DeleteInstructorComment(ClaimsPrincipal User, Guid commentId);
}