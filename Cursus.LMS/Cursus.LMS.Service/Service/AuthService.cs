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
using Azure.Core;

namespace Cursus.LMS.Service.Service;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;
    private readonly IEmailSender _emailSender;
    private readonly IFirebaseService _firebaseService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
        IConfiguration configuration, IMapper mapper, IEmailService emailService, ApplicationDbContext dbContext,
        IFirebaseService firebaseService, IHttpContextAccessor httpContextAccessor, IEmailSender emailSender,
        ITokenService tokenService)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _mapper = mapper;
        _emailService = emailService;
        _dbContext = dbContext;
        _firebaseService = firebaseService;
        _httpContextAccessor = httpContextAccessor;
        _emailSender = emailSender;
        _tokenService = tokenService;
    }


    public async Task<ResponseDTO> SignUpStudent(RegisterStudentDTO registerStudentDTO)
    {
        try
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

            var isPhonenumerExit =
                await _userManager.Users.AnyAsync(u => u.PhoneNumber == registerStudentDTO.PhoneNumber);
            if (isPhonenumerExit)
            {
                return new ResponseDTO()
                {
                    Message = "Phone number is using by another user",
                    Result = registerStudentDTO,
                    IsSuccess = false,
                    StatusCode = 500
                };
            }


            // Create new instance of ApplicationUser
            ApplicationUser newUser = new ApplicationUser()
            {
                Address = registerStudentDTO.Address,
                Email = registerStudentDTO.Email,
                BirthDate = registerStudentDTO.BirthDate,
                UserName = registerStudentDTO.Email,
                FullName = registerStudentDTO.FullName,
                Gender = registerStudentDTO.Gender,
                Country = registerStudentDTO.Country,
                PhoneNumber = registerStudentDTO.PhoneNumber,
                AvatarUrl = "",
                TaxNumber = ""
            };

            // Create new user to database
            var createUserResult = await _userManager.CreateAsync(newUser, registerStudentDTO.Password);

            // Check if error occur
            if (!createUserResult.Succeeded)
            {
                // Return result internal service error
                return new ResponseDTO()
                {
                    Message = createUserResult.Errors.ToString(),
                    IsSuccess = false,
                    StatusCode = 500,
                    Result = registerStudentDTO
                };
            }

            var user = await _userManager.FindByEmailAsync(registerStudentDTO.Email);

            Student student = new Student()
            {
                UserId = user.Id,
                University = registerStudentDTO.University
            };

            PaymentCard paymentCard = new PaymentCard()
            {
                CardName = registerStudentDTO.CardName,
                CardNumber = registerStudentDTO.CardNumber,
                CardProvider = registerStudentDTO.CardProvider,
                UserId = user.Id
            };


            var isRoleExist = await _roleManager.RoleExistsAsync(StaticUserRoles.Student);

            // Check if role !exist to create new role 
            if (isRoleExist is false)
            {
                await _roleManager.CreateAsync(new IdentityRole(StaticUserRoles.Student));
            }


            // Add role for the user
            await _userManager.AddToRoleAsync(user, StaticUserRoles.Student);

            // Create new Student relate with ApplicationUser
            await _dbContext.Students.AddAsync(student);

            // Create new Payment relate with ApplicationUser
            await _dbContext.PaymentCards.AddAsync(paymentCard);

            // Save change to database
            await _dbContext.SaveChangesAsync();

            // Return result success
            return new ResponseDTO()
            {
                Message = "Create new user successfully",
                IsSuccess = true,
                StatusCode = 200,
                Result = registerStudentDTO
            };
        }
        catch (Exception e)
        {
            // Return result exception
            return new ResponseDTO()
            {
                Message = e.Message,
                Result = registerStudentDTO,
                IsSuccess = false,
                StatusCode = 500
            };
        }
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

            var isPhonenumerExit = await _userManager.Users.AnyAsync(u => u.PhoneNumber == instructorDto.PhoneNumber);
            if (isPhonenumerExit)
            {
                return new ResponseDTO()
                {
                    Message = "Phone number is using by another user",
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
                TaxNumber = instructorDto.TaxNumber,
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

            // Create instance of payment card
            PaymentCard paymentCard = new PaymentCard()
            {
                CardName = instructorDto.CardName,
                CardNumber = instructorDto.CardNumber,
                CardProvider = instructorDto.CardProvider,
                UserId = user.Id
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

            // Create card for instructor
            await _dbContext.PaymentCards.AddAsync(paymentCard);

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
    public async Task<ResponseDTO> SignIn(SignDTO signDTO)
    {
        try
        {
            var user = await _userManager.FindByEmailAsync(signDTO.Email);
            if (user == null)
            {
                new ResponseDTO()
                {
                    Message = "User does not exist!",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 404
                };
            }

            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, signDTO.Password);

            if (!isPasswordCorrect)
            {
                new ResponseDTO()
                {
                    Message = "Incorrect email or password",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 400
                };
            }

            if (!user.EmailConfirmed)
            {
                new ResponseDTO()
                {
                    Message = "You need to confirm email!",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 401
                };
            }

            var accessToken = await _tokenService.GenerateJwtAccessTokenAsync(user);
            var refreshToken = await _tokenService.GenerateJwtRefreshTokenAsync(user);
            await _tokenService.StoreRefreshToken(user.Id, refreshToken);

            var userInfo = _mapper.Map<UserInfo>(user);
            var roles = await _userManager.GetRolesAsync(user);
            userInfo.Roles = roles;

            return new ResponseDTO()
            {
                Result = new SignResponseDTO()
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    UserInfo = userInfo
                },
                Message = "Sign in successfully",
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    /// <summary>
    /// This method for refresh token
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public async Task<ResponseDTO> Refresh(string token)
    {
        try
        {
            ClaimsPrincipal user = await _tokenService.GetPrincipalFromToken(token);

            var userId = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            if (userId is null)
            {
                return new ResponseDTO()
                {
                    Message = "Token is not valid",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null
                };
            }

            var applicationUser = await _userManager.FindByIdAsync(userId);
            if (applicationUser is null)
            {
                return new ResponseDTO()
                {
                    Message = "User does not exist",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null
                };
            }


            var tokenOnRedis = await _tokenService.RetrieveRefreshToken(applicationUser.Id);
            if (tokenOnRedis != token)
            {
                return new ResponseDTO()
                {
                    Message = "Token is not valid",
                    IsSuccess = false,
                    StatusCode = 400,
                    Result = null
                };
            }

            var accessToken = await _tokenService.GenerateJwtAccessTokenAsync(applicationUser);
            var refreshToken = await _tokenService.GenerateJwtRefreshTokenAsync(applicationUser);

            await _tokenService.StoreRefreshToken(applicationUser.Id, refreshToken);
            
            return new ResponseDTO()
            {
                Result = new JwtTokenDTO()
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken
                },
                IsSuccess = true,
                StatusCode = 200,
                Message = "Refresh Token Successfully!"
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = e.Message,
                IsSuccess = false,
                StatusCode = 500,
                Result = null
            };
        }
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

    public async Task<ResponseDTO> ForgotPassword(ForgotPasswordDTO forgotPasswordDto)
    {
        try
        {
            // Tìm người dùng theo Email/Số điện thoại
            var user = await _userManager.FindByEmailAsync(forgotPasswordDto.EmailOrPhone);
            if (user == null)
            {
                user = await _userManager.Users.FirstOrDefaultAsync(
                    u => u.PhoneNumber == forgotPasswordDto.EmailOrPhone);
            }

            if (user == null || !user.EmailConfirmed)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "No user found or account not activated.",
                    StatusCode = 400
                };
            }

            // Tạo mã token
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            // Gửi email chứa đường link đặt lại mật khẩu. //reset-password

            var resetLink = $"https://nostran.w3spaces.com?token={token}&email={user.Email}";

            // Lấy ngày hiện tại
            var currentDate = DateTime.Now.ToString("MMMM d, yyyy");

            var userAgent = _httpContextAccessor.HttpContext?.Request.Headers["User-Agent"];

            // Lấy tên hệ điều hành
            var operatingSystem = GetUserAgentOperatingSystem(userAgent);

            // Lấy tên trình duyệt
            var browser = GetUserAgentBrowser(userAgent);

            // Lấy địa chỉ IP của client
            /*var clientIp = _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? "Unknown";
            var client = new RestClient("https://ipapi.co/" + clientIp + "/json/");
            var request = new RestRequest(Method.Get);
            IRestSponse response = client.Execute(request);

            if (response.IsSuccessful) {
                // Phân tích JSON response để lấy thông tin vị trí
            }*/

            // Gửi email chứa đường link đặt lại mật khẩu
            var emailBody = $@"
<table style=""width: 720px; margin: 0 auto;"">
    <tr>
        <td align=""left""><img src=""https://demo.stripocdn.email/content/guids/videoImgGuid/images/group_48_CGo.png"" alt=""Cursus Logo"" style=""display: block"" height=""37"" title=""Logo"" /></td>
        <td align=""center""><h2 style=""font-size: 16px"">{currentDate}</h2></td>
        <td align=""right"">
           <div>   
                <a target=""_blank"" href=""#""><img title=""Facebook"" src=""https://tlr.stripocdn.email/content/assets/img/social-icons/logo-black/facebook-logo-black.png"" alt=""Facebook"" width=""24"" height=""24"" /></a>           
                <a target=""_blank"" href=""#""><img title=""Twitter"" src=""https://tlr.stripocdn.email/content/assets/img/social-icons/logo-black/twitter-logo-black.png"" alt=""Twitter"" width=""24"" height=""24"" /></a>           
                <a target=""_blank"" href=""#""><img title=""Instagram"" src=""https://tlr.stripocdn.email/content/assets/img/social-icons/logo-black/instagram-logo-black.png"" alt=""Instagram"" width=""24"" height=""24"" /></a>           
                <a target=""_blank"" href=""#""><img title=""Youtube"" src=""https://tlr.stripocdn.email/content/assets/img/social-icons/logo-black/youtube-logo-black.png"" alt=""Youtube"" width=""24"" height=""24"" /></a>
           </div>
        </td>
    </tr>
</table>

<div style=""width: 720px; margin: 0 auto;"">
    <div style=""text-align: -webkit-center;"">
        <img src=""https://demo.stripocdn.email/content/guids/videoImgGuid/images/5184834_EjS.png"" alt=""Reset Image"" style=""display: block;"" title=""Reset Image"" width=""560"">
    </div>
    <div>
        <h2 style=""line-height: 120%;"">Forgot Your Password ?</h2>
        <p style=""font-size: 16px; line-height: 120%;"">Hi <strong>{user.FullName}</strong>,<br><br>We’ve received a request to reset the password for the Cursus account associated with <strong>{user.UserName}</strong>. No changes have been made to your account yet. This password reset is only valid for the next 24 hours.<br><br>You can reset your password by clicking the link button below:</p>
        <div style=""text-align: center; margin-bottom: 40px; margin-top: 40px;"">
            <button style=""background: #26c662; border-radius: 5px; border: none; padding: 10px 20px;"">
                <a href=""{resetLink}"" target=""_blank"" style=""color: rgb(255, 255, 255); background: rgb(38, 198, 98); border-radius: 5px; text-decoration: none;"">RESET YOUR PASSWORD</a>
            </button>
        </div>
    </div>
    <div>
        <p style=""font-size: 16px; line-height: 120%;"">For security, this request was received from a <strong>{operatingSystem}</strong> device using <strong>{browser}</strong> have IP address is {{clientIp}}. If you did not request a password reset, please ignore this email or contact support if you have questions.<br><br></p><p style=""font-size: 16px; line-height: 120%;"">Thanks,</p><p style=""font-size: 16px; line-height: 120%;"">The Cursus Team</p></td>
    </div>
    <div style=""background-color: #f6f6f6;"">
        <div style=""padding-top: 10px; "">
            <h2 style=""padding-left: 20px;"" ;><strong>Questions? We have people</strong></h2>
        </div>
        <div style=""text-align: center; padding-top: 20px;"">

<table style=""width: 720px; margin: 0 auto; padding-bottom: 10px;"">
    <tr>
        <td align=""center"">
           <div style=""background-color: white; width: 273px; border-radius: 10px; text-align: center; padding-top: 1px; padding-bottom: 1px;"">
              <h2 style=""color: #666666;""><strong>Call</strong></h2>
              <a target=""_blank"" href=""#""><img src=""https://tlr.stripocdn.email/content/guids/CABINET_2af5bc24a97b758207855506115773ae/images/73661620310209153.png"" alt=""Phone""  width=""20""></a>
              <p style=""margin-top: 5px;""><a target=""_blank"" style=""color: #666666; text-decoration: none;"" href=""tel:"">(+84) 0329 - 258 - 953&nbsp;</a></p>
           </div>
        </td>
        <td align=""center"">
           <div style=""background-color: white; width: 273px; border-radius: 10px; text-align: center; padding-top: 1px; padding-bottom: 1px;"">
              <h2 style=""color: #666666;""><strong>Reply</strong></h2>
              <a target=""_blank"" href=""#""><img src=""https://tlr.stripocdn.email/content/guids/CABINET_2af5bc24a97b758207855506115773ae/images/16961620310208834.png"" alt=""Email""  width=""20""></a>
              <p style=""margin-top: 5px;""><a target=""_blank"" href=""mailto:cursusservicetts@email.com"" style=""color: #666666; text-decoration: none;"">cursusservicetts@gmail.com</a></p>
           </div>
        </td>
    </tr>
</table>
 
            <p style=""padding-top: 10px; padding-bottom: 20px;"">Monday - Friday, 8 am - 6 pm est</p>
        </div>                       
    </div>    
    <div style=""background-color: #26c662; "">
        <div style=""text-align: center; padding-top: 30px;"">
            <a target=""_blank"" href=""mailto:cursusservicetts@email.com"" style=""color: #ffffff; text-decoration: none; padding-right: 20px;"">About us</a>
            <a target=""_blank"" href=""#"" style=""color: #ffffff; text-decoration: none; padding-right: 20px;"">Blog</a>
            <a target=""_blank"" href=""#"" style=""color: #ffffff; text-decoration: none; padding-right: 20px;"">Career</a>
            <a target=""_blank"" href=""#"" style=""color: #ffffff; text-decoration: none;"">News</a>
        </div>
        <div style=""text-align: center; padding-top: 20px;"">            
            <a style=""padding: 20px;"" target=""_blank"" href=""#""><img title=""Facebook"" src=""https://tlr.stripocdn.email/content/assets/img/social-icons/logo-white/facebook-logo-white.png"" alt=""Facebook"" width=""24"" height=""24""></a>
            <a style=""padding: 20px;"" target=""_blank"" href=""#""><img title=""Twitter"" src=""https://tlr.stripocdn.email/content/assets/img/social-icons/logo-white/twitter-logo-white.png"" alt=""Twitter"" width=""24"" height=""24""></a>
            <a style=""padding: 20px;"" target=""_blank"" href=""#""><img title=""Instagram"" src=""https://tlr.stripocdn.email/content/assets/img/social-icons/logo-white/instagram-logo-white.png"" alt=""Instagram"" width=""24"" height=""24""></a>
            <a style=""padding: 20px; align-self: center;"" target=""_blank"" href=""#""><img title=""Youtube"" src=""https://tlr.stripocdn.email/content/assets/img/social-icons/logo-white/youtube-logo-white.png"" alt=""Youtube"" width=""24"" height=""24""></a>          
        </div>
        <div>
            <p style=""font-size: 12px; text-align: center; color: #ffffff;padding: 10px 50px 30px 50px"">You are receiving this email because you have visited our site or asked us about the regular newsletter. Make sure our messages get to your Inbox (and not your bulk or junk folders).<br>
            <a target=""_blank"" style=""font-size: 12px; color: #ffffff;"" href=""#"">Privacy police</a> | <a target=""_blank"" style=""font-size: 12px; color: #ffffff;"">Unsubscribe</a></p>
        </div>
    </div>  
</div>";

            await _emailService.SendEmailAsync(user.Email, "Reset password for your Cursus account", emailBody);

            // Helper functions (you might need to refine these based on your User-Agent parsing logic)
            string GetUserAgentOperatingSystem(string userAgent)
            {
                // ... Logic to extract the operating system from the user-agent string
                // Example:
                if (userAgent.Contains("Windows")) return "Windows";
                else if (userAgent.Contains("Mac")) return "macOS";
                else if (userAgent.Contains("Linux")) return "Linux";
                else return "Unknown";
            }

            string GetUserAgentBrowser(string userAgent)
            {
                // ... Logic to extract the browser from the user-agent string
                // Example:
                if (userAgent.Contains("Chrome")) return "Chrome";
                else if (userAgent.Contains("Firefox")) return "Firefox";
                else if (userAgent.Contains("Safari")) return "Safari";
                else return "Unknown";
            }

            return new ResponseDTO
            {
                IsSuccess = true,
                Message = "The password reset link has been sent to your email.",
                StatusCode = 200
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = e.Message,
                StatusCode = 500
            };
        }
    }

    // Reset password
    public async Task<ResponseDTO> ResetPassword(string email, string token, string password)
    {
        try
        {
            // Tìm người dùng theo email
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "User not found.",
                    StatusCode = 400
                };
            }

            // Xác thực token và reset mật khẩu
            var result = await _userManager.ResetPasswordAsync(user, token, password);
            if (result.Succeeded)
            {
                return new ResponseDTO
                {
                    IsSuccess = true,
                    Message = "Reset password successfully.",
                    StatusCode = 200
                };
            }
            else
            {
                // Xử lý lỗi nếu token không hợp lệ hoặc có lỗi khác
                StringBuilder errors = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    errors.AppendLine(error.Description);
                }

                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = errors.ToString(),
                    StatusCode = 400
                };
            }
        }
        catch (Exception e)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = e.Message,
                StatusCode = 500
            };
        }
    }

// Thay đổi mật khẩu người dùng
    public async Task<ResponseDTO> ChangePassword(string userId, string oldPassword, string newPassword,
        string confirmNewPassword)
    {
        try
        {
            // Lấy id của người dùng
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new ResponseDTO { IsSuccess = false, Message = "User not found." };
            }

            // Thực hiện xác thực mật khẩu và thay đổi mật khẩu

            // Kiểm tra sự trùng khớp của mật khẩu mới và xác nhận mật khẩu mới 
            if (newPassword != confirmNewPassword)
            {
                return new ResponseDTO
                    { IsSuccess = false, Message = "New password and confirm new password not match." };
            }

            // Không cho phép thay đổi mật khẩu cũ
            if (newPassword == oldPassword)
            {
                return new ResponseDTO
                    { IsSuccess = false, Message = "New password cannot be the same as the old password." };
            }

            // Thực hiện thay đổi mật khẩu
            var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            if (result.Succeeded)
            {
                return new ResponseDTO { IsSuccess = true, Message = "Password changed successfully." };
            }
            else
            {
                return new ResponseDTO
                {
                    IsSuccess = false, Message = "Password change failed. Please ensure the old password is correct."
                };
            }
        }
        catch (Exception e)
        {
            return new ResponseDTO { IsSuccess = false, Message = e.Message };
        }
    }

    /// <summary>
    /// This method for send a token to confirm email
    /// </summary>
    /// <param name="email">Email of user that need to confirm email</param>
    /// <returns></returns>
    public async Task<ResponseDTO> SendVerifyEmail(string email, string confirmationLink)
    {
        try
        {
            await _emailSender.SendVerifyEmail(email, confirmationLink);
            return new()
            {
                Message = "Send verify email successfully",
                IsSuccess = true,
                StatusCode = 200,
                Result = null
            };
        }
        catch (Exception e)
        {
            return new()
            {
                Message = e.Message,
                IsSuccess = false,
                StatusCode = 500,
                Result = null
            };
        }
    }

    /// <summary>
    /// This method to verify email has been sent
    /// </summary>
    /// <param name="userId">User that to define who need to confirm email</param>
    /// <param name="token">Token generated by system was sent through email</param>
    /// <returns></returns>
    public async Task<ResponseDTO> VerifyEmail(string userId, string token)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user.EmailConfirmed)
        {
            return new ResponseDTO()
            {
                Message = "Your email has been confirmed!",
                IsSuccess = true,
                StatusCode = 200,
                Result = null
            };
        }

        var confirmResult = await _userManager.ConfirmEmailAsync(user, token);

        if (!confirmResult.Succeeded)
        {
            return new()
            {
                Message = confirmResult.Errors.ToString(),
                StatusCode = 400,
                IsSuccess = false,
                Result = null
            };
        }

        return new()
        {
            Message = "Confirm Email Successfully",
            IsSuccess = true,
            StatusCode = 200,
            Result = null
        };
    }
}