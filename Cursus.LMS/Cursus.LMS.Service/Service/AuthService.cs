using System.Collections.Concurrent;
using AutoMapper;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Utility.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using FirebaseAdmin.Auth;
using Newtonsoft.Json.Linq;

namespace Cursus.LMS.Service.Service;

public class AuthService : IAuthService
{
    private readonly IUserManagerRepository _userManagerRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;
    private readonly IFirebaseService _firebaseService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    private static readonly ConcurrentDictionary<string, (int Count, DateTime LastRequest)> ResetPasswordAttempts =
        new();

    public AuthService
    (
        IUserManagerRepository userManagerRepository,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IMapper mapper,
        IEmailService emailService,
        IFirebaseService firebaseService,
        IHttpContextAccessor httpContextAccessor,
        ITokenService tokenService,
        IUnitOfWork unitOfWork
    )
    {
        _userManagerRepository = userManagerRepository;
        _userManager = userManager;
        _roleManager = roleManager;
        _mapper = mapper;
        _emailService = emailService;
        _firebaseService = firebaseService;
        _httpContextAccessor = httpContextAccessor;
        _tokenService = tokenService;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseDTO> SignUpStudent(RegisterStudentDTO registerStudentDTO)
    {
        try
        {
            var isEmailExit = await _userManagerRepository.FindByEmailAsync(registerStudentDTO.Email);
            if (isEmailExit is not null)
            {
                return new ResponseDTO()
                {
                    Message = "Email is using by another user",
                    Result = registerStudentDTO,
                    IsSuccess = false,
                    StatusCode = 400
                };
            }

            var isPhonenumerExit =
                await _userManagerRepository.CheckIfPhoneNumberExistsAsync(registerStudentDTO.PhoneNumber);
            if (isPhonenumerExit)
            {
                return new ResponseDTO()
                {
                    Message = "Phone number is using by another user",
                    Result = registerStudentDTO,
                    IsSuccess = false,
                    StatusCode = 400
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
                UpdateTime = DateTime.Now,
                AvatarUrl = "",
                TaxNumber = "",
                LockoutEnabled = false
            };

            // Create new user to database
            var createUserResult = await _userManagerRepository.CreateAsync(newUser, registerStudentDTO.Password);

            // Check if error occur
            if (!createUserResult.Succeeded)
            {
                // Return result internal service error
                return new ResponseDTO()
                {
                    Message = "Create user failed",
                    IsSuccess = false,
                    StatusCode = 400,
                    Result = registerStudentDTO
                };
            }

            var user = await _userManagerRepository.FindByPhoneAsync(registerStudentDTO.PhoneNumber);

            Student student = new Student()
            {
                UserId = user.Id,
                University = registerStudentDTO.University
            };

            var isRoleExist = await _roleManager.RoleExistsAsync(StaticUserRoles.Student);

            // Check if role !exist to create new role 
            if (isRoleExist is false)
            {
                await _roleManager.CreateAsync(new IdentityRole(StaticUserRoles.Student));
            }

            // Add role for the user
            var isRoleAdd = await _userManagerRepository.AddToRoleAsync(user, StaticUserRoles.Student);

            if (!isRoleAdd.Succeeded)
            {
                return new ResponseDTO()
                {
                    Message = "Error adding role",
                    IsSuccess = false,
                    StatusCode = 500,
                    Result = registerStudentDTO
                };
            }

            // Create new Student relate with ApplicationUser
            var isStudentAdd = await _unitOfWork.StudentRepository.AddAsync(student);
            if (isStudentAdd == null)
            {
                return new ResponseDTO()
                {
                    Message = "Failed to add student",
                    IsSuccess = false,
                    StatusCode = 500,
                    Result = registerStudentDTO
                };
            }

            // Save change to database
            var isSuccess = await _unitOfWork.SaveAsync();
            if (isSuccess <= 0)
            {
                return new ResponseDTO()
                {
                    Message = "Failed to save changes to the database",
                    IsSuccess = false,
                    StatusCode = 500,
                    Result = registerStudentDTO
                };
            }

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
    /// <param name="signUpInstructorDto">The data transfer object containing instructor details.</param>
    /// <returns><see cref="ResponseDTO"/> object containing the result of the registration process.</returns>
    public async Task<ResponseDTO> SignUpInstructor(SignUpInstructorDTO signUpInstructorDto)
    {
        try
        {
            // Find exist user with the email from signUpInstructorDto
            var user = await _userManager.FindByEmailAsync(signUpInstructorDto.Email);

            // Check if user exist
            if (user is not null)
            {
                return new ResponseDTO()
                {
                    Message = "Email is using by another user",
                    Result = signUpInstructorDto,
                    IsSuccess = false,
                    StatusCode = 500
                };
            }

            var isPhonenumerExit =
                await _userManagerRepository.CheckIfPhoneNumberExistsAsync(signUpInstructorDto.PhoneNumber);
            
            if (isPhonenumerExit)
            {
                return new ResponseDTO()
                {
                    Message = "Phone number is using by another user",
                    Result = signUpInstructorDto,
                    IsSuccess = false,
                    StatusCode = 500
                };
            }


            // Create new instance of ApplicationUser
            ApplicationUser newUser = new ApplicationUser()
            {
                Address = signUpInstructorDto.Address,
                Email = signUpInstructorDto.Email,
                BirthDate = signUpInstructorDto.BirthDate,
                UserName = signUpInstructorDto.Email,
                FullName = signUpInstructorDto.FullName,
                Gender = signUpInstructorDto.Gender,
                Country = signUpInstructorDto.Country,
                PhoneNumber = signUpInstructorDto.PhoneNumber,
                TaxNumber = signUpInstructorDto.TaxNumber,
                UpdateTime = DateTime.Now,
                LockoutEnabled = false
            };

            // Create new user to database
            var createUserResult = await _userManager.CreateAsync(newUser, signUpInstructorDto.Password);


            // Check if error occur
            if (!createUserResult.Succeeded)
            {
                // Return result internal service error
                return new ResponseDTO()
                {
                    Message = createUserResult.Errors.ToString(),
                    IsSuccess = false,
                    StatusCode = 500,
                    Result = signUpInstructorDto
                };
            }

            // Get the user again 
            user = await _userManager.FindByEmailAsync(signUpInstructorDto.Email);


            // Create instance of instructor
            Instructor instructor = new Instructor()
            {
                UserId = user.Id,
                Degree = signUpInstructorDto.Degree,
                Industry = signUpInstructorDto.Industry,
                Introduction = signUpInstructorDto.Introduction,
                AcceptedBy = "",
                AcceptedTime = null,
                RejectedBy = "",
                RejectedTime = null,
                IsAccepted = null
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
            await _unitOfWork.InstructorRepository.AddAsync(instructor);

            // Save change to database
            await _unitOfWork.SaveAsync();

            // Return result success
            return new ResponseDTO()
            {
                Message = "Create new user successfully",
                IsSuccess = true,
                StatusCode = 200,
                Result = signUpInstructorDto
            };
        }
        catch (Exception e)
        {
            // Return result exception
            return new ResponseDTO()
            {
                Message = e.Message,
                Result = signUpInstructorDto,
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

            var instructor = await _unitOfWork.InstructorRepository.GetAsync(x => x.UserId == userId);

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

            await _unitOfWork.SaveAsync();

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

            var instructor = await _unitOfWork.InstructorRepository.GetAsync(x => x.UserId == userId);

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
    public async Task<ResponseDTO> SignIn(SignDTO signDto)
    {
        try
        {
            var user = await _userManager.FindByEmailAsync(signDto.Email);
            if (user == null)
            {
                return new ResponseDTO()
                {
                    Message = "User does not exist!",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 404
                };
            }

            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, signDto.Password);

            if (!isPasswordCorrect)
            {
                return new ResponseDTO()
                {
                    Message = "Incorrect email or password",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 400
                };
            }

            if (!user.EmailConfirmed)
            {
                return new ResponseDTO()
                {
                    Message = "You need to confirm email!",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 401
                };
            }

            if (user.LockoutEnd is not null)
            {
                return new ResponseDTO()
                {
                    Message = "User has been locked",
                    IsSuccess = false,
                    StatusCode = 403,
                    Result = null
                };
            }

            var accessToken = await _tokenService.GenerateJwtAccessTokenAsync(user);
            var refreshToken = await _tokenService.GenerateJwtRefreshTokenAsync(user);
            await _tokenService.StoreRefreshToken(user.Id, refreshToken);

            user.LastLoginTime = DateTime.UtcNow;
            user.SendClearEmail = false;
            await _userManager.UpdateAsync(user);

            return new ResponseDTO()
            {
                Result = new SignResponseDTO()
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                },
                Message = "Sign in successfully",
                IsSuccess = true,
                StatusCode = 200
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
                    StatusCode = 400,
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

            await _tokenService.DeleteRefreshToken(applicationUser.Id);
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


    //Forgot password
    private string ip;
    private string city;
    private string region;
    private string country;
    private const int MaxAttemptsPerDay = 3;

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

            // Kiểm tra giới hạn gửi yêu cầu đặt lại mật khẩu
            var email = user.Email;
            var now = DateTime.Now;

            if (ResetPasswordAttempts.TryGetValue(email, out var attempts))
            {
                // Kiểm tra xem đã quá 1 ngày kể từ lần thử cuối cùng chưa
                if (now - attempts.LastRequest >= TimeSpan.FromSeconds(1))
                {
                    // Reset số lần thử về 0 và cập nhật thời gian thử cuối cùng
                    ResetPasswordAttempts[email] = (1, now);
                }
                else if (attempts.Count >= MaxAttemptsPerDay)
                {
                    // Quá số lần reset cho phép trong vòng 1 ngày, gửi thông báo 
                    await _emailService.SendEmailAsync(user.Email,
                        "Password Reset Request Limit Exceeded",
                        $"You have exceeded the daily limit for password reset requests. Please try again after 24 hours."
                    );

                    // Vẫn trong thời gian chặn, trả về lỗi
                    return new ResponseDTO
                    {
                        IsSuccess = false,
                        Message =
                            "You have exceeded the daily limit for password reset requests. Please try again after 24 hours.",
                        StatusCode = 429
                    };
                }
                else
                {
                    // Chưa vượt quá số lần thử và thời gian chờ, tăng số lần thử và cập nhật thời gian
                    ResetPasswordAttempts[email] = (attempts.Count + 1, now);
                }
            }
            else
            {
                // Email chưa có trong danh sách, thêm mới với số lần thử là 1 và thời gian hiện tại
                ResetPasswordAttempts.AddOrUpdate(email, (1, now), (key, old) => (old.Count + 1, now));
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

            // Lấy location
            var url = "https://ipinfo.io/14.169.10.115/json?token=823e5c403c980f";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = await response.Content.ReadAsStringAsync();
                    JObject data = JObject.Parse(jsonContent);

                    this.ip = data["ip"].ToString();
                    this.city = data["city"].ToString();
                    this.region = data["region"].ToString();
                    this.country = data["country"].ToString();
                }
                else
                {
                    return new ResponseDTO
                    {
                        IsSuccess = false,
                        Message = "Error: Unable to retrieve data.",
                        StatusCode = 400
                    };
                }
            }

            // Gửi email chứa đường link đặt lại mật khẩu
            await _emailService.SendEmailResetAsync(user.Email, "Reset password for your Cursus account", user,
                currentDate, resetLink, operatingSystem, browser, ip, region, city, country);

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

            // Kiểm tra xem mật khẩu mới có trùng với mật khẩu cũ hay không
            if (await _userManager.CheckPasswordAsync(user, password))
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "New password cannot be the same as the old password.",
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
                    IsSuccess = false,
                    Message = "Password change failed. Please ensure the old password is correct."
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
            await _emailService.SendVerifyEmail(email, confirmationLink);
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
                Message = "Invalid token",
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

    /// <summary>
    /// This method for check email exist or not
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public async Task<ResponseDTO> CheckEmailExist(string email)
    {
        try
        {
            var user = await _userManager.FindByEmailAsync(email);
            return new()
            {
                Result = user is not null,
                Message = user is null ? "Email does not exist" : "Email is existed",
                IsSuccess = true,
                StatusCode = 200
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
    /// This method for check phoneNumber exist or not
    /// </summary>
    /// <param name="phoneNumber"></param>
    /// <returns></returns>
    public async Task<ResponseDTO> CheckPhoneNumberExist(string phoneNumber)
    {
        try
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);

            return new()
            {
                Result = user is not null,
                Message = user is null ? "Phone number does not exist!" : "Phone number was existed",
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception e)
        {
            return new()
            {
                Message = e.Message,
                Result = null,
                IsSuccess = false,
                StatusCode = 500
            };
        }
    }

    /// <summary>
    /// This method for update student profile
    /// </summary>
    /// <param name="User"></param>
    /// <param name="studentProfileDto"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ResponseDTO> CompleteStudentProfile(
        ClaimsPrincipal User,
        CompleteStudentProfileDTO studentProfileDto)
    {
        try
        {
            // Find user in database
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = await _userManager.FindByIdAsync(userId);

            // user is null mean user does not exist to update
            if (user is null)
            {
                return new ResponseDTO()
                {
                    Message = "User does not exist!",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = studentProfileDto,
                };
            }

            // Check if phone number is user by another user but not the user to update
            var isPhonenumerExit =
                await _userManagerRepository.CheckIfPhoneNumberExistsAsync(studentProfileDto.PhoneNumber);
            if (isPhonenumerExit)
            {
                return new ResponseDTO()
                {
                    Message = "Phone number is using by another user",
                    Result = studentProfileDto,
                    IsSuccess = false,
                    StatusCode = 500
                };
            }

            user.BirthDate = studentProfileDto.BirthDate;
            user.PhoneNumber = studentProfileDto.PhoneNumber;
            user.Address = studentProfileDto.Address;
            user.Country = studentProfileDto.Country;
            user.Gender = studentProfileDto.Gender;

            var student = await _unitOfWork.StudentRepository.GetAsync(x => x.UserId == userId);
            if (student is null)
            {
                student = new Student()
                {
                    UserId = user.Id,
                    University = studentProfileDto.University
                };
                await _unitOfWork.StudentRepository.AddAsync(student);
            }
            else
            {
                student.University = studentProfileDto.University;
            }

            var isRoleExist = await _roleManager.RoleExistsAsync(StaticUserRoles.Student);

            // Check if role !exist to create new role 
            if (isRoleExist is false)
            {
                await _roleManager.CreateAsync(new IdentityRole(StaticUserRoles.Student));
            }

            // Add role for the user
            await _userManager.AddToRoleAsync(user, StaticUserRoles.Student);

            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                Message = "Update student profile successfully",
                IsSuccess = true,
                StatusCode = 200,
                Result = studentProfileDto
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

    /// <summary>
    /// This method for update instructor profile
    /// </summary>
    /// <param name="User"></param>
    /// <param name="instructorProfileDto"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ResponseDTO> CompleteInstructorProfile(
        ClaimsPrincipal User,
        CompleteInstructorProfileDTO instructorProfileDto)
    {
        try
        {
            // Find user in database
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = await _userManager.FindByIdAsync(userId);

            // user is null mean user does not exist to update
            if (user is null)
            {
                return new ResponseDTO()
                {
                    Message = "User does not exist!",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = instructorProfileDto,
                };
            }

            // Check if phone number is user by another user but not the user to update
            var isPhonenumerExit =
                await _userManager.Users.AnyAsync(
                    u => u.PhoneNumber == instructorProfileDto.PhoneNumber && u.Id != user.Id);
            if (isPhonenumerExit)
            {
                return new ResponseDTO()
                {
                    Message = "Phone number is using by another user",
                    Result = instructorProfileDto,
                    IsSuccess = false,
                    StatusCode = 500
                };
            }

            user.BirthDate = instructorProfileDto.BirthDate;
            user.PhoneNumber = instructorProfileDto.PhoneNumber;
            user.Address = instructorProfileDto.Address;
            user.Country = instructorProfileDto.Country;
            user.Gender = instructorProfileDto.Gender;
            user.TaxNumber = instructorProfileDto.TaxNumber;
            user.UpdateTime = DateTime.Now;

            // Find the instructor profile to add or update
            var instructor = await _unitOfWork.InstructorRepository.GetAsync(x => x.UserId == userId);
            if (instructor is null)
            {
                instructor = new Instructor()
                {
                    UserId = user.Id,
                    Introduction = instructorProfileDto.Introduction,
                    Degree = instructorProfileDto.Degree,
                    Industry = instructorProfileDto.Industry
                };
                await _unitOfWork.InstructorRepository.AddAsync(instructor);
            }
            else
            {
                instructor.Introduction = instructorProfileDto.Introduction;
                instructor.Industry = instructorProfileDto.Industry;
            }

            var isRoleExist = await _roleManager.RoleExistsAsync(StaticUserRoles.Instructor);

            // Check if role !exist to create new role 
            if (isRoleExist is false)
            {
                await _roleManager.CreateAsync(new IdentityRole(StaticUserRoles.Instructor));
            }

            // Add role for the user
            await _userManager.AddToRoleAsync(user, StaticUserRoles.Instructor);

            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                Message = "Update student profile successfully",
                IsSuccess = true,
                StatusCode = 200,
                Result = instructorProfileDto
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

    public async Task<ResponseDTO> GetUserInfo(ClaimsPrincipal User)
    {
        // Find user in database
        try
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = await _userManager.FindByIdAsync(userId);

            // user is null mean user does not exist to update
            if (user is null)
            {
                return new ResponseDTO()
                {
                    Message = "User does not exist!",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null,
                };
            }

            var userInfo = _mapper.Map<UserInfoDTO>(user);
            var roles = await _userManager.GetRolesAsync(user);
            userInfo.Roles = roles;
            userInfo.isAccepted = true;


            if (roles.Contains(StaticUserRoles.Instructor))
            {
                var instructor = await _unitOfWork.InstructorRepository.GetAsync(x => x.UserId == user.Id);
                userInfo.isUploadDegree = instructor?.DegreeImageUrl != null ? true : false;
                userInfo.isAccepted = instructor?.IsAccepted;
                userInfo.InstructorId = instructor?.InstructorId;
            }

            if (roles.Contains(StaticUserRoles.Student))
            {
                var student = await _unitOfWork.StudentRepository.GetByUserId(userId);
                userInfo.StudentId = student?.StudentId;
            }

            return new ResponseDTO()
            {
                Message = "Get user info successfully",
                IsSuccess = true,
                StatusCode = 200,
                Result = userInfo,
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = "Something went wrong",
                IsSuccess = false,
                StatusCode = 500,
                Result = null,
            };
        }
    }

    public async Task<MemoryStream> DisplayUserAvatar(string userId)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(userId);

            var stream = await _firebaseService.GetImage(user.AvatarUrl);

            return stream;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<DegreeResponseDTO> DisplayInstructorDegree(string userId)
    {
        try
        {
            if (userId is null)
            {
                throw new Exception("User Unauthenticated!");
            }

            var instructor = await _unitOfWork.InstructorRepository.GetAsync(x => x.UserId == userId);

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
    /// This method for sign in by google
    /// </summary>
    /// <param name="signInByGoogleDto"></param>
    /// <returns></returns>
    public async Task<ResponseDTO> SignInByGoogle(SignInByGoogleDTO signInByGoogleDto)
    {
        try
        {
            //lấy thông tin từ google
            FirebaseToken googleTokenS =
                await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(signInByGoogleDto.Token);
            string userId = googleTokenS.Uid;
            string email = googleTokenS.Claims["email"].ToString();
            string name = googleTokenS.Claims["name"].ToString();
            string avatarUrl = googleTokenS.Claims["picture"].ToString();

            //tìm kiem người dùng trong database
            var user = await _userManager.FindByEmailAsync(email);
            UserLoginInfo? userLoginInfo = null;
            if (user is not null)
            {
                userLoginInfo = _userManager.GetLoginsAsync(user).GetAwaiter().GetResult()
                    .FirstOrDefault(x => x.LoginProvider == StaticLoginProvider.Google);
            }

            if (user.LockoutEnd is not null)
            {
                return new ResponseDTO()
                {
                    Message = "User has been locked",
                    IsSuccess = false,
                    StatusCode = 403,
                    Result = null
                };
            }

            if (user is not null && userLoginInfo is null)
            {
                return new ResponseDTO()
                {
                    Result = new SignResponseDTO()
                    {
                        RefreshToken = null,
                        AccessToken = null,
                    },
                    Message = "The email is using by another user",
                    IsSuccess = false,
                    StatusCode = 400
                };
            }

            if (userLoginInfo is null && user is null)
            {
                //tạo một user mới khi chưa có trong database
                user = new ApplicationUser
                {
                    Email = email,
                    FullName = name,
                    UserName = email,
                    AvatarUrl = avatarUrl,
                    EmailConfirmed = true,
                    UpdateTime = null
                };

                await _userManager.CreateAsync(user);
                await _userManager.AddLoginAsync(user,
                    new UserLoginInfo(StaticLoginProvider.Google, userId, "GOOGLE"));
            }

            var accessToken = await _tokenService.GenerateJwtAccessTokenAsync(user);
            var refreshToken = await _tokenService.GenerateJwtRefreshTokenAsync(user);
            await _tokenService.StoreRefreshToken(user.Id, refreshToken);

            user.LastLoginTime = DateTime.UtcNow;
            user.SendClearEmail = false;
            await _userManager.UpdateAsync(user);

            return new ResponseDTO()
            {
                Result = new SignResponseDTO()
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                },
                Message = "Sign in successfully",
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (FirebaseAuthException e)
        {
            return new ResponseDTO()
            {
                Result = new SignResponseDTO()
                {
                    AccessToken = null,
                    RefreshToken = null,
                },
                Message = "Something went wrong",
                IsSuccess = false,
                StatusCode = 500
            };
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="updateStudentDto"></param>
    /// <returns></returns>
    public async Task<ResponseDTO> UpdateStudent(UpdateStudentProfileDTO updateStudentDTO, ClaimsPrincipal User)
    {
        try
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId is null)
            {
                return new ResponseDTO
                {
                    Message = "User not found",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 404
                };
            }

            var studentToUpdate = await _unitOfWork.StudentRepository.GetByUserId(userId);

            if (studentToUpdate == null)
            {
                return new ResponseDTO
                {
                    Message = "Student not found",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 404
                };
            }

            // Update student-specific fields
            studentToUpdate.University = updateStudentDTO.University;

            // Update related ApplicationUser fields
            studentToUpdate.ApplicationUser.Address = updateStudentDTO.Address;
            studentToUpdate.ApplicationUser.BirthDate = updateStudentDTO.BirthDate;
            studentToUpdate.ApplicationUser.Gender = updateStudentDTO.Gender;
            studentToUpdate.ApplicationUser.FullName = updateStudentDTO.FullName;
            studentToUpdate.ApplicationUser.Country = updateStudentDTO.Country;

            _unitOfWork.StudentRepository.Update(studentToUpdate);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO
            {
                Message = "Student updated successfully",
                Result = null,
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO
            {
                Message = e.Message,
                Result = null,
                IsSuccess = false,
                StatusCode = 500
            };
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="updateStudentDto"></param>
    /// <returns></returns>
    public async Task<ResponseDTO> UpdateInstructor(UpdateIntructorProfileDTO updateIntructorDTO, ClaimsPrincipal User)
    {
        try
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId is null)
            {
                return new ResponseDTO
                {
                    Message = "User not found",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 404
                };
            }

            var intructorToUpdate = await _unitOfWork.InstructorRepository.GetByUserId(userId);

            if (intructorToUpdate == null)
            {
                return new ResponseDTO
                {
                    Message = "Intructor not found",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 404
                };
            }

            // Update student-specific fields
            intructorToUpdate.Degree = updateIntructorDTO.Degree;
            intructorToUpdate.Industry = updateIntructorDTO.Industry;
            intructorToUpdate.Introduction = updateIntructorDTO.Introduction;

            // Update related ApplicationUser fields
            intructorToUpdate.ApplicationUser.Address = updateIntructorDTO.Address;
            intructorToUpdate.ApplicationUser.BirthDate = updateIntructorDTO.BirthDate;
            intructorToUpdate.ApplicationUser.Gender = updateIntructorDTO.Gender;
            intructorToUpdate.ApplicationUser.FullName = updateIntructorDTO.FullName;
            intructorToUpdate.ApplicationUser.Country = updateIntructorDTO.Country;
            intructorToUpdate.ApplicationUser.TaxNumber = updateIntructorDTO.TaxNumber;

            _unitOfWork.InstructorRepository.Update(intructorToUpdate);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO
            {
                Message = "Updated instructor successfully",
                Result = null,
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO
            {
                Message = e.Message,
                Result = null,
                IsSuccess = false,
                StatusCode = 500
            };
        }
    }

    public async Task<ResponseDTO> LockUser(LockUserDTO lockUserDto)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(lockUserDto.UserId);


            if (user is null)
            {
                return new ResponseDTO()
                {
                    Message = "User was not found",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null
                };
            }

            var userRole = await _userManager.GetRolesAsync(user);

            if (userRole.Contains(StaticUserRoles.Admin))
            {
                return new ResponseDTO()
                {
                    Message = "Lock user was failed",
                    IsSuccess = false,
                    StatusCode = 400,
                    Result = null
                };
            }

            user.LockoutEnd = DateTimeOffset.MaxValue;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return new ResponseDTO()
                {
                    Message = "Lock user was failed",
                    IsSuccess = false,
                    StatusCode = 400,
                    Result = null
                };
            }

            return new ResponseDTO()
            {
                Message = "Lock user successfully",
                IsSuccess = true,
                StatusCode = 200,
                Result = null
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

    public async Task<ResponseDTO> UnlockUser(LockUserDTO lockUserDto)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(lockUserDto.UserId);

            if (user is null)
            {
                return new ResponseDTO()
                {
                    Message = "User was not found",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null
                };
            }

            user.LockoutEnd = null;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return new ResponseDTO()
                {
                    Message = "Unlock user was failed",
                    IsSuccess = false,
                    StatusCode = 400,
                    Result = null
                };
            }

            return new ResponseDTO()
            {
                Message = "Unlock user successfully",
                IsSuccess = true,
                StatusCode = 200,
                Result = null
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

    public async Task SendClearEmail(int fromMonth)
    {
        try
        {
            var fromDate = DateTime.UtcNow.AddMonths(-fromMonth);
            var users = _userManager.Users
                .Where(user => user.LastLoginTime <= fromDate || user.LastLoginTime == null)
                .ToList();

            var admins = await _userManager.GetUsersInRoleAsync(StaticUserRoles.Admin);

            foreach (var admin in admins)
            {
                users.Remove(admin);
            }

            if (users.IsNullOrEmpty())
            {
                return;
            }

            var studentCourses = await _unitOfWork.StudentCourseRepository.GetAllAsync();
            var courses = await _unitOfWork.CourseRepository.GetAllAsync();

            foreach (var studentCourse in studentCourses)
            {
                var student = await _unitOfWork.StudentRepository
                    .GetAsync(x => x.StudentId == studentCourse.StudentId);
                var user = await _userManagerRepository.FindByIdAsync(student.UserId);
                users.Remove(user);
            }

            foreach (var course in courses)
            {
                var instructor = await _unitOfWork.InstructorRepository
                    .GetAsync(x => x.InstructorId == course.InstructorId);
                var user = await _userManagerRepository.FindByIdAsync(instructor.UserId);
                users.Remove(user);
            }

            foreach (var user in users)
            {
                if (user.Email is null) continue;
                var result = await _emailService.SendEmailRemindDeleteAccount(user.Email);
                if (result)
                {
                    user.SendClearEmail = true;
                    await _userManager.UpdateAsync(user);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public async Task ClearUser()
    {
        try
        {
            var users = _userManager.Users.Where(user => user.SendClearEmail == true).ToList();

            var students = new List<Student>();
            var ordersHeaders = new List<OrderHeader>();
            var ordersDetails = new List<OrderDetails>();
            var ordersStatus = new List<OrderStatus>();
            var cartsHeaders = new List<CartHeader>();
            var cartsDetails = new List<CartDetails>();
            var studentsComments = new List<StudentComment>();
            var coursesBookmarked = new List<CourseBookmark>();

            var instructors = new List<Instructor>();
            var instructorsComments = new List<InstructorComment>();
            var instructorsRatings = new List<InstructorRating>();

            foreach (var user in users)
            {
                await _emailService.SendEmailDeleteAccount(user.Email);
                var role = await _userManager.GetRolesAsync(user);

                if (role.Contains(StaticUserRoles.Instructor))
                {
                    var instructor = await _unitOfWork.InstructorRepository.GetAsync(x => x.UserId == user.Id);

                    // Get instructorComment
                    var instructorComment = await _unitOfWork.InstructorCommentRepository
                        .GetAllAsync(x => x.InstructorId == instructor.InstructorId);

                    // Get instructorRatting
                    var instructorRating = await _unitOfWork.InstructorRatingRepository
                        .GetAllAsync(x => x.InstructorId == instructor.InstructorId);

                    instructors.Add(instructor);
                    instructorsComments.AddRange(instructorComment);
                    instructorsRatings.AddRange(instructorRating);
                }

                if (role.Contains(StaticUserRoles.Student))
                {
                    var student = await _unitOfWork.StudentRepository.GetAsync(x => x.UserId == user.Id);
                    students.Add(student);


                    // Get orderHeader and orderDetails
                    var orderHeaders =
                        await _unitOfWork.OrderHeaderRepository.GetAllAsync(x => x.StudentId == student.StudentId);
                    foreach (var orderHeader in orderHeaders)
                    {
                        var orderDetails =
                            await _unitOfWork.OrderDetailsRepository.GetAllAsync(x =>
                                x.OrderHeaderId == orderHeader.Id);
                        var orderStatus =
                            await _unitOfWork.OrderStatusRepository.GetAllAsync(x => x.OrderHeaderId == orderHeader.Id);
                        ordersDetails.AddRange(orderDetails);
                        ordersStatus.AddRange(orderStatus);
                    }

                    ordersHeaders.AddRange(orderHeaders);

                    //Get courseBookmarked
                    var courseBookmarks =
                        await _unitOfWork.CourseBookmarkRepository.GetAllAsync(x => x.StudentId == student.StudentId);
                    coursesBookmarked.AddRange(courseBookmarks);

                    //Get studentComments
                    var studentComments =
                        await _unitOfWork.StudentCommentRepository.GetAllAsync(x => x.StudentId == student.StudentId);
                    studentsComments.AddRange(studentComments);

                    //Get cartHeader and cartDetails
                    var cartHeaders =
                        await _unitOfWork.CartHeaderRepository.GetAllAsync(x => x.StudentId == student.StudentId);
                    foreach (var cartHeader in cartHeaders)
                    {
                        var cartDetails =
                            await _unitOfWork.CartDetailsRepository.GetAllAsync(x => x.CartHeaderId == cartHeader.Id);
                        cartsDetails.AddRange(cartDetails);
                    }

                    cartsHeaders.AddRange(cartHeaders);
                }
            }

            _unitOfWork.InstructorCommentRepository.RemoveRange(instructorsComments);
            _unitOfWork.InstructorRatingRepository.RemoveRange(instructorsRatings);

            _unitOfWork.StudentCommentRepository.RemoveRange(studentsComments);
            _unitOfWork.CourseBookmarkRepository.RemoveRange(coursesBookmarked);
            _unitOfWork.CartDetailsRepository.RemoveRange(cartsDetails);
            _unitOfWork.CartHeaderRepository.RemoveRange(cartsHeaders);
            _unitOfWork.OrderStatusRepository.RemoveRange(ordersStatus);
            _unitOfWork.OrderDetailsRepository.RemoveRange(ordersDetails);
            _unitOfWork.OrderHeaderRepository.RemoveRange(ordersHeaders);

            _unitOfWork.InstructorRepository.RemoveRange(instructors);
            _unitOfWork.StudentRepository.RemoveRange(students);

            foreach (var user in users)
            {
                await DeleteUserAndRelatedDataAsync(user);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private async Task DeleteUserAndRelatedDataAsync(ApplicationUser user)
    {
        var roles = await _userManager.GetRolesAsync(user);
        if (roles.Any())
        {
            await _userManager.RemoveFromRolesAsync(user, roles);
        }

        var claims = await _userManager.GetClaimsAsync(user);
        if (claims.Any())
        {
            foreach (var claim in claims)
            {
                await _userManager.RemoveClaimAsync(user, claim);
            }
        }

        var logins = await _userManager.GetLoginsAsync(user);
        if (logins.Any())
        {
            foreach (var login in logins)
            {
                await _userManager.RemoveLoginAsync(user, login.LoginProvider, login.ProviderKey);
            }
        }

        var tokens = await _userManager.GetAuthenticationTokenAsync(user, "provider", "name");
        if (tokens != null)
        {
            await _userManager.RemoveAuthenticationTokenAsync(user, "provider", "name");
        }

        var result = await _userManager.DeleteAsync(user);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                Console.WriteLine($"Error deleting user: {error.Description}");
            }
        }
    }
}