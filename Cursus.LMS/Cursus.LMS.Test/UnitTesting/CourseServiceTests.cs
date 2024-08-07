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
using Cursus.LMS.Utility.Constants;
using Hangfire;

public class CourseServiceTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IStudentCourseService> _studentCourseServiceMock;
    private readonly Mock<ICourseProgressService> _courseProgressServiceMock;
    private readonly CourseService _courseService;
    private readonly Mock<IBackgroundJobClient> _backgroundJobClientMock;

    public CourseServiceTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _mapperMock = new Mock<IMapper>();
        _studentCourseServiceMock = new Mock<IStudentCourseService>();
        _courseProgressServiceMock = new Mock<ICourseProgressService>();
        _backgroundJobClientMock = new Mock<IBackgroundJobClient>();
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

        _unitOfWorkMock.Setup(u => u.CourseRepository.GetAsync(
            It.IsAny<Expression<Func<Course, bool>>>(),
            It.IsAny<string>()))
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
    [Fact]
    public async Task GetCourseInfo_ShouldReturnNotFound_WhenCourseDoesNotExist()
    {
        // Arrange
        var courseId = Guid.NewGuid();

        var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Role, "User")
        }));

        _unitOfWorkMock.Setup(u => u.CourseRepository.GetAsync(It.IsAny<Expression<Func<Course, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync((Course)null);

        // Act
        var result = await _courseService.GetCourseInfo(userClaims, courseId);

        // Assert
        Assert.NotNull(result);
        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
        Assert.Null(result.Result);
        Assert.Equal("Course was not found", result.Message);
    }
    [Fact]
    public async Task GetCourseInfo_ShouldHandleException()
    {
        // Arrange
        var courseId = Guid.NewGuid();

        var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Role, "User")
        }));

        _unitOfWorkMock.Setup(u => u.CourseRepository.GetAsync(It.Is<Expression<Func<Course, bool>>>(exp => exp.ToString().Contains("x => x.Id == courseId")), null))
                       .ThrowsAsync(new Exception("Database error"));

        // Act
        var result = await _courseService.GetCourseInfo(userClaims, courseId);

        // Assert
        Assert.NotNull(result);
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Null(result.Result);
        Assert.Equal("Database error", result.Message);
    }
    [Fact]
    public async Task ActivateCourse_ShouldReturnSuccess_WhenCourseExists()
    {
        // Arrange
        var courseId = Guid.NewGuid();
        var course = new Course
        {
            Id = courseId,
            Status = StaticCourseStatus.Activated // Initial status
        };

        _unitOfWorkMock.Setup(u => u.CourseRepository.GetAsync(It.IsAny<Expression<Func<Course, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync(course);

        _unitOfWorkMock.Setup(u => u.CourseRepository.Update(It.IsAny<Course>()));

        _unitOfWorkMock.Setup(u => u.SaveAsync()).ReturnsAsync(1);

        var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Role, "User")
        }));

        // Act
        var result = await _courseService.ActivateCourse(userClaims, courseId);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Null(result.Result);
        Assert.Equal("Activated course successfully", result.Message);

        _unitOfWorkMock.Verify(u => u.CourseRepository.Update(It.Is<Course>(c => c.Status == StaticCourseStatus.Activated)), Times.Once);
        _unitOfWorkMock.Verify(u => u.SaveAsync(), Times.Once);
    }
    [Fact]
    public async Task ActivateCourse_ShouldReturnNotFound_WhenCourseDoesNotExist()
    {
        // Arrange
        var courseId = Guid.NewGuid();
        _unitOfWorkMock.Setup(u => u.CourseRepository.GetAsync(It.IsAny<Expression<Func<Course, bool>>>(), It.IsAny<string>()))
                       .ReturnsAsync((Course)null);

        var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Role, "User")
        }));

        // Act
        var result = await _courseService.ActivateCourse(userClaims, courseId);

        // Assert
        Assert.NotNull(result);
        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
        Assert.Null(result.Result);
        Assert.Equal("Course was not found", result.Message);
    }
    [Fact]
    public async Task ActivateCourse_ShouldReturnServerError_WhenExceptionThrown()
    {
        // Arrange
        var courseId = Guid.NewGuid();
        var exceptionMessage = "Database error";
        _unitOfWorkMock.Setup(u => u.CourseRepository.GetAsync(It.Is<Expression<Func<Course, bool>>>(exp => exp.ToString().Contains("x => x.Id == courseId")), It.IsAny<string>()))
                       .ThrowsAsync(new Exception(exceptionMessage));

        var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Role, "User")
        }));

        // Act
        var result = await _courseService.ActivateCourse(userClaims, courseId);

        // Assert
        Assert.NotNull(result);
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Null(result.Result);
        Assert.Equal(exceptionMessage, result.Message);
    }
    [Fact]
    public async Task ActivateCourse_ShouldNotUpdate_WhenExceptionThrownDuringUpdate()
    {
        // Arrange
        var courseId = Guid.NewGuid();
        var course = new Course
        {
            Id = courseId,
            Status = StaticCourseStatus.Pending // Initial status
        };

        _unitOfWorkMock.Setup(u => u.CourseRepository.GetAsync(It.Is<Expression<Func<Course, bool>>>(exp => exp.ToString().Contains("x => x.Id == courseId")), It.IsAny<string>()))
                       .ReturnsAsync(course);

        _unitOfWorkMock.Setup(u => u.CourseRepository.Update(It.IsAny<Course>()))
                       .Throws(new Exception("Update error"));

        var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Role, "User")
        }));

        // Act
        var result = await _courseService.ActivateCourse(userClaims, courseId);

        // Assert
        Assert.NotNull(result);
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Null(result.Result);
        Assert.Equal("Update error", result.Message);

        _unitOfWorkMock.Verify(u => u.CourseRepository.Update(It.IsAny<Course>()), Times.Once);
        _unitOfWorkMock.Verify(u => u.SaveAsync(), Times.Never);
    }
    [Fact]
    public async Task EnrollCourse_ShouldReturnSuccess_WhenAllConditionsAreMet()
    {
        // Arrange
        var courseId = Guid.NewGuid();
        var studentId = Guid.NewGuid();
        var enrollCourseDto = new EnrollCourseDTO
        {
            courseId = courseId,
            studentId = studentId
        };

        var studentCourse = new StudentCourse
        {
            Id = Guid.NewGuid(),
            CourseId = courseId,
            StudentId = studentId,
            Status = StaticStatus.StudentCourse.Pending
        };

        var course = new Course
        {
            Id = courseId
        };

        var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
        new Claim(ClaimTypes.Role, "User")
        }));

        _unitOfWorkMock.Setup(u => u.StudentCourseRepository.GetAsync(It.IsAny<Expression<Func<StudentCourse, bool>>>(), null))
                       .ReturnsAsync(studentCourse);

        _unitOfWorkMock.Setup(u => u.CourseRepository.GetAsync(It.IsAny<Expression<Func<Course, bool>>>(), null))
                       .ReturnsAsync(course);

        _studentCourseServiceMock.Setup(s => s.UpdateStudentCourse(It.IsAny<ClaimsPrincipal>(), It.IsAny<UpdateStudentCourseDTO>()));

        _courseProgressServiceMock.Setup(c => c.CreateProgress(It.IsAny<CreateProgressDTO>()));

        // Act
        var result = await _courseService.EnrollCourse(userClaims, enrollCourseDto);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Null(result.Result);
        Assert.Equal("Enroll course successfully", result.Message);
    }

    [Fact]
    public async Task EnrollCourse_ShouldReturn404_WhenCourseDoesNotExist()
    {
        // Arrange
        var courseId = Guid.NewGuid();
        var studentId = Guid.NewGuid();
        var enrollCourseDto = new EnrollCourseDTO
        {
            courseId = courseId,
            studentId = studentId
        };

        var studentCourse = new StudentCourse
        {
            Id = Guid.NewGuid(),
            CourseId = courseId,
            StudentId = studentId,
            Status = StaticStatus.StudentCourse.Pending
        };

        var course = new Course
        {
            Id = courseId
        };

        var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
        new Claim(ClaimTypes.Role, "User")
        }));

        _unitOfWorkMock.Setup(u => u.StudentCourseRepository.GetAsync(It.IsAny<Expression<Func<StudentCourse, bool>>>(), null))
                       .ReturnsAsync(studentCourse);

        _unitOfWorkMock.Setup(u => u.CourseRepository.GetAsync(It.IsAny<Expression<Func<Course, bool>>>(), null))
                       .ReturnsAsync((Course)null);

        // Act
        var result = await _courseService.EnrollCourse(It.IsAny<ClaimsPrincipal>(), enrollCourseDto);

        // Assert
        Assert.NotNull(result);
        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
        Assert.Null(result.Result);
        Assert.Equal("Course was not found", result.Message);
    }
    [Fact]
    public async Task EnrollCourse_ShouldReturn400_WhenStudentDoesNotOwnCourse()
    {
        // Arrange
        var courseId = Guid.NewGuid();
        var studentId = Guid.NewGuid();
        var enrollCourseDto = new EnrollCourseDTO
        {
            courseId = courseId,
            studentId = studentId
        };

        var course = new Course
        {
            Id = courseId
        };

        _unitOfWorkMock.Setup(u => u.StudentCourseRepository.GetAsync(It.IsAny<Expression<Func<StudentCourse, bool>>>(), null))
                       .ReturnsAsync((StudentCourse)null);

        _unitOfWorkMock.Setup(u => u.CourseRepository.GetAsync(It.IsAny<Expression<Func<Course, bool>>>(), null))
                       .ReturnsAsync(course);

        // Act
        var result = await _courseService.EnrollCourse(It.IsAny<ClaimsPrincipal>(), enrollCourseDto);

        // Assert
        Assert.NotNull(result);
        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
        Assert.Null(result.Result);
        Assert.Equal("Student was not own this course", result.Message);
    }
    [Fact]
    public async Task EnrollCourse_ShouldReturn400_WhenStudentCourseStatusIsNotPending()
    {
        // Arrange
        var courseId = Guid.NewGuid();
        var studentId = Guid.NewGuid();
        var enrollCourseDto = new EnrollCourseDTO
        {
            courseId = courseId,
            studentId = studentId
        };

        var studentCourse = new StudentCourse
        {
            Id = Guid.NewGuid(),
            CourseId = courseId,
            StudentId = studentId,
            Status = StaticStatus.StudentCourse.Enrolled
        };

        var course = new Course
        {
            Id = courseId
        };

        _unitOfWorkMock.Setup(u => u.StudentCourseRepository.GetAsync(It.IsAny<Expression<Func<StudentCourse, bool>>>(), null))
                       .ReturnsAsync(studentCourse);

        _unitOfWorkMock.Setup(u => u.CourseRepository.GetAsync(It.IsAny<Expression<Func<Course, bool>>>(), null))
                       .ReturnsAsync(course);

        // Act
        var result = await _courseService.EnrollCourse(It.IsAny<ClaimsPrincipal>(), enrollCourseDto);

        // Assert
        Assert.NotNull(result);
        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
        Assert.Null(result.Result);
        Assert.Equal("Student was not own this course", result.Message);
    }

    [Fact]
    public async Task SuggestCourse_ShouldReturnSuccess_WhenCoursesAreFound()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var courses = new List<StudentCourse>
        {
            new StudentCourse { StudentId = studentId, CourseId = Guid.NewGuid(), Status = 1 },
            new StudentCourse { StudentId = studentId, CourseId = Guid.NewGuid(), Status = 1 }
        };
        var courseVersions = new List<CourseVersion>
        {
            new CourseVersion { CourseId = courses[0].CourseId, CategoryId = Guid.NewGuid() },
            new CourseVersion { CourseId = courses[1].CourseId, CategoryId = Guid.NewGuid() }
        };
        var relatedCourses = new List<Course>
        {
            new Course { Id = Guid.NewGuid() },
            new Course { Id = Guid.NewGuid() }
        };

        _unitOfWorkMock.Setup(u => u.StudentCourseRepository.GetAsync(It.IsAny<Expression<Func<StudentCourse, bool>>>(), It.IsAny<string>())).ReturnsAsync(courses.First());
        _unitOfWorkMock.Setup(u => u.StudentCourseRepository.GetAllAsync(It.IsAny<Expression<Func<StudentCourse, bool>>>(), It.IsAny<string>())).ReturnsAsync(courses);
        _unitOfWorkMock.Setup(u => u.CourseVersionRepository.GetAllAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>())).ReturnsAsync(courseVersions);
        _unitOfWorkMock.Setup(u => u.CourseRepository.GetAsync(It.IsAny<Expression<Func<Course, bool>>>(), It.IsAny<string>())).ReturnsAsync(relatedCourses.First());

        // Act
        var result = await _courseService.SuggestCourse(studentId);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.True(((List<Course>)result.Result).Count <= 5); // Assuming the limit is set to 5
        Assert.Equal("Suggest course successfully", result.Message);
    }

    [Fact]
    public async Task SuggestCourse_ShouldReturnError_WhenStudentIdInvalid()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        _unitOfWorkMock.Setup(u => u.StudentCourseRepository.GetAsync(It.IsAny<Expression<Func<StudentCourse, bool>>>(), It.IsAny<string>())).ReturnsAsync((StudentCourse)null);

        // Act
        var result = await _courseService.SuggestCourse(studentId);

        // Assert
        Assert.NotNull(result);
        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
        Assert.Equal("StudentID Invalid", result.Message);
    }
    [Fact]
    public async Task SuggestCourse_ShouldReturn400_WhenStudentHasNoEnrolledCourses()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var courses = new List<StudentCourse>
        {
            new StudentCourse { StudentId = studentId, CourseId = Guid.NewGuid(), Status = 1 },
            new StudentCourse { StudentId = studentId, CourseId = Guid.NewGuid(), Status = 1 }
        };

        _unitOfWorkMock.Setup(u => u.StudentCourseRepository.GetAsync(It.IsAny<Expression<Func<StudentCourse, bool>>>(), It.IsAny<string>())).ReturnsAsync(courses.First());
        _unitOfWorkMock.Setup(u => u.StudentCourseRepository.GetAllAsync(It.IsAny<Expression<Func<StudentCourse, bool>>>(), It.IsAny<string>())).ReturnsAsync((List<StudentCourse>)null);
        // Act
        var result = await _courseService.SuggestCourse(studentId);

        // Assert
        Assert.NotNull(result);
        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
        Assert.Equal("Student has not enrolled in any courses", result.Message);
    }
    [Fact]
    public async Task SuggestCourse_ShouldReturnEmptyList_WhenNoRelatedCoursesFound()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var courses = new List<StudentCourse>
        {
            new StudentCourse { StudentId = studentId, CourseId = Guid.NewGuid(), Status = 1 },
            new StudentCourse { StudentId = studentId, CourseId = Guid.NewGuid(), Status = 1 }
        };

        _unitOfWorkMock.Setup(u => u.StudentCourseRepository.GetAsync(It.IsAny<Expression<Func<StudentCourse, bool>>>(), It.IsAny<string>())).ReturnsAsync(courses.First());
        _unitOfWorkMock.Setup(u => u.StudentCourseRepository.GetAllAsync(It.IsAny<Expression<Func<StudentCourse, bool>>>(), It.IsAny<string>())).ReturnsAsync(courses);
        _unitOfWorkMock.Setup(u => u.CourseVersionRepository.GetAllAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>())).ReturnsAsync(new List<CourseVersion>());
        _unitOfWorkMock.Setup(u => u.CourseRepository.GetAsync(It.IsAny<Expression<Func<Course, bool>>>(), It.IsAny<string>())).ReturnsAsync((Course)null);

        // Act
        var result = await _courseService.SuggestCourse(studentId);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Empty((List<Course>)result.Result);
    }
    [Fact]
    public async Task SuggestCourse_ShouldHandleExceptionGracefully()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        _unitOfWorkMock.Setup(u => u.StudentCourseRepository.GetAsync(It.IsAny<Expression<Func<StudentCourse, bool>>>(), It.IsAny<string>())).ThrowsAsync(new Exception("Database error"));

        // Act
        var result = await _courseService.SuggestCourse(studentId);

        // Assert
        Assert.NotNull(result);
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Equal("Database error", result.Message);
    }

    [Fact]
    public async Task UpsertCourseTotal_ShouldReturn404_WhenCourseNotFound()
    {
        // Arrange
        var courseId = Guid.NewGuid();
        _unitOfWorkMock.Setup(u => u.CourseRepository.GetAsync(It.IsAny<Expression<Func<Course, bool>>>(), It.IsAny<string>())).ReturnsAsync((Course)null);

        var upsertCourseTotalDto = new UpsertCourseTotalDTO { CourseId = courseId };

        // Act
        var result = await _courseService.UpsertCourseTotal(upsertCourseTotalDto);

        // Assert
        Assert.NotNull(result);
        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
        Assert.Equal("Course was not found", result.Message);
    }
    [Fact]
    public async Task UpsertCourseTotal_ShouldUpdateTotalStudent_WhenTotalStudentIsProvided()
    {
        // Arrange
        var courseId = Guid.NewGuid();
        var course = new Course { Id = courseId, TotalStudent = 10 };

        _unitOfWorkMock.Setup(u => u.CourseRepository.GetAsync(It.IsAny<Expression<Func<Course, bool>>>(), It.IsAny<string>())).ReturnsAsync(course);

        var upsertCourseTotalDto = new UpsertCourseTotalDTO { CourseId = courseId, TotalStudent = 5 };

        // Act
        var result = await _courseService.UpsertCourseTotal(upsertCourseTotalDto);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(15, ((Course)result.Result).TotalStudent);
    }
    [Fact]
    public async Task UpsertCourseTotal_ShouldUpdateTotalEarnedAndIncrementTotalStudent_WhenTotalEarnedIsProvided()
    {
        // Arrange
        var courseId = Guid.NewGuid();
        var course = new Course { Id = courseId, TotalStudent = 10, TotalEarned = 500 };

        _unitOfWorkMock.Setup(u => u.CourseRepository.GetAsync(It.IsAny<Expression<Func<Course, bool>>>(), It.IsAny<string>())).ReturnsAsync(course);

        var upsertCourseTotalDto = new UpsertCourseTotalDTO { CourseId = courseId, TotalEarned = 100 };

        // Act
        var result = await _courseService.UpsertCourseTotal(upsertCourseTotalDto);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(11, ((Course)result.Result).TotalStudent);
        Assert.Equal(600, ((Course)result.Result).TotalEarned);
    }
    [Fact]
    public async Task UpsertCourseTotal_ShouldUpdateTotalRate_WhenUpdateTotalRateIsTrue()
    {
        // Arrange
        var courseId = Guid.NewGuid();
        var course = new Course { Id = courseId, TotalRate = (float)3.0 };

        var courseReviews = new List<CourseReview>
    {
        new CourseReview { CourseId = courseId, Rate = 4 },
        new CourseReview { CourseId = courseId, Rate = 5 }
    };

        // Mock the repository methods
        _unitOfWorkMock.Setup(u => u.CourseRepository.GetAsync(It.IsAny<Expression<Func<Course, bool>>>(), It.IsAny<string>())).ReturnsAsync(course);
        _unitOfWorkMock.Setup(u => u.CourseReviewRepository.GetAllAsync(It.IsAny<Expression<Func<CourseReview, bool>>>(), It.IsAny<string>())).ReturnsAsync(courseReviews);

        var upsertCourseTotalDto = new UpsertCourseTotalDTO { CourseId = courseId, UpdateTotalRate = true };

        // Act
        var result = await _courseService.UpsertCourseTotal(upsertCourseTotalDto);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal((float)4.5, ((Course)result.Result).TotalRate);
    }
    [Fact]
    public async Task UpsertCourseTotal_ShouldNotUpdateAnyField_WhenDtoFieldsAreNull()
    {
        // Arrange
        var courseId = Guid.NewGuid();
        var course = new Course { Id = courseId, TotalStudent = 10, TotalEarned = 500, TotalRate = (float)4.0 };

        _unitOfWorkMock.Setup(u => u.CourseRepository.GetAsync(It.IsAny<Expression<Func<Course, bool>>>(), It.IsAny<string>())).ReturnsAsync(course);

        var upsertCourseTotalDto = new UpsertCourseTotalDTO { CourseId = courseId };

        // Act
        var result = await _courseService.UpsertCourseTotal(upsertCourseTotalDto);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(10, ((Course)result.Result).TotalStudent);
        Assert.Equal(500, ((Course)result.Result).TotalEarned);
        Assert.Equal((float)4.0, ((Course)result.Result).TotalRate);
    }
    [Fact]
    public async Task UpsertCourseTotal_ShouldHandleException_WhenAnErrorOccurs()
    {
        // Arrange
        var courseId = Guid.NewGuid();
        _unitOfWorkMock.Setup(u => u.CourseRepository.GetAsync(It.IsAny<Expression<Func<Course, bool>>>(), It.IsAny<string>())).ThrowsAsync(new Exception("Exception Message"));

        var upsertCourseTotalDto = new UpsertCourseTotalDTO { CourseId = courseId };

        // Act
        var result = await _courseService.UpsertCourseTotal(upsertCourseTotalDto);

        // Assert
        Assert.NotNull(result);
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Equal("Exception Message", result.Message);
    }
    [Fact]
    public async Task GetAllBookMarkedCoursesById_ShouldReturn404_WhenStudentNotFound()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        _unitOfWorkMock.Setup(u => u.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), null))
            .ReturnsAsync((Student)null);

        // Act
        var result = await _courseService.GetAllBookMarkedCoursesById(studentId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
        Assert.Equal("Student not found", result.Message);
    }

    [Fact]
    public async Task GetAllBookMarkedCoursesById_ShouldReturnBookmarkedCoursesSortedInDescendingOrder_WhenSortOrderIsDesc()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var bookmarks = new List<CourseBookmark>
        {
            new CourseBookmark { StudentId = studentId, CreatedTime = DateTime.Now.AddDays(-2) },
            new CourseBookmark { StudentId = studentId, CreatedTime = DateTime.Now }
        };

        _unitOfWorkMock.Setup(u => u.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), null))
            .ReturnsAsync(new Student { StudentId = studentId });
        _unitOfWorkMock.Setup(u => u.CourseBookmarkRepository.GetAllAsync(It.IsAny<Expression<Func<CourseBookmark, bool>>>(), null))
            .ReturnsAsync(bookmarks);

        // Act
        var result = await _courseService.GetAllBookMarkedCoursesById(studentId, "desc");

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        var resultList = result.Result as List<CourseBookmark>;
        Assert.NotNull(resultList);
        Assert.Equal(2, resultList.Count);
        Assert.True(resultList[0].CreatedTime > resultList[1].CreatedTime);
    }

    [Fact]
    public async Task GetAllBookMarkedCoursesById_ShouldReturnBookmarkedCoursesSortedInAscendingOrder_WhenSortOrderIsAsc()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var bookmarks = new List<CourseBookmark>
        {
            new CourseBookmark { StudentId = studentId, CreatedTime = DateTime.Now.AddDays(-2) },
            new CourseBookmark { StudentId = studentId, CreatedTime = DateTime.Now }
        };

        _unitOfWorkMock.Setup(u => u.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), null))
            .ReturnsAsync(new Student { StudentId = studentId });
        _unitOfWorkMock.Setup(u => u.CourseBookmarkRepository.GetAllAsync(It.IsAny<Expression<Func<CourseBookmark, bool>>>(), null))
            .ReturnsAsync(bookmarks);

        // Act
        var result = await _courseService.GetAllBookMarkedCoursesById(studentId, "asc");

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        var resultList = result.Result as List<CourseBookmark>;
        Assert.NotNull(resultList);
        Assert.Equal(2, resultList.Count);
        Assert.True(resultList[0].CreatedTime < resultList[1].CreatedTime);
    }

    [Fact]
    public async Task GetAllBookMarkedCoursesById_ShouldReturnBookmarkedCoursesSortedInDescendingOrder_WhenSortOrderIsInvalid()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var bookmarks = new List<CourseBookmark>
        {
            new CourseBookmark { StudentId = studentId, CreatedTime = DateTime.Now.AddDays(-2) },
            new CourseBookmark { StudentId = studentId, CreatedTime = DateTime.Now }
        };

        _unitOfWorkMock.Setup(u => u.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), null))
            .ReturnsAsync(new Student { StudentId = studentId });
        _unitOfWorkMock.Setup(u => u.CourseBookmarkRepository.GetAllAsync(It.IsAny<Expression<Func<CourseBookmark, bool>>>(), null))
            .ReturnsAsync(bookmarks);

        // Act
        var result = await _courseService.GetAllBookMarkedCoursesById(studentId, "invalid");

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        var resultList = result.Result as List<CourseBookmark>;
        Assert.NotNull(resultList);
        Assert.Equal(2, resultList.Count);
        Assert.True(resultList[0].CreatedTime > resultList[1].CreatedTime);
    }

    [Fact]
    public async Task GetAllBookMarkedCoursesById_ShouldReturnBookmarkedCoursesSortedInDescendingOrder_WhenSortOrderIsNotProvided()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var bookmarks = new List<CourseBookmark>
        {
            new CourseBookmark { StudentId = studentId, CreatedTime = DateTime.Now.AddDays(-2) },
            new CourseBookmark { StudentId = studentId, CreatedTime = DateTime.Now }
        };

        _unitOfWorkMock.Setup(u => u.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), null))
            .ReturnsAsync(new Student { StudentId = studentId });
        _unitOfWorkMock.Setup(u => u.CourseBookmarkRepository.GetAllAsync(It.IsAny<Expression<Func<CourseBookmark, bool>>>(), null))
            .ReturnsAsync(bookmarks);

        // Act
        var result = await _courseService.GetAllBookMarkedCoursesById(studentId);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        var resultList = result.Result as List<CourseBookmark>;
        Assert.NotNull(resultList);
        Assert.Equal(2, resultList.Count);
        Assert.True(resultList[0].CreatedTime > resultList[1].CreatedTime);
    }

    [Fact]
    public async Task GetAllBookMarkedCoursesById_ShouldReturn500_WhenExceptionIsThrown()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        _unitOfWorkMock.Setup(u => u.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), null))
            .ThrowsAsync(new Exception("Test Exception"));

        // Act
        var result = await _courseService.GetAllBookMarkedCoursesById(studentId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Equal("Test Exception", result.Message);
    }

    [Fact]
    public async Task CreateBookMarkedCourse_ShouldReturn404_WhenStudentIdIsInvalid()
    {
        // Arrange
        var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
        new Claim(ClaimTypes.NameIdentifier, "user-id-1")
        }));
        var createCourseBookmarkDTO = new CreateCourseBookmarkDTO { StudentId = Guid.NewGuid(), CourseId = Guid.NewGuid() };
        _unitOfWorkMock.Setup(u => u.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), null))
            .ReturnsAsync((Student)null);

        // Act
        var result = await _courseService.CreateBookMarkedCourse(userClaims, createCourseBookmarkDTO);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
        Assert.Equal("StudentID Invalid", result.Message);
    }

    [Fact]
    public async Task CreateBookMarkedCourse_ShouldReturn400_WhenCourseIsAlreadyBookmarked()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var courseId = Guid.NewGuid();

        var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
        new Claim(ClaimTypes.NameIdentifier, "user-id-1")
        }));
        var createCourseBookmarkDTO = new CreateCourseBookmarkDTO { StudentId = studentId, CourseId = courseId };
        _unitOfWorkMock.Setup(u => u.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), null))
            .ReturnsAsync(new Student { StudentId = studentId });
        _unitOfWorkMock.Setup(u => u.CourseBookmarkRepository.GetAsync(It.IsAny<Expression<Func<CourseBookmark, bool>>>(), null))
            .ReturnsAsync(new CourseBookmark { CourseId = courseId, StudentId = studentId });

        // Act
        var result = await _courseService.CreateBookMarkedCourse(userClaims, createCourseBookmarkDTO);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
        Assert.Equal("Course is already bookmarked", result.Message);
    }

    [Fact]
    public async Task CreateBookMarkedCourse_ShouldCreateNewBookmarkedCourseSuccessfully()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var courseId = Guid.NewGuid();
        var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
        new Claim(ClaimTypes.NameIdentifier, "user-id-1")
        }));
        var createCourseBookmarkDTO = new CreateCourseBookmarkDTO { StudentId = studentId, CourseId = courseId };
        _unitOfWorkMock.Setup(u => u.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), null))
            .ReturnsAsync(new Student { StudentId = studentId });
        _unitOfWorkMock.Setup(u => u.CourseBookmarkRepository.GetAsync(It.IsAny<Expression<Func<CourseBookmark, bool>>>(), null))
            .ReturnsAsync((CourseBookmark)null);
        _unitOfWorkMock.Setup(u => u.CourseBookmarkRepository.AddAsync(It.IsAny<CourseBookmark>())).Returns(Task.CompletedTask);
        _unitOfWorkMock.Setup(u => u.SaveAsync()).ReturnsAsync(1);

        // Act
        var result = await _courseService.CreateBookMarkedCourse(userClaims, createCourseBookmarkDTO);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("Course bookmarked successfully.", result.Message);
    }

    [Fact]
    public async Task CreateBookMarkedCourse_ShouldReturn500_WhenExceptionIsThrown()
    {
        // Arrange
        var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
        new Claim(ClaimTypes.NameIdentifier, "user-id-1")
        }));
        var createCourseBookmarkDTO = new CreateCourseBookmarkDTO { StudentId = Guid.NewGuid(), CourseId = Guid.NewGuid() };
        _unitOfWorkMock.Setup(u => u.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), null))
            .ThrowsAsync(new Exception("Test Exception"));

        // Act
        var result = await _courseService.CreateBookMarkedCourse(userClaims, createCourseBookmarkDTO);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Equal("Test Exception", result.Message);
    }

    [Fact]
    public async Task CreateBookMarkedCourse_ShouldReturn400_WhenUserIdentityIsNotValid()
    {
        // Arrange
        var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
        new Claim(ClaimTypes.NameIdentifier, "user-id-1")
        }));
        var createCourseBookmarkDTO = new CreateCourseBookmarkDTO { StudentId = Guid.NewGuid(), CourseId = Guid.NewGuid() };
        _unitOfWorkMock.Setup(u => u.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), null))
            .ReturnsAsync(new Student { StudentId = createCourseBookmarkDTO.StudentId });
        _unitOfWorkMock.Setup(u => u.CourseBookmarkRepository.GetAsync(It.IsAny<Expression<Func<CourseBookmark, bool>>>(), null))
            .ReturnsAsync((CourseBookmark)null);


        // Act
        var result = await _courseService.CreateBookMarkedCourse(userClaims, createCourseBookmarkDTO);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
        Assert.Equal("User identity is not valid", result.Message);
    }

    [Fact]
    public async Task CreateBookMarkedCourse_ShouldReturn400_WhenCourseIdIsInvalid()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
        new Claim(ClaimTypes.NameIdentifier, "user-id-1")
        }));
        var createCourseBookmarkDTO = new CreateCourseBookmarkDTO { StudentId = studentId, CourseId = Guid.NewGuid() };
        _unitOfWorkMock.Setup(u => u.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), null))
            .ReturnsAsync(new Student { StudentId = studentId });
        _unitOfWorkMock.Setup(u => u.CourseBookmarkRepository.GetAsync(It.IsAny<Expression<Func<CourseBookmark, bool>>>(), null))
            .ReturnsAsync((CourseBookmark)null);
        _unitOfWorkMock.Setup(u => u.CourseRepository.GetAsync(It.IsAny<Expression<Func<Course, bool>>>(), null))
            .ReturnsAsync((Course)null);

        // Act
        var result = await _courseService.CreateBookMarkedCourse(userClaims, createCourseBookmarkDTO);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
        Assert.Equal("CourseID Invalid", result.Message);
    }

    [Fact]
    public async Task DeleteBookMarkedCourse_ShouldReturn404_WhenBookmarkNotFound()
    {
        // Arrange
        var bookmarkId = Guid.NewGuid();
        _unitOfWorkMock.Setup(u => u.CourseBookmarkRepository.GetAsync(It.IsAny<Expression<Func<CourseBookmark, bool>>>(), It.IsAny<string>())).ReturnsAsync((CourseBookmark)null);

        // Act
        var result = await _courseService.DeleteBookMarkedCourse(bookmarkId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
        Assert.Equal("Course bookmark not found.", result.Message);
    }
    [Fact]
    public async Task DeleteBookMarkedCourse_ShouldReturn200_WhenBookmarkIsFoundAndDeleted()
    {
        // Arrange
        var bookmarkId = Guid.NewGuid();
        var courseBookmark = new CourseBookmark { Id = bookmarkId };
        _unitOfWorkMock.Setup(u => u.CourseBookmarkRepository.GetAsync(It.IsAny<Expression<Func<CourseBookmark, bool>>>(), It.IsAny<string>())).ReturnsAsync(courseBookmark);
        _unitOfWorkMock.Setup(u => u.CourseBookmarkRepository.Remove(It.IsAny<CourseBookmark>()));
        _unitOfWorkMock.Setup(u => u.SaveAsync());

        // Act
        var result = await _courseService.DeleteBookMarkedCourse(bookmarkId);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("Course bookmark removed successfully.", result.Message);
    }
    [Fact]
    public async Task DeleteBookMarkedCourse_ShouldCallRemove_WhenBookmarkIsFound()
    {
        // Arrange
        var bookmarkId = Guid.NewGuid();
        var courseBookmark = new CourseBookmark { Id = bookmarkId };
        _unitOfWorkMock.Setup(u => u.CourseBookmarkRepository.GetAsync(It.IsAny<Expression<Func<CourseBookmark, bool>>>(), It.IsAny<string>())).ReturnsAsync(courseBookmark);
        _unitOfWorkMock.Setup(u => u.CourseBookmarkRepository.Remove(It.IsAny<CourseBookmark>()));

        // Act
        await _courseService.DeleteBookMarkedCourse(bookmarkId);

        // Assert
        _unitOfWorkMock.Verify(u => u.CourseBookmarkRepository.Remove(It.IsAny<CourseBookmark>()), Times.Once);
    }
    [Fact]
    public async Task DeleteBookMarkedCourse_ShouldCallSaveAsync_WhenBookmarkIsDeleted()
    {
        // Arrange
        var bookmarkId = Guid.NewGuid();
        var courseBookmark = new CourseBookmark { Id = bookmarkId };
        _unitOfWorkMock.Setup(u => u.CourseBookmarkRepository.GetAsync(It.IsAny<Expression<Func<CourseBookmark, bool>>>(), It.IsAny<string>())).ReturnsAsync(courseBookmark);
        _unitOfWorkMock.Setup(u => u.CourseBookmarkRepository.Remove(It.IsAny<CourseBookmark>()));
        _unitOfWorkMock.Setup(u => u.SaveAsync());

        // Act
        await _courseService.DeleteBookMarkedCourse(bookmarkId);

        // Assert
        _unitOfWorkMock.Verify(u => u.SaveAsync(), Times.Once);
    }
    [Fact]
    public async Task GetBestCoursesSuggestion_ShouldReturn200_WhenCoursesAreFound()
    {
        // Arrange
        var courses = new List<Course>
    {
        new Course { Id = Guid.NewGuid(), TotalStudent = 50 },
        new Course { Id = Guid.NewGuid(), TotalStudent = 100 },
        // Add more courses here
    };
        _unitOfWorkMock.Setup(u => u.CourseRepository.GetAllAsync(It.IsAny<Expression<Func<Course, bool>>>(), It.IsAny<string>())).ReturnsAsync(courses);

        // Act
        var result = await _courseService.GetBestCoursesSuggestion();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("Get best courses suggestion successfully", result.Message);
        Assert.Equal(2, ((List<Course>)result.Result).Count);
    }
    [Fact]
    public async Task GetBestCoursesSuggestion_ShouldReturnEmptyList_WhenNoCoursesAvailable()
    {
        // Arrange
        var courses = new List<Course>();
        _unitOfWorkMock.Setup(u => u.CourseRepository.GetAllAsync(It.IsAny<Expression<Func<Course, bool>>>(), It.IsAny<string>())).ReturnsAsync(courses);

        // Act
        var result = await _courseService.GetBestCoursesSuggestion();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("Get best courses suggestion successfully", result.Message);
        Assert.Empty((List<Course>)result.Result);
    }
    [Fact]
    public async Task GetBestCoursesSuggestion_ShouldReturnTop10Courses_WhenMoreThan10CoursesAvailable()
    {
        // Arrange
        var courses = Enumerable.Range(1, 15).Select(i => new Course
        {
            Id = Guid.NewGuid(),
            TotalStudent = 15 - i
        }).ToList();
        _unitOfWorkMock.Setup(u => u.CourseRepository.GetAllAsync(It.IsAny<Expression<Func<Course, bool>>>(), It.IsAny<string>())).ReturnsAsync(courses);

        // Act
        var result = await _courseService.GetBestCoursesSuggestion();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("Get best courses suggestion successfully", result.Message);
        var resultList = (List<Course>)result.Result;
        Assert.Equal(10, resultList.Count);
        Assert.True(resultList.First().TotalStudent >= resultList.Last().TotalStudent);
    }
    [Fact]
    public async Task GetBestCoursesSuggestion_ShouldReturn500_WhenExceptionOccurs()
    {
        // Arrange
        _unitOfWorkMock.Setup(u => u.CourseRepository.GetAllAsync(It.IsAny<Expression<Func<Course, bool>>>(), It.IsAny<string>())).ThrowsAsync(new Exception("Database error"));

        // Act
        var result = await _courseService.GetBestCoursesSuggestion();

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(500, result.StatusCode);
        Assert.Equal("Database error", result.Message);
    }



}
