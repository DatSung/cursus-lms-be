using System.Security.Claims;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;

namespace Cursus.LMS.Service.Service;

public class InstructorService : IInstructorService
{
    public Task<ResponseDTO> GetAll
    (
        ClaimsPrincipal User,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber,
        int pageSize
    )
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> UpdateById(Guid id, UpdateInstructorDTO updateInstructorDto)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> AcceptInstructor(ClaimsPrincipal User, Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> RejectInstructor(ClaimsPrincipal User, Guid id)
    {
        throw new NotImplementedException();
    }
}