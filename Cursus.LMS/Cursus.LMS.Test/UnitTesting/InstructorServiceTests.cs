using Moq;
using Xunit;
using Cursus.LMS.Service.Service;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.DataAccess.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cursus.LMS.Service.Hubs;
using System.Linq.Expressions;

public class InstructorServiceTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<IClosedXMLService> _mockClosedXmlService;
    private readonly Mock<IWebHostEnvironment> _mockEnv;
    private readonly Mock<IConfiguration> _mockConfig;
    private readonly Mock<IHubContext<NotificationHub>> _mockNotificationHub;
    private readonly InstructorService _instructorService;
    private readonly Mock<IUserManagerRepository> _mockUserManagerRepository;

    public InstructorServiceTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockMapper = new Mock<IMapper>();
        _mockClosedXmlService = new Mock<IClosedXMLService>();
        _mockEnv = new Mock<IWebHostEnvironment>();
        _mockConfig = new Mock<IConfiguration>();
        _mockNotificationHub = new Mock<IHubContext<NotificationHub>>();
        _mockUserManagerRepository = new Mock<IUserManagerRepository>();

        _instructorService = new InstructorService(
            _mockUnitOfWork.Object,
            _mockMapper.Object,
            _mockClosedXmlService.Object,
            _mockEnv.Object,
            _mockConfig.Object,
            _mockNotificationHub.Object);

    }

    [Fact]
    public async Task GetById_ShouldReturnInstructorInfo_WhenInstructorExists()
    {
        // Arrange
        var instructorId = Guid.NewGuid();
        var instructor = new Instructor
        {
            InstructorId = instructorId,
            UserId = "id",
            ApplicationUser = new ApplicationUser
            {
                Id = "id",
                AvatarUrl = "http://example.com/avatar.jpg",
                FullName = "John Doe",
                Email = "john.doe@example.com",
                Address = "123 Main St",
                PhoneNumber = "1234567890",
                Gender = "Male",
                BirthDate = new DateTime(1980, 1, 1),
                Country = "CountryName",
                TaxNumber = "123456789"
            },
            Degree = "PhD",
            Industry = "Education",
            Introduction = "An experienced instructor",
            IsAccepted = true
        };

        _mockUnitOfWork.Setup(u => u.InstructorRepository.GetById(instructorId))
                       .ReturnsAsync(instructor);

        // Act
        var result = await _instructorService.GetById(instructorId);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.NotNull(result.Result);
        var instructorDto = Assert.IsType<InstructorInfoDTO>(result.Result);
        Assert.Equal(instructorId, instructorDto.InstructorId);
        Assert.Equal("John Doe", instructorDto.FullName);
    }

    [Fact]
    public async Task GetById_ShouldReturnNotFound_WhenInstructorDoesNotExist()
    {
        // Arrange
        var instructorId = Guid.NewGuid();
        _mockUnitOfWork.Setup(u => u.InstructorRepository.GetById(instructorId))
                       .ReturnsAsync((Instructor)null);

        // Act
        var result = await _instructorService.GetById(instructorId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
        Assert.Null(result.Result);
    }

    [Fact]
    public async Task GetById_ShouldHandleException_WhenExceptionIsThrown()
    {
        // Arrange
        var instructorId = Guid.NewGuid();
        _mockUnitOfWork.Setup(u => u.InstructorRepository.GetById(instructorId))
                       .ThrowsAsync(new Exception("Database error"));

        // Act
        var result = await _instructorService.GetById(instructorId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Null(result.Result);
    }

    [Fact]
    public async Task UpdateById_ShouldUpdateInstructorSuccessfully_WhenValidDataIsProvided()
    {
        // Arrange
        var instructorId = Guid.NewGuid();
        var updateInstructorDto = new UpdateInstructorDTO
        {
            InstructorId = instructorId,
            Degree = "Updated Degree",
            Industry = "Updated Industry",
            Introduction = "Updated Introduction",
            Address = "New Address",
            BirthDate = new DateTime(1990, 1, 1),
            PhoneNumber = "9876543210",
            Gender = "Female",
            FullName = "Jane Doe",
            Country = "Updated Country",
            Email = "jane.doe@example.com",
            TaxNumber = "987654321"
        };

        var instructor = new Instructor
        {
            InstructorId = instructorId,
            ApplicationUser = new ApplicationUser
            {
                Address = "Old Address",
                BirthDate = new DateTime(1980, 1, 1),
                PhoneNumber = "1234567890",
                Gender = "Male",
                FullName = "John Doe",
                Country = "Old Country",
                Email = "john.doe@example.com",
                TaxNumber = "123456789"
            }
        };

        _mockUnitOfWork.Setup(u => u.InstructorRepository.GetById(instructorId))
                       .ReturnsAsync(instructor);
        _mockUnitOfWork.Setup(u => u.InstructorRepository.Update(instructor))
                       .Verifiable();
        _mockUnitOfWork.Setup(u => u.SaveAsync())
                       .ReturnsAsync(1);

        // Act
        var result = await _instructorService.UpdateById(updateInstructorDto);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        _mockUnitOfWork.Verify(u => u.InstructorRepository.Update(instructor), Times.Once);
    }

    [Fact]
    public async Task UpdateById_ShouldReturnNotFound_WhenInstructorDoesNotExist()
    {
        // Arrange
        var updateInstructorDto = new UpdateInstructorDTO
        {
            InstructorId = Guid.NewGuid()
        };

        _mockUnitOfWork.Setup(u => u.InstructorRepository.GetById(updateInstructorDto.InstructorId))
                       .ReturnsAsync((Instructor)null);

        // Act
        var result = await _instructorService.UpdateById(updateInstructorDto);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
    }

    [Fact]
    public async Task UpdateById_ShouldReturnBadRequest_WhenSaveFails()
    {
        // Arrange
        var instructorId = Guid.NewGuid();
        var updateInstructorDto = new UpdateInstructorDTO
        {
            InstructorId = instructorId
        };

        var instructor = new Instructor { InstructorId = instructorId };

        _mockUnitOfWork.Setup(u => u.InstructorRepository.GetById(instructorId))
                       .ReturnsAsync(instructor);
        _mockUnitOfWork.Setup(u => u.InstructorRepository.Update(instructor))
                       .Verifiable();
        _mockUnitOfWork.Setup(u => u.SaveAsync())
                       .ReturnsAsync(0);

        // Act
        var result = await _instructorService.UpdateById(updateInstructorDto);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
    }

    [Fact]
    public async Task UpdateById_ShouldHandleException_WhenExceptionIsThrown()
    {
        // Arrange
        var instructorId = Guid.NewGuid();
        var updateInstructorDto = new UpdateInstructorDTO
        {
            InstructorId = instructorId
        };

        _mockUnitOfWork.Setup(u => u.InstructorRepository.GetById(instructorId))
                       .ThrowsAsync(new Exception("Database error"));

        // Act
        var result = await _instructorService.UpdateById(updateInstructorDto);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
    }

    [Fact]
    public async Task UpdateById_ShouldUpdateOnlyProvidedFields()
    {
        // Arrange
        var instructorId = Guid.NewGuid();
        var updateInstructorDto = new UpdateInstructorDTO
        {
            InstructorId = instructorId,
            Degree = "Updated Degree"
        };

        var instructor = new Instructor
        {
            InstructorId = instructorId,
            Degree = "Old Degree",
            Industry = "Old Industry",
            Introduction = "Old Introduction",
            ApplicationUser = new ApplicationUser
            {
                Address = "Old Address",
                BirthDate = new DateTime(1980, 1, 1),
                PhoneNumber = "1234567890",
                Gender = "Male",
                FullName = "John Doe",
                Country = "Old Country",
                Email = "john.doe@example.com",
                TaxNumber = "123456789"
            }
        };

        _mockUnitOfWork.Setup(u => u.InstructorRepository.GetById(instructorId))
                       .ReturnsAsync(instructor);
        _mockUnitOfWork.Setup(u => u.InstructorRepository.Update(instructor))
                       .Verifiable();
        _mockUnitOfWork.Setup(u => u.SaveAsync())
                       .ReturnsAsync(1);

        // Act
        var result = await _instructorService.UpdateById(updateInstructorDto);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("Updated Degree", instructor.Degree);
        Assert.Equal("Old Industry", instructor.Industry); // Ensure unchanged fields remain the same
        Assert.Equal("Old Introduction", instructor.Introduction);
    }

    [Fact]
    public async Task UpdateById_ShouldHandleNullInputGracefully()
    {
        // Arrange
        UpdateInstructorDTO updateInstructorDto = null;

        // Act
        var result = await _instructorService.UpdateById(updateInstructorDto);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode); // Assuming null input is treated as a bad request
    }
    [Fact]
    public async Task AcceptInstructor_ShouldAcceptInstructorSuccessfully_WhenValidIdIsProvided()
    {
        // Arrange
        var instructorId = Guid.NewGuid();
        var userId = "user-123";

        var instructor = new Instructor
        {
            InstructorId = instructorId,
            IsAccepted = false
        };

        var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        }));

        _mockUnitOfWork.Setup(u => u.InstructorRepository.GetById(instructorId))
                       .ReturnsAsync(instructor);
        _mockUnitOfWork.Setup(u => u.SaveAsync())
                       .ReturnsAsync(1);

        // Act
        var result = await _instructorService.AcceptInstructor(userClaims, instructorId);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(true, instructor.IsAccepted);
        Assert.Equal(userId, instructor.AcceptedBy);
        Assert.NotNull(instructor.AcceptedTime);
    }

    [Fact]
    public async Task AcceptInstructor_ShouldReturnNotFound_WhenInstructorDoesNotExist()
    {
        // Arrange
        var instructorId = Guid.NewGuid();
        var userClaims = new ClaimsPrincipal(new ClaimsIdentity());

        _mockUnitOfWork.Setup(u => u.InstructorRepository.GetById(instructorId))
                       .ReturnsAsync((Instructor)null);

        // Act
        var result = await _instructorService.AcceptInstructor(userClaims, instructorId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
        Assert.Equal("Instructor was not found", result.Message);
    }

    [Fact]
    public async Task AcceptInstructor_ShouldHandleException_WhenExceptionIsThrown()
    {
        // Arrange
        var instructorId = Guid.NewGuid();
        var userClaims = new ClaimsPrincipal(new ClaimsIdentity());

        _mockUnitOfWork.Setup(u => u.InstructorRepository.GetById(instructorId))
                       .ThrowsAsync(new Exception("Database error"));

        // Act
        var result = await _instructorService.AcceptInstructor(userClaims, instructorId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Equal("Database error", result.Message);
    }
    [Fact]
    public async Task RejectInstructor_ShouldRejectInstructorSuccessfully_WhenValidIdIsProvided()
    {
        // Arrange
        var instructorId = Guid.NewGuid();
        var userId = "user-123";

        var instructor = new Instructor
        {
            InstructorId = instructorId,
            IsAccepted = true
        };

        var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        }));

        _mockUnitOfWork.Setup(u => u.InstructorRepository.GetById(instructorId))
                       .ReturnsAsync(instructor);
        _mockUnitOfWork.Setup(u => u.SaveAsync())
                       .ReturnsAsync(1);

        // Act
        var result = await _instructorService.RejectInstructor(userClaims, instructorId);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.False(instructor.IsAccepted);
        Assert.Equal(userId, instructor.RejectedBy);
        Assert.NotNull(instructor.RejectedTime);
    }

    [Fact]
    public async Task RejectInstructor_ShouldReturnNotFound_WhenInstructorDoesNotExist()
    {
        // Arrange
        var instructorId = Guid.NewGuid();
        var userClaims = new ClaimsPrincipal(new ClaimsIdentity());

        _mockUnitOfWork.Setup(u => u.InstructorRepository.GetById(instructorId))
                       .ReturnsAsync((Instructor)null);

        // Act
        var result = await _instructorService.RejectInstructor(userClaims, instructorId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
        Assert.Equal("Instructor was not found", result.Message);
    }

    [Fact]
    public async Task RejectInstructor_ShouldHandleException_WhenExceptionIsThrown()
    {
        // Arrange
        var instructorId = Guid.NewGuid();
        var userClaims = new ClaimsPrincipal(new ClaimsIdentity());

        _mockUnitOfWork.Setup(u => u.InstructorRepository.GetById(instructorId))
                       .ThrowsAsync(new Exception("Database error"));

        // Act
        var result = await _instructorService.RejectInstructor(userClaims, instructorId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Equal("Database error", result.Message);
    }
    [Fact]
    public async Task GetInstructorTotalCourses_ShouldReturnTotalCourses_WhenValidIdIsProvided()
    {
        // Arrange
        var instructorId = Guid.NewGuid();
        var instructor = new Instructor { InstructorId = instructorId };
        var courses = new List<Course>
        {
            new Course { Status = 0, InstructorId = instructorId },
            new Course { Status = 1, InstructorId = instructorId },
            new Course { Status = 1, InstructorId = instructorId },
            new Course { Status = 2, InstructorId = instructorId },
            new Course { Status = 3, InstructorId = instructorId }
        };

        _mockUnitOfWork.Setup(u => u.InstructorRepository.GetAsync(It.IsAny<Expression<Func<Instructor, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(instructor);
        _mockUnitOfWork.Setup(u => u.CourseRepository.GetAllAsync(It.IsAny<Expression<Func<Course, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(courses);

        // Act
        var result = await _instructorService.GetInstructorTotalCourses(instructorId);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        var data = (InstructorTotalCount)result.Result;
        Assert.Equal(5, data.Total);
        Assert.Equal(1, data.Pending);
        Assert.Equal(2, data.Activated);
        Assert.Equal(1, data.Rejected);
        Assert.Equal(1, data.Deleted);
    }

    [Fact]
    public async Task GetInstructorTotalCourses_ShouldReturnBadRequest_WhenInstructorIdIsInvalid()
    {
        // Arrange
        var instructorId = Guid.NewGuid();
        _mockUnitOfWork.Setup(u => u.InstructorRepository.GetAsync(It.IsAny<Expression<Func<Instructor, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync((Instructor)null);

        // Act
        var result = await _instructorService.GetInstructorTotalCourses(instructorId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
        Assert.Equal("InstructorId Invalid", result.Message);
    }

    [Fact]
    public async Task GetInstructorTotalCourses_ShouldHandleException_WhenExceptionIsThrown()
    {
        // Arrange
        var instructorId = Guid.NewGuid();
        _mockUnitOfWork.Setup(u => u.InstructorRepository.GetAsync(It.IsAny<Expression<Func<Instructor, bool>>>(), It.IsAny<string>()))
                       .ThrowsAsync(new Exception("Database error"));

        // Act
        var result = await _instructorService.GetInstructorTotalCourses(instructorId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Equal("Database error", result.Message);
    }
    [Fact]
    public async Task GetInstructorTotalRating_ShouldReturnCorrectCounts_WhenRatingsExist()
    {
        // Arrange
        var instructorId = Guid.NewGuid();
        var instructorRatings = new List<InstructorRating>
        {
            new InstructorRating { Rate = 1, InstructorId = instructorId },
            new InstructorRating { Rate = 2, InstructorId = instructorId },
            new InstructorRating { Rate = 3, InstructorId = instructorId },
            new InstructorRating { Rate = 4, InstructorId = instructorId },
            new InstructorRating { Rate = 5, InstructorId = instructorId },
            new InstructorRating { Rate = 1, InstructorId = instructorId },
            new InstructorRating { Rate = 2, InstructorId = instructorId },
        };

        _mockUnitOfWork.Setup(u => u.InstructorRatingRepository.GetAllAsync(It.IsAny<Expression<Func<InstructorRating, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(instructorRatings);

        // Act
        var result = await _instructorService.GetInstructorTotalRating(instructorId);

        // Assert
        var resultData = (InstructorAvgCount)result.Result;
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(2, resultData.One);
        Assert.Equal(2, resultData.Two);
        Assert.Equal(1, resultData.Three);
        Assert.Equal(1, resultData.Four);
        Assert.Equal(1, resultData.Five);
    }

    [Fact]
    public async Task GetInstructorTotalRating_ShouldReturnNoRatingsFound_WhenNoRatingsExist()
    {
        // Arrange
        var instructorId = Guid.NewGuid();

        _mockUnitOfWork.Setup(u => u.InstructorRatingRepository.GetAllAsync(It.IsAny<Expression<Func<InstructorRating, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(new List<InstructorRating>());

        // Act
        var result = await _instructorService.GetInstructorTotalRating(instructorId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
        Assert.Equal("No ratings found for this instructor.", result.Message);
    }

    [Fact]
    public async Task GetInstructorTotalRating_ShouldHandleException_WhenExceptionIsThrown()
    {
        // Arrange
        var instructorId = Guid.NewGuid();
        _mockUnitOfWork.Setup(u => u.InstructorRatingRepository.GetAllAsync(It.IsAny<Expression<Func<InstructorRating, bool>>>(), It.IsAny<string>()))
                       .ThrowsAsync(new Exception("Database error"));

        // Act
        var result = await _instructorService.GetInstructorTotalRating(instructorId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Equal("Database error", result.Message);
    }
    [Fact]
    public async Task GetAllInstructorComment_ShouldReturnPagedComments_WhenCommentsExist()
    {
        // Arrange
        var instructorId = Guid.NewGuid();
        var comments = new List<InstructorComment>
        {
            new InstructorComment { InstructorId = instructorId, Status = 1, CreatedTime = DateTime.UtcNow },
            new InstructorComment { InstructorId = instructorId, Status = 1, CreatedTime = DateTime.UtcNow.AddDays(-1) }
        };

        var commentsDto = new List<GetAllCommentsDTO>
        {
            new GetAllCommentsDTO { /* map properties here */ },
            new GetAllCommentsDTO { /* map properties here */ }
        };

        _mockUnitOfWork.Setup(u => u.InstructorCommentRepository.GetAllAsync(It.IsAny<Expression<Func<InstructorComment, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(comments);
        _mockMapper.Setup(m => m.Map<List<GetAllCommentsDTO>>(It.IsAny<List<InstructorComment>>()))
                   .Returns(commentsDto);

        // Act
        var result = await _instructorService.GetAllInstructorComment(instructorId, 1, 1);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(1, ((List<GetAllCommentsDTO>)result.Result).Count); // Check if pagination worked
    }

    [Fact]
    public async Task GetAllInstructorComment_ShouldReturnNoContent_WhenNoCommentsExist()
    {
        // Arrange
        var instructorId = Guid.NewGuid();

        _mockUnitOfWork.Setup(u => u.InstructorCommentRepository.GetAllAsync(It.IsAny<Expression<Func<InstructorComment, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(new List<InstructorComment>());

        // Act
        var result = await _instructorService.GetAllInstructorComment(instructorId, 1, 1);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(204, result.StatusCode);
        Assert.Null(result.Result);
    }

    [Fact]
    public async Task GetAllInstructorComment_ShouldHandleException_WhenExceptionIsThrown()
    {
        // Arrange
        var instructorId = Guid.NewGuid();
        _mockUnitOfWork.Setup(u => u.InstructorCommentRepository.GetAllAsync(It.IsAny<Expression<Func<InstructorComment, bool>>>(), It.IsAny<string>()))
                       .ThrowsAsync(new Exception("Database error"));

        // Act
        var result = await _instructorService.GetAllInstructorComment(instructorId, 1, 1);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Equal("Database error", result.Message);
    }
    [Fact]
    public async Task CreateInstructorComment_ShouldReturnSuccess_WhenValidDataIsProvided()
    {
        // Arrange
        var instructorId = Guid.NewGuid();
        var userId = "user-id";
        var adminEmail = "admin@example.com";

        var createInstructorCommentDto = new CreateInstructorCommentDTO
        {
            Comment = "Great instructor!",
            instructorId = instructorId
        };

        var instructor = new Instructor
        {
            InstructorId = instructorId
        };

        var admin = new ApplicationUser
        {
            Email = adminEmail
        };

        _mockUnitOfWork.Setup(u => u.InstructorRepository.GetAsync(It.IsAny<Expression<Func<Instructor, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(instructor);
        _mockUserManagerRepository.Setup(um => um.FindByIdAsync(userId))
                        .ReturnsAsync(admin);

        // Act
        var result = await _instructorService.CreateInstructorComment(
            new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })),
            createInstructorCommentDto
        );

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("Comment created successfully", result.Message);
        var comment = (InstructorComment)result.Result;
        Assert.Equal(createInstructorCommentDto.Comment, comment.Comment);
        Assert.Equal(instructorId, comment.InstructorId);
        Assert.Equal(adminEmail, comment.CreatedBy);
    }

    [Fact]
    public async Task CreateInstructorComment_ShouldReturnBadRequest_WhenInstructorIdIsInvalid()
    {
        // Arrange
        var createInstructorCommentDto = new CreateInstructorCommentDTO
        {
            Comment = "Great instructor!",
            instructorId = Guid.NewGuid()
        };

        _mockUnitOfWork.Setup(u => u.InstructorRepository.GetAsync(It.IsAny<Expression<Func<Instructor, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync((Instructor)null);

        // Act
        var result = await _instructorService.CreateInstructorComment(
            new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, "user-id") })),
            createInstructorCommentDto
        );

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
        Assert.Equal("InstructorId Invalid", result.Message);
    }

    [Fact]
    public async Task CreateInstructorComment_ShouldHandleException_WhenExceptionIsThrown()
    {
        // Arrange
        var createInstructorCommentDto = new CreateInstructorCommentDTO
        {
            Comment = "Great instructor!",
            instructorId = Guid.NewGuid()
        };

        _mockUnitOfWork.Setup(u => u.InstructorRepository.GetAsync(It.IsAny<Expression<Func<Instructor, bool>>>(), It.IsAny<string>()))
                       .ThrowsAsync(new Exception("Database error"));

        // Act
        var result = await _instructorService.CreateInstructorComment(
            new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, "user-id") })),
            createInstructorCommentDto
        );

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Equal("Database error", result.Message);
    }
    [Fact]
    public async Task UpdateInstructorComment_ShouldReturnSuccess_WhenValidDataIsProvided()
    {
        // Arrange
        var commentId = Guid.NewGuid();
        var userId = "user-id";
        var adminEmail = "admin@example.com";

        var updateInstructorCommentDto = new UpdateInstructorCommentDTO
        {
            Id = commentId,
            comment = "Updated comment"
        };

        var existingComment = new InstructorComment
        {
            Id = commentId,
            Comment = "Old comment",
            Status = 0
        };

        var admin = new ApplicationUser
        {
            Email = adminEmail
        };

        _mockUnitOfWork.Setup(u => u.InstructorCommentRepository.GetAsync(It.IsAny<Expression<Func<InstructorComment, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(existingComment);
        _mockUserManagerRepository.Setup(um => um.FindByIdAsync(userId))
                        .ReturnsAsync(admin);

        // Act
        var result = await _instructorService.UpdateInstructorComment(
            new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })),
            updateInstructorCommentDto
        );

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("Comment updated successfully", result.Message);
        Assert.Equal("Updated comment", existingComment.Comment);
        Assert.Equal(adminEmail, existingComment.UpdatedBy);
        Assert.Equal(1, existingComment.Status);
    }

    [Fact]
    public async Task UpdateInstructorComment_ShouldReturnBadRequest_WhenCommentIdIsInvalid()
    {
        // Arrange
        var updateInstructorCommentDto = new UpdateInstructorCommentDTO
        {
            Id = Guid.NewGuid(),
            comment = "Updated comment"
        };

        _mockUnitOfWork.Setup(u => u.InstructorCommentRepository.GetAsync(It.IsAny<Expression<Func<InstructorComment, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync((InstructorComment)null);

        // Act
        var result = await _instructorService.UpdateInstructorComment(
            new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, "user-id") })),
            updateInstructorCommentDto
        );

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
        Assert.Equal("InstructorId Invalid", result.Message);
    }

    [Fact]
    public async Task UpdateInstructorComment_ShouldHandleException_WhenExceptionIsThrown()
    {
        // Arrange
        var updateInstructorCommentDto = new UpdateInstructorCommentDTO
        {
            Id = Guid.NewGuid(),
            comment = "Updated comment"
        };

        _mockUnitOfWork.Setup(u => u.InstructorCommentRepository.GetAsync(It.IsAny<Expression<Func<InstructorComment, bool>>>(), It.IsAny<string>()))
                       .ThrowsAsync(new Exception("Database error"));

        // Act
        var result = await _instructorService.UpdateInstructorComment(
            new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, "user-id") })),
            updateInstructorCommentDto
        );

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Equal("Database error", result.Message);
    }


}
