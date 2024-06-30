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

    public async Task<ResponseDTO> CloneSectionsDetailsVersion
    (
        ClaimsPrincipal User,
        Guid courseSectionVersionId
    )
    {
        try
        {
           

            return new ResponseDTO()
            {
                IsSuccess = true,
                StatusCode = 200,
                Message = "Clone course section of course version successfully",
                Result = null
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                IsSuccess = false,
                StatusCode = 500,
                Message = e.Message,
                Result = null
            };
        }
    }

    public Task<ResponseDTO> GetSectionsDetailsVersions
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

    public Task<ResponseDTO> GetSectionDetailsVersion(ClaimsPrincipal User)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> CreateSectionDetailsVersion(ClaimsPrincipal User)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> EditSectionDetailsVersion(ClaimsPrincipal User)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> RemoveSectionDetailsVersion(ClaimsPrincipal User)
    {
        throw new NotImplementedException();
    }
}