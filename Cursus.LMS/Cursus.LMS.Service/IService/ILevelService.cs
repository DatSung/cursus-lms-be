using System.Security.Claims;
using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface ILevelService
{
    Task<ResponseDTO> GetLevels
    (
        ClaimsPrincipal User,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber = 0,
        int pageSize = 0
    );

    Task<ResponseDTO> GetLevel(ClaimsPrincipal User, Guid levelId);
    Task<ResponseDTO> CreateLevel(ClaimsPrincipal User, CreateLevelDTO createLevelDto);
    Task<ResponseDTO> UpdateLevel(ClaimsPrincipal User, UpdateLevelDTO updateLevelDto);
    Task<ResponseDTO> DeleteLevel(ClaimsPrincipal User, Guid levelId);
}
