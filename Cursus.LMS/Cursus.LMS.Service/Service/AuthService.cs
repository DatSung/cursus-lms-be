using AutoMapper;
using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Cursus.LMS.Utility.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Cursus.LMS.Service.Service;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;
    private readonly IFirebaseService _firebaseService;

    public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
        IConfiguration configuration, IMapper mapper, IEmailService emailService, ApplicationDbContext dbContext,
        IFirebaseService firebaseService)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _mapper = mapper;
        _emailService = emailService;
        _dbContext = dbContext;
        _firebaseService = firebaseService;
    }


    public async Task<ResponseDTO> SignUpStudent(RegisterStudentDTO registerStudentDTO)
    {
        var isEmailExit = await _userManager.FindByEmailAsync(registerStudentDTO.Email);


        if (isEmailExit is not null)
        {
            return new ResponseDTO()
            {
                Message = "Email is using by another user",
                Result = registerStudentDTO,
                IsSuccess = false,
                StatusCode = 500
            };
        }



        return new ResponseDTO()
        {
            IsSuccess = true,
            StatusCode = 201,
            Message = "User created successfully"
        };
    }

    /// <summary>
    /// Registers a new instructor in the system.
    /// </summary>
    /// <param name="instructorDto">The data transfer object containing instructor details.</param>
    /// <returns><see cref="ResponseDTO"/> object containing the result of the registration process.</returns>
    public async Task<ResponseDTO> SignUpInstructor(InstructorDTO instructorDto)
    {
        try
        {
            // Find exist user with the email from instructorDto
            var user = await _userManager.FindByEmailAsync(instructorDto.Email);

            // Check if user exist
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

            // Create new instance of ApplicationUser
            ApplicationUser newUser = new ApplicationUser()
            {
                Address = instructorDto.Address,
                Email = instructorDto.Email,
                BirthDate = instructorDto.BirthDate,
                UserName = instructorDto.Email,
                FullName = instructorDto.FullName,
                Gender = instructorDto.Gender,
                Country = instructorDto.Country,
                PhoneNumber = instructorDto.PhoneNumber,
                AvatarUrl = ""
            };

            // Create new user to database
            var createUserResult = await _userManager.CreateAsync(newUser, instructorDto.Password);

            // Check if error occur
            if (!createUserResult.Succeeded)
            {
                // Return result internal service error
                return new ResponseDTO()
                {
                    Message = createUserResult.Errors.ToString(),
                    IsSuccess = false,
                    StatusCode = 500,
                    Result = instructorDto
                };
            }

            // Get the user again 
            user = await _userManager.FindByEmailAsync(instructorDto.Email);

            // Create instance of instructor
            Instructor instructor = new Instructor()
            {
                UserId = user.Id,
                Degree = instructorDto.Degree,
                Industry = instructorDto.Industry,
                Introduction = instructorDto.Introduction
            };

            // Get role instructor in database
            var isRoleExist = await _roleManager.RoleExistsAsync(StaticUserRoles.Instructor);

            // Check if role !exist to create new role 
            if (isRoleExist is false)
            {
                await _roleManager.CreateAsync(new IdentityRole(StaticUserRoles.Instructor));
            }

            // Add role for the user
            await _userManager.AddToRoleAsync(user, StaticUserRoles.Instructor);

            // Create new Instructor relate with ApplicationUser
            await _dbContext.Instructors.AddAsync(instructor);

            // Save change to database
            await _dbContext.SaveChangesAsync();

            // Return result success
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
            // Return result exception
            return new ResponseDTO()
            {
                Message = e.Message,
                Result = instructorDto,
                IsSuccess = false,
                StatusCode = 500
            };
        }
    }

    /// <summary>
    /// This method for instructor to upload their degree
    /// </summary>
    /// <param name="file">Image of a degree</param>
    /// <param name="User">User who sent request</param>
    /// <returns></returns>
    public async Task<ResponseDTO> UploadInstructorDegree(IFormFile file, ClaimsPrincipal User)
    {
        try
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId is null)
            {
                throw new Exception("Not authentication!");
            }

            var instructor = await _dbContext.Instructors.FirstOrDefaultAsync(x => x.UserId == userId);

            if (instructor is null)
            {
                throw new Exception("Instructor does not exist");
            }

            var responseDto = await _firebaseService.UploadImage(file, StaticFirebaseFolders.InstructorDegrees);

            if (!responseDto.IsSuccess)
            {
                throw new Exception("Image upload fail!");
            }

            instructor.DegreeImageUrl = responseDto.Result.ToString();

            await _dbContext.SaveChangesAsync();

            return new ResponseDTO()
            {
                IsSuccess = true,
                StatusCode = 200,
                Result = responseDto.Result,
                Message = "Upload instructor degree successfully"
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                IsSuccess = false,
                StatusCode = 500,
                Result = null,
                Message = e.Message
            };
        }
    }

    /// <summary>
    /// This method to get instructor degree image
    /// </summary>
    /// <param name="User"></param>
    /// <returns></returns>
    public async Task<DegreeResponseDTO> GetInstructorDegree(ClaimsPrincipal User)
    {
        try
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId is null)
            {
                throw new Exception("User Unauthenticated!");
            }

            var instructor = await _dbContext.Instructors.FirstOrDefaultAsync(x => x.UserId == userId);

            if (instructor is null)
            {
                throw new Exception("Instructor does not exist!");
            }

            var degreePath = instructor?.DegreeImageUrl;
            if (degreePath.IsNullOrEmpty())
            {
                throw new Exception("Instructors did not upload degree!");
            }

            var stream = await _firebaseService.GetImage(instructor.DegreeImageUrl);

            if (stream is null)
            {
                throw new Exception("Instructor did not upload degree");
            }

            var contentType = "Unsupported extensions!";
            
            if (degreePath.EndsWith(".pdf"))
            {
                contentType = StaticFileExtensions.Pdf;
            }

            if (degreePath.EndsWith(".png"))
            {
                contentType = StaticFileExtensions.Png;
            }

            if (degreePath.EndsWith(".jpg") || degreePath.EndsWith(",jpeg"))
            {
                contentType = StaticFileExtensions.Jpeg;
            }

            return new DegreeResponseDTO()
            {
                Message = "Get file successfully",
                Stream = stream,
                ContentType = contentType,
                FileName = Path.GetFileName(degreePath)
            };
        }
        catch (Exception e)
        {
            return new DegreeResponseDTO()
            {
                ContentType = null,
                Message = e.Message,
                Stream = null
            };
        }
    }

    /// <summary>
    /// This method for users to upload their avatar
    /// </summary>
    /// <param name="file">An user avatar image</param>
    /// <param name="user">An user who sent request</param>
    /// <returns></returns>
    public async Task<ResponseDTO> UploadUserAvatar(IFormFile file, ClaimsPrincipal User)
    {
        try
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId is null)
            {
                throw new Exception("Not authentication!");
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user is null)
            {
                throw new Exception("User does not exist");
            }

            var responseDto = await _firebaseService.UploadImage(file, StaticFirebaseFolders.UserAvatars);

            if (!responseDto.IsSuccess)
            {
                throw new Exception("Image upload fail!");
            }

            user.AvatarUrl = responseDto.Result?.ToString();

            var updateResult = await _userManager.UpdateAsync(user);

            if (!updateResult.Succeeded)
            {
                throw new Exception("Update user avatar fail!");
            }

            return new ResponseDTO()
            {
                Message = "Upload user avatar successfully!",
                Result = null,
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = e.Message,
                Result = null,
                IsSuccess = false,
                StatusCode = 500
            };
        }
    }

    /// <summary>
    /// This method for user to get their avatar
    /// </summary>
    /// <param name="User">An user who sent request</param>
    /// <returns></returns>
    public async Task<MemoryStream> GetUserAvatar(ClaimsPrincipal User)
    {
        try
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            var user = await _userManager.FindByIdAsync(userId);

            var stream = await _firebaseService.GetImage(user.AvatarUrl);

            return stream;
        }
        catch (Exception e)
        {
            return null;
        }
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
            expires: DateTime.Now.AddMinutes(15), //thời gian hết hạn là 15p
            claims: authClaims, //danh sách thông tin của người dùng
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