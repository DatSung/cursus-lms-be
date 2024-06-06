using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.Service.IService;

public interface ITokenService
{
    Task<string> GenerateJwtAccessTokenAsync(ApplicationUser user);
    Task<string> GenerateJwtRefreshTokenAsync();
    Task<bool> StoreRefreshToken(string userId, string refreshToken);
    Task<string> RetrieveRefreshToken(string userId);
    Task<bool> DeleteRefreshToken(string userId);
}