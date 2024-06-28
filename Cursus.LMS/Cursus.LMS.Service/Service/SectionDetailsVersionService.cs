using System.Security.Claims;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;

namespace Cursus.LMS.Service.Service;

public class SectionDetailsVersionService : ISectionDetailsVersionService
{
    private readonly IUnitOfWork _unitOfWork;

    public SectionDetailsVersionService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<ResponseDTO> GetSectionsDetails
    (
        ClaimsPrincipal User,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> GetSectionDetails(ClaimsPrincipal User)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> CreateSectionDetails(ClaimsPrincipal User)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> EditSectionDetails(ClaimsPrincipal User)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> RemoveSectionDetails(ClaimsPrincipal User)
    {
        throw new NotImplementedException();
    }
}