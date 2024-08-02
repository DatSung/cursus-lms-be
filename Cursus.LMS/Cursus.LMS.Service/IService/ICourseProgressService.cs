using System.Security.Claims;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface ICourseProgressService
{
    Task<ResponseDTO> CreateProgress(CreateProgressDTO createProgressDto);
    Task<ResponseDTO> UpdateProgress(ClaimsPrincipal User, UpdateProgressDTO updateProgressDto);
    Task<ResponseDTO> GetProgress(GetProgressDTO getProgressDto);
    Task<ResponseDTO> GetPercentage(GetPercentageDTO getPercentageDto);
}