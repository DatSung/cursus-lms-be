using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Service.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

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

    public AuthServiceTests()
    {
        _userManagerRepositoryMock = new Mock<IUserManagerRepository>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _userManagerMock = new Mock<UserManager<ApplicationUser>>(
            Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);
        _roleManagerMock = new Mock<RoleManager<IdentityRole>>(
            Mock.Of<IRoleStore<IdentityRole>>(), null, null, null, null);
        _tokenServiceMock = new Mock<ITokenService>();
        _mapperMock = new Mock<IMapper>();
        _emailServiceMock = new Mock<IEmailService>();
        _firebaseServiceMock = new Mock<IFirebaseService>();
        _httpContextAccessorMock = new Mock<IHttpContextAccessor>();

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
}
