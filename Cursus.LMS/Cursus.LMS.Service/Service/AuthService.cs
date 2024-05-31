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


    public Task<ResponseDTO> SignUpStudent()
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseDTO> SignUpInstructor(InstructorDTO instructorDto)
    {
        try
        {
            var user = await _userManager.FindByEmailAsync(instructorDto.Email);

            if (user is not null)
            {
                return new ResponseDTO()
                {
                    Message = "Email is using by another user",
                    Result = instructorDto,
                    IsSuccess = false,
                    StatusCode = 500
                };
            }

            ApplicationUser newUser = new ApplicationUser()
            {
                Address = instructorDto.Address,
                Email = instructorDto.Email,
                UserName = instructorDto.Email,
                FullName = instructorDto.FullName,
                Gender = instructorDto.Gender,
                Country = instructorDto.Country,
                PhoneNumber = instructorDto.PhoneNumber,
                AvartarUrl = ""
            };

            var createUserResult = await _userManager.CreateAsync(newUser, instructorDto.Password);

            if (!createUserResult.Succeeded)
            {
                return new ResponseDTO()
                {
                    Message = createUserResult.Errors.ToString(),
                    IsSuccess = false,
                    StatusCode = 500,
                    Result = instructorDto
                };
            }

            user = await _userManager.FindByEmailAsync(instructorDto.Email);
            Instructor instructor = new Instructor()
            {
                UserId = user.Id,
                Degree = instructorDto.Degree,
                Industry = instructorDto.Industry,
                Introduction = instructorDto.Introduction
            };

            await _dbContext.Instructors.AddAsync(instructor);
            await _dbContext.SaveChangesAsync();

            return new ResponseDTO()
            {
                Message = "Create new user successfully",
                IsSuccess = true,
                StatusCode = 200,
                Result = instructorDto
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = e.Message,
                Result = instructorDto,
                IsSuccess = false,
                StatusCode = 500
            };
        }
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