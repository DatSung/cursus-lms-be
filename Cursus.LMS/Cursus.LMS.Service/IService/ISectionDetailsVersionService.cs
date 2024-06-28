using System.Security.Claims;
using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface ISectionDetailsVersionService
{
    Task<ResponseDTO> GetSectionsDetails
    (
        ClaimsPrincipal User,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber,
        int pageSize
    );

    Task<ResponseDTO> GetSectionDetails(ClaimsPrincipal User);
    Task<ResponseDTO> CreateSectionDetails(ClaimsPrincipal User);
    Task<ResponseDTO> EditSectionDetails(ClaimsPrincipal User);
    Task<ResponseDTO> RemoveSectionDetails(ClaimsPrincipal User);
}