using Xunit;
using Moq;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Cursus.LMS.Service.Service;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.DataAccess.IRepository;
using System.Threading.Tasks;
using Cursus.LMS.Model.Domain;
using System;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;

public class AuthServiceTests
{
    private readonly Mock<IUserManagerRepository> _userManagerRepositoryMock;
    private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;
    private readonly Mock<RoleManager<IdentityRole>> _roleManagerMock;
    private readonly Mock<IConfiguration> _configurationMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IEmailService> _emailServiceMock;
    private readonly Mock<IFirebaseService> _firebaseServiceMock;
    private readonly Mock<IHttpContextAccessor> _httpContextAccessorMock;
    private readonly Mock<ITokenService> _tokenServiceMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IPaymentCardRepository> _paymentCardRepositoryMock;
    private readonly AuthService _authService;
    private readonly RegisterStudentDTO registerStudentDTO;

    public AuthServiceTests()
    {
        _userManagerRepositoryMock = new Mock<IUserManagerRepository>();
        _userManagerMock = new Mock<UserManager<ApplicationUser>>(
            new Mock<IUserStore<ApplicationUser>>().Object, null, null, null, null, null, null, null, null);
        _roleManagerMock = new Mock<RoleManager<IdentityRole>>(
            new Mock<IRoleStore<IdentityRole>>().Object, null, null, null, null);
        _configurationMock = new Mock<IConfiguration>();
        _mapperMock = new Mock<IMapper>();
        _emailServiceMock = new Mock<IEmailService>();
        _firebaseServiceMock = new Mock<IFirebaseService>();
        _httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        _tokenServiceMock = new Mock<ITokenService>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _paymentCardRepositoryMock = new Mock<IPaymentCardRepository>();

        _unitOfWorkMock.SetupGet(x => x.PaymentCardRepository).Returns(_paymentCardRepositoryMock.Object);

        _authService = new AuthService(
            _userManagerRepositoryMock.Object,
            _userManagerMock.Object,
            _roleManagerMock.Object,
            _configurationMock.Object,
            _mapperMock.Object,
            _emailServiceMock.Object,
            _firebaseServiceMock.Object,
            _httpContextAccessorMock.Object,
            _tokenServiceMock.Object,
            _unitOfWorkMock.Object);

        registerStudentDTO = new RegisterStudentDTO
        {
            Email = "test@example.com",
            PhoneNumber = "1234567890",
            CardNumber = "1234567890123456",
            Password = "Password123!",
            Address = "123 Main St",
            BirthDate = DateTime.Now.AddYears(-20),
            FullName = "John Doe",
            Gender = "Male",
            Country = "Country",
            University = "University",
            CardName = "John Doe",
            CardProvider = "Visa"
        };
    }

    /// <summary>
    /// SignUpStudent
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task SignUpStudent_EmailAlreadyExists_ReturnsErrorResponse()
    {
        // Arrange
        var registerStudentDTO = new RegisterStudentDTO
        {
            Email = "test@example.com",
            PhoneNumber = "1234567890",
            CardNumber = "1234567890123456"
        };
        _userManagerRepositoryMock.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync(new ApplicationUser());

        // Act
        var result = await _authService.SignUpStudent(registerStudentDTO);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Email is using by another user", result.Message);
    }

    [Fact]
    public async Task SignUpStudent_PhoneNumberAlreadyExists_ReturnsErrorResponse()
    {
        // Arrange
        var registerStudentDTO = new RegisterStudentDTO
        {
            Email = "test@example.com",
            PhoneNumber = "1234567890",
            CardNumber = "1234567890123456"
        };
        _userManagerRepositoryMock.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync((ApplicationUser)null);
        _userManagerRepositoryMock.Setup(x => x.CheckIfPhoneNumberExistsAsync(It.IsAny<string>())).ReturnsAsync(true);

        // Act
        var result = await _authService.SignUpStudent(registerStudentDTO);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Phone number is using by another user", result.Message);
    }

    [Fact]
    public async Task SignUpStudent_CardNumberAlreadyExists_ReturnsErrorResponse()
    {
        // Arrange
        var registerStudentDTO = new RegisterStudentDTO
        {
            Email = "test@example.com",
            PhoneNumber = "1234567890",
            CardNumber = "1234567890123456"
        };
        _userManagerRepositoryMock.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync((ApplicationUser)null);
        _userManagerRepositoryMock.Setup(x => x.CheckIfPhoneNumberExistsAsync(It.IsAny<string>())).ReturnsAsync(false);
        _unitOfWorkMock.Setup(x => x.PaymentCardRepository.CardNumberExistsAsync(It.IsAny<string>())).ReturnsAsync(new PaymentCard());

        // Act
        var result = await _authService.SignUpStudent(registerStudentDTO);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Card number is using by another user", result.Message);
    }
    [Fact]
    public async Task SignUpStudent_AddRole_ReturnsErrorResponse()
    {
        // Arrange
        var registerStudentDTO = new RegisterStudentDTO
        {
            Email = "test@example.com",
            PhoneNumber = "1234567890",
            CardNumber = "1234567890123456",
            Password = "Password123!",
            Address = "123 Main St",
            BirthDate = DateTime.Now.AddYears(-20),
            FullName = "John Doe",
            Gender = "Male",
            Country = "Country",
            University = "University",
            CardName = "John Doe",
            CardProvider = "Visa"
        }; // Fill with necessary data
        _userManagerRepositoryMock.Setup(repo => repo.FindByEmailAsync(registerStudentDTO.Email)).ReturnsAsync((ApplicationUser)null);
        _userManagerRepositoryMock.Setup(repo => repo.CheckIfPhoneNumberExistsAsync(registerStudentDTO.PhoneNumber)).ReturnsAsync(false);
        _unitOfWorkMock.Setup(uow => uow.PaymentCardRepository.CardNumberExistsAsync(registerStudentDTO.CardNumber)).ReturnsAsync((PaymentCard)null);
        _userManagerRepositoryMock.Setup(repo => repo.FindByPhoneAsync(registerStudentDTO.PhoneNumber)).ReturnsAsync( new ApplicationUser());
        _userManagerRepositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
        _roleManagerMock.Setup(repo => repo.RoleExistsAsync(StaticUserRoles.Student)).ReturnsAsync(false);
        _userManagerRepositoryMock.Setup(repo => repo.AddToRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Error adding role" }));
        // Act
        var result = await _authService.SignUpStudent(registerStudentDTO);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Error adding role", result.Message);
        // Additional assertions as needed
    }


    [Fact]
    public async Task SignUpStudent_AddStudent_ReturnsErrorResponse()
    {
        // Arrange
        var registerStudentDTO = new RegisterStudentDTO
        {
            Email = "test@example.com",
            PhoneNumber = "1234567890",
            CardNumber = "1234567890123456",
            Password = "Password123!",
            Address = "123 Main St",
            BirthDate = DateTime.Now.AddYears(-20),
            FullName = "John Doe",
            Gender = "Male",
            Country = "Country",
            University = "University",
            CardName = "John Doe",
            CardProvider = "Visa"
        }; // Fill with necessary data
        _userManagerRepositoryMock.Setup(repo => repo.FindByEmailAsync(registerStudentDTO.Email)).ReturnsAsync((ApplicationUser)null);
        _userManagerRepositoryMock.Setup(repo => repo.CheckIfPhoneNumberExistsAsync(registerStudentDTO.PhoneNumber)).ReturnsAsync(false);
        _unitOfWorkMock.Setup(uow => uow.PaymentCardRepository.CardNumberExistsAsync(registerStudentDTO.CardNumber)).ReturnsAsync((PaymentCard)null);
        _userManagerRepositoryMock.Setup(repo => repo.FindByPhoneAsync(registerStudentDTO.PhoneNumber)).ReturnsAsync(new ApplicationUser());
        _userManagerRepositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
        _roleManagerMock.Setup(repo => repo.RoleExistsAsync(StaticUserRoles.Student)).ReturnsAsync(false);
        _userManagerRepositoryMock.Setup(repo => repo.AddToRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
        _unitOfWorkMock.Setup(uow => uow.StudentRepository.AddAsync(It.IsAny<Student>())).ReturnsAsync((Student)null);
        // Act
        var result = await _authService.SignUpStudent(registerStudentDTO);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Failed to add student", result.Message);
        // Additional assertions as needed
    }


    [Fact]
    public async Task SignUpStudent_AddPayment_ReturnsErrorResponse()
    {
        var registerStudentDTO = new RegisterStudentDTO
        {
            Email = "test@example.com",
            PhoneNumber = "1234567890",
            CardNumber = "1234567890123456",
            Password = "Password123!",
            Address = "123 Main St",
            BirthDate = DateTime.Now.AddYears(-20),
            FullName = "John Doe",
            Gender = "Male",
            Country = "Country",
            University = "University",
            CardName = "John Doe",
            CardProvider = "Visa"
        }; // Fill with necessary data
        _userManagerRepositoryMock.Setup(repo => repo.FindByEmailAsync(registerStudentDTO.Email)).ReturnsAsync((ApplicationUser)null);
        _userManagerRepositoryMock.Setup(repo => repo.CheckIfPhoneNumberExistsAsync(registerStudentDTO.PhoneNumber)).ReturnsAsync(false);
        _unitOfWorkMock.Setup(uow => uow.PaymentCardRepository.CardNumberExistsAsync(registerStudentDTO.CardNumber)).ReturnsAsync((PaymentCard)null);
        _userManagerRepositoryMock.Setup(repo => repo.FindByPhoneAsync(registerStudentDTO.PhoneNumber)).ReturnsAsync(new ApplicationUser());
        _userManagerRepositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
        _roleManagerMock.Setup(repo => repo.RoleExistsAsync(StaticUserRoles.Student)).ReturnsAsync(false);
        _userManagerRepositoryMock.Setup(repo => repo.AddToRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
        _unitOfWorkMock.Setup(uow => uow.StudentRepository.AddAsync(It.IsAny<Student>())).ReturnsAsync(new Student());
        _unitOfWorkMock.Setup(x => x.PaymentCardRepository.AddAsync(It.IsAny<PaymentCard>())).ReturnsAsync((PaymentCard)null);

        // Act
        var result = await _authService.SignUpStudent(registerStudentDTO);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Failed to add payment card", result.Message);
        Assert.Equal(500, result.StatusCode);
    }

    [Fact]
    public async Task SignUpStudent_SaveChanges_ReturnsErrorResponse()
    {
        var registerStudentDTO = new RegisterStudentDTO
        {
            Email = "test@example.com",
            PhoneNumber = "1234567890",
            CardNumber = "1234567890123456",
            Password = "Password123!",
            Address = "123 Main St",
            BirthDate = DateTime.Now.AddYears(-20),
            FullName = "John Doe",
            Gender = "Male",
            Country = "Country",
            University = "University",
            CardName = "John Doe",
            CardProvider = "Visa"
        }; // Fill with necessary data
        _userManagerRepositoryMock.Setup(repo => repo.FindByEmailAsync(registerStudentDTO.Email)).ReturnsAsync((ApplicationUser)null);
        _userManagerRepositoryMock.Setup(repo => repo.CheckIfPhoneNumberExistsAsync(registerStudentDTO.PhoneNumber)).ReturnsAsync(false);
        _unitOfWorkMock.Setup(uow => uow.PaymentCardRepository.CardNumberExistsAsync(registerStudentDTO.CardNumber)).ReturnsAsync((PaymentCard)null);
        _userManagerRepositoryMock.Setup(repo => repo.FindByPhoneAsync(registerStudentDTO.PhoneNumber)).ReturnsAsync(new ApplicationUser());
        _userManagerRepositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
        _roleManagerMock.Setup(repo => repo.RoleExistsAsync(StaticUserRoles.Student)).ReturnsAsync(false);
        _userManagerRepositoryMock.Setup(repo => repo.AddToRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
        _unitOfWorkMock.Setup(uow => uow.StudentRepository.AddAsync(It.IsAny<Student>())).ReturnsAsync(new Student());
        _unitOfWorkMock.Setup(x => x.PaymentCardRepository.AddAsync(It.IsAny<PaymentCard>())).ReturnsAsync(new PaymentCard());
        _unitOfWorkMock.Setup(x => x.SaveAsync()).ReturnsAsync(0);

        // Act
        var result = await _authService.SignUpStudent(registerStudentDTO);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Failed to save changes to the database", result.Message);
        Assert.Equal(500, result.StatusCode);
    }



    [Fact]
    public async Task SignUpStudent_Success_ReturnsSuccessResponse()
    {
        // Arrange
        var registerStudentDTO = new RegisterStudentDTO
        {
            Email = "test@example.com",
            PhoneNumber = "1234567890",
            CardNumber = "1234567890123456",
            Password = "Password123!",
            Address = "123 Main St",
            BirthDate = DateTime.Now.AddYears(-20),
            FullName = "John Doe",
            Gender = "Male",
            Country = "Country",
            University = "University",
            CardName = "John Doe",
            CardProvider = "Visa"
        }; // Fill with necessary data
        _userManagerRepositoryMock.Setup(repo => repo.FindByEmailAsync(registerStudentDTO.Email)).ReturnsAsync((ApplicationUser)null);
        _userManagerRepositoryMock.Setup(repo => repo.CheckIfPhoneNumberExistsAsync(registerStudentDTO.PhoneNumber)).ReturnsAsync(false);
        _unitOfWorkMock.Setup(uow => uow.PaymentCardRepository.CardNumberExistsAsync(registerStudentDTO.CardNumber)).ReturnsAsync((PaymentCard)null);
        _userManagerRepositoryMock.Setup(repo => repo.FindByPhoneAsync(registerStudentDTO.PhoneNumber)).ReturnsAsync(new ApplicationUser());
        _userManagerRepositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
        _roleManagerMock.Setup(repo => repo.RoleExistsAsync(StaticUserRoles.Student)).ReturnsAsync(false);
        _userManagerRepositoryMock.Setup(repo => repo.AddToRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
        _unitOfWorkMock.Setup(uow => uow.StudentRepository.AddAsync(It.IsAny<Student>())).ReturnsAsync(new Student());
        _unitOfWorkMock.Setup(x => x.PaymentCardRepository.AddAsync(It.IsAny<PaymentCard>())).ReturnsAsync(new PaymentCard());
        _unitOfWorkMock.Setup(x => x.SaveAsync()).ReturnsAsync(1); // Mock the SaveAsync method

        // Act
        var result = await _authService.SignUpStudent(registerStudentDTO);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal("Create new user successfully", result.Message);
    }
}
