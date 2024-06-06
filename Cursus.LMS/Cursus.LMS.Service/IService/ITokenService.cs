using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.Service.IService;

public interface ITokenService
{
    Task<string> GenerateJwtAccessTokenAsync(ApplicationUser user);
    Task<string> GenerateJwtRefreshTokenAsync();
}