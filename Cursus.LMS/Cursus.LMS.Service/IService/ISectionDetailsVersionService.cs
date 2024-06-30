using System.Security.Claims;
using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface ISectionDetailsVersionService
{
    Task<ResponseDTO> CloneSectionsDetailsVersion
    (
        ClaimsPrincipal User,
        CloneSectionsDetailsVersionDTO cloneSectionsDetailsVersionDto
    );

    Task<ResponseDTO> GetSectionsDetailsVersions
    (
        ClaimsPrincipal User,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber,
        int pageSize
    );

    Task<ResponseDTO> GetSectionDetailsVersion(ClaimsPrincipal User);
    Task<ResponseDTO> CreateSectionDetailsVersion(ClaimsPrincipal User);
    Task<ResponseDTO> EditSectionDetailsVersion(ClaimsPrincipal User);
    Task<ResponseDTO> RemoveSectionDetailsVersion(ClaimsPrincipal User);
}