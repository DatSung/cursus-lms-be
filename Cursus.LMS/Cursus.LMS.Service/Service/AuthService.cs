using AutoMapper;
using Azure.Core;
using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;

namespace Cursus.LMS.Service.Service;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;

    public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
        IConfiguration configuration, IMapper mapper, IEmailService emailService, ApplicationDbContext dbContext)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _mapper = mapper;
        _emailService = emailService;
        _dbContext = dbContext;
    }


    public Task<ResponseDTO> SignUpStudent()
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> SignUpInstructor()
    {
        throw new NotImplementedException();
    }
    //Sign In bằng email và password trả về role tương ứng
    public async Task<SignResponseDTO> SignIn(SignDTO signDTO)
    {
        var user = await _userManager.FindByEmailAsync(signDTO.Email);
        if (user == null)
        {
            return null;
        }
        var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, signDTO.Password);

        if (!isPasswordCorrect)
        {
            return null;
        }
        var accessToken = await GenerateJwtTokenAsync(user);
        var userInfo = _mapper.Map<UserInfo>(user);
        var roles = await _userManager.GetRolesAsync(user);
        userInfo.Roles = roles;

        return new SignResponseDTO()
        {
            AccessToken = accessToken,
            UserInfo = userInfo
        };
    }

    //Kiểm tra thông tin để lấy đúng role của người dùng 
    public async Task<string> GenerateJwtTokenAsync(ApplicationUser? user)
    {
        var userRoles = await _userManager.GetRolesAsync(user);

        var authClaims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim("FullName", user.FullName),
            new Claim("PhoneNumber", user.PhoneNumber),
            new Claim("Email", user.Email),
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
            expires: DateTime.Now.AddMinutes(15),//thời gian hết hạn là 15p
            claims: authClaims,//danh sách thông tin của người dùng
            signingCredentials: signingCredentials
        );
        // tạo thành công mã thông báo
        var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenObject);

        return accessToken;
    }

    public Task<ResponseDTO> ForgotPassword()
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> ChangePassword()
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> VerifyEmail()
    {
        throw new NotImplementedException();
    }

}