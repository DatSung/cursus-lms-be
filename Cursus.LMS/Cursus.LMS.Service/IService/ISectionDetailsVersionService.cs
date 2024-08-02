using System.Security.Claims;
using Cursus.LMS.Model.DTO;
using Microsoft.AspNetCore.Http;

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
        Guid? courseSectionId,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber,
        int pageSize
    );

    Task<ResponseDTO> GetSectionDetailsVersion
    (
        ClaimsPrincipal User, Guid detailsId
    );

    Task<ResponseDTO> CreateSectionDetailsVersion
    (
        ClaimsPrincipal User,
        CreateSectionDetailsVersionDTO createSectionDetailsVersionDto
    );

    Task<ResponseDTO> EditSectionDetailsVersion
    (
        ClaimsPrincipal User,
        EditSectionDetailsVersionDTO editSectionDetailsVersionDto
    );

    Task<ResponseDTO> RemoveSectionDetailsVersion
    (
        ClaimsPrincipal User,
        Guid detailsId
    );

    Task<ResponseDTO> UploadSectionDetailsVersionContent
    (
        ClaimsPrincipal User,
        Guid detailsId,
        UploadSectionDetailsVersionContentDTO uploadSectionDetailsVersionContentDto
    );

    Task<ContentResponseDTO> DisplaySectionDetailsVersionContent
    (
        Guid sectionDetailsVersionId,
        string userId,
        string type
    );
}