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
    Task<ResponseDTO> UpdateById(Guid id, UpdateInstructorDTO updateInstructorDto);
    Task<ResponseDTO> AcceptInstructor(ClaimsPrincipal User, Guid id);
    Task<ResponseDTO> RejectInstructor(ClaimsPrincipal User, Guid id);
}