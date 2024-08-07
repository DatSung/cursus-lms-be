using Moq;
using Xunit;
using Cursus.LMS.Service.Service;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.DataAccess.IRepository;
using Microsoft.Extensions.Configuration;  // Make sure this is included
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Cursus.LMS.Service.Hubs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using System.Linq.Expressions;

public class StudentServiceTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<IClosedXMLService> _mockClosedXmlService;
    private readonly Mock<IHubContext<NotificationHub>> _mockNotificationHub;
    private readonly Mock<IWebHostEnvironment> _mockEnv;
    private readonly Mock<IConfiguration> _mockConfig;
    private readonly StudentService _studentService;

    public StudentServiceTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockMapper = new Mock<IMapper>();
        _mockClosedXmlService = new Mock<IClosedXMLService>();
        _mockNotificationHub = new Mock<IHubContext<NotificationHub>>();
        _mockEnv = new Mock<IWebHostEnvironment>();
        _mockConfig = new Mock<IConfiguration>();

        _studentService = new StudentService(
            _mockUnitOfWork.Object,
            _mockMapper.Object,
            _mockClosedXmlService.Object,
            _mockNotificationHub.Object,
            _mockEnv.Object,
            _mockConfig.Object);
    }

    [Fact]
    public async Task GetById_ShouldReturnStudent_WhenStudentExists()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var userId = Guid.NewGuid().ToString(); // Convert Guid to string
        var student = new Student
        {
            StudentId = studentId,
            UserId = userId, // Assign string value here
            ApplicationUser = new ApplicationUser
            {
                AvatarUrl = "http://example.com/avatar.png",
                FullName = "John Doe",
                Email = "john.doe@example.com",
                Address = "123 Main St",
                BirthDate = new DateTime(2000, 1, 1),
                Country = "Country",
                Gender = "Male",
                PhoneNumber = "123-456-7890"
            },
            University = "Example University"
        };

        _mockUnitOfWork.Setup(u => u.StudentRepository.GetById(studentId))
                       .ReturnsAsync(student);

        // Act
        var result = await _studentService.GetById(studentId);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        var studentDto = result.Result as StudentFullInfoDTO;
        Assert.NotNull(studentDto);
        Assert.Equal(studentId, studentDto.StudentId);
        Assert.Equal("John Doe", studentDto.FullName);
        Assert.Equal("john.doe@example.com", studentDto.Email);
    }


    [Fact]
    public async Task GetById_ShouldReturnNotFound_WhenStudentDoesNotExist()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        _mockUnitOfWork.Setup(u => u.StudentRepository.GetById(studentId))
                       .ReturnsAsync((Student)null);

        // Act
        var result = await _studentService.GetById(studentId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
        Assert.Equal("Instructor was not found", result.Message);
    }

    [Fact]
    public async Task GetById_ShouldHandleException_WhenExceptionIsThrown()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        _mockUnitOfWork.Setup(u => u.StudentRepository.GetById(studentId))
                       .ThrowsAsync(new Exception("Database error"));

        // Act
        var result = await _studentService.GetById(studentId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Equal("Database error", result.Message);
    }
    [Fact]
    public async Task UpdateById_ShouldUpdateStudent_WhenStudentExists()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var updateStudentDTO = new UpdateStudentDTO
        {
            StudentId = studentId,
            FullName = "Jane Doe",
            University = "New University",
            Address = "456 Elm St",
            BirthDate = new DateTime(1995, 5, 15),
            Gender = "Female",
            Country = "New Country"
        };
        var student = new Student
        {
            StudentId = studentId,
            ApplicationUser = new ApplicationUser
            {
                FullName = "John Doe",
                Address = "123 Main St",
                BirthDate = new DateTime(2000, 1, 1),
                Gender = "Male",
                Country = "Country"
            },
            University = "Old University"
        };

        _mockUnitOfWork.Setup(u => u.StudentRepository.GetById(studentId))
            .ReturnsAsync(student);
        _mockUnitOfWork.Setup(u => u.StudentRepository.Update(student)).Verifiable();
        _mockUnitOfWork.Setup(u => u.SaveAsync()).ReturnsAsync(1);

        // Act
        var result = await _studentService.UpdateById(updateStudentDTO);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("Student updated successfully", result.Message);
        _mockUnitOfWork.Verify(u => u.StudentRepository.Update(student), Times.Once);
    }

    [Fact]
    public async Task UpdateById_ShouldReturnNotFound_WhenStudentDoesNotExist()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var updateStudentDTO = new UpdateStudentDTO { StudentId = studentId };

        _mockUnitOfWork.Setup(u => u.StudentRepository.GetById(studentId))
            .ReturnsAsync((Student)null);

        // Act
        var result = await _studentService.UpdateById(updateStudentDTO);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
        Assert.Equal("Student not found", result.Message);
    }

    [Fact]
    public async Task UpdateById_ShouldReturnBadRequest_WhenUpdateStudentDTOIsNull()
    {
        // Act
        var result = await _studentService.UpdateById(null);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
        Assert.Equal("Invalid request data", result.Message);
    }

    [Fact]
    public async Task UpdateById_ShouldHandleException()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var updateStudentDTO = new UpdateStudentDTO { StudentId = studentId };

        _mockUnitOfWork.Setup(u => u.StudentRepository.GetById(studentId))
            .ThrowsAsync(new Exception("Database error"));

        // Act
        var result = await _studentService.UpdateById(updateStudentDTO);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Equal("An error occurred while updating the student", result.Message);
    }

    [Fact]
    public async Task UpdateById_ShouldNotUpdate_WhenPartialDataIsProvided()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var updateStudentDTO = new UpdateStudentDTO
        {
            StudentId = studentId,
            FullName = "Partial Update"
        };
        var student = new Student
        {
            StudentId = studentId,
            ApplicationUser = new ApplicationUser
            {
                FullName = "Original Name",
                Address = "Original Address",
                BirthDate = new DateTime(2000, 1, 1),
                Gender = "Original Gender",
                Country = "Original Country"
            },
            University = "Original University"
        };

        _mockUnitOfWork.Setup(u => u.StudentRepository.GetById(studentId))
            .ReturnsAsync(student);
        _mockUnitOfWork.Setup(u => u.StudentRepository.Update(student)).Verifiable();
        _mockUnitOfWork.Setup(u => u.SaveAsync()).ReturnsAsync(1);

        // Act
        var result = await _studentService.UpdateById(updateStudentDTO);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("Student updated successfully", result.Message);
        Assert.Equal("Partial Update", student.ApplicationUser.FullName);
        Assert.Equal("Original Address", student.ApplicationUser.Address); // Unchanged
    }

    [Fact]
    public async Task UpdateById_ShouldHandleInvalidData()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var updateStudentDTO = new UpdateStudentDTO
        {
            StudentId = studentId,
            FullName = new string('A', 1000) // Invalid long name
        };
        var student = new Student
        {
            StudentId = studentId,
            ApplicationUser = new ApplicationUser
            {
                FullName = "Original Name",
                Address = "Original Address",
                BirthDate = new DateTime(2000, 1, 1),
                Gender = "Original Gender",
                Country = "Original Country"
            },
            University = "Original University"
        };

        _mockUnitOfWork.Setup(u => u.StudentRepository.GetById(studentId))
            .ReturnsAsync(student);
        _mockUnitOfWork.Setup(u => u.StudentRepository.Update(student)).Verifiable();
        _mockUnitOfWork.Setup(u => u.SaveAsync()).ReturnsAsync(1);

        // Act
        var result = await _studentService.UpdateById(updateStudentDTO);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode); // Expect failure due to invalid data handling
    }
    private ClaimsPrincipal CreateUserClaimsPrincipal(string userId)
    {
        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId)
            };
        var identity = new ClaimsIdentity(claims, "TestAuthType");
        return new ClaimsPrincipal(identity);
    }

    [Fact]
    public async Task ActivateStudent_ShouldActivateStudent_WhenStudentExists()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var userId = Guid.NewGuid().ToString();
        var student = new Student
        {
            StudentId = studentId,
            ApplicationUser = new ApplicationUser
            {
                LockoutEnabled = false,
                LockoutEnd = null
            }
        };

        var user = CreateUserClaimsPrincipal(userId);

        _mockUnitOfWork.Setup(u => u.StudentRepository.GetById(studentId))
            .ReturnsAsync(student);
        _mockUnitOfWork.Setup(u => u.SaveAsync()).ReturnsAsync(1);

        // Act
        var result = await _studentService.ActivateStudent(user, studentId);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("Active student successfully", result.Message);
        Assert.True(student.ApplicationUser.LockoutEnabled);
        Assert.NotNull(student.ApplicationUser.LockoutEnd);
        _mockUnitOfWork.Verify(u => u.SaveAsync(), Times.Once);
    }

    [Fact]
    public async Task ActivateStudent_ShouldReturnNotFound_WhenStudentDoesNotExist()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var user = CreateUserClaimsPrincipal(Guid.NewGuid().ToString());

        _mockUnitOfWork.Setup(u => u.StudentRepository.GetById(studentId))
            .ReturnsAsync((Student)null);

        // Act
        var result = await _studentService.ActivateStudent(user, studentId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
        Assert.Equal("Student was not found", result.Message);
    }

    [Fact]
    public async Task ActivateStudent_ShouldHandleInvalidUserClaims()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var claims = new List<Claim>(); // No user id claim
        var identity = new ClaimsIdentity(claims, "TestAuthType");
        var user = new ClaimsPrincipal(identity);

        // Act
        var result = await _studentService.ActivateStudent(user, studentId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
        Assert.Equal("Invalid user claims", result.Message);
    }

    [Fact]
    public async Task ActivateStudent_ShouldNotChangeLockout_WhenStudentIsAlreadyActive()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var userId = Guid.NewGuid().ToString();
        var student = new Student
        {
            StudentId = studentId,
            ApplicationUser = new ApplicationUser
            {
                LockoutEnabled = true,
                LockoutEnd = DateTime.UtcNow
            }
        };

        var user = CreateUserClaimsPrincipal(userId);

        _mockUnitOfWork.Setup(u => u.StudentRepository.GetById(studentId))
            .ReturnsAsync(student);
        _mockUnitOfWork.Setup(u => u.SaveAsync()).ReturnsAsync(1);

        // Act
        var result = await _studentService.ActivateStudent(user, studentId);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("Active student successfully", result.Message);
        Assert.True(student.ApplicationUser.LockoutEnabled); // Still true
        Assert.NotNull(student.ApplicationUser.LockoutEnd); // Still not null
        _mockUnitOfWork.Verify(u => u.SaveAsync(), Times.Once);
    }

    [Fact]
    public async Task ActivateStudent_ShouldHandleException()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var userId = Guid.NewGuid().ToString();
        var user = CreateUserClaimsPrincipal(userId);

        _mockUnitOfWork.Setup(u => u.StudentRepository.GetById(studentId))
            .ThrowsAsync(new Exception("Database error"));

        // Act
        var result = await _studentService.ActivateStudent(user, studentId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Equal("Database error", result.Message);
    }

    [Fact]
    public async Task ActivateStudent_ShouldLockStudent_WhenStudentIsLocked()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var userId = Guid.NewGuid().ToString();
        var student = new Student
        {
            StudentId = studentId,
            ApplicationUser = new ApplicationUser
            {
                LockoutEnabled = false,
                LockoutEnd = DateTime.UtcNow.AddDays(1)
            }
        };

        var user = CreateUserClaimsPrincipal(userId);

        _mockUnitOfWork.Setup(u => u.StudentRepository.GetById(studentId))
            .ReturnsAsync(student);
        _mockUnitOfWork.Setup(u => u.SaveAsync()).ReturnsAsync(1);

        // Act
        var result = await _studentService.ActivateStudent(user, studentId);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("Active student successfully", result.Message);
        Assert.True(student.ApplicationUser.LockoutEnabled);
        Assert.NotNull(student.ApplicationUser.LockoutEnd);
        _mockUnitOfWork.Verify(u => u.SaveAsync(), Times.Once);
    }
    [Fact]
    public async Task DeactivateStudent_ShouldReturnSuccess_WhenStudentExists()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var userId = Guid.NewGuid().ToString();
        var userClaims = CreateUserClaimsPrincipal(userId);
        var student = new Student
        {
            StudentId = studentId,
            ApplicationUser = new ApplicationUser
            {
                LockoutEnabled = true
            }
        };

        _mockUnitOfWork.Setup(u => u.StudentRepository.GetById(studentId))
            .ReturnsAsync(student);
        _mockUnitOfWork.Setup(u => u.SaveAsync())
            .ReturnsAsync(1);

        // Act
        var result = await _studentService.DeactivateStudent(userClaims, studentId);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("Reject instructor successfully", result.Message);
    }

    [Fact]
    public async Task DeactivateStudent_ShouldReturnNotFound_WhenStudentDoesNotExist()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var userId = Guid.NewGuid().ToString();
        var userClaims = CreateUserClaimsPrincipal(userId);

        _mockUnitOfWork.Setup(u => u.StudentRepository.GetById(studentId))
            .ReturnsAsync((Student)null);

        // Act
        var result = await _studentService.DeactivateStudent(userClaims, studentId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
        Assert.Equal("Student was not found", result.Message);
    }

    [Fact]
    public async Task DeactivateStudent_ShouldReturnInternalServerError_WhenExceptionIsThrown()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var userId = Guid.NewGuid().ToString();
        var userClaims = CreateUserClaimsPrincipal(userId);

        _mockUnitOfWork.Setup(u => u.StudentRepository.GetById(studentId))
            .ThrowsAsync(new Exception("Database error"));

        // Act
        var result = await _studentService.DeactivateStudent(userClaims, studentId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Equal("Database error", result.Message);
    }

    [Fact]
    public async Task DeactivateStudent_ShouldReturnSuccess_WhenStudentIsAlreadyInactive()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var userId = Guid.NewGuid().ToString();
        var userClaims = CreateUserClaimsPrincipal(userId);
        var student = new Student
        {
            StudentId = studentId,
            ApplicationUser = new ApplicationUser
            {
                LockoutEnabled = false
            }
        };

        _mockUnitOfWork.Setup(u => u.StudentRepository.GetById(studentId))
            .ReturnsAsync(student);
        _mockUnitOfWork.Setup(u => u.SaveAsync())
            .ReturnsAsync(1);

        // Act
        var result = await _studentService.DeactivateStudent(userClaims, studentId);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("Reject instructor successfully", result.Message);
    }

    [Fact]
    public async Task DeactivateStudent_ShouldReturnInvalidUser_WhenUserClaimsAreInvalid()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var userClaims = new ClaimsPrincipal();

        // Act
        var result = await _studentService.DeactivateStudent(userClaims, studentId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
    }

    [Fact]
    public async Task DeactivateStudent_ShouldLockStudent_WhenLockoutIsDisabled()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var userId = Guid.NewGuid().ToString();
        var userClaims = CreateUserClaimsPrincipal(userId);
        var student = new Student
        {
            StudentId = studentId,
            ApplicationUser = new ApplicationUser
            {
                LockoutEnabled = true
            }
        };

        _mockUnitOfWork.Setup(u => u.StudentRepository.GetById(studentId))
            .ReturnsAsync(student);
        _mockUnitOfWork.Setup(u => u.SaveAsync())
            .ReturnsAsync(1);

        // Act
        var result = await _studentService.DeactivateStudent(userClaims, studentId);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("Reject instructor successfully", result.Message);
        Assert.False(student.ApplicationUser.LockoutEnabled);
    }

    [Fact]
    public async Task GetStudentTotalCourses_ShouldReturnTotalCourses_WhenStudentExists()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var courses = new List<StudentCourseStatus>
            {
                new StudentCourseStatus { Id = studentId, Status = 0 },
                new StudentCourseStatus { Id = studentId, Status = 1 },
                new StudentCourseStatus { Id = studentId, Status = 1 },
                new StudentCourseStatus { Id = studentId, Status = 3 },
                new StudentCourseStatus { Id = studentId, Status = 4 }
            };

        _mockUnitOfWork.Setup(u => u.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), It.IsAny<string>()))
            .ReturnsAsync(new Student { StudentId = studentId });
        _mockUnitOfWork.Setup(u => u.StudentCourseStatusRepository.GetAllAsync(It.IsAny<Expression<Func<StudentCourseStatus, bool>>>(), It.IsAny<string>()))
            .ReturnsAsync(courses.AsQueryable());

        // Act
        var result = await _studentService.GetStudentTotalCourses(studentId);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("Get Course Successful", result.Message);
        var totalCountDTO = result.Result as StudentTotalCountDTO;
        Assert.NotNull(totalCountDTO);
        Assert.Equal(5, totalCountDTO.Total);
        Assert.Equal(1, totalCountDTO.Pending);
        Assert.Equal(2, totalCountDTO.Enrolled);
        Assert.Equal(1, totalCountDTO.Completed);
        Assert.Equal(1, totalCountDTO.Canceled);
    }

    [Fact]
    public async Task GetStudentTotalCourses_ShouldReturnStudentIdInvalid_WhenStudentDoesNotExist()
    {
        // Arrange
        var studentId = Guid.NewGuid();

        _mockUnitOfWork.Setup(u => u.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), It.IsAny<string>()))
            .ReturnsAsync((Student)null);

        // Act
        var result = await _studentService.GetStudentTotalCourses(studentId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
        Assert.Equal("StudentId Invalid", result.Message);
    }

    [Fact]
    public async Task GetStudentTotalCourses_ShouldReturnInternalServerError_WhenExceptionIsThrown()
    {
        // Arrange
        var studentId = Guid.NewGuid();

        _mockUnitOfWork.Setup(u => u.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), It.IsAny<string>()))
            .ThrowsAsync(new Exception("Database error"));

        // Act
        var result = await _studentService.GetStudentTotalCourses(studentId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Equal("Database error", result.Message);
    }

    [Fact]
    public async Task GetStudentTotalCourses_ShouldReturnZeroCounts_WhenNoCoursesFound()
    {
        // Arrange
        var studentId = Guid.NewGuid();

        _mockUnitOfWork.Setup(u => u.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), It.IsAny<string>()))
            .ReturnsAsync(new Student { StudentId = studentId });
        _mockUnitOfWork.Setup(u => u.StudentCourseStatusRepository.GetAllAsync(It.IsAny<Expression<Func<StudentCourseStatus, bool>>>(), It.IsAny<string>()))
            .ReturnsAsync(new List<StudentCourseStatus>().AsQueryable());

        // Act
        var result = await _studentService.GetStudentTotalCourses(studentId);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("Get Course Successful", result.Message);
        var totalCountDTO = result.Result as StudentTotalCountDTO;
        Assert.NotNull(totalCountDTO);
        Assert.Equal(0, totalCountDTO.Total);
        Assert.Equal(0, totalCountDTO.Pending);
        Assert.Equal(0, totalCountDTO.Enrolled);
        Assert.Equal(0, totalCountDTO.Completed);
        Assert.Equal(0, totalCountDTO.Canceled);
    }
}
