using System.Security.Claims;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Microsoft.IdentityModel.Tokens;

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
        CloneSectionsDetailsVersionDTO cloneSectionsDetailsVersionDto
    )
    {
        try
        {
            var sectionDetailsVersions =
                await _unitOfWork.SectionDetailsVersionRepository
                    .GetSectionDetailsVersionsOfCourseSectionVersionAsync
                    (
                        cloneSectionsDetailsVersionDto.OldCourseSectionVersionId,
                        asNoTracking: true
                    );

            if (sectionDetailsVersions.IsNullOrEmpty())
            {
                return new ResponseDTO()
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null,
                    Message = "Section details of course section version was not found"
                };
            }

            foreach (var sectionDetailsVersion in sectionDetailsVersions)
            {
                sectionDetailsVersion.Id = Guid.NewGuid();
                sectionDetailsVersion.CourseSectionVersionId = cloneSectionsDetailsVersionDto.NewCourseSectionVersionId;
            }

            await _unitOfWork.SectionDetailsVersionRepository.AddRangeAsync(sectionDetailsVersions);
            await _unitOfWork.SaveAsync();

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