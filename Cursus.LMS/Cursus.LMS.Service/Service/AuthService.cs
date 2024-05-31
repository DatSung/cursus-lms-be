using AutoMapper;
using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

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


    public async Task<ResponseDTO> SignUpStudent(RegisterStudentDTO registerStudentDTO)
    {
        var isEmailExit = await _userManager.FindByEmailAsync(registerStudentDTO.Email);
        

        if (isEmailExit == null)
        {
            return new ResponseDTO()
            {
                IsSuccess = false,
                StatusCode = 409,
                Message = "Email or Phone already exists"
            };
        }


        
        return new ResponseDTO()
        {
            IsSuccess = true,
            StatusCode = 201,
            Message = "User created successfully"
        };
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