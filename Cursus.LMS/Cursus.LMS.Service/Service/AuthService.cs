using AutoMapper;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Cursus.LMS.Service.Service;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;

    public AuthService(UserManager<ApplicationUser?> userManager, RoleManager<IdentityRole> roleManager,
        IConfiguration configuration, IMapper mapper, IEmailService emailService)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _mapper = mapper;
        _emailService = emailService;
    }


    public Task<ResponseDTO> SignUpStudent()
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> SignUpInstructor()
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> SignIn()
    {
        throw new NotImplementedException();
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