using System.Security.Claims;
using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.Service.IService;

public interface ITokenService
{
    Task<string> GenerateJwtAccessTokenAsync(ApplicationUser user);
    Task<string> GenerateJwtRefreshTokenAsync(ApplicationUser user);
    Task<bool> StoreRefreshToken(string userId, string refreshToken);
    Task<ClaimsPrincipal> GetPrincipalFromToken(string token);
    Task<string> RetrieveRefreshToken(string userId);
    Task<bool> DeleteRefreshToken(string userId);
}