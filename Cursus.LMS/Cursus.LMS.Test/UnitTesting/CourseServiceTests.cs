using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Cursus.LMS.Service;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.DataAccess.Repository;
using Cursus.LMS.DataAccess.IRepository;
using AutoMapper;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Service.Service;
using System.Security.Claims;
using Cursus.LMS.Model.DTO;

public class CourseServiceTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IStudentCourseService> _studentCourseServiceMock;
    private readonly Mock<ICourseProgressService> _courseProgressServiceMock;
    private readonly CourseService _courseService;

    public CourseServiceTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _mapperMock = new Mock<IMapper>();
        _studentCourseServiceMock = new Mock<IStudentCourseService>();
        _courseProgressServiceMock = new Mock<ICourseProgressService>();

        _courseService = new CourseService(
            _unitOfWorkMock.Object,
            _mapperMock.Object,
            _studentCourseServiceMock.Object,
            _courseProgressServiceMock.Object);
    }

    [Fact]
    public async Task GetTopTrendingCategories_ShouldReturnAllCategories_WhenThereAreExactly3Categories()
    {
        // Arrange
        var courseVersionId1 = Guid.NewGuid();
        var courseVersionId2 = Guid.NewGuid();
        var courseVersionId3 = Guid.NewGuid();
        var categoryId1 = Guid.NewGuid();
        var categoryId2 = Guid.NewGuid();
        var categoryId3 = Guid.NewGuid();

        var courses = new List<Course>
        {
            new Course { Id = Guid.NewGuid(), TotalStudent = 10, CourseVersionId = courseVersionId1 },
            new Course { Id = Guid.NewGuid(), TotalStudent = 20, CourseVersionId = courseVersionId2 },
            new Course { Id = Guid.NewGuid(), TotalStudent = 30, CourseVersionId = courseVersionId3 }
        };

        var courseVersions = new List<CourseVersion>
        {
            new CourseVersion { Id = courseVersionId1, CategoryId = categoryId1 },
            new CourseVersion { Id = courseVersionId2, CategoryId = categoryId2 },
            new CourseVersion { Id = courseVersionId3, CategoryId = categoryId3 }
        };

        var categories = new List<Category>
        {
            new Category { Id = categoryId1, Name = "Category 1" },
            new Category { Id = categoryId2, Name = "Category 2" },
            new Category { Id = categoryId3, Name = "Category 3" }
        };

        _unitOfWorkMock.Setup(u => u.CourseRepository.GetAllAsync(It.IsAny<Expression<Func<Course, bool>>>(), null))
                       .ReturnsAsync(courses);
        _unitOfWorkMock.Setup(u => u.CourseVersionRepository.GetAllAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), null))
                       .ReturnsAsync(courseVersions);
        _unitOfWorkMock.Setup(u => u.CategoryRepository.GetAllAsync(It.IsAny<Expression<Func<Category, bool>>>(), null))
                       .ReturnsAsync(categories);

        // Act
        var result = await _courseService.GetTopTrendingCategories();

        // Assert
        Assert.Equal(3, result.Count);
    }

    [Fact]
    public async Task GetTopTrendingCategories_ShouldReturnEmptyList_WhenNoCoursesExist()
    {
        // Arrange
        _unitOfWorkMock.Setup(u => u.CourseRepository.GetAllAsync(It.IsAny<Expression<Func<Course, bool>>>(), null))
                       .ReturnsAsync(new List<Course>());

        // Act
        var result = await _courseService.GetTopTrendingCategories();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public async Task CreateFrameCourse_ShouldReturnNotFound_WhenInstructorDoesNotExist()
    {
        // Arrange
        var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
        new Claim(ClaimTypes.NameIdentifier, "user-id-1")
        }));

        _unitOfWorkMock.Setup(u => u.InstructorRepository.GetAsync(It.IsAny<Expression<Func<Instructor, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync((Instructor)null);

        // Act
        var result = await _courseService.CreateFrameCourse(userClaims, Guid.NewGuid());

        // Assert
        Assert.NotNull(result);
        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
        Assert.Equal("Instructor does not exist", result.Message);
    }

    [Fact]
    public async Task CreateFrameCourse_ShouldReturnForbidden_WhenInstructorIsNotAccepted()
    {
        // Arrange
        var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
        new Claim(ClaimTypes.NameIdentifier, "user-id-1")
        }));

        var instructor = new Instructor { InstructorId = Guid.NewGuid(), UserId = "user-id-1", IsAccepted = false, ApplicationUser = new ApplicationUser { Email = "test@example.com" } };

        _unitOfWorkMock.Setup(u => u.InstructorRepository.GetAsync(It.IsAny<Expression<Func<Instructor, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(instructor);

        // Act
        var result = await _courseService.CreateFrameCourse(userClaims, Guid.NewGuid());

        // Assert
        Assert.NotNull(result);
        Assert.False(result.IsSuccess);
        Assert.Equal(403, result.StatusCode);
        Assert.Equal("Permission to create course was not found", result.Message);
    }
    [Fact]
    public async Task CreateFrameCourse_ShouldReturnSuccess_WhenInstructorIsAccepted()
    {
        // Arrange
        var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
        new Claim(ClaimTypes.NameIdentifier, "user-id-1")
        }));

        var instructor = new Instructor { InstructorId = Guid.NewGuid(), UserId = "user-id-1", IsAccepted = true, ApplicationUser = new ApplicationUser { Email = "test@example.com" } };
        var courseVersionId = Guid.NewGuid();

        _unitOfWorkMock.Setup(u => u.InstructorRepository.GetAsync(It.IsAny<Expression<Func<Instructor, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(instructor);
        _unitOfWorkMock.Setup(u => u.CourseRepository.AddAsync(It.IsAny<Course>())).Returns(Task.CompletedTask);
        _unitOfWorkMock.Setup(u => u.SaveAsync()).ReturnsAsync(1); 
            
        // Act
        var result = await _courseService.CreateFrameCourse(userClaims, courseVersionId);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("Create empty course successfully", result.Message);
        Assert.NotNull(result.Result);
    }

    [Fact]
    public async Task GetCourse_ShouldReturnCourse_WhenCourseExists()
    {
        // Arrange
        var courseId = Guid.NewGuid();
        var courseVersionId = Guid.NewGuid();

        var course = new Course
        {
            Id = courseId,
            CourseVersionId = courseVersionId
        };

        var courseVersion = new CourseVersion
        {
            Id = courseVersionId,
            Title = "Course Title",
            Code = "CT001",
            Price = 150
        };

        var courseVersionDto = new GetCourseVersionDTO
        {
            Id = courseVersionId,
            Title = "Course Title",
            Code = "CT001",
            Price = 150
        };

        var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
        new Claim(ClaimTypes.Role, "User")
        }));

        _unitOfWorkMock.Setup(u => u.CourseRepository.GetAsync(It.IsAny<Expression<Func<Course, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(course);

        _unitOfWorkMock.Setup(u => u.CourseVersionRepository.GetAsync(
            It.IsAny<Expression<Func<CourseVersion, bool>>>(),
            It.IsAny<string>()))
            .ReturnsAsync(courseVersion);
        _mapperMock.Setup(m => m.Map<GetCourseVersionDTO>(courseVersion))
               .Returns(courseVersionDto);

        // Act
        var result = await _courseService.GetCourse(userClaims, courseId);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.NotNull(result.Result);
        var courseVersionDtoResult = Assert.IsType<GetCourseVersionDTO>(result.Result);
        Assert.Equal("Course Title", courseVersionDtoResult.Title);
        Assert.Equal("CT001", courseVersionDtoResult.Code);
        Assert.Equal(150, courseVersionDtoResult.Price);
    }

    [Fact]
    public async Task GetCourse_ShouldReturnNotFound_WhenCourseDoesNotExist()
    {
        // Arrange
        var courseId = Guid.NewGuid();

        _unitOfWorkMock.Setup(u => u.CourseRepository.GetAsync(
            It.IsAny<Expression<Func<Course, bool>>>(),
            It.IsAny<string>()))
            .ReturnsAsync((Course)null);

        // Act
        var result = await _courseService.GetCourse(new ClaimsPrincipal(), courseId);

        // Assert
        Assert.NotNull(result);
        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
        Assert.Null(result.Result);
        Assert.Equal("Course was not found", result.Message);
    }
    [Fact]
    public async Task GetCourse_ShouldReturnNotFound_WhenCourseVersionDoesNotExist()
    {
        // Arrange
        var courseId = Guid.NewGuid();
        var courseVersionId = Guid.NewGuid();

        var course = new Course
        {
            Id = courseId,
            CourseVersionId = courseVersionId
        };

        _unitOfWorkMock.Setup(u => u.CourseRepository.GetAsync(
            It.Is<Expression<Func<Course, bool>>>(exp => exp.ToString().Contains("x => x.Id == courseId")),
            It.IsAny<string>()))
            .ReturnsAsync(course);

        _unitOfWorkMock.Setup(u => u.CourseVersionRepository.GetAsync(
            It.Is<Expression<Func<CourseVersion, bool>>>(exp => exp.ToString().Contains("x => x.Id == courseVersionId")),
            It.IsAny<string>()))
            .ReturnsAsync((CourseVersion)null);

        // Act
        var result = await _courseService.GetCourse(new ClaimsPrincipal(), courseId);

        // Assert
        Assert.NotNull(result);
        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
        Assert.Null(result.Result);
        Assert.Equal("Course was not found", result.Message);
    }
    [Fact]
    public async Task GetCourse_ShouldReturnServerError_WhenExceptionOccurs()
    {
        // Arrange
        var courseId = Guid.NewGuid();

        _unitOfWorkMock.Setup(u => u.CourseRepository.GetAsync(
            It.IsAny<Expression<Func<Course, bool>>>(),
            It.IsAny<string>()))
            .ThrowsAsync(new Exception("Database error"));

        // Act
        var result = await _courseService.GetCourse(new ClaimsPrincipal(), courseId);

        // Assert
        Assert.NotNull(result);
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Null(result.Result);
        Assert.Equal("Database error", result.Message);
    }

    [Fact]
    public async Task GetCourseInfo_ShouldReturnCourseInfo_WhenCourseExists()
    {
        // Arrange
        var courseId = Guid.NewGuid();
        var course = new Course
        {
            Id = courseId,
            InstructorId = Guid.NewGuid(),
            Code = "CT001",
            TotalRate = 4.5f,
            Version = 1,
            CourseVersionId = Guid.NewGuid()
        };

        var getCourseInfoDto = new GetCourseInfoDTO
        {
            Id = courseId,
            InstructorId = course.InstructorId,
            Code = course.Code,
            StudentSlots = 30,
            TotalRate = course.TotalRate,
            Version = course.Version,
            CourseVersionId = course.CourseVersionId
        };

        var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Role, "User")
        }));

        _unitOfWorkMock.Setup(u => u.CourseRepository.GetAsync(It.Is<Expression<Func<Course, bool>>>(exp => exp.ToString().Contains("x => x.Id == courseId")), null))
                       .ReturnsAsync(course);

        _mapperMock.Setup(m => m.Map<GetCourseInfoDTO>(course))
                   .Returns(getCourseInfoDto);

        // Act
        var result = await _courseService.GetCourseInfo(userClaims, courseId);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.NotNull(result.Result);
        var courseInfoDto = Assert.IsType<GetCourseInfoDTO>(result.Result);
        Assert.Equal(courseId, courseInfoDto.Id);
        Assert.Equal(course.InstructorId, courseInfoDto.InstructorId);
        Assert.Equal(course.Code, courseInfoDto.Code);
        Assert.Equal(30, courseInfoDto.StudentSlots);
        Assert.Equal(course.TotalRate, courseInfoDto.TotalRate);
        Assert.Equal(course.Version, courseInfoDto.Version);
        Assert.Equal(course.CourseVersionId, courseInfoDto.CourseVersionId);
    }



}
