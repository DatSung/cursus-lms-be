using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Cursus.LMS.Service.Service;

public class TokenService : ITokenService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _configuration;
    private readonly IRedisService _redisService;

    public TokenService(UserManager<ApplicationUser> userManager, IConfiguration configuration,
        IRedisService redisService)
    {
        _userManager = userManager;
        _configuration = configuration;
        _redisService = redisService;
    }

    public async Task<string> GenerateJwtAccessTokenAsync(ApplicationUser user)
    {
        var userRoles = await _userManager.GetRolesAsync(user);

        var authClaims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
        };

        foreach (var role in userRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, role));
        }

        //tạo các đối tượng mã hóa
        var authSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
        var signingCredentials = new SigningCredentials(authSecret, SecurityAlgorithms.HmacSha256);

        var tokenObject = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddMinutes(60), //thời gian hết hạn là 60p
            claims: authClaims, //danh sách thông tin của người dùng
            signingCredentials: signingCredentials
        );
        // tạo thành công mã thông báo          
        var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenObject);

        return accessToken;
    }

    /// <summary>
    /// This method for create refresh token
    /// </summary>
    /// <returns></returns>
    public async Task<string> GenerateJwtRefreshTokenAsync(ApplicationUser user)
    {
        var authClaims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
        };

        //tạo các đối tượng mã hóa
        var authSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
        var signingCredentials = new SigningCredentials(authSecret, SecurityAlgorithms.HmacSha256);

        var tokenObject = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddDays(3), //thời gian hết hạn là 15p
            claims: authClaims, //danh sách thông tin của người dùng
            signingCredentials: signingCredentials
        );
        // tạo thành công mã thông báo          
        var refreshToken = new JwtSecurityTokenHandler().WriteToken(tokenObject);

        return refreshToken;
    }

    public async Task<ClaimsPrincipal> GetPrincipalFromToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]);

        try
        {
            var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _configuration["JWT:ValidIssuer"],
                ValidAudience = _configuration["JWT:ValidAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(key)
            }, out SecurityToken validatedToken);
            return principal;
        }
        catch
        {
            // Token validation failed
            return null;
        }
    }

    /// <summary>
    /// This method for store refresh token on redis cloud
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="refreshToken"></param>
    /// <returns></returns>
    public async Task<bool> StoreRefreshToken(string userId, string refreshToken)
    {
        string redisKey = $"userId:{userId}:refreshToken";
        var result = await _redisService.StoreString(redisKey, refreshToken);
        return result;
    }

    /// <summary>
    /// This method for get refresh token from redis cloud
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<string> RetrieveRefreshToken(string userId)
    {
        string redisKey = $"userId:{userId}:refreshToken";
        var result = await _redisService.RetrieveString(redisKey);
        return result;
    }

    /// <summary>
    /// This method for delete refresh token on redis cloud
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteRefreshToken(string userId)
    {
        string redisKey = $"userId:{userId}:refreshToken";
        var result = await _redisService.DeleteString(redisKey);
        return result;
    }
}