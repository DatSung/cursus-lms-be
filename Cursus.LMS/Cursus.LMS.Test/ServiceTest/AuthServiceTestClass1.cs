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
using System.Security.Claims;

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
    private readonly Mock<IEmailSender> _emailSenderMock;
    private readonly Mock<ITokenService> _tokenServiceMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IPaymentCardRepository> _paymentCardRepositoryMock;
    private readonly AuthService _authService;
    private readonly RegisterStudentDTO registerStudentDTO;
    private readonly SignUpInstructorDTO _instructorDTO;

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
        _emailSenderMock = new Mock<IEmailSender>();
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
            _emailSenderMock.Object,
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

        _instructorDTO = new SignUpInstructorDTO
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
            Degree = "PhD",
            Industry = "Education",
            Introduction = "Introduction text",
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
        _userManagerRepositoryMock.Setup(repo => repo.FindByPhoneAsync(registerStudentDTO.PhoneNumber)).ReturnsAsync(new ApplicationUser());
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


    /// <summary>
    /// SignUpInstructor
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task SignUpInstructor_EmailAlreadyExists_ReturnsErrorResponse()
    {
        // Arrange
        _userManagerRepositoryMock.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync(new ApplicationUser());

        // Act
        var result = await _authService.SignUpInstructor(_instructorDTO);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Email is using by another user", result.Message);
    }
    [Fact]
    public async Task SignUpInstructor_PhoneNumberAlreadyExists_ReturnsErrorResponse()
    {
        // Arrange
        _userManagerRepositoryMock.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync((ApplicationUser)null);
        _userManagerRepositoryMock.Setup(x => x.CheckIfPhoneNumberExistsAsync(It.IsAny<string>())).ReturnsAsync(true);

        // Act
        var result = await _authService.SignUpInstructor(_instructorDTO);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Phone number is using by another user", result.Message);
    }

    [Fact]
    public async Task SignUpInstructor_CardNumberAlreadyExists_ReturnsErrorResponse()
    {
        // Arrange
        _userManagerRepositoryMock.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync((ApplicationUser)null);
        _userManagerRepositoryMock.Setup(x => x.CheckIfPhoneNumberExistsAsync(It.IsAny<string>())).ReturnsAsync(false);
        _unitOfWorkMock.Setup(x => x.PaymentCardRepository.CardNumberExistsAsync(It.IsAny<string>())).ReturnsAsync(new PaymentCard());

        // Act
        var result = await _authService.SignUpInstructor(_instructorDTO);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Card number is using by another user", result.Message);
    }

    [Fact]
    public async Task SignUpInstructor_AddRole_ReturnsErrorResponse()
    {
        // Arrange
        _userManagerRepositoryMock.Setup(repo => repo.FindByEmailAsync(_instructorDTO.Email)).ReturnsAsync((ApplicationUser)null);
        _userManagerRepositoryMock.Setup(repo => repo.CheckIfPhoneNumberExistsAsync(_instructorDTO.PhoneNumber)).ReturnsAsync(false);
        _unitOfWorkMock.Setup(uow => uow.PaymentCardRepository.CardNumberExistsAsync(_instructorDTO.CardNumber)).ReturnsAsync((PaymentCard)null);
        _userManagerRepositoryMock.Setup(repo => repo.FindByPhoneAsync(_instructorDTO.PhoneNumber)).ReturnsAsync(new ApplicationUser());
        _userManagerRepositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
        _roleManagerMock.Setup(repo => repo.RoleExistsAsync(StaticUserRoles.Instructor)).ReturnsAsync(false);
        _userManagerRepositoryMock.Setup(repo => repo.AddToRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Error adding role" }));

        // Act
        var result = await _authService.SignUpInstructor(_instructorDTO);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Error adding role", result.Message);
    }

    [Fact]
    public async Task SignUpInstructor_AddInstructor_ReturnsErrorResponse()
    {
        // Arrange
        _userManagerRepositoryMock.Setup(repo => repo.FindByEmailAsync(_instructorDTO.Email)).ReturnsAsync((ApplicationUser)null);
        _userManagerRepositoryMock.Setup(repo => repo.CheckIfPhoneNumberExistsAsync(_instructorDTO.PhoneNumber)).ReturnsAsync(false);
        _unitOfWorkMock.Setup(uow => uow.PaymentCardRepository.CardNumberExistsAsync(_instructorDTO.CardNumber)).ReturnsAsync((PaymentCard)null);
        _userManagerRepositoryMock.Setup(repo => repo.FindByPhoneAsync(_instructorDTO.PhoneNumber)).ReturnsAsync(new ApplicationUser());
        _userManagerRepositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
        _roleManagerMock.Setup(repo => repo.RoleExistsAsync(StaticUserRoles.Instructor)).ReturnsAsync(false);
        _userManagerRepositoryMock.Setup(repo => repo.AddToRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
        _unitOfWorkMock.Setup(uow => uow.InstructorRepository.AddAsync(It.IsAny<Instructor>())).ReturnsAsync((Instructor)null);

        // Act
        var result = await _authService.SignUpInstructor(_instructorDTO);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Failed to add instructor", result.Message);
    }

    [Fact]
    public async Task SignUpInstructor_AddPayment_ReturnsErrorResponse()
    {
        // Arrange
        _userManagerRepositoryMock.Setup(repo => repo.FindByEmailAsync(_instructorDTO.Email)).ReturnsAsync((ApplicationUser)null);
        _userManagerRepositoryMock.Setup(repo => repo.CheckIfPhoneNumberExistsAsync(_instructorDTO.PhoneNumber)).ReturnsAsync(false);
        _unitOfWorkMock.Setup(uow => uow.PaymentCardRepository.CardNumberExistsAsync(_instructorDTO.CardNumber)).ReturnsAsync((PaymentCard)null);
        _userManagerRepositoryMock.Setup(repo => repo.FindByPhoneAsync(_instructorDTO.PhoneNumber)).ReturnsAsync(new ApplicationUser());
        _userManagerRepositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
        _roleManagerMock.Setup(repo => repo.RoleExistsAsync(StaticUserRoles.Instructor)).ReturnsAsync(false);
        _userManagerRepositoryMock.Setup(repo => repo.AddToRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
        _unitOfWorkMock.Setup(uow => uow.InstructorRepository.AddAsync(It.IsAny<Instructor>())).ReturnsAsync(new Instructor());
        _unitOfWorkMock.Setup(x => x.PaymentCardRepository.AddAsync(It.IsAny<PaymentCard>())).ReturnsAsync((PaymentCard)null);

        // Act
        var result = await _authService.SignUpInstructor(_instructorDTO);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Failed to add payment card", result.Message);
    }
    [Fact]
    public async Task SignUpInstructor_SaveChanges_ReturnsErrorResponse()
    {
        // Arrange
        _userManagerRepositoryMock.Setup(repo => repo.FindByEmailAsync(_instructorDTO.Email)).ReturnsAsync((ApplicationUser)null);
        _userManagerRepositoryMock.Setup(repo => repo.CheckIfPhoneNumberExistsAsync(_instructorDTO.PhoneNumber)).ReturnsAsync(false);
        _unitOfWorkMock.Setup(uow => uow.PaymentCardRepository.CardNumberExistsAsync(_instructorDTO.CardNumber)).ReturnsAsync((PaymentCard)null);
        _userManagerRepositoryMock.Setup(repo => repo.FindByPhoneAsync(_instructorDTO.PhoneNumber)).ReturnsAsync(new ApplicationUser());
        _userManagerRepositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
        _roleManagerMock.Setup(repo => repo.RoleExistsAsync(StaticUserRoles.Instructor)).ReturnsAsync(false);
        _userManagerRepositoryMock.Setup(repo => repo.AddToRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
        _unitOfWorkMock.Setup(uow => uow.InstructorRepository.AddAsync(It.IsAny<Instructor>())).ReturnsAsync(new Instructor());
        _unitOfWorkMock.Setup(x => x.PaymentCardRepository.AddAsync(It.IsAny<PaymentCard>())).ReturnsAsync(new PaymentCard());
        _unitOfWorkMock.Setup(x => x.SaveAsync()).ReturnsAsync(0);

        // Act
        var result = await _authService.SignUpInstructor(_instructorDTO);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Failed to save changes to the database", result.Message);
    }

    [Fact]
    public async Task SignUpInstructor_ValidData_ReturnsSuccessResponse()
    {
        // Arrange
        _userManagerRepositoryMock.Setup(repo => repo.FindByEmailAsync(_instructorDTO.Email)).ReturnsAsync((ApplicationUser)null);
        _userManagerRepositoryMock.Setup(repo => repo.CheckIfPhoneNumberExistsAsync(_instructorDTO.PhoneNumber)).ReturnsAsync(false);
        _unitOfWorkMock.Setup(uow => uow.PaymentCardRepository.CardNumberExistsAsync(_instructorDTO.CardNumber)).ReturnsAsync((PaymentCard)null);
        _userManagerRepositoryMock.Setup(repo => repo.FindByPhoneAsync(_instructorDTO.PhoneNumber)).ReturnsAsync(new ApplicationUser());
        _userManagerRepositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
        _roleManagerMock.Setup(repo => repo.RoleExistsAsync(StaticUserRoles.Instructor)).ReturnsAsync(false);
        _userManagerRepositoryMock.Setup(repo => repo.AddToRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
        _unitOfWorkMock.Setup(uow => uow.InstructorRepository.AddAsync(It.IsAny<Instructor>())).ReturnsAsync(new Instructor());
        _unitOfWorkMock.Setup(x => x.PaymentCardRepository.AddAsync(It.IsAny<PaymentCard>())).ReturnsAsync(new PaymentCard());
        _unitOfWorkMock.Setup(x => x.SaveAsync()).ReturnsAsync(1);

        // Act
        var result = await _authService.SignUpInstructor(_instructorDTO);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal("Create new user successfully", result.Message);
    }
    /// <summary>
    /// UploadInstructorDegree
    /// </summary>
    /// <returns></returns>

    [Fact]
    public async Task UploadInstructorDegree_UserNotAuthenticated_ReturnsErrorResponse()
    {
        // Arrange
        var fileMock = new Mock<IFormFile>();
        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());

        // Act
        var result = await _authService.UploadInstructorDegree(fileMock.Object, claimsPrincipal);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Equal("Not authentication!", result.Message);
    }

    [Fact]
    public async Task UploadInstructorDegree_InstructorNotFound_ReturnsErrorResponse()
    {
        // Arrange
        var fileMock = new Mock<IFormFile>();
        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, "userId")
        }));
        _unitOfWorkMock.Setup(x => x.InstructorRepository.GetAsync(It.IsAny<string>())).ReturnsAsync((Instructor)null);

        // Act
        var result = await _authService.UploadInstructorDegree(fileMock.Object, claimsPrincipal);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Equal("Instructor does not exist", result.Message);
    }

    [Fact]
    public async Task UploadInstructorDegree_ImageUploadFails_ReturnsErrorResponse()
    {
        // Arrange
        var fileMock = new Mock<IFormFile>();
        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, "userId")
        }));
        _unitOfWorkMock.Setup(x => x.InstructorRepository.GetAsync(It.IsAny<string>())).ReturnsAsync(new Instructor());
        _firebaseServiceMock.Setup(x => x.UploadImage(It.IsAny<IFormFile>(), It.IsAny<string>())).ReturnsAsync(new ResponseDTO { IsSuccess = false });

        // Act
        var result = await _authService.UploadInstructorDegree(fileMock.Object, claimsPrincipal);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Equal("Image upload fail!", result.Message);
    }

    [Fact]
    public async Task UploadInstructorDegree_SaveChangesFails_ReturnsErrorResponse()
    {
        // Arrange
        var fileMock = new Mock<IFormFile>();
        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, "userId")
        }));
        _unitOfWorkMock.Setup(x => x.InstructorRepository.GetAsync(It.IsAny<string>())).ReturnsAsync(new Instructor());
        _firebaseServiceMock.Setup(x => x.UploadImage(It.IsAny<IFormFile>(), It.IsAny<string>())).ReturnsAsync(new ResponseDTO { IsSuccess = true, Result = "url" });
        _unitOfWorkMock.Setup(x => x.SaveAsync()).ReturnsAsync(0);

        // Act
        var result = await _authService.UploadInstructorDegree(fileMock.Object, claimsPrincipal);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
        Assert.Equal("Failed to save changes to the database", result.Message);
    }

    [Fact]
    public async Task UploadInstructorDegree_SuccessfulUpload_ReturnsSuccessResponse()
    {
        // Arrange
        var fileMock = new Mock<IFormFile>();
        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, "userId")
        }));
        var instructor = new Instructor();
        _unitOfWorkMock.Setup(x => x.InstructorRepository.GetAsync(It.IsAny<string>())).ReturnsAsync(instructor);
        _firebaseServiceMock.Setup(x => x.UploadImage(It.IsAny<IFormFile>(), It.IsAny<string>())).ReturnsAsync(new ResponseDTO { IsSuccess = true, Result = "url" });
        _unitOfWorkMock.Setup(x => x.SaveAsync()).ReturnsAsync(1);

        // Act
        var result = await _authService.UploadInstructorDegree(fileMock.Object, claimsPrincipal);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("Upload instructor degree successfully", result.Message);
        Assert.Equal("url", instructor.DegreeImageUrl);
    }

    /// <summary>
    /// GetInstructorDegree
    /// </summary>
    /// <returns></returns>

    [Fact]
    public async Task GetInstructorDegree_UserNotAuthenticated_ReturnsErrorResponse()
    {
        // Arrange
        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());

        // Act
        var result = await _authService.GetInstructorDegree(claimsPrincipal);

        // Assert
        Assert.Null(result.ContentType);
        Assert.Null(result.Stream);
        Assert.Equal("User Unauthenticated!", result.Message);
    }

    [Fact]
    public async Task GetInstructorDegree_InstructorNotFound_ReturnsErrorResponse()
    {
        // Arrange
        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, "userId")
        }));
        _unitOfWorkMock.Setup(x => x.InstructorRepository.GetAsync(It.IsAny<string>())).ReturnsAsync((Instructor)null);

        // Act
        var result = await _authService.GetInstructorDegree(claimsPrincipal);

        // Assert
        Assert.Null(result.ContentType);
        Assert.Null(result.Stream);
        Assert.Equal("Instructor does not exist!", result.Message);
    }

    [Fact]
    public async Task GetInstructorDegree_DegreeNotUploaded_ReturnsErrorResponse()
    {
        // Arrange
        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, "userId")
        }));
        var instructor = new Instructor { DegreeImageUrl = null };
        _unitOfWorkMock.Setup(x => x.InstructorRepository.GetAsync(It.IsAny<string>())).ReturnsAsync(instructor);

        // Act
        var result = await _authService.GetInstructorDegree(claimsPrincipal);

        // Assert
        Assert.Null(result.ContentType);
        Assert.Null(result.Stream);
        Assert.Equal("Instructors did not upload degree!", result.Message);
    }

    [Fact]
    public async Task GetInstructorDegree_DegreeUploadMissing_ReturnsErrorResponse()
    {
        //Arrange
        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
       {
            new Claim(ClaimTypes.NameIdentifier, "userId")
       }));
        var instructor = new Instructor { DegreeImageUrl = "degreePath" };
        _unitOfWorkMock.Setup(x => x.InstructorRepository.GetAsync(It.IsAny<string>())).ReturnsAsync(instructor);
        _firebaseServiceMock.Setup(x => x.UploadImage(It.IsAny<IFormFile>(), It.IsAny<string>())).ReturnsAsync(new ResponseDTO { IsSuccess = true, Result = "url" });
        _firebaseServiceMock.Setup(x => x.GetImage(It.IsAny<string>())).ReturnsAsync((MemoryStream)null); // Corrected setup

        //Act
        var result = await _authService.GetInstructorDegree(claimsPrincipal);

        //Assert
        Assert.Null(result.ContentType);
        Assert.Null(result.Stream);
        Assert.Equal("Instructor did not upload degree", result.Message);
    }

    [Fact]
    public async Task GetInstructorDegree_SuccessfulRetrieval_ReturnsSuccessResponse()
    {
        // Arrange
        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, "userId")
        }));
        var degreePath = "degreePath.pdf";
        var instructor = new Instructor { DegreeImageUrl = degreePath };
        var streamMock = new MemoryStream();
        _unitOfWorkMock.Setup(x => x.InstructorRepository.GetAsync(It.IsAny<string>())).ReturnsAsync(instructor);
        _firebaseServiceMock.Setup(x => x.GetImage(It.IsAny<string>())).ReturnsAsync(streamMock);

        // Act
        var result = await _authService.GetInstructorDegree(claimsPrincipal);

        // Assert
        Assert.Equal(StaticFileExtensions.Pdf, result.ContentType);
        Assert.Equal("degreePath.pdf", result.FileName);
        Assert.Equal("Get file successfully", result.Message);
        Assert.Equal(streamMock, result.Stream);
    }

    [Theory]
    [InlineData("degreePath.pdf", StaticFileExtensions.Pdf)]
    [InlineData("degreePath.png", StaticFileExtensions.Png)]
    [InlineData("degreePath.jpg", StaticFileExtensions.Jpeg)]
    [InlineData("degreePath.jpeg", StaticFileExtensions.Jpeg)]
    public async Task GetInstructorDegree_ValidFileExtensions_ReturnsCorrectContentType(string degreePath, string expectedContentType)
    {
        // Arrange
        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, "userId")
        }));
        var instructor = new Instructor { DegreeImageUrl = degreePath };
        var streamMock = new MemoryStream();
        _unitOfWorkMock.Setup(x => x.InstructorRepository.GetAsync(It.IsAny<string>())).ReturnsAsync(instructor);
        _firebaseServiceMock.Setup(x => x.GetImage(It.IsAny<string>())).ReturnsAsync(streamMock);

        // Act
        var result = await _authService.GetInstructorDegree(claimsPrincipal);

        // Assert
        Assert.Equal(expectedContentType, result.ContentType);
        Assert.Equal(Path.GetFileName(degreePath), result.FileName);
        Assert.Equal("Get file successfully", result.Message);
        Assert.Equal(streamMock, result.Stream);
    }

    /// <summary>
    /// UploadUserAvatar
    /// </summary>
    /// <returns></returns>

    [Fact]
    public async Task UploadUserAvatar_SuccessfullyUploadsAvatar_ReturnsSuccessResponse()
    {
        // Arrange
        var userId = "testUserId";
        var fileMock = new Mock<IFormFile>();
        fileMock.Setup(f => f.FileName).Returns("test.jpg");
        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId)
            }));
        var user = new ApplicationUser { Id = userId };
        var uploadResponse = new ResponseDTO { IsSuccess = true, Result = "avatarUrl" };

        _userManagerRepositoryMock.Setup(r => r.FindByIdAsync(userId)).ReturnsAsync(user);
        _firebaseServiceMock.Setup(s => s.UploadImage(fileMock.Object, StaticFirebaseFolders.UserAvatars)).ReturnsAsync(uploadResponse);
        _userManagerRepositoryMock.Setup(r => r.UpdateAsync(user)).ReturnsAsync(IdentityResult.Success);

        // Act
        var result = await _authService.UploadUserAvatar(fileMock.Object, claimsPrincipal);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("Upload user avatar successfully!", result.Message);
        Assert.Null(result.Result);

        // Verify interactions
        _userManagerRepositoryMock.Verify(r => r.FindByIdAsync(userId), Times.Once);
        _firebaseServiceMock.Verify(s => s.UploadImage(fileMock.Object, StaticFirebaseFolders.UserAvatars), Times.Once);
        _userManagerRepositoryMock.Verify(r => r.UpdateAsync(user), Times.Once);
    }
    [Fact]
    public async Task UploadUserAvatar_UserNotAuthenticated_ReturnsErrorResponse()
    {
        // Arrange
        var fileMock = new Mock<IFormFile>();
        var claimsPrincipal = new ClaimsPrincipal(); // Empty ClaimsPrincipal

        // Act
        var result = await _authService.UploadUserAvatar(fileMock.Object, claimsPrincipal);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Equal("Not authentication!", result.Message);
        Assert.Null(result.Result);
    }

    [Fact]
    public async Task UploadUserAvatar_UserNotFound_ReturnsErrorResponse()
    {
        // Arrange
        var userId = "testUserId";
        var fileMock = new Mock<IFormFile>();
        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId)
            }));

        _userManagerRepositoryMock.Setup(r => r.FindByIdAsync(userId)).ReturnsAsync((ApplicationUser)null); // User not found scenario

        // Act
        var result = await _authService.UploadUserAvatar(fileMock.Object, claimsPrincipal);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Equal("User does not exist", result.Message);
        Assert.Null(result.Result);

        // Verify interactions
        _userManagerRepositoryMock.Verify(r => r.FindByIdAsync(userId), Times.Once);
        _firebaseServiceMock.Verify(s => s.UploadImage(It.IsAny<IFormFile>(), It.IsAny<string>()), Times.Never); // Ensure UploadImage was not called
        _userManagerRepositoryMock.Verify(r => r.UpdateAsync(It.IsAny<ApplicationUser>()), Times.Never); // Ensure UpdateAsync was not called
    }

    [Fact]
    public async Task UploadUserAvatar_FirebaseUploadFails_ReturnsErrorResponse()
    {
        // Arrange
        var userId = "testUserId";
        var fileMock = new Mock<IFormFile>();
        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId)
            }));
        var user = new ApplicationUser { Id = userId };
        var uploadResponse = new ResponseDTO { IsSuccess = false, Message = "Image upload fail!" };

        _userManagerRepositoryMock.Setup(r => r.FindByIdAsync(userId)).ReturnsAsync(user);
        _firebaseServiceMock.Setup(s => s.UploadImage(fileMock.Object, StaticFirebaseFolders.UserAvatars)).ReturnsAsync(uploadResponse);

        // Act
        var result = await _authService.UploadUserAvatar(fileMock.Object, claimsPrincipal);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Equal("Image upload fail!", result.Message);
        Assert.Null(result.Result);

        // Verify interactions
        _userManagerRepositoryMock.Verify(r => r.FindByIdAsync(userId), Times.Once);
        _firebaseServiceMock.Verify(s => s.UploadImage(fileMock.Object, StaticFirebaseFolders.UserAvatars), Times.Once);
        _userManagerRepositoryMock.Verify(r => r.UpdateAsync(It.IsAny<ApplicationUser>()), Times.Never); // Ensure UpdateAsync was not called
    }

    [Fact]
    public async Task UploadUserAvatar_UpdateUserFails_ReturnsErrorResponse()
    {
        // Arrange
        var userId = "testUserId";
        var fileMock = new Mock<IFormFile>();
        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId)
            }));
        var user = new ApplicationUser { Id = userId };
        var uploadResponse = new ResponseDTO { IsSuccess = true, Result = "avatarUrl" };

        _userManagerRepositoryMock.Setup(r => r.FindByIdAsync(userId)).ReturnsAsync(user);
        _firebaseServiceMock.Setup(s => s.UploadImage(fileMock.Object, StaticFirebaseFolders.UserAvatars)).ReturnsAsync(uploadResponse);
        _userManagerRepositoryMock.Setup(r => r.UpdateAsync(user)).ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Update user avatar fail!" }));

        // Act
        var result = await _authService.UploadUserAvatar(fileMock.Object, claimsPrincipal);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Equal("Update user avatar fail!", result.Message);
        Assert.Null(result.Result);

        // Verify interactions
        _userManagerRepositoryMock.Verify(r => r.FindByIdAsync(userId), Times.Once);
        _firebaseServiceMock.Verify(s => s.UploadImage(fileMock.Object, StaticFirebaseFolders.UserAvatars), Times.Once);
        _userManagerRepositoryMock.Verify(r => r.UpdateAsync(user), Times.Once);
    }

    /// <summary>
    /// GetUserAvatar
    /// </summary>
    /// <returns></returns>

    [Fact]
    public async Task GetUserAvatar_UserExists_ReturnsMemoryStream()
    {
        // Arrange
        var userId = "testUserId";
        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
                new Claim(ClaimTypes.NameIdentifier, userId)
        }));
        var user = new ApplicationUser { Id = userId, AvatarUrl = "avatarUrl" };
        var streamMock = new MemoryStream();

        _userManagerRepositoryMock.Setup(r => r.FindByIdAsync(userId)).ReturnsAsync(user);
        _firebaseServiceMock.Setup(s => s.GetImage(user.AvatarUrl)).ReturnsAsync(streamMock);

        // Act
        var result = await _authService.GetUserAvatar(claimsPrincipal);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(streamMock, result);

        // Verify interactions
        _userManagerRepositoryMock.Verify(r => r.FindByIdAsync(userId), Times.Once);
        _firebaseServiceMock.Verify(s => s.GetImage(user.AvatarUrl), Times.Once);
    }

    [Fact]
    public async Task GetUserAvatar_UserDoesNotExist_ReturnsNull()
    {
        // Arrange
        var userId = "testUserId";
        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
                new Claim(ClaimTypes.NameIdentifier, userId)
        }));

        _userManagerRepositoryMock.Setup(r => r.FindByIdAsync(userId)).ReturnsAsync((ApplicationUser)null);

        // Act
        var result = await _authService.GetUserAvatar(claimsPrincipal);

        // Assert
        Assert.Null(result);

        // Verify interactions
        _userManagerRepositoryMock.Verify(r => r.FindByIdAsync(userId), Times.Once);
        _firebaseServiceMock.Verify(s => s.GetImage(It.IsAny<string>()), Times.Never); // Ensure GetImage was not called
    }

    [Fact]
    public async Task GetUserAvatar_AvatarImageNotFound_ReturnsNull()
    {
        // Arrange
        var userId = "testUserId";
        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
                new Claim(ClaimTypes.NameIdentifier, userId)
        }));
        var user = new ApplicationUser { Id = userId, AvatarUrl = "avatarUrl" };

        _userManagerRepositoryMock.Setup(r => r.FindByIdAsync(userId)).ReturnsAsync(user);
        _firebaseServiceMock.Setup(s => s.GetImage(user.AvatarUrl)).ReturnsAsync((MemoryStream)null);

        // Act
        var result = await _authService.GetUserAvatar(claimsPrincipal);

        // Assert
        Assert.Null(result);

        // Verify interactions
        _userManagerRepositoryMock.Verify(r => r.FindByIdAsync(userId), Times.Once);
        _firebaseServiceMock.Verify(s => s.GetImage(user.AvatarUrl), Times.Once);
    }
    /// <summary>
    /// SignIn
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task SignIn_UserExistsAndCorrectPassword_ReturnsSuccessfulResponse()
    {
        // Arrange
        var signDTO = new SignDTO { Email = "test@example.com", Password = "password" };
        var user = new ApplicationUser { Email = signDTO.Email, EmailConfirmed = true };
        var accessToken = "fakeAccessToken";
        var refreshToken = "fakeRefreshToken";

        _userManagerRepositoryMock.Setup(r => r.FindByEmailAsync(signDTO.Email)).ReturnsAsync(user);
        _userManagerRepositoryMock.Setup(r => r.CheckPasswordAsync(user, signDTO.Password)).ReturnsAsync(true);
        _tokenServiceMock.Setup(s => s.GenerateJwtAccessTokenAsync(user)).ReturnsAsync(accessToken);
        _tokenServiceMock.Setup(s => s.GenerateJwtRefreshTokenAsync(user)).ReturnsAsync(refreshToken);

        // Act
        var result = await _authService.SignIn(signDTO);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("Sign in successfully", result.Message);
        Assert.NotNull(result.Result);
        Assert.IsType<SignResponseDTO>(result.Result);
        Assert.Equal(accessToken, ((SignResponseDTO)result.Result).AccessToken);
        Assert.Equal(refreshToken, ((SignResponseDTO)result.Result).RefreshToken);

        // Verify interactions
        _userManagerRepositoryMock.Verify(r => r.FindByEmailAsync(signDTO.Email), Times.Once);
        _userManagerRepositoryMock.Verify(r => r.CheckPasswordAsync(user, signDTO.Password), Times.Once);
        _tokenServiceMock.Verify(s => s.GenerateJwtAccessTokenAsync(user), Times.Once);
        _tokenServiceMock.Verify(s => s.GenerateJwtRefreshTokenAsync(user), Times.Once);
        _tokenServiceMock.Verify(s => s.StoreRefreshToken(user.Id, refreshToken), Times.Once);
    }

    [Fact]
    public async Task SignIn_UserDoesNotExist_ReturnsErrorResponse()
    {
        // Arrange
        var signDTO = new SignDTO { Email = "nonexistent@example.com", Password = "password" };

        _userManagerRepositoryMock.Setup(r => r.FindByEmailAsync(signDTO.Email)).ReturnsAsync((ApplicationUser?)null);

        // Act
        var result = await _authService.SignIn(signDTO);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
        Assert.Equal("User does not exist!", result.Message);
        Assert.Null(result.Result);

        // Verify interactions
        _userManagerRepositoryMock.Verify(r => r.FindByEmailAsync(signDTO.Email), Times.Once);
        _userManagerRepositoryMock.Verify(r => r.CheckPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()), Times.Never);
        _tokenServiceMock.Verify(s => s.GenerateJwtAccessTokenAsync(It.IsAny<ApplicationUser>()), Times.Never);
        _tokenServiceMock.Verify(s => s.GenerateJwtRefreshTokenAsync(It.IsAny<ApplicationUser>()), Times.Never);
        _tokenServiceMock.Verify(s => s.StoreRefreshToken(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public async Task SignIn_IncorrectPassword_ReturnsErrorResponse()
    {
        // Arrange
        var signDTO = new SignDTO { Email = "test@example.com", Password = "wrongpassword" };
        var user = new ApplicationUser { Email = signDTO.Email, EmailConfirmed = true };

        _userManagerRepositoryMock.Setup(r => r.FindByEmailAsync(signDTO.Email)).ReturnsAsync(user);
        _userManagerRepositoryMock.Setup(r => r.CheckPasswordAsync(user, signDTO.Password)).ReturnsAsync(false);

        // Act
        var result = await _authService.SignIn(signDTO);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
        Assert.Equal("Incorrect email or password", result.Message);
        Assert.Null(result.Result);

        // Verify interactions
        _userManagerRepositoryMock.Verify(r => r.FindByEmailAsync(signDTO.Email), Times.Once);
        _userManagerRepositoryMock.Verify(r => r.CheckPasswordAsync(user, signDTO.Password), Times.Once);
        _tokenServiceMock.Verify(s => s.GenerateJwtAccessTokenAsync(It.IsAny<ApplicationUser>()), Times.Never);
        _tokenServiceMock.Verify(s => s.GenerateJwtRefreshTokenAsync(It.IsAny<ApplicationUser>()), Times.Never);
        _tokenServiceMock.Verify(s => s.StoreRefreshToken(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public async Task SignIn_UnconfirmedEmail_ReturnsErrorResponse()
    {
        // Arrange
        var signDTO = new SignDTO { Email = "test@example.com", Password = "password" };
        var user = new ApplicationUser { Email = signDTO.Email, EmailConfirmed = false };

        _userManagerRepositoryMock.Setup(r => r.FindByEmailAsync(signDTO.Email)).ReturnsAsync(user);

        // Act
        var result = await _authService.SignIn(signDTO);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(401, result.StatusCode);
        Assert.Equal("You need to confirm email!", result.Message);
        Assert.Null(result.Result);

        // Verify interactions
        _userManagerRepositoryMock.Verify(r => r.FindByEmailAsync(signDTO.Email), Times.Once);
        _userManagerRepositoryMock.Verify(r => r.CheckPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()), Times.Never);
        _tokenServiceMock.Verify(s => s.GenerateJwtAccessTokenAsync(It.IsAny<ApplicationUser>()), Times.Never);
        _tokenServiceMock.Verify(s => s.GenerateJwtRefreshTokenAsync(It.IsAny<ApplicationUser>()), Times.Never);
        _tokenServiceMock.Verify(s => s.StoreRefreshToken(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
    }
    /// <summary>
    /// Refresh
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task Refresh_ValidToken_ReturnsNewTokens()
    {
        // Arrange
        var userId = "validUserId";
        var token = "validToken";
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        }));
        var applicationUser = new ApplicationUser { Id = userId };
        var newAccessToken = "newAccessToken";
        var newRefreshToken = "newRefreshToken";

        _tokenServiceMock.Setup(ts => ts.GetPrincipalFromToken(token)).ReturnsAsync(user);
        _userManagerRepositoryMock.Setup(ur => ur.FindByIdAsync(userId)).ReturnsAsync(applicationUser);
        _tokenServiceMock.Setup(ts => ts.RetrieveRefreshToken(userId)).ReturnsAsync(token);
        _tokenServiceMock.Setup(ts => ts.GenerateJwtAccessTokenAsync(applicationUser)).ReturnsAsync(newAccessToken);
        _tokenServiceMock.Setup(ts => ts.GenerateJwtRefreshTokenAsync(applicationUser)).ReturnsAsync(newRefreshToken);

        // Act
        var result = await _authService.Refresh(token);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("Refresh Token Successfully!", result.Message);
        Assert.NotNull(result.Result);
        var jwtTokenDTO = Assert.IsType<JwtTokenDTO>(result.Result);
        Assert.Equal(newAccessToken, jwtTokenDTO.AccessToken);
        Assert.Equal(newRefreshToken, jwtTokenDTO.RefreshToken);
    }
    [Fact]
    public async Task Refresh_InvalidToken_ReturnsErrorResponse()
    {
        // Arrange
        var userId = "";
        var token = "invalidToken";
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        }));

        _tokenServiceMock.Setup(ts => ts.GetPrincipalFromToken(token)).ReturnsAsync(user);

        // Act
        var result = await _authService.Refresh(token);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
        Assert.Equal("Token is not valid", result.Message);
        Assert.Null(result.Result);
    }

    [Fact]
    public async Task Refresh_UserDoesNotExist_ReturnsErrorResponse()
    {
        // Arrange
        var userId = "nonExistentUserId";
        var token = "validToken";
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        }));

        _tokenServiceMock.Setup(ts => ts.GetPrincipalFromToken(token)).ReturnsAsync(user);
        _userManagerRepositoryMock.Setup(ur => ur.FindByIdAsync(userId)).ReturnsAsync((ApplicationUser)null);

        // Act
        var result = await _authService.Refresh(token);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
        Assert.Equal("User does not exist", result.Message);
        Assert.Null(result.Result);
    }

    [Fact]
    public async Task Refresh_TokenDoesNotMatchStoredToken_ReturnsErrorResponse()
    {
        // Arrange
        var userId = "validUserId";
        var token = "validToken";
        var storedToken = "differentToken";
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        }));
        var applicationUser = new ApplicationUser { Id = userId };

        _tokenServiceMock.Setup(ts => ts.GetPrincipalFromToken(token)).ReturnsAsync(user);
        _userManagerRepositoryMock.Setup(ur => ur.FindByIdAsync(userId)).ReturnsAsync(applicationUser);
        _tokenServiceMock.Setup(ts => ts.RetrieveRefreshToken(userId)).ReturnsAsync(storedToken);

        // Act
        var result = await _authService.Refresh(token);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
        Assert.Equal("Token is not valid", result.Message);
        Assert.Null(result.Result);
    }

    [Fact]
    public async Task Refresh_ThrowsException_ReturnsErrorResponse()
    {
        // Arrange
        var token = "validToken";
        _tokenServiceMock.Setup(ts => ts.GetPrincipalFromToken(token)).ThrowsAsync(new Exception("Unexpected error"));

        // Act
        var result = await _authService.Refresh(token);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Equal("Unexpected error", result.Message);
        Assert.Null(result.Result);
    }
    /// <summary>
    /// ForgetPassword
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task ForgotPassword_UserNotFound_ReturnsErrorResponse()
    {
        // Arrange
        var forgotPasswordDto = new ForgotPasswordDTO { EmailOrPhone = "test@example.com" };

        _userManagerRepositoryMock.Setup(r => r.FindByEmailAsync(forgotPasswordDto.EmailOrPhone)).ReturnsAsync((ApplicationUser)null);
        _userManagerRepositoryMock.Setup(r => r.FindByPhoneAsync(forgotPasswordDto.EmailOrPhone)).ReturnsAsync((ApplicationUser)null);

        // Act
        var result = await _authService.ForgotPassword(forgotPasswordDto);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
        Assert.Equal("No user found or account not activated.", result.Message);
    }
    [Fact]
    public async Task ForgotPassword_UserNotActivated_ReturnsErrorResponse()
    {
        // Arrange
        var forgotPasswordDto = new ForgotPasswordDTO { EmailOrPhone = "test@example.com" };
        var user = new ApplicationUser { Email = forgotPasswordDto.EmailOrPhone, EmailConfirmed = false };

        _userManagerRepositoryMock.Setup(r => r.FindByEmailAsync(forgotPasswordDto.EmailOrPhone)).ReturnsAsync(user);
        _userManagerRepositoryMock.Setup(r => r.FindByPhoneAsync(forgotPasswordDto.EmailOrPhone)).ReturnsAsync(user);

        // Act
        var result = await _authService.ForgotPassword(forgotPasswordDto);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
        Assert.Equal("No user found or account not activated.", result.Message);
    }
    [Fact]
    public async Task ForgotPassword_SuccessfulRequest_ReturnsSuccessResponse()
    {
        // Arrange
        var forgotPasswordDto = new ForgotPasswordDTO { EmailOrPhone = "test@example.com" };
        var user = new ApplicationUser { Email = forgotPasswordDto.EmailOrPhone, EmailConfirmed = true };
        var resetToken = "resetToken";

        _userManagerRepositoryMock.Setup(r => r.FindByEmailAsync(forgotPasswordDto.EmailOrPhone)).ReturnsAsync(user);
        _userManagerRepositoryMock.Setup(r => r.FindByPhoneAsync(forgotPasswordDto.EmailOrPhone)).ReturnsAsync(user);
        _userManagerRepositoryMock.Setup(r => r.GeneratePasswordResetTokenAsync(user)).ReturnsAsync(resetToken);

        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers["User-Agent"] = "TestUserAgent";
        _httpContextAccessorMock.Setup(x => x.HttpContext).Returns(httpContext);

        // Act
        var result = await _authService.ForgotPassword(forgotPasswordDto);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("The password reset link has been sent to your email.", result.Message);
    }
    /// <summary>
    /// ResetPassword
    /// </summary>
    /// <returns></returns>

    [Fact]
    public async Task ResetPassword_UserNotFound_ReturnsErrorResponse()
    {
        // Arrange
        string email = "test@example.com";
        string token = "resetToken";
        string newPassword = "newPassword";

        _userManagerRepositoryMock.Setup(r => r.FindByEmailAsync(email)).ReturnsAsync((ApplicationUser)null);

        // Act
        var result = await _authService.ResetPassword(email, token, newPassword);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
        Assert.Equal("User not found.", result.Message);
    }
    [Fact]
    public async Task ResetPassword_NewPasswordSameAsOldPassword_ReturnsErrorResponse()
    {
        // Arrange
        string email = "test@example.com";
        string token = "resetToken";
        string newPassword = "newPassword";
        var user = new ApplicationUser { Email = email };

        _userManagerRepositoryMock.Setup(r => r.FindByEmailAsync(email)).ReturnsAsync(user);
        _userManagerRepositoryMock.Setup(r => r.CheckPasswordAsync(user, newPassword)).ReturnsAsync(true);

        // Act
        var result = await _authService.ResetPassword(email, token, newPassword);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
        Assert.Equal("New password cannot be the same as the old password.", result.Message);
    }

    [Fact]
    public async Task ResetPassword_SuccessfulReset_ReturnsSuccessResponse()
    {
        // Arrange
        string email = "test@example.com";
        string token = "resetToken";
        string newPassword = "newPassword";
        var user = new ApplicationUser { Email = email };
        var identityResult = IdentityResult.Success;

        _userManagerRepositoryMock.Setup(r => r.FindByEmailAsync(email)).ReturnsAsync(user);
        _userManagerRepositoryMock.Setup(r => r.CheckPasswordAsync(user, newPassword)).ReturnsAsync(false);
        _userManagerRepositoryMock.Setup(r => r.ResetPasswordAsync(user, token, newPassword)).ReturnsAsync(identityResult);

        // Act
        var result = await _authService.ResetPassword(email, token, newPassword);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("Reset password successfully.", result.Message);
    }

    [Fact]
    public async Task ResetPassword_TokenValidationFails_ReturnsErrorResponse()
    {
        // Arrange
        string email = "test@example.com";
        string token = "resetToken";
        string newPassword = "newPassword";
        var user = new ApplicationUser { Email = email };
        var identityResult = IdentityResult.Failed(new IdentityError { Description = "Invalid token." });

        _userManagerRepositoryMock.Setup(r => r.FindByEmailAsync(email)).ReturnsAsync(user);
        _userManagerRepositoryMock.Setup(r => r.CheckPasswordAsync(user, newPassword)).ReturnsAsync(false);
        _userManagerRepositoryMock.Setup(r => r.ResetPasswordAsync(user, token, newPassword)).ReturnsAsync(identityResult);

        // Act
        var result = await _authService.ResetPassword(email, token, newPassword);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
        Assert.Contains("Invalid token.", result.Message);
    }
}
