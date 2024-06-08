﻿using System.Collections.Concurrent;
using AutoMapper;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;
    private readonly IEmailSender _emailSender;
    private readonly IFirebaseService _firebaseService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    private static readonly ConcurrentDictionary<string, (int Count, DateTime LastRequest)> ResetPasswordAttempts =
        new();

    public AuthService(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration configuration,
        IMapper mapper,
        IEmailService emailService,
        IFirebaseService firebaseService,
        IHttpContextAccessor httpContextAccessor,
        IEmailSender emailSender,
        ITokenService tokenService, IUnitOfWork unitOfWork)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _mapper = mapper;
        _emailService = emailService;
        _firebaseService = firebaseService;
        _httpContextAccessor = httpContextAccessor;
        _emailSender = emailSender;
        _tokenService = tokenService;
        _unitOfWork = unitOfWork;
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

            var isCardExist =
                await _unitOfWork.PaymentCardRepository.GetAsync(x => x.CardNumber == registerStudentDTO.CardNumber);
            if (isCardExist is not null)
            {
                return new ResponseDTO()
                {
                    Message = "Card number is using by another user",
                    StatusCode = 400,
                    Result = registerStudentDTO,
                    IsSuccess = false
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
            await _unitOfWork.StudentRepository.AddAsync(student);

            // Create new Payment relate with ApplicationUser
            await _unitOfWork.PaymentCardRepository.AddAsync(paymentCard);

            // Save change to database
            await _unitOfWork.SaveAsync();

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

            var isCardExist =
                await _unitOfWork.PaymentCardRepository.GetAsync(x => x.CardNumber == instructorDto.CardNumber);
            if (isCardExist is not null)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    StatusCode = 400,
                    Message = "Card number is using by another user",
                    Result = null
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
                UpdateTime = DateTime.Now
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
            await _unitOfWork.InstructorRepository.AddAsync(instructor);

            // Create card for instructor
            await _unitOfWork.PaymentCardRepository.AddAsync(paymentCard);

            // Save change to database
            await _unitOfWork.SaveAsync();

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

    //Student-SignInbyGoogle
    public async Task<SignResponseDTO> StudentSignInByGoogle(StudentSignInByGoogleDTO studentSignInByGoogleDTO)
    {
        try
        {
            //lấy thông tin từ google
            FirebaseToken googleTokenS =
                await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(studentSignInByGoogleDTO.GoogleToken);
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

            if (user is not null && userLoginInfo is null)
            {
                return new SignResponseDTO()
                {
                    Message = "The email is using by another user",
                    RefreshToken = null,
                    AccessToken = null,
                    UserInfo = null,
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
                };

                await _userManager.CreateAsync(user);

                var isRoleExist = await _roleManager.RoleExistsAsync(StaticUserRoles.Student);
                if (isRoleExist is false)
                {
                    await _roleManager.CreateAsync(new IdentityRole(StaticUserRoles.Student));
                }

                await _userManager.AddToRoleAsync(user, StaticUserRoles.Student);
                await _userManager.AddLoginAsync(user,
                    new UserLoginInfo(StaticLoginProvider.Google, userId, "GOOGLE"));
            }

            var accessToken = await _tokenService.GenerateJwtAccessTokenAsync(user);
            var refreshToken = await _tokenService.GenerateJwtRefreshTokenAsync(user);
            await _tokenService.StoreRefreshToken(user.Id, refreshToken);

            var userInfo = _mapper.Map<UserInfo>(user);
            userInfo.Roles = await _userManager.GetRolesAsync(user);
            return new SignResponseDTO()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                UserInfo = userInfo
            };
        }
        catch (FirebaseAuthException e)
        {
            return new SignResponseDTO()
            {
                Message = e.Message
            };
        }
    }

    //Instructor-SignInbyGoogle
    public async Task<SignResponseDTO> InstructorSignInByGoogle(InstructorSignInByGoogleDTO instructorSignInByGoogleDto)
    {
        try
        {
            //lấy thông tin từ google
            FirebaseToken googleTokenS =
                await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(instructorSignInByGoogleDto.GoogleToken);
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

            if (user is not null && userLoginInfo is null)
            {
                return new SignResponseDTO()
                {
                    Message = "The email is using by another user",
                    RefreshToken = null,
                    AccessToken = null,
                    UserInfo = null,
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
                };

                await _userManager.CreateAsync(user);

                var isRoleExist = await _roleManager.RoleExistsAsync(StaticUserRoles.Instructor);
                if (isRoleExist is false)
                {
                    await _roleManager.CreateAsync(new IdentityRole(StaticUserRoles.Instructor));
                }

                await _userManager.AddToRoleAsync(user, StaticUserRoles.Instructor);
                await _userManager.AddLoginAsync(user,
                    new UserLoginInfo(StaticLoginProvider.Google, userId, "GOOGLE"));
            }

            var accessToken = await _tokenService.GenerateJwtAccessTokenAsync(user);
            var refreshToken = await _tokenService.GenerateJwtRefreshTokenAsync(user);
            await _tokenService.StoreRefreshToken(user.Id, refreshToken);

            var userInfo = _mapper.Map<UserInfo>(user);
            userInfo.Roles = await _userManager.GetRolesAsync(user);
            return new SignResponseDTO()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                UserInfo = userInfo
            };
        }
        catch (FirebaseAuthException e)
        {
            return new SignResponseDTO()
            {
                Message = e.Message
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
}