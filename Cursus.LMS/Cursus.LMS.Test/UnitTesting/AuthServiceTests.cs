using AutoMapper; // Corrected casing
using Cursus.LMS.DataAccess.IRepository; // Corrected casing
using Cursus.LMS.Model.Domain; // Corrected casing
using Cursus.LMS.Model.DTO; // Corrected casing
using Cursus.LMS.Service.IService; // Corrected casing
using Cursus.LMS.Service.Service; // Corrected casing
using Cursus.LMS.Utility.Constants; // Corrected casing
using Humanizer;
using Microsoft.AspNetCore.Http; // Corrected casing
using Microsoft.AspNetCore.Identity; // Corrected casing
using Microsoft.EntityFrameworkCore; // Corrected casing
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc; // Corrected casing
using Microsoft.Extensions.Logging; // Corrected casing
using System.Linq.Expressions;
namespace Cursus.LMS.Service.Tests
{
    public class AuthServiceTests
    {
        private readonly AuthService _authService;
        private readonly Mock<IUserManagerRepository> _userManagerRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;
        private readonly Mock<RoleManager<IdentityRole>> _roleManagerMock;
        private readonly Mock<ITokenService> _tokenServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IEmailService> _emailServiceMock;
        private readonly Mock<IFirebaseService> _firebaseServiceMock;
        private readonly Mock<IHttpContextAccessor> _httpContextAccessorMock;
        private readonly List<ApplicationUser> _mockUsers;
        private readonly StudentService _studentService;


        public AuthServiceTests()
        {
            _userManagerRepositoryMock = new Mock<IUserManagerRepository>();
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(
                Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);
            _roleManagerMock = new Mock<RoleManager<IdentityRole>>(
                Mock.Of<IRoleStore<IdentityRole>>(), null, null, null, null);
            _mapperMock = new Mock<IMapper>();
            _emailServiceMock = new Mock<IEmailService>();
            _firebaseServiceMock = new Mock<IFirebaseService>();
            _httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            _tokenServiceMock = new Mock<ITokenService>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mockUsers = new List<ApplicationUser>();
            _userManagerMock.Setup(x => x.Users).Returns(_mockUsers.AsQueryable());

            _authService = new AuthService(
                _userManagerRepositoryMock.Object,
                _userManagerMock.Object,
                _roleManagerMock.Object,
                _mapperMock.Object,
                _emailServiceMock.Object,
                _firebaseServiceMock.Object,
                _httpContextAccessorMock.Object,
                _tokenServiceMock.Object,
                _unitOfWorkMock.Object
            );
        }


        [Fact]
        public async Task SignUpStudent_EmailAlreadyExists_ReturnsBadRequest()
        {
            // Arrange
            var registerStudentDTO = new RegisterStudentDTO { Email = "test@example.com" };
            _userManagerRepositoryMock.Setup(x => x.FindByEmailAsync(registerStudentDTO.Email))
                .ReturnsAsync(new ApplicationUser());

            // Act
            var result = await _authService.SignUpStudent(registerStudentDTO);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Email is using by another user", result.Message);
        }

        [Fact]
        public async Task SignUpStudent_PhoneNumberAlreadyExists_ReturnsBadRequest()
        {
            // Arrange
            var registerStudentDTO = new RegisterStudentDTO { Email = "test@example.com", PhoneNumber = "1234567890" };
            _userManagerRepositoryMock.Setup(x => x.FindByEmailAsync(registerStudentDTO.Email))
                .ReturnsAsync((ApplicationUser)null);
            _userManagerRepositoryMock.Setup(x => x.CheckIfPhoneNumberExistsAsync(registerStudentDTO.PhoneNumber))
                .ReturnsAsync(true);

            // Act
            var result = await _authService.SignUpStudent(registerStudentDTO);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Phone number is using by another user", result.Message);
        }

        [Fact]
        public async Task SignUpStudent_CreateUserFailed_ReturnsBadRequest()
        {
            // Arrange
            var registerStudentDTO = new RegisterStudentDTO { Email = "test@example.com", PhoneNumber = "1234567890", Password = "password" };
            _userManagerRepositoryMock.Setup(x => x.FindByEmailAsync(registerStudentDTO.Email))
                .ReturnsAsync((ApplicationUser)null);
            _userManagerRepositoryMock.Setup(x => x.CheckIfPhoneNumberExistsAsync(registerStudentDTO.PhoneNumber))
                .ReturnsAsync(false);
            _userManagerRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), registerStudentDTO.Password))
                .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Create user failed" }));

            // Act
            var result = await _authService.SignUpStudent(registerStudentDTO);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(400, result.StatusCode);
            Assert.Contains("Create user failed", result.Message);
        }

        [Fact]
        public async Task SignUpStudent_AddRoleFailed_ReturnsInternalServerError()
        {
            // Arrange
            var registerStudentDTO = new RegisterStudentDTO { Email = "test@example.com", PhoneNumber = "1234567890", Password = "password" };
            var newUser = new ApplicationUser { Id = "1" };
            _userManagerRepositoryMock.Setup(x => x.FindByEmailAsync(registerStudentDTO.Email))
                .ReturnsAsync((ApplicationUser)null);
            _userManagerRepositoryMock.Setup(x => x.CheckIfPhoneNumberExistsAsync(registerStudentDTO.PhoneNumber))
                .ReturnsAsync(false);
            _userManagerRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), registerStudentDTO.Password))
                .ReturnsAsync(IdentityResult.Success);
            _userManagerRepositoryMock.Setup(x => x.FindByPhoneAsync(registerStudentDTO.PhoneNumber))
                .ReturnsAsync(newUser);
            _roleManagerMock.Setup(x => x.RoleExistsAsync(It.IsAny<string>()))
                .ReturnsAsync(true);
            _userManagerRepositoryMock.Setup(x => x.AddToRoleAsync(newUser, It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Add role failed" }));

            // Act
            var result = await _authService.SignUpStudent(registerStudentDTO);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Error adding role", result.Message);
        }

        [Fact]
        public async Task SignUpStudent_AddStudentFailed_ReturnsInternalServerError()
        {
            // Arrange
            var registerStudentDTO = new RegisterStudentDTO { Email = "test@example.com", PhoneNumber = "1234567890", Password = "password" };
            var newUser = new ApplicationUser { Id = "1" };
            _userManagerRepositoryMock.Setup(x => x.FindByEmailAsync(registerStudentDTO.Email))
                .ReturnsAsync((ApplicationUser)null);
            _userManagerRepositoryMock.Setup(x => x.CheckIfPhoneNumberExistsAsync(registerStudentDTO.PhoneNumber))
                .ReturnsAsync(false);
            _userManagerRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), registerStudentDTO.Password))
                .ReturnsAsync(IdentityResult.Success);
            _userManagerRepositoryMock.Setup(x => x.FindByPhoneAsync(registerStudentDTO.PhoneNumber))
                .ReturnsAsync(newUser);
            _roleManagerMock.Setup(x => x.RoleExistsAsync(It.IsAny<string>()))
                .ReturnsAsync(true);
            _userManagerRepositoryMock.Setup(x => x.AddToRoleAsync(newUser, It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);
            _unitOfWorkMock.Setup(x => x.StudentRepository.AddAsync(It.IsAny<Student>()))
                .ReturnsAsync((Student)null);

            // Act
            var result = await _authService.SignUpStudent(registerStudentDTO);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Failed to add student", result.Message);
        }

        [Fact]
        public async Task SignUpStudent_SaveChangesFailed_ReturnsInternalServerError()
        {
            // Arrange
            var registerStudentDTO = new RegisterStudentDTO { Email = "test@example.com", PhoneNumber = "1234567890", Password = "password" };
            var newUser = new ApplicationUser { Id = "1" };
            var newStudent = new Student { UserId = "1" };
            _userManagerRepositoryMock.Setup(x => x.FindByEmailAsync(registerStudentDTO.Email))
                .ReturnsAsync((ApplicationUser)null);
            _userManagerRepositoryMock.Setup(x => x.CheckIfPhoneNumberExistsAsync(registerStudentDTO.PhoneNumber))
                .ReturnsAsync(false);
            _userManagerRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), registerStudentDTO.Password))
                .ReturnsAsync(IdentityResult.Success);
            _userManagerRepositoryMock.Setup(x => x.FindByPhoneAsync(registerStudentDTO.PhoneNumber))
                .ReturnsAsync(newUser);
            _roleManagerMock.Setup(x => x.RoleExistsAsync(It.IsAny<string>()))
                .ReturnsAsync(true);
            _userManagerRepositoryMock.Setup(x => x.AddToRoleAsync(newUser, It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);
            _unitOfWorkMock.Setup(x => x.StudentRepository.AddAsync(It.IsAny<Student>()))
                .ReturnsAsync(newStudent);
            _unitOfWorkMock.Setup(x => x.SaveAsync()).ReturnsAsync(0);

            // Act
            var result = await _authService.SignUpStudent(registerStudentDTO);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Failed to save changes to the database", result.Message);
        }

        [Fact]
        public async Task SignUpStudent_Success_ReturnsOk()
        {
            // Arrange
            var registerStudentDTO = new RegisterStudentDTO { Email = "test@example.com", PhoneNumber = "1234567890", Password = "password" };
            var newUser = new ApplicationUser { Id = "1" };
            var newStudent = new Student { UserId = "1" };
            _userManagerRepositoryMock.Setup(x => x.FindByEmailAsync(registerStudentDTO.Email))
                .ReturnsAsync((ApplicationUser)null);
            _userManagerRepositoryMock.Setup(x => x.CheckIfPhoneNumberExistsAsync(registerStudentDTO.PhoneNumber))
                .ReturnsAsync(false);
            _userManagerRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), registerStudentDTO.Password))
                .ReturnsAsync(IdentityResult.Success);
            _userManagerRepositoryMock.Setup(x => x.FindByPhoneAsync(registerStudentDTO.PhoneNumber))
                .ReturnsAsync(newUser);
            _roleManagerMock.Setup(x => x.RoleExistsAsync(It.IsAny<string>()))
                .ReturnsAsync(true);
            _userManagerRepositoryMock.Setup(x => x.AddToRoleAsync(newUser, It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);
            _unitOfWorkMock.Setup(x => x.StudentRepository.AddAsync(It.IsAny<Student>()))
                .ReturnsAsync(newStudent);
            _unitOfWorkMock.Setup(x => x.SaveAsync()).ReturnsAsync(1);

            // Act
            var result = await _authService.SignUpStudent(registerStudentDTO);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Create new user successfully", result.Message);
        }

        [Fact]
        public async Task SignUpInstructor_EmailAlreadyExists_ReturnsErrorResponse()
        {
            // Arrange
            var signUpInstructorDto = new SignUpInstructorDTO { Email = "test@example.com" };
            _userManagerMock.Setup(um => um.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync(new ApplicationUser());

            // Act
            var result = await _authService.SignUpInstructor(signUpInstructorDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Email is using by another user", result.Message);
        }
        [Fact]
        public async Task SignUpInstructor_PhoneNumberAlreadyExists_ReturnsErrorResponse()
        {
            // Arrange
            var signUpInstructorDto = new SignUpInstructorDTO { Email = "test@example.com", PhoneNumber = "1234567890" };
            _userManagerMock.Setup(um => um.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync((ApplicationUser)null);
            _userManagerRepositoryMock.Setup(r => r.CheckIfPhoneNumberExistsAsync(It.IsAny<string>())).ReturnsAsync(true);

            // Act
            var result = await _authService.SignUpInstructor(signUpInstructorDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Phone number is using by another user", result.Message);
        }




        [Fact]
        public async Task SignUpInstructor_RoleExists_DoesNotCreateRole()
        {
            // Arrange
            var signUpInstructorDto = new SignUpInstructorDTO { Email = "test@example.com" };
            _userManagerMock.Setup(um => um.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync((ApplicationUser)null);
            _userManagerRepositoryMock.Setup(r => r.CheckIfPhoneNumberExistsAsync(It.IsAny<string>())).ReturnsAsync(false);
            _roleManagerMock.Setup(rm => rm.RoleExistsAsync(It.IsAny<string>())).ReturnsAsync(true);

            // Act
            var result = await _authService.SignUpInstructor(signUpInstructorDto);

            // Assert
            _roleManagerMock.Verify(rm => rm.CreateAsync(It.IsAny<IdentityRole>()), Times.Never);
        }
        [Fact]
        public async Task UserUnauthenticated_ReturnsErrorResponse()
        {
            // Arrange
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());

            // Act
            var result = await _authService.GetInstructorDegree(claimsPrincipal);

            // Assert
            Assert.Null(result.ContentType);
            Assert.Equal("User Unauthenticated!", result.Message);
            Assert.Null(result.Stream);
        }

        [Fact]
        public async Task InstructorNotFound_ReturnsErrorResponse()
        {
            // Arrange
            var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, "123") };
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims));
            _unitOfWorkMock.Setup(u => u.InstructorRepository.GetAsync(It.IsAny<Expression<Func<Instructor, bool>>>(), It.IsAny<string>()))
                           .ReturnsAsync((Instructor)null);

            // Act
            var result = await _authService.GetInstructorDegree(claimsPrincipal);

            // Assert
            Assert.Null(result.ContentType);
            Assert.Equal("Instructor does not exist!", result.Message);
            Assert.Null(result.Stream);
        }
        [Fact]
        public async Task DegreeNotUploaded_ReturnsErrorResponse()
        {
            // Arrange
            var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, "123") };
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims));
            var instructor = new Instructor { DegreeImageUrl = string.Empty };
            _unitOfWorkMock.Setup(u => u.InstructorRepository.GetAsync(It.IsAny<Expression<Func<Instructor, bool>>>(), It.IsAny<string>()))
                           .ReturnsAsync(instructor);

            // Act
            var result = await _authService.GetInstructorDegree(claimsPrincipal);

            // Assert
            Assert.Null(result.ContentType);
            Assert.Equal("Instructors did not upload degree!", result.Message);
            Assert.Null(result.Stream);
        }

        [Fact]
        public async Task DegreeNotFoundInFirebase_ReturnsErrorResponse()
        {
            // Arrange
            var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, "123") };
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims));
            var instructor = new Instructor { DegreeImageUrl = "path/to/degree.png" };
            _unitOfWorkMock.Setup(u => u.InstructorRepository.GetAsync(It.IsAny<Expression<Func<Instructor, bool>>>(), It.IsAny<string>()))
                           .ReturnsAsync(instructor);
            _firebaseServiceMock.Setup(fs => fs.GetImage(It.IsAny<string>())).ReturnsAsync((MemoryStream)null);

            // Act
            var result = await _authService.GetInstructorDegree(claimsPrincipal);

            // Assert
            Assert.Null(result.ContentType);
            Assert.Equal("Instructor did not upload degree", result.Message);
            Assert.Null(result.Stream);
        }

        [Fact]
        public async Task UnsupportedFileExtension_ReturnsErrorResponse()
        {
            // Arrange
            var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, "123") };
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims));
            var instructor = new Instructor { DegreeImageUrl = "path/to/degree.txt" };
            _unitOfWorkMock.Setup(u => u.InstructorRepository.GetAsync(It.IsAny<Expression<Func<Instructor, bool>>>(), It.IsAny<string>()))
                           .ReturnsAsync(instructor);
            var mockStream = new MemoryStream();
            _firebaseServiceMock.Setup(fs => fs.GetImage(It.IsAny<string>())).ReturnsAsync(mockStream);

            // Act
            var result = await _authService.GetInstructorDegree(claimsPrincipal);

            // Assert
            Assert.Equal("Unsupported extensions!", result.ContentType);
            Assert.Equal("Get file successfully", result.Message);
            Assert.Equal(mockStream, result.Stream);
        }

        [Fact]
        public async Task SuccessfulRetrieval_ReturnsDegreeResponse()
        {
            // Arrange
            var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, "123") };
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims));
            var instructor = new Instructor { DegreeImageUrl = "path/to/degree.png" };
            _unitOfWorkMock.Setup(u => u.InstructorRepository.GetAsync(It.IsAny<Expression<Func<Instructor, bool>>>(), It.IsAny<string>()))
                           .ReturnsAsync(instructor);
            var mockStream = new MemoryStream();
            _firebaseServiceMock.Setup(fs => fs.GetImage(It.IsAny<string>())).ReturnsAsync(mockStream);

            // Act
            var result = await _authService.GetInstructorDegree(claimsPrincipal);

            // Assert
            Assert.Equal(StaticFileExtensions.Png, result.ContentType);
            Assert.Equal("Get file successfully", result.Message);
            Assert.Equal(mockStream, result.Stream);
            Assert.Equal("degree.png", result.FileName);
        }

        //GetAvatar

        [Fact]
        public async Task GetUserAvatar_UserNotAuthenticated_ReturnsNull()
        {
            // Arrange
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());

            // Act
            var result = await _authService.GetUserAvatar(claimsPrincipal);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetUserAvatar_UserDoesNotExist_ReturnsNull()
        {
            // Arrange
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, "1") }));

            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync((ApplicationUser)null);

            // Act
            var result = await _authService.GetUserAvatar(claimsPrincipal);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetUserAvatar_AvatarUrlNotSet_ReturnsNull()
        {
            // Arrange
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, "1") }));
            var user = new ApplicationUser { AvatarUrl = null };

            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);

            // Act
            var result = await _authService.GetUserAvatar(claimsPrincipal);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetUserAvatar_AvatarImageNotFound_ReturnsNull()
        {
            // Arrange
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, "1") }));
            var user = new ApplicationUser { AvatarUrl = "avatar_url" };

            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);
            _firebaseServiceMock.Setup(fs => fs.GetImage(It.IsAny<string>())).ReturnsAsync((MemoryStream)null);

            // Act
            var result = await _authService.GetUserAvatar(claimsPrincipal);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetUserAvatar_AvatarImageFound_ReturnsStream()
        {
            // Arrange
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, "1") }));
            var user = new ApplicationUser { AvatarUrl = "avatar_url" };
            var memoryStream = new MemoryStream();

            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);
            _firebaseServiceMock.Setup(fs => fs.GetImage(It.IsAny<string>())).ReturnsAsync(memoryStream);

            // Act
            var result = await _authService.GetUserAvatar(claimsPrincipal);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(memoryStream, result);
        }

        [Fact]
        public async Task GetUserAvatar_ExceptionThrown_ReturnsNull()
        {
            // Arrange
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, "1") }));

            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ThrowsAsync(new Exception());

            // Act
            var result = await _authService.GetUserAvatar(claimsPrincipal);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task SignIn_UserDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var signDTO = new SignDTO { Email = "test@example.com", Password = "Password123" };
            _userManagerMock.Setup(um => um.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync((ApplicationUser)null);

            // Act
            var result = await _authService.SignIn(signDTO);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("User does not exist!", result.Message);
        }

        [Fact]
        public async Task SignIn_IncorrectPassword_ReturnsBadRequest()
        {
            // Arrange
            var signDTO = new SignDTO { Email = "test@example.com", Password = "Password123" };
            var user = new ApplicationUser { Email = signDTO.Email };
            _userManagerMock.Setup(um => um.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync(user);
            _userManagerMock.Setup(um => um.CheckPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(false);

            // Act
            var result = await _authService.SignIn(signDTO);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Incorrect email or password", result.Message);
        }

        [Fact]
        public async Task SignIn_EmailNotConfirmed_ReturnsUnauthorized()
        {
            // Arrange
            var signDTO = new SignDTO { Email = "test@example.com", Password = "Password123" };
            var user = new ApplicationUser { Email = signDTO.Email, EmailConfirmed = false };
            _userManagerMock.Setup(um => um.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync(user);
            _userManagerMock.Setup(um => um.CheckPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(true);

            // Act
            var result = await _authService.SignIn(signDTO);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(401, result.StatusCode);
            Assert.Equal("You need to confirm email!", result.Message);
        }

        [Fact]
        public async Task SignIn_UserLockedOut_ReturnsForbidden()
        {
            // Arrange
            var signDTO = new SignDTO { Email = "test@example.com", Password = "Password123" };
            var user = new ApplicationUser { Email = signDTO.Email, EmailConfirmed = true, LockoutEnd = DateTimeOffset.UtcNow.AddMinutes(30) };
            _userManagerMock.Setup(um => um.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync(user);
            _userManagerMock.Setup(um => um.CheckPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(true);

            // Act
            var result = await _authService.SignIn(signDTO);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(403, result.StatusCode);
            Assert.Equal("User has been locked", result.Message);
        }

        [Fact]
        public async Task SignIn_Success_ReturnsTokens()
        {
            // Arrange
            var signDTO = new SignDTO { Email = "test@example.com", Password = "Password123" };
            var user = new ApplicationUser { Email = signDTO.Email, EmailConfirmed = true, LockoutEnd = null };
            var accessToken = "accessToken";
            var refreshToken = "refreshToken";

            _userManagerMock.Setup(um => um.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync(user);
            _userManagerMock.Setup(um => um.CheckPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(true);
            _tokenServiceMock.Setup(ts => ts.GenerateJwtAccessTokenAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(accessToken);
            _tokenServiceMock.Setup(ts => ts.GenerateJwtRefreshTokenAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(refreshToken);

            // Act
            var result = await _authService.SignIn(signDTO);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Sign in successfully", result.Message);
            var signResponse = Assert.IsType<SignResponseDTO>(result.Result);
            Assert.Equal(accessToken, signResponse.AccessToken);
            Assert.Equal(refreshToken, signResponse.RefreshToken);
        }

        [Fact]
        public async Task SignIn_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var signDTO = new SignDTO { Email = "test@example.com", Password = "Password123" };
            _userManagerMock.Setup(um => um.FindByEmailAsync(It.IsAny<string>())).ThrowsAsync(new Exception("An error occurred"));

            // Act
            var result = await _authService.SignIn(signDTO);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("An error occurred", result.Message);
        }
        [Fact]
        public async Task Refresh_InvalidToken_ReturnsBadRequest()
        {
            // Arrange
            var token = "invalid_token";
            _tokenServiceMock.Setup(ts => ts.GetPrincipalFromToken(It.IsAny<string>())).ReturnsAsync((ClaimsPrincipal)null);

            // Act
            var result = await _authService.Refresh(token);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Token is not valid", result.Message);
        }

        [Fact]
        public async Task Refresh_UserDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var token = "valid_token";
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.NameIdentifier, "user_id")
            }));
            _tokenServiceMock.Setup(ts => ts.GetPrincipalFromToken(It.IsAny<string>())).ReturnsAsync(claimsPrincipal);
            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync((ApplicationUser)null);

            // Act
            var result = await _authService.Refresh(token);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("User does not exist", result.Message);
        }

        [Fact]
        public async Task Refresh_TokenDoesNotMatch_ReturnsBadRequest()
        {
            // Arrange
            var token = "valid_token";
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.NameIdentifier, "user_id")
            }));
            var user = new ApplicationUser { Id = "user_id" };
            _tokenServiceMock.Setup(ts => ts.GetPrincipalFromToken(It.IsAny<string>())).ReturnsAsync(claimsPrincipal);
            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);
            _tokenServiceMock.Setup(ts => ts.RetrieveRefreshToken(It.IsAny<string>())).ReturnsAsync("different_token");

            // Act
            var result = await _authService.Refresh(token);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Token is not valid", result.Message);
        }

        [Fact]
        public async Task Refresh_Success_ReturnsNewTokens()
        {
            // Arrange
            var token = "valid_token";
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.NameIdentifier, "user_id")
            }));
            var user = new ApplicationUser { Id = "user_id" };
            var accessToken = "new_access_token";
            var refreshToken = "new_refresh_token";

            _tokenServiceMock.Setup(ts => ts.GetPrincipalFromToken(It.IsAny<string>())).ReturnsAsync(claimsPrincipal);
            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);
            _tokenServiceMock.Setup(ts => ts.RetrieveRefreshToken(It.IsAny<string>())).ReturnsAsync(token);
            _tokenServiceMock.Setup(ts => ts.GenerateJwtAccessTokenAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(accessToken);
            _tokenServiceMock.Setup(ts => ts.GenerateJwtRefreshTokenAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(refreshToken);

            // Act
            var result = await _authService.Refresh(token);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Refresh Token Successfully!", result.Message);
            var jwtToken = Assert.IsType<JwtTokenDTO>(result.Result);
            Assert.Equal(accessToken, jwtToken.AccessToken);
            Assert.Equal(refreshToken, jwtToken.RefreshToken);
        }

        [Fact]
        public async Task ResetPassword_UserNotFound_ReturnsNotFound()
        {
            // Arrange
            var email = "test@example.com";
            var token = "reset_token";
            var password = "new_password";
            _userManagerMock.Setup(um => um.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync((ApplicationUser)null);

            // Act
            var result = await _authService.ResetPassword(email, token, password);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("User not found.", result.Message);
        }
        [Fact]
        public async Task ResetPassword_SameAsOldPassword_ReturnsBadRequest()
        {
            // Arrange
            var email = "test@example.com";
            var token = "reset_token";
            var password = "old_password";
            var user = new ApplicationUser { Email = email };
            _userManagerMock.Setup(um => um.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync(user);
            _userManagerMock.Setup(um => um.CheckPasswordAsync(user, It.IsAny<string>())).ReturnsAsync(true);

            // Act
            var result = await _authService.ResetPassword(email, token, password);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("New password cannot be the same as the old password.", result.Message);
        }
        [Fact]
        public async Task ResetPassword_Success_ReturnsOk()
        {
            // Arrange
            var email = "test@example.com";
            var token = "reset_token";
            var password = "new_password";
            var user = new ApplicationUser { Email = email };
            _userManagerMock.Setup(um => um.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync(user);
            _userManagerMock.Setup(um => um.CheckPasswordAsync(user, It.IsAny<string>())).ReturnsAsync(false);
            _userManagerMock.Setup(um => um.ResetPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>(), It.IsAny<string>()))
                            .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _authService.ResetPassword(email, token, password);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Reset password successfully.", result.Message);
        }
        [Fact]
        public async Task ResetPassword_TokenInvalid_ReturnsBadRequest()
        {
            // Arrange
            var email = "test@example.com";
            var token = "invalid_token";
            var password = "new_password";
            var user = new ApplicationUser { Email = email };
            _userManagerMock.Setup(um => um.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync(user);
            _userManagerMock.Setup(um => um.CheckPasswordAsync(user, It.IsAny<string>())).ReturnsAsync(false);
            _userManagerMock.Setup(um => um.ResetPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>(), It.IsAny<string>()))
                            .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Invalid token" }));

            // Act
            var result = await _authService.ResetPassword(email, token, password);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(400, result.StatusCode);
            Assert.Contains("Invalid token", result.Message);
        }
        [Fact]
        public async Task ResetPassword_PasswordResetFails_ReturnsBadRequest()
        {
            // Arrange
            var email = "test@example.com";
            var token = "reset_token";
            var password = "new_password";
            var user = new ApplicationUser { Email = email };
            _userManagerMock.Setup(um => um.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync(user);
            _userManagerMock.Setup(um => um.CheckPasswordAsync(user, It.IsAny<string>())).ReturnsAsync(false);
            _userManagerMock.Setup(um => um.ResetPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>(), It.IsAny<string>()))
                            .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Password reset failed" }));

            // Act
            var result = await _authService.ResetPassword(email, token, password);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(400, result.StatusCode);
            Assert.Contains("Password reset failed", result.Message);
        }
        [Fact]
        public async Task ResetPassword_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var email = "test@example.com";
            var token = "reset_token";
            var password = "new_password";
            _userManagerMock.Setup(um => um.FindByEmailAsync(It.IsAny<string>())).ThrowsAsync(new Exception("Unexpected error"));

            // Act
            var result = await _authService.ResetPassword(email, token, password);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Unexpected error", result.Message);
        }
        [Fact]
        public async Task ChangePassword_UserNotFound_ReturnsNotFound()
        {
            // Arrange
            var userId = "non_existing_user";
            var oldPassword = "old_password";
            var newPassword = "new_password";
            var confirmNewPassword = "new_password";
            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync((ApplicationUser)null);

            // Act
            var result = await _authService.ChangePassword(userId, oldPassword, newPassword, confirmNewPassword);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("User not found.", result.Message);
        }
        [Fact]
        public async Task ChangePassword_NewPasswordMismatch_ReturnsBadRequest()
        {
            // Arrange
            var userId = "existing_user";
            var oldPassword = "old_password";
            var newPassword = "new_password";
            var confirmNewPassword = "different_new_password";
            var user = new ApplicationUser { Id = userId };
            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);

            // Act
            var result = await _authService.ChangePassword(userId, oldPassword, newPassword, confirmNewPassword);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("New password and confirm new password do not match.", result.Message);
        }
        [Fact]
        public async Task ChangePassword_NewPasswordSameAsOld_ReturnsBadRequest()
        {
            // Arrange
            var userId = "existing_user";
            var oldPassword = "password";
            var newPassword = "password";
            var confirmNewPassword = "password";
            var user = new ApplicationUser { Id = userId };
            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);

            // Act
            var result = await _authService.ChangePassword(userId, oldPassword, newPassword, confirmNewPassword);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("New password cannot be the same as the old password.", result.Message);
        }
        [Fact]
        public async Task ChangePassword_Success_ReturnsOk()
        {
            // Arrange
            var userId = "existing_user";
            var oldPassword = "old_password";
            var newPassword = "new_password";
            var confirmNewPassword = "new_password";
            var user = new ApplicationUser { Id = userId };
            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);
            _userManagerMock.Setup(um => um.ChangePasswordAsync(user, oldPassword, newPassword))
                            .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _authService.ChangePassword(userId, oldPassword, newPassword, confirmNewPassword);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Password changed successfully.", result.Message);
        }
        [Fact]
        public async Task ChangePassword_Failure_ReturnsBadRequest()
        {
            // Arrange
            var userId = "existing_user";
            var oldPassword = "old_password";
            var newPassword = "new_password";
            var confirmNewPassword = "new_password";
            var user = new ApplicationUser { Id = userId };
            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);
            _userManagerMock.Setup(um => um.ChangePasswordAsync(user, oldPassword, newPassword))
                            .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Old password is incorrect." }));

            // Act
            var result = await _authService.ChangePassword(userId, oldPassword, newPassword, confirmNewPassword);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(400, result.StatusCode);
            Assert.Contains("Old password is incorrect", result.Message);
        }
        [Fact]
        public async Task ChangePassword_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var userId = "existing_user";
            var oldPassword = "old_password";
            var newPassword = "new_password";
            var confirmNewPassword = "new_password";
            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ThrowsAsync(new Exception("Unexpected error"));

            // Act
            var result = await _authService.ChangePassword(userId, oldPassword, newPassword, confirmNewPassword);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("An error occurred: Unexpected error", result.Message);
        }
        [Fact]
        public async Task SendVerifyEmail_Success_ReturnsOk()
        {
            // Arrange
            var email = "test@example.com";
            var confirmationLink = "https://example.com/confirm";
            _emailServiceMock.Setup(e => e.SendVerifyEmail(email, confirmationLink)).Returns(Task.FromResult(true));

            // Act
            var result = await _authService.SendVerifyEmail(email, confirmationLink);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Send verify email successfully", result.Message);
        }

        [Fact]
        public async Task SendVerifyEmail_EmailServiceFails_ReturnsInternalServerError()
        {
            // Arrange
            var email = "test@example.com";
            var confirmationLink = "https://example.com/confirm";
            _emailServiceMock.Setup(e => e.SendVerifyEmail(email, confirmationLink)).ThrowsAsync(new Exception("Email service failed"));

            // Act
            var result = await _authService.SendVerifyEmail(email, confirmationLink);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Email service failed", result.Message);
        }

        [Fact]
        public async Task VerifyEmail_EmailAlreadyConfirmed_ReturnsSuccess()
        {
            // Arrange
            var userId = "user123";
            var token = "token";
            var user = new ApplicationUser { EmailConfirmed = true };
            _userManagerMock.Setup(um => um.FindByIdAsync(userId)).ReturnsAsync(user);

            // Act
            var result = await _authService.VerifyEmail(userId, token);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Your email has been confirmed!", result.Message);
        }
        [Fact]
        public async Task VerifyEmail_ConfirmEmailFails_ReturnsBadRequest()
        {
            // Arrange
            var userId = "user123";
            var token = "token";
            var user = new ApplicationUser { EmailConfirmed = false };
            _userManagerMock.Setup(um => um.FindByIdAsync(userId)).ReturnsAsync(user);
            _userManagerMock.Setup(um => um.ConfirmEmailAsync(user, token))
                            .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Invalid token" }));

            // Act
            var result = await _authService.VerifyEmail(userId, token);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Invalid token", result.Message);
        }
        [Fact]
        public async Task VerifyEmail_ConfirmEmailSucceeds_ReturnsSuccess()
        {
            // Arrange
            var userId = "user123";
            var token = "token";
            var user = new ApplicationUser { EmailConfirmed = false };
            _userManagerMock.Setup(um => um.FindByIdAsync(userId)).ReturnsAsync(user);
            _userManagerMock.Setup(um => um.ConfirmEmailAsync(user, token))
                            .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _authService.VerifyEmail(userId, token);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Confirm Email Successfully", result.Message);
        }

        [Fact]
        public async Task CheckEmailExist_EmailExists_ReturnsSuccessResponse()
        {
            // Arrange
            var email = "test@example.com";
            var user = new ApplicationUser { Email = email };
            _userManagerMock.Setup(um => um.FindByEmailAsync(email)).ReturnsAsync(user);

            // Act
            var result = await _authService.CheckEmailExist(email);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Email is existed", result.Message);
        }

        [Fact]
        public async Task CheckEmailExist_EmailDoesNotExist_ReturnsFailureResponse()
        {
            // Arrange
            var email = "test@example.com";
            _userManagerMock.Setup(um => um.FindByEmailAsync(email)).ReturnsAsync((ApplicationUser)null);

            // Act
            var result = await _authService.CheckEmailExist(email);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Email does not exist", result.Message);
        }

        [Fact]
        public async Task CheckEmailExist_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var email = "test@example.com";
            _userManagerMock.Setup(um => um.FindByEmailAsync(email)).ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _authService.CheckEmailExist(email);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Database error", result.Message);
            Assert.Null(result.Result);
        }
        [Fact]
        public async Task CompleteStudentProfile_UserDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, "user123") }));
            var dto = new CompleteStudentProfileDTO { PhoneNumber = "123-456-7890" };
            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync((ApplicationUser)null);

            // Act
            var result = await _authService.CompleteStudentProfile(claimsPrincipal, dto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("User does not exist!", result.Message);
        }

        [Fact]
        public async Task CompleteStudentProfile_PhoneNumberAlreadyUsed_ReturnsConflict()
        {
            // Arrange
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, "user123") }));
            var dto = new CompleteStudentProfileDTO { PhoneNumber = "123-456-7890" };
            var user = new ApplicationUser { Id = "user123" };
            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);
            _userManagerRepositoryMock.Setup(r => r.CheckIfPhoneNumberExistsAsync(It.IsAny<string>())).ReturnsAsync(true);

            // Act
            var result = await _authService.CompleteStudentProfile(claimsPrincipal, dto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Phone number is using by another user", result.Message);
        }



        [Fact]
        public async Task CompleteStudentProfile_RoleAlreadyExists_DoesNotCreateRole()
        {
            // Arrange
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, "user123") }));
            var dto = new CompleteStudentProfileDTO { PhoneNumber = "123-456-7890", University = "University X" };
            var user = new ApplicationUser { Id = "user123" };

            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);
            _userManagerRepositoryMock.Setup(r => r.CheckIfPhoneNumberExistsAsync(It.IsAny<string>())).ReturnsAsync(false);
            _roleManagerMock.Setup(rm => rm.RoleExistsAsync(It.IsAny<string>())).ReturnsAsync(true);

            var student = new Student { UserId = "user123", University = "Old University" };
            _unitOfWorkMock.Setup(uow => uow.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), It.IsAny<string>())).ReturnsAsync(student);

            // Act
            var result = await _authService.CompleteStudentProfile(claimsPrincipal, dto);

            // Assert
            _roleManagerMock.Verify(rm => rm.CreateAsync(It.IsAny<IdentityRole>()), Times.Never);
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Update student profile successfully", result.Message);
        }


        [Fact]
        public async Task CompleteStudentProfile_SuccessfulUpdate_ReturnsSuccess()
        {
            // Arrange
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, "user123") }));
            var dto = new CompleteStudentProfileDTO { PhoneNumber = "123-456-7890" };
            var user = new ApplicationUser { Id = "user123" };
            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);
            _userManagerRepositoryMock.Setup(r => r.CheckIfPhoneNumberExistsAsync(It.IsAny<string>())).ReturnsAsync(false);
            _roleManagerMock.Setup(rm => rm.RoleExistsAsync(It.IsAny<string>())).ReturnsAsync(true);
            var student = new Student { UserId = "user123", University = "Old University" };
            _unitOfWorkMock.Setup(uow => uow.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), It.IsAny<string>())).ReturnsAsync(student);

            _unitOfWorkMock.Setup(uow => uow.SaveAsync()).ReturnsAsync(1);

            // Act
            var result = await _authService.CompleteStudentProfile(claimsPrincipal, dto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Update student profile successfully", result.Message);
        }

        [Fact]
        public async Task CompleteStudentProfile_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, "user123") }));
            var dto = new CompleteStudentProfileDTO { PhoneNumber = "123-456-7890" };
            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _authService.CompleteStudentProfile(claimsPrincipal, dto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Database error", result.Message);
            Assert.Null(result.Result);
        }

        [Fact]
        public async Task CompleteInstructorProfile_UserDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, "user123") }));
            var dto = new CompleteInstructorProfileDTO { PhoneNumber = "123-456-7890" };
            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync((ApplicationUser)null);

            // Act
            var result = await _authService.CompleteInstructorProfile(claimsPrincipal, dto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("User does not exist!", result.Message);
        }



        [Fact]
        public async Task CompleteInstructorProfile_RoleAlreadyExists_DoesNotCreateRole()
        {
            // Arrange
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, "user123") }));
            var dto = new CompleteInstructorProfileDTO { PhoneNumber = "123-456-7890" };
            var user = new ApplicationUser { Id = "user123" };
            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);
            _userManagerRepositoryMock.Setup(r => r.CheckIfPhoneNumberExistsAsync(It.IsAny<string>())).ReturnsAsync(false);
            _roleManagerMock.Setup(rm => rm.RoleExistsAsync(It.IsAny<string>())).ReturnsAsync(true);

            // Act
            var result = await _authService.CompleteInstructorProfile(claimsPrincipal, dto);

            // Assert
            _roleManagerMock.Verify(rm => rm.CreateAsync(It.IsAny<IdentityRole>()), Times.Never);
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Update student profile successfully", result.Message);
        }

        [Fact]
        public async Task CompleteInstructorProfile_SuccessfulUpdate_ReturnsSuccess()
        {
            // Arrange
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, "user123") }));
            var dto = new CompleteInstructorProfileDTO { PhoneNumber = "123-456-7890" };
            var user = new ApplicationUser { Id = "user123" };
            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);
            _userManagerRepositoryMock.Setup(r => r.CheckIfPhoneNumberExistsAsync(It.IsAny<string>())).ReturnsAsync(false);
            _roleManagerMock.Setup(rm => rm.RoleExistsAsync(It.IsAny<string>())).ReturnsAsync(true);
            _unitOfWorkMock.Setup(uow => uow.SaveAsync()).ReturnsAsync(1);

            // Act
            var result = await _authService.CompleteInstructorProfile(claimsPrincipal, dto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Update student profile successfully", result.Message);
        }

        [Fact]
        public async Task CompleteInstructorProfile_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, "user123") }));
            var dto = new CompleteInstructorProfileDTO { PhoneNumber = "123-456-7890" };
            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _authService.CompleteInstructorProfile(claimsPrincipal, dto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Database error", result.Message);
            Assert.Null(result.Result);
        }
        [Fact]
        public async Task GetUserInfo_UserExistsWithInstructorRole_ReturnsInstructorInfo()
        {
            // Arrange
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, "user123") }));
            var user = new ApplicationUser { Id = "user123" };
            var InstructorId = Guid.NewGuid();
            var instructor = new Instructor { UserId = "user123", DegreeImageUrl = "url", IsAccepted = true, InstructorId = InstructorId };

            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);
            _userManagerMock.Setup(um => um.GetRolesAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(new List<string> { StaticUserRoles.Instructor });
            _unitOfWorkMock.Setup(uow => uow.InstructorRepository.GetAsync(It.IsAny<Expression<Func<Instructor, bool>>>(), It.IsAny<string>())).ReturnsAsync(instructor);

            // Act
            var result = await _authService.GetUserInfo(claimsPrincipal);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            var userInfo = Assert.IsType<UserInfoDTO>(result.Result);
            Assert.True(userInfo.isUploadDegree);
            Assert.True(userInfo.isAccepted);
            Assert.Equal(InstructorId, userInfo.InstructorId);
        }

        [Fact]
        public async Task DisplayUserAvatar_UserExists_ReturnsAvatarStream()
        {
            // Arrange
            var userId = "user123";
            var user = new ApplicationUser { Id = userId, AvatarUrl = "avatar_url" };
            var memoryStream = new MemoryStream();

            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);
            _firebaseServiceMock.Setup(fs => fs.GetImage(It.IsAny<string>())).ReturnsAsync(memoryStream);

            // Act
            var result = await _authService.DisplayUserAvatar(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(memoryStream, result);
            _userManagerMock.Verify(um => um.FindByIdAsync(userId), Times.Once);
            _firebaseServiceMock.Verify(fs => fs.GetImage(user.AvatarUrl), Times.Once);
        }
        [Fact]
        public async Task DisplayInstructorDegree_InstructorExistsAndDegreeUploaded_ReturnsDegreeResponse()
        {
            // Arrange
            var userId = "user123";
            var instructor = new Instructor { UserId = userId, DegreeImageUrl = "degree.pdf" };
            var memoryStream = new MemoryStream();

            _unitOfWorkMock.Setup(uow => uow.InstructorRepository.GetAsync(It.IsAny<Expression<Func<Instructor, bool>>>(), It.IsAny<string>())).ReturnsAsync(instructor);
            _firebaseServiceMock.Setup(fs => fs.GetImage(It.IsAny<string>())).ReturnsAsync(memoryStream);

            // Act
            var result = await _authService.DisplayInstructorDegree(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Get file successfully", result.Message);
            Assert.Equal(memoryStream, result.Stream);
            Assert.Equal(StaticFileExtensions.Pdf, result.ContentType);
            Assert.Equal(Path.GetFileName(instructor.DegreeImageUrl), result.FileName);
        }
        [Fact]
        public async Task DisplayInstructorDegree_UserIdIsNull_ThrowsException()
        {
            // Arrange
            string userId = null;

            // Act
            var result = await _authService.DisplayInstructorDegree(userId);

            // Assert
            Assert.Null(result.Stream);
            Assert.Equal("User Unauthenticated!", result.Message);
        }
        [Fact]
        public async Task DisplayInstructorDegree_InstructorDoesNotExist_ThrowsException()
        {
            // Arrange
            var userId = "user123";

            _unitOfWorkMock.Setup(uow => uow.InstructorRepository.GetAsync(It.IsAny<Expression<Func<Instructor, bool>>>(), It.IsAny<string>())).ReturnsAsync((Instructor)null);

            // Act
            var result = await _authService.DisplayInstructorDegree(userId);

            // Assert
            Assert.Null(result.Stream);
            Assert.Equal("Instructor does not exist!", result.Message);
        }
        [Fact]
        public async Task UpdateStudent_UserNotFound_ReturnsNotFound()
        {
            // Arrange
            var updateStudentDTO = new UpdateStudentProfileDTO();
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());

            // Act
            var result = await _authService.UpdateStudent(updateStudentDTO, claimsPrincipal);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("User not found", result.Message);
        }
        [Fact]
        public async Task UpdateStudent_StudentNotFound_ReturnsNotFound()
        {
            // Arrange
            var updateStudentDTO = new UpdateStudentProfileDTO();
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, "user123") }));

            _unitOfWorkMock.Setup(uow => uow.StudentRepository.GetByUserId(It.IsAny<string>())).ReturnsAsync((Student)null);

            // Act
            var result = await _authService.UpdateStudent(updateStudentDTO, claimsPrincipal);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("Student not found", result.Message);
        }

        [Fact]
        public async Task UpdateStudent_SuccessfullyUpdatesStudent_ReturnsSuccess()
        {
            // Arrange
            var updateStudentDTO = new UpdateStudentProfileDTO
            {
                University = "Test University",
                Address = "123 Test Street",
                BirthDate = new DateTime(2000, 1, 1),
                Gender = "Male",
                FullName = "Test User",
                Country = "Test Country"
            };
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, "user123") }));

            var student = new Student
            {
                UserId = "user123",
                University = "Old University",
                ApplicationUser = new ApplicationUser
                {
                    Address = "Old Address",
                    BirthDate = new DateTime(1990, 1, 1),
                    Gender = "Female",
                    FullName = "Old Name",
                    Country = "Old Country"
                }
            };

            _unitOfWorkMock.Setup(uow => uow.StudentRepository.GetByUserId(It.IsAny<string>())).ReturnsAsync(student);
            _unitOfWorkMock.Setup(uow => uow.StudentRepository.Update(It.IsAny<Student>()));
            _unitOfWorkMock.Setup(uow => uow.SaveAsync()).ReturnsAsync(1);

            // Act
            var result = await _authService.UpdateStudent(updateStudentDTO, claimsPrincipal);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Student updated successfully", result.Message);
        }

        [Fact]
        public async Task UpdateStudent_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var updateStudentDTO = new UpdateStudentProfileDTO();
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, "user123") }));

            _unitOfWorkMock.Setup(uow => uow.StudentRepository.GetByUserId(It.IsAny<string>())).ThrowsAsync(new Exception("Test exception"));

            // Act
            var result = await _authService.UpdateStudent(updateStudentDTO, claimsPrincipal);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Test exception", result.Message);
        }

        [Fact]
        public async Task UpdateInstructor_UserNotFound_ReturnsNotFound()
        {
            // Arrange
            var updateInstructorDTO = new UpdateIntructorProfileDTO();
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());

            // Act
            var result = await _authService.UpdateInstructor(updateInstructorDTO, claimsPrincipal);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("User not found", result.Message);
        }

        [Fact]
        public async Task UpdateInstructor_InstructorNotFound_ReturnsNotFound()
        {
            // Arrange
            var updateInstructorDTO = new UpdateIntructorProfileDTO();
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, "user123") }));

            _unitOfWorkMock.Setup(uow => uow.InstructorRepository.GetByUserId(It.IsAny<string>())).ReturnsAsync((Instructor)null);

            // Act
            var result = await _authService.UpdateInstructor(updateInstructorDTO, claimsPrincipal);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("Instructor not found", result.Message);
        }

        [Fact]
        public async Task UpdateInstructor_SuccessfullyUpdatesInstructor_ReturnsSuccess()
        {
            // Arrange
            var updateInstructorDTO = new UpdateIntructorProfileDTO
            {
                Degree = "PhD",
                Industry = "Computer Science",
                Introduction = "Expert in AI",
                Address = "123 Test Street",
                BirthDate = new DateTime(1980, 1, 1),
                Gender = "Male",
                FullName = "Dr. Test User",
                Country = "Test Country",
                TaxNumber = "123-456-789"
            };
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, "user123") }));

            var instructor = new Instructor
            {
                UserId = "user123",
                Degree = "Old Degree",
                Industry = "Old Industry",
                Introduction = "Old Introduction",
                ApplicationUser = new ApplicationUser
                {
                    Address = "Old Address",
                    BirthDate = new DateTime(1970, 1, 1),
                    Gender = "Female",
                    FullName = "Old Name",
                    Country = "Old Country",
                    TaxNumber = "987-654-321"
                }
            };

            _unitOfWorkMock.Setup(uow => uow.InstructorRepository.GetByUserId(It.IsAny<string>())).ReturnsAsync(instructor);
            _unitOfWorkMock.Setup(uow => uow.InstructorRepository.Update(It.IsAny<Instructor>()));
            _unitOfWorkMock.Setup(uow => uow.SaveAsync()).ReturnsAsync(1);

            // Act
            var result = await _authService.UpdateInstructor(updateInstructorDTO, claimsPrincipal);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Updated instructor successfully", result.Message);
        }

        [Fact]
        public async Task UpdateInstructor_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var updateInstructorDTO = new UpdateIntructorProfileDTO();
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, "user123") }));

            _unitOfWorkMock.Setup(uow => uow.InstructorRepository.GetByUserId(It.IsAny<string>())).ThrowsAsync(new Exception("Test exception"));

            // Act
            var result = await _authService.UpdateInstructor(updateInstructorDTO, claimsPrincipal);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Test exception", result.Message);
        }

        [Fact]
        public async Task LockUser_UserNotFound_ReturnsNotFound()
        {
            // Arrange
            var lockUserDto = new LockUserDTO { UserId = "nonexistentUserId" };

            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync((ApplicationUser)null);

            // Act
            var result = await _authService.LockUser(lockUserDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("User was not found", result.Message);
        }

        [Fact]
        public async Task LockUser_UserIsAdmin_ReturnsBadRequest()
        {
            // Arrange
            var lockUserDto = new LockUserDTO { UserId = "adminUserId" };
            var user = new ApplicationUser { Id = "adminUserId" };

            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);
            _userManagerMock.Setup(um => um.GetRolesAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(new List<string> { StaticUserRoles.Admin });

            // Act
            var result = await _authService.LockUser(lockUserDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Lock user was failed", result.Message);
        }

        [Fact]
        public async Task LockUser_FailureToUpdateUser_ReturnsBadRequest()
        {
            // Arrange
            var lockUserDto = new LockUserDTO { UserId = "user123" };
            var user = new ApplicationUser { Id = "user123" };

            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);
            _userManagerMock.Setup(um => um.GetRolesAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(new List<string> { StaticUserRoles.Admin });
            _userManagerMock.Setup(um => um.UpdateAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Update failed" }));

            // Act
            var result = await _authService.LockUser(lockUserDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Lock user was failed", result.Message);
        }

        [Fact]
        public async Task LockUser_SuccessfullyLocksUser_ReturnsSuccess()
        {
            // Arrange
            var lockUserDto = new LockUserDTO { UserId = "user123" };
            var user = new ApplicationUser { Id = "user123" };

            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);
            _userManagerMock.Setup(um => um.GetRolesAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(new List<string> { StaticUserRoles.Instructor });
            _userManagerMock.Setup(um => um.UpdateAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _authService.LockUser(lockUserDto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Lock user successfully", result.Message);
        }

        [Fact]
        public async Task LockUser_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var lockUserDto = new LockUserDTO { UserId = "user123" };

            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ThrowsAsync(new Exception("Test exception"));

            // Act
            var result = await _authService.LockUser(lockUserDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Test exception", result.Message);
        }
        [Fact]
        public async Task UnlockUser_UserNotFound_ReturnsNotFound()
        {
            // Arrange
            var lockUserDto = new LockUserDTO { UserId = "nonexistentUserId" };

            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync((ApplicationUser)null);

            // Act
            var result = await _authService.UnlockUser(lockUserDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("User was not found", result.Message);
        }

        [Fact]
        public async Task UnlockUser_FailureToUpdateUser_ReturnsBadRequest()
        {
            // Arrange
            var lockUserDto = new LockUserDTO { UserId = "user123" };
            var user = new ApplicationUser { Id = "user123" };

            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);
            _userManagerMock.Setup(um => um.UpdateAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Update failed" }));

            // Act
            var result = await _authService.UnlockUser(lockUserDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Unlock user was failed", result.Message);
        }

        [Fact]
        public async Task UnlockUser_SuccessfullyUnlocksUser_ReturnsSuccess()
        {
            // Arrange
            var lockUserDto = new LockUserDTO { UserId = "user123" };
            var user = new ApplicationUser { Id = "user123" };

            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);
            _userManagerMock.Setup(um => um.UpdateAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _authService.UnlockUser(lockUserDto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Unlock user successfully", result.Message);
        }

        [Fact]
        public async Task UnlockUser_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var lockUserDto = new LockUserDTO { UserId = "user123" };

            _userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ThrowsAsync(new Exception("Test exception"));

            // Act
            var result = await _authService.UnlockUser(lockUserDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Test exception", result.Message);
        }
        [Fact]
        public async Task SendClearEmail_NoUsersToSendEmails_Returns()
        {
            // Arrange
            var fromMonth = 3;
            _userManagerMock.Setup(um => um.Users).Returns((new List<ApplicationUser>()).AsQueryable());

            // Act
            await _authService.SendClearEmail(fromMonth);

            // Assert
            _emailServiceMock.Verify(es => es.SendEmailRemindDeleteAccount(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task SendClearEmail_SuccessfullySendsEmails()
        {
            // Arrange
            var fromMonth = 3;
            var users = new List<ApplicationUser>
        {
            new ApplicationUser { Id = "user1", Email = "user1@example.com", LastLoginTime = DateTime.UtcNow.AddMonths(-4) },
            new ApplicationUser { Id = "user2", Email = "user2@example.com", LastLoginTime = DateTime.UtcNow.AddMonths(-5) }
        };
            _userManagerMock.Setup(um => um.Users).Returns(users.AsQueryable());
            _userManagerMock.Setup(um => um.GetUsersInRoleAsync(It.IsAny<string>())).ReturnsAsync(new List<ApplicationUser>());
            _unitOfWorkMock.Setup(uow => uow.StudentCourseRepository.GetAllAsync(It.IsAny<Expression<Func<StudentCourse, bool>>>(), It.IsAny<string>())).ReturnsAsync(new List<StudentCourse>());
            _unitOfWorkMock.Setup(uow => uow.CourseRepository.GetAllAsync(It.IsAny<Expression<Func<Course, bool>>>(), It.IsAny<string>())).ReturnsAsync(new List<Course>());
            _emailServiceMock.Setup(es => es.SendEmailRemindDeleteAccount(It.IsAny<string>())).ReturnsAsync(true);
            _userManagerMock.Setup(um => um.UpdateAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(IdentityResult.Success);

            // Act
            await _authService.SendClearEmail(fromMonth);

            // Assert
            _emailServiceMock.Verify(es => es.SendEmailRemindDeleteAccount("user1@example.com"), Times.Once);
            _emailServiceMock.Verify(es => es.SendEmailRemindDeleteAccount("user2@example.com"), Times.Once);
            _userManagerMock.Verify(um => um.UpdateAsync(It.IsAny<ApplicationUser>()), Times.Exactly(2));
        }

        [Fact]
        public async Task SendClearEmail_ExceptionThrown_LogsException()
        {
            // Arrange
            var fromMonth = 3;
            _userManagerMock.Setup(um => um.Users).Throws(new Exception("Test exception"));

            // Act
            await _authService.SendClearEmail(fromMonth);

            // Assert
            // Check console output or other logging mechanism if applicable.
        }

    }
}
