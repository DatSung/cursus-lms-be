using System.Security.Claims;
using Cursus.LMS.Model.DTO;
using Task = DocumentFormat.OpenXml.Office2021.DocumentTasks.Task;

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
    Task<ResponseDTO> GetAllInstructorComment(Guid instructorId, int pageNumber, int pageSize);
    Task<ResponseDTO> CreateInstructorComment(ClaimsPrincipal User, CreateInstructorCommentDTO createInstructorComment);
    Task<ResponseDTO> UpdateInstructorComment(ClaimsPrincipal User, UpdateInstructorCommentDTO updateInstructorComment);
    Task<ResponseDTO> DeleteInstructorComment(Guid commentId);
    Task<ResponseDTO> ExportInstructors(string userId, int month, int year);
    Task<ClosedXMLResponseDTO> DownloadInstructors(string fileName);
}