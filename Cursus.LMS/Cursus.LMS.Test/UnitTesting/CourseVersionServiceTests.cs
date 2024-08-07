using Moq;
using Xunit;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Service.Service;
using Cursus.LMS.Utility.Constants;
using System.Security.Claims;
using System.Linq.Expressions;
using Hangfire;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Http;


namespace Cursus.LMS.Service.Tests
{
    public class CourseVersionServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<ICourseService> _mockCourseService;
        private readonly Mock<ICourseSectionVersionService> _mockCourseSectionVersionService;
        private readonly Mock<ICourseVersionStatusService> _mockCourseVersionStatusService;
        private readonly Mock<IFirebaseService> _mockFirebaseService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CourseVersionService _service;
        private readonly Mock<IBackgroundJobClient> _mockBackgroundJobClient;
        private readonly Mock<IUserManagerRepository> _mockUserManagerRepository;


        public CourseVersionServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockCourseService = new Mock<ICourseService>();
            _mockCourseSectionVersionService = new Mock<ICourseSectionVersionService>();
            _mockCourseVersionStatusService = new Mock<ICourseVersionStatusService>();
            _mockFirebaseService = new Mock<IFirebaseService>();
            _mockMapper = new Mock<IMapper>();
            _mockBackgroundJobClient = new Mock<IBackgroundJobClient>();
            _mockUserManagerRepository = new Mock<IUserManagerRepository>();

            _service = new CourseVersionService(
                _mockUnitOfWork.Object,
                _mockCourseService.Object,
                _mockMapper.Object,
                _mockCourseVersionStatusService.Object,
                _mockCourseSectionVersionService.Object,
                _mockFirebaseService.Object
            );
        }

        [Fact]
        public async Task GetCourseVersions_ReturnsSuccess_WhenValidInputs()
        {
            // Arrange
            var courseId = Guid.NewGuid();
            var courseVersions = new List<CourseVersion>
    {
        new CourseVersion { Id = Guid.NewGuid(), Title = "Title1", Code = "Code1", Description = "Description1", Price = 100, CurrentStatus = 1 },
        new CourseVersion { Id = Guid.NewGuid(), Title = "Title2", Code = "Code2", Description = "Description2", Price = 200, CurrentStatus = 2 }
    };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAllAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), "Category,Level"))
                .ReturnsAsync(courseVersions);

            _mockMapper.Setup(m => m.Map<List<GetCourseVersionDTO>>(It.IsAny<List<CourseVersion>>()))
                .Returns(new List<GetCourseVersionDTO>());

            // Act
            var result = await _service.GetCourseVersions(
                new ClaimsPrincipal(),
                courseId,
                null,
                null,
                null,
                true,
                1,
                10
            );

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Result);
            Assert.IsType<List<GetCourseVersionDTO>>(result.Result);
        }
        [Fact]
        public async Task GetCourseVersions_ReturnsNotFound_WhenNoCourseVersions()
        {
            // Arrange
            var courseId = Guid.NewGuid();

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAllAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), "Category,Level"))
                .ReturnsAsync(new List<CourseVersion>());

            // Act
            var result = await _service.GetCourseVersions(
                new ClaimsPrincipal(),
                courseId,
                null,
                null,
                null,
                true,
                1,
                10
            );

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Null(result.Result);
        }
        [Fact]
        public async Task GetCourseVersions_ReturnsError_WhenExceptionThrown()
        {
            // Arrange
            var courseId = Guid.NewGuid();

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAllAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), "Category,Level"))
                .ThrowsAsync(new Exception("Test exception"));

            // Act
            var result = await _service.GetCourseVersions(
                new ClaimsPrincipal(),
                courseId,
                null,
                null,
                null,
                true,
                1,
                10
            );

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Test exception", result.Message);
            Assert.Null(result.Result);
        }
        [Fact]
        public async Task GetCourseVersions_ReturnsFilteredResults_WhenFilterCriteriaProvided()
        {
            // Arrange
            var courseId = Guid.NewGuid();
            var courseVersions = new List<CourseVersion>
    {
        new CourseVersion { Id = Guid.NewGuid(), Title = "Advanced Title", Code = "Code1", Description = "Advanced Description", Price = 150, CurrentStatus = 1 },
        new CourseVersion { Id = Guid.NewGuid(), Title = "Basic Title", Code = "Code2", Description = "Basic Description", Price = 100, CurrentStatus = 1 }
    };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAllAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), "Category,Level"))
                .ReturnsAsync(courseVersions);

            _mockMapper.Setup(m => m.Map<List<GetCourseVersionDTO>>(It.IsAny<List<CourseVersion>>()))
                .Returns((List<CourseVersion> cv) => cv.Select(c => new GetCourseVersionDTO { Title = c.Title }).ToList());

            // Act
            var result = await _service.GetCourseVersions(
                new ClaimsPrincipal(),
                courseId,
                "title",
                "Advanced",
                null,
                true,
                1,
                10
            );

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Result);
            var courseVersionDtos = result.Result as List<GetCourseVersionDTO>;
            Assert.Single(courseVersionDtos);
            Assert.Contains(courseVersionDtos, dto => dto.Title.Contains("Advanced", StringComparison.CurrentCultureIgnoreCase));
        }

        [Fact]
        public async Task GetCourseVersions_ReturnsSortedResults_WhenSortCriteriaProvided()
        {
            // Arrange
            var courseId = Guid.NewGuid();
            var courseVersions = new List<CourseVersion>
    {
        new CourseVersion { Id = Guid.NewGuid(), Title = "Title B", Code = "Code1", Description = "Description1", Price = 200, CurrentStatus = 1 },
        new CourseVersion { Id = Guid.NewGuid(), Title = "Title A", Code = "Code2", Description = "Description2", Price = 100, CurrentStatus = 1 }
    };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAllAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), "Category,Level"))
                .ReturnsAsync(courseVersions);

            _mockMapper.Setup(m => m.Map<List<GetCourseVersionDTO>>(It.IsAny<List<CourseVersion>>()))
                .Returns((List<CourseVersion> cv) => cv.Select(c => new GetCourseVersionDTO { Title = c.Title }).ToList());

            // Act
            var result = await _service.GetCourseVersions(
                new ClaimsPrincipal(),
                courseId,
                null,
                null,
                "title",
                true,
                1,
                10
            );

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Result);
            var courseVersionDtos = result.Result as List<GetCourseVersionDTO>;
            Assert.Equal("Title A", courseVersionDtos.FirstOrDefault()?.Title);
        }
        [Fact]
        public async Task GetCourseVersions_ReturnsPaginatedResults_WhenPageNumberAndSizeProvided()
        {
            // Arrange
            var courseId = Guid.NewGuid();
            var courseVersions = new List<CourseVersion>
    {
        new CourseVersion { Id = Guid.NewGuid(), Title = "Title1", Code = "Code1", Description = "Description1", Price = 100, CurrentStatus = 1 },
        new CourseVersion { Id = Guid.NewGuid(), Title = "Title2", Code = "Code2", Description = "Description2", Price = 200, CurrentStatus = 1 },
        new CourseVersion { Id = Guid.NewGuid(), Title = "Title3", Code = "Code3", Description = "Description3", Price = 300, CurrentStatus = 1 }
    };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAllAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), "Category,Level"))
                .ReturnsAsync(courseVersions);

            _mockMapper.Setup(m => m.Map<List<GetCourseVersionDTO>>(It.IsAny<List<CourseVersion>>()))
                .Returns((List<CourseVersion> cv) => cv.Select(c => new GetCourseVersionDTO { Title = c.Title }).ToList());

            // Act
            var result = await _service.GetCourseVersions(
                new ClaimsPrincipal(),
                courseId,
                null,
                null,
                null,
                true,
                2, // Page Number
                1  // Page Size
            );

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Result);
            var courseVersionDtos = result.Result as List<GetCourseVersionDTO>;
            Assert.Single(courseVersionDtos);
            Assert.Equal("Title2", courseVersionDtos[0].Title);
        }
        [Fact]
        public async Task GetCourseVersion_ReturnsSuccess_WhenCourseVersionExists()
        {
            // Arrange
            var courseVersionId = Guid.NewGuid();
            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                Title = "Sample Course Version",
                Code = "CV001",
                Description = "Sample Description",
                Price = 100,
                CurrentStatus = 1
            };

            var courseVersionDto = new GetCourseVersionDTO
            {
                Title = courseVersion.Title,
                Code = courseVersion.Code,
                Description = courseVersion.Description,
                Price = courseVersion.Price,
                CurrentStatus = courseVersion.CurrentStatus
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(
                It.IsAny<Expression<Func<CourseVersion, bool>>>(),
                "Category,Level"))
                .ReturnsAsync(courseVersion);

            _mockMapper.Setup(m => m.Map<GetCourseVersionDTO>(It.IsAny<CourseVersion>()))
                .Returns(courseVersionDto);

            // Act
            var result = await _service.GetCourseVersion(new ClaimsPrincipal(), courseVersionId);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Result);
            var resultDto = result.Result as GetCourseVersionDTO;
            Assert.Equal(courseVersion.Title, resultDto.Title);
            Assert.Equal(courseVersion.Code, resultDto.Code);
        }
        [Fact]
        public async Task GetCourseVersion_ReturnsNotFound_WhenCourseVersionDoesNotExist()
        {
            // Arrange
            var courseVersionId = Guid.NewGuid();

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(
                It.IsAny<Expression<Func<CourseVersion, bool>>>(),
                "Category,Level"))
                .ReturnsAsync((CourseVersion)null);

            // Act
            var result = await _service.GetCourseVersion(new ClaimsPrincipal(), courseVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode); // Adjust status code based on your implementation
            Assert.Equal("Course version was not found", result.Message);
            Assert.Null(result.Result);
        }
        [Fact]
        public async Task GetCourseVersion_ReturnsError_WhenExceptionThrown()
        {
            // Arrange
            var courseVersionId = Guid.NewGuid();
            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(
                It.IsAny<Expression<Func<CourseVersion, bool>>>(),
                "Category,Level"))
                .ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _service.GetCourseVersion(new ClaimsPrincipal(), courseVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Database error", result.Message);
            Assert.Null(result.Result);
        }
        [Fact]
        public async Task GetCourseVersion_ReturnsEmptyResult_WhenCourseVersionHasNoDetails()
        {
            // Arrange
            var courseVersionId = Guid.NewGuid();
            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                Title = "Course with No Details",
                Code = "CV002",
                Description = "No details",
                Price = 50,
                CurrentStatus = 1
            };

            var courseVersionDto = new GetCourseVersionDTO
            {
                Title = courseVersion.Title,
                Code = courseVersion.Code,
                Description = courseVersion.Description,
                Price = courseVersion.Price,
                CurrentStatus = courseVersion.CurrentStatus
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(
                It.IsAny<Expression<Func<CourseVersion, bool>>>(),
                "Category,Level"))
                .ReturnsAsync(courseVersion);

            _mockMapper.Setup(m => m.Map<GetCourseVersionDTO>(It.IsAny<CourseVersion>()))
                .Returns(courseVersionDto);

            // Act
            var result = await _service.GetCourseVersion(new ClaimsPrincipal(), courseVersionId);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            var resultDto = result.Result as GetCourseVersionDTO;
            Assert.NotNull(resultDto);
            Assert.Equal(courseVersion.Title, resultDto.Title);
            Assert.Equal(courseVersion.Code, resultDto.Code);
        }
        [Fact]
        public async Task GetCourseVersion_ReturnsDifferentDetails_WhenMultipleCourseVersionsExist()
        {
            // Arrange
            var courseVersionId1 = Guid.NewGuid();
            var courseVersionId2 = Guid.NewGuid();

            var courseVersion1 = new CourseVersion
            {
                Id = courseVersionId1,
                Title = "First Course Version",
                Code = "CV001",
                Description = "First description",
                Price = 100,
                CurrentStatus = 1
            };

            var courseVersion2 = new CourseVersion
            {
                Id = courseVersionId2,
                Title = "Second Course Version",
                Code = "CV002",
                Description = "Second description",
                Price = 150,
                CurrentStatus = 2
            };

            var courseVersionDto2 = new GetCourseVersionDTO
            {
                Title = courseVersion2.Title,
                Code = courseVersion2.Code,
                Description = courseVersion2.Description,
                Price = courseVersion2.Price,
                CurrentStatus = courseVersion2.CurrentStatus
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(
                It.IsAny<Expression<Func<CourseVersion, bool>>>(),
                "Category,Level"))
                .ReturnsAsync(courseVersion2);

            _mockMapper.Setup(m => m.Map<GetCourseVersionDTO>(It.IsAny<CourseVersion>()))
                .Returns(courseVersionDto2);

            // Act
            var result = await _service.GetCourseVersion(new ClaimsPrincipal(), courseVersionId2);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            var resultDto = result.Result as GetCourseVersionDTO;
            Assert.Equal(courseVersion2.Title, resultDto.Title);
            Assert.Equal(courseVersion2.Code, resultDto.Code);
        }
        [Fact]
        public async Task GetCourseVersion_ReturnsNull_WhenCourseVersionIdIsInvalid()
        {
            // Arrange
            var invalidCourseVersionId = Guid.Empty;

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(
                It.IsAny<Expression<Func<CourseVersion, bool>>>(),
                "Category,Level"))
                .ReturnsAsync((CourseVersion)null);

            // Act
            var result = await _service.GetCourseVersion(new ClaimsPrincipal(), invalidCourseVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("Course version was not found", result.Message);
            Assert.Null(result.Result);
        }
        [Fact]
        public async Task CreateCourseAndVersion_ReturnsSuccess_WhenValidInputs()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var createDto = new CreateNewCourseAndVersionDTO
            {
                Title = "New Course",
                Code = "NC001",
                Description = "Course Description",
                LearningTime = 10,
                Price = 100,
                CourseImgUrl = "http://example.com/image.png",
                CategoryId = Guid.NewGuid(),
                LevelId = Guid.NewGuid()
            };

            var instructor = new Instructor
            {
                InstructorId = Guid.NewGuid(),
                UserId = userId,
                IsAccepted = true,
                StripeAccountId = "stripe123"
            };

            var course = new Course
            {
                Id = Guid.NewGuid(),
                InstructorId = instructor.InstructorId
            };

            _mockUnitOfWork.Setup(uow => uow.InstructorRepository.GetAsync(It.IsAny<Expression<Func<Instructor, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(instructor);

            _mockCourseService.Setup(cs => cs.CreateFrameCourse(It.IsAny<ClaimsPrincipal>(), It.IsAny<Guid>()))
                .ReturnsAsync(new ResponseDTO { IsSuccess = true, Result = course });

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.AddAsync(It.IsAny<CourseVersion>()))
                .Returns(Task.CompletedTask);

            _mockCourseVersionStatusService.Setup(cvs => cvs.CreateCourseVersionStatus(It.IsAny<ClaimsPrincipal>(), It.IsAny<CreateCourseVersionStatusDTO>()))
                .ReturnsAsync(new ResponseDTO { IsSuccess = true });

            // Act
            var result = await _service.CreateCourseAndVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), createDto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.IsType<Guid>(result.Result);
        }
        [Fact]
        public async Task CreateCourseAndVersion_ReturnsNotFound_WhenInstructorNotFound()
        {
            // Arrange
            var userId = "user123";
            var createDto = new CreateNewCourseAndVersionDTO();

            _mockUnitOfWork.Setup(uow => uow.InstructorRepository.GetAsync(It.IsAny<Expression<Func<Instructor, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((Instructor)null);

            // Act
            var result = await _service.CreateCourseAndVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), createDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("Instructor was not found", result.Message);
        }
        [Fact]
        public async Task CreateCourseAndVersion_ReturnsForbidden_WhenInstructorNotAccepted()
        {
            // Arrange
            var userId = "user123";
            var createDto = new CreateNewCourseAndVersionDTO();
            var instructor = new Instructor
            {
                UserId = userId,
                IsAccepted = false
            };

            _mockUnitOfWork.Setup(uow => uow.InstructorRepository.GetAsync(It.IsAny<Expression<Func<Instructor, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(instructor);

            // Act
            var result = await _service.CreateCourseAndVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), createDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(403, result.StatusCode);
            Assert.Equal("Instructor was not allow to create course", result.Message);
        }
        [Fact]
        public async Task CreateCourseAndVersion_ReturnsBadRequest_WhenStripeAccountIdIsMissing()
        {
            // Arrange
            var userId = "user123";
            var createDto = new CreateNewCourseAndVersionDTO();
            var instructor = new Instructor
            {
                UserId = userId,
                IsAccepted = true,
                StripeAccountId = null
            };

            _mockUnitOfWork.Setup(uow => uow.InstructorRepository.GetAsync(It.IsAny<Expression<Func<Instructor, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(instructor);

            // Act
            var result = await _service.CreateCourseAndVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), createDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Instructor need to create stripe account", result.Message);
        }
        [Fact]
        public async Task CreateCourseAndVersion_ReturnsError_WhenCourseCreationFails()
        {
            // Arrange
            var userId = "user123";
            var createDto = new CreateNewCourseAndVersionDTO();
            var instructor = new Instructor
            {
                UserId = userId,
                IsAccepted = true,
                StripeAccountId = "stripe123"
            };

            _mockUnitOfWork.Setup(uow => uow.InstructorRepository.GetAsync(It.IsAny<Expression<Func<Instructor, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(instructor);

            _mockCourseService.Setup(cs => cs.CreateFrameCourse(It.IsAny<ClaimsPrincipal>(), It.IsAny<Guid>()))
                .ReturnsAsync(new ResponseDTO { IsSuccess = false, Message = "Failed to create course" });

            // Act
            var result = await _service.CreateCourseAndVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), createDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(400, result.StatusCode); // Adjust status code based on your implementation
            Assert.Equal("Failed to create course", result.Message);
        }
        [Fact]
        public async Task CreateCourseAndVersion_ReturnsError_WhenExceptionThrown()
        {
            // Arrange
            var userId = "user123";
            var createDto = new CreateNewCourseAndVersionDTO();
            var instructor = new Instructor
            {
                UserId = userId,
                IsAccepted = true,
                StripeAccountId = "stripe123"
            };

            _mockUnitOfWork.Setup(uow => uow.InstructorRepository.GetAsync(It.IsAny<Expression<Func<Instructor, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(instructor);

            _mockCourseService.Setup(cs => cs.CreateFrameCourse(It.IsAny<ClaimsPrincipal>(), It.IsAny<Guid>()))
                .ThrowsAsync(new Exception("Unexpected error"));

            // Act
            var result = await _service.CreateCourseAndVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), createDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Unexpected error", result.Message);
        }
        [Fact]
        public async Task CloneCourseVersion_ReturnsSuccess_WhenValidInputs()
        {
            // Arrange
            var userId = "user123";
            var oldCourseVersionId = Guid.NewGuid();
            var newCourseVersionId = Guid.NewGuid();
            var cloneDto = new CloneCourseVersionDTO
            {
                CourseVersionId = oldCourseVersionId
            };

            var courseVersion = new CourseVersion
            {
                Id = oldCourseVersionId,
                CourseId = Guid.NewGuid(),
                Title = "Original Title",
                Version = 1
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetCourseVersionAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(courseVersion);

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetTotalCourseVersionsAsync(It.IsAny<Guid>()))
                .ReturnsAsync(1);

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.AddAsync(It.IsAny<CourseVersion>()))
                .Returns(Task.CompletedTask);

            _mockCourseSectionVersionService.Setup(cs => cs.CloneCourseSectionVersion(It.IsAny<ClaimsPrincipal>(), It.IsAny<CloneCourseSectionVersionDTO>()))
                .ReturnsAsync(new ResponseDTO { IsSuccess = true });

            _mockCourseVersionStatusService.Setup(cvs => cvs.CreateCourseVersionStatus(It.IsAny<ClaimsPrincipal>(), It.IsAny<CreateCourseVersionStatusDTO>()))
                .ReturnsAsync(new ResponseDTO { IsSuccess = true });

            // Act
            var result = await _service.CloneCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), cloneDto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Clone new course version successfully", result.Message);
        }
        [Fact]
        public async Task CloneCourseVersion_ReturnsNotFound_WhenCourseVersionDoesNotExist()
        {
            // Arrange
            var userId = "user123";
            var cloneDto = new CloneCourseVersionDTO
            {
                CourseVersionId = Guid.NewGuid()
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetCourseVersionAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync((CourseVersion)null);

            // Act
            var result = await _service.CloneCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), cloneDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("Course version does not exist", result.Message);
        }
        [Fact]
        public async Task CloneCourseVersion_ReturnsError_WhenCourseSectionVersionCloneFails()
        {
            // Arrange
            var userId = "user123";
            var oldCourseVersionId = Guid.NewGuid();
            var cloneDto = new CloneCourseVersionDTO
            {
                CourseVersionId = oldCourseVersionId
            };

            var courseVersion = new CourseVersion
            {
                Id = oldCourseVersionId,
                CourseId = Guid.NewGuid(),
                Title = "Original Title",
                Version = 1
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetCourseVersionAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(courseVersion);

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetTotalCourseVersionsAsync(It.IsAny<Guid>()))
                .ReturnsAsync(1);

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.AddAsync(It.IsAny<CourseVersion>()))
                .Returns(Task.CompletedTask);

            _mockCourseSectionVersionService.Setup(cs => cs.CloneCourseSectionVersion(It.IsAny<ClaimsPrincipal>(), It.IsAny<CloneCourseSectionVersionDTO>()))
                .ReturnsAsync(new ResponseDTO { StatusCode = 500, Message = "Error cloning section version" });

            // Act
            var result = await _service.CloneCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), cloneDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Error cloning section version", result.Message);
        }
        [Fact]
        public async Task CloneCourseVersion_ReturnsError_WhenCourseVersionStatusCreationFails()
        {
            // Arrange
            var userId = "user123";
            var oldCourseVersionId = Guid.NewGuid();
            var cloneDto = new CloneCourseVersionDTO
            {
                CourseVersionId = oldCourseVersionId
            };

            var courseVersion = new CourseVersion
            {
                Id = oldCourseVersionId,
                CourseId = Guid.NewGuid(),
                Title = "Original Title",
                Version = 1
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetCourseVersionAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(courseVersion);

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetTotalCourseVersionsAsync(It.IsAny<Guid>()))
                .ReturnsAsync(1);

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.AddAsync(It.IsAny<CourseVersion>()))
                .Returns(Task.CompletedTask);

            _mockCourseSectionVersionService.Setup(cs => cs.CloneCourseSectionVersion(It.IsAny<ClaimsPrincipal>(), It.IsAny<CloneCourseSectionVersionDTO>()))
                .ReturnsAsync(new ResponseDTO { IsSuccess = true });

            _mockCourseVersionStatusService.Setup(cvs => cvs.CreateCourseVersionStatus(It.IsAny<ClaimsPrincipal>(), It.IsAny<CreateCourseVersionStatusDTO>()))
                .ReturnsAsync(new ResponseDTO { IsSuccess = false, Message = "Error creating course version status" });

            // Act
            var result = await _service.CloneCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), cloneDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Error creating course version status", result.Message);
        }
        [Fact]
        public async Task CloneCourseVersion_ReturnsSuccess_WhenStatusIsNew()
        {
            // Arrange
            var userId = "user123";
            var oldCourseVersionId = Guid.NewGuid();
            var cloneDto = new CloneCourseVersionDTO
            {
                CourseVersionId = oldCourseVersionId
            };

            var courseVersion = new CourseVersion
            {
                Id = oldCourseVersionId,
                CourseId = Guid.NewGuid(),
                Title = "Original Title",
                Version = 1
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetCourseVersionAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(courseVersion);

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetTotalCourseVersionsAsync(It.IsAny<Guid>()))
                .ReturnsAsync(1);

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.AddAsync(It.IsAny<CourseVersion>()))
                .Returns(Task.CompletedTask);

            _mockCourseSectionVersionService.Setup(cs => cs.CloneCourseSectionVersion(It.IsAny<ClaimsPrincipal>(), It.IsAny<CloneCourseSectionVersionDTO>()))
                .ReturnsAsync(new ResponseDTO { IsSuccess = true });

            _mockCourseVersionStatusService.Setup(cvs => cvs.CreateCourseVersionStatus(It.IsAny<ClaimsPrincipal>(), It.IsAny<CreateCourseVersionStatusDTO>()))
                .ReturnsAsync(new ResponseDTO { IsSuccess = true });

            // Act
            var result = await _service.CloneCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), cloneDto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Clone new course version successfully", result.Message);
        }
        [Fact]
        public async Task CloneCourseVersion_ReturnsError_WhenExceptionThrown()
        {
            // Arrange
            var userId = "user123";
            var oldCourseVersionId = Guid.NewGuid();
            var cloneDto = new CloneCourseVersionDTO
            {
                CourseVersionId = oldCourseVersionId
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetCourseVersionAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ThrowsAsync(new Exception("Unexpected error"));

            // Act
            var result = await _service.CloneCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), cloneDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Unexpected error", result.Message);
        }
        [Fact]
        public async Task EditCourseVersion_ReturnsSuccess_WhenValidInputs()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var editDto = new EditCourseVersionDTO
            {
                Id = courseVersionId,
                Title = "Updated Title",
                Code = "Updated Code",
                Description = "Updated Description",
                LearningTime = 10,
                Price = 99.99,
                CourseImgUrl = "http://example.com/image.png",
                CategoryId = Guid.NewGuid(),
                LevelId = Guid.NewGuid()
            };

            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                CurrentStatus = StaticCourseVersionStatus.New
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersion);

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.Update(It.IsAny<CourseVersion>()))
                .Verifiable();

            _mockUnitOfWork.Setup(uow => uow.SaveAsync())
                .ReturnsAsync(1);

            // Act
            var result = await _service.EditCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), editDto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Update course version successfully", result.Message);
            _mockUnitOfWork.Verify();
        }
        [Fact]
        public async Task EditCourseVersion_ReturnsNotFound_WhenCourseVersionDoesNotExist()
        {
            // Arrange
            var userId = "user123";
            var editDto = new EditCourseVersionDTO
            {
                Id = Guid.NewGuid()
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((CourseVersion)null);

            // Act
            var result = await _service.EditCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), editDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("Course version was not found", result.Message);
        }
        [Fact]
        public async Task EditCourseVersion_ReturnsError_WhenCourseVersionSubmitted()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var editDto = new EditCourseVersionDTO
            {
                Id = courseVersionId
            };

            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                CurrentStatus = StaticCourseVersionStatus.Submitted
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersion);

            // Act
            var result = await _service.EditCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), editDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(401, result.StatusCode);
            Assert.Equal("This course version was submitted", result.Message);
        }
        [Fact]
        public async Task EditCourseVersion_ReturnsError_WhenCourseVersionMerged()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var editDto = new EditCourseVersionDTO
            {
                Id = courseVersionId
            };

            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                CurrentStatus = StaticCourseVersionStatus.Merged
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersion);

            // Act
            var result = await _service.EditCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), editDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(401, result.StatusCode);
            Assert.Equal("This course version was merged", result.Message);
        }
        [Fact]
        public async Task EditCourseVersion_ReturnsError_WhenCourseVersionRemoved()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var editDto = new EditCourseVersionDTO
            {
                Id = courseVersionId
            };

            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                CurrentStatus = StaticCourseVersionStatus.Removed
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersion);

            // Act
            var result = await _service.EditCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), editDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(401, result.StatusCode);
            Assert.Equal("This course version was removed", result.Message);
        }
        [Fact]
        public async Task EditCourseVersion_ReturnsError_WhenExceptionThrown()
        {
            // Arrange
            var userId = "user123";
            var editDto = new EditCourseVersionDTO
            {
                Id = Guid.NewGuid()
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception("Unexpected error"));

            // Act
            var result = await _service.EditCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), editDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Unexpected error", result.Message);
        }

        [Fact]
        public async Task RemoveCourseVersion_ReturnsSuccess_WhenValidInputs()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                CurrentStatus = StaticCourseVersionStatus.New
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersion);

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.Update(It.IsAny<CourseVersion>()))
                .Verifiable();

            _mockUnitOfWork.Setup(uow => uow.SaveAsync())
                .ReturnsAsync(1);

            _mockCourseVersionStatusService.Setup(s => s.CreateCourseVersionStatus(It.IsAny<ClaimsPrincipal>(), It.IsAny<CreateCourseVersionStatusDTO>()))
                .ReturnsAsync(new ResponseDTO { IsSuccess = true, StatusCode = 200 });

            // Act
            var result = await _service.RemoveCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Remove course version successfully", result.Message);
            _mockUnitOfWork.Verify();
        }
        [Fact]
        public async Task RemoveCourseVersion_ReturnsNotFound_WhenCourseVersionDoesNotExist()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((CourseVersion)null);

            // Act
            var result = await _service.RemoveCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("Course version was not found", result.Message);
        }
        [Fact]
        public async Task RemoveCourseVersion_ReturnsError_WhenCourseVersionSubmitted()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                CurrentStatus = StaticCourseVersionStatus.Submitted
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersion);

            // Act
            var result = await _service.RemoveCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(401, result.StatusCode);
            Assert.Equal("Course version have been submitted", result.Message);
        }
        [Fact]
        public async Task RemoveCourseVersion_ReturnsError_WhenCourseVersionMerged()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                CurrentStatus = StaticCourseVersionStatus.Merged
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersion);

            // Act
            var result = await _service.RemoveCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(401, result.StatusCode);
            Assert.Equal("Course version have been merged", result.Message);
        }
        [Fact]
        public async Task RemoveCourseVersion_ReturnsError_WhenCourseVersionRemoved()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                CurrentStatus = StaticCourseVersionStatus.Removed
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersion);

            // Act
            var result = await _service.RemoveCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(401, result.StatusCode);
            Assert.Equal("Course version have been removed", result.Message);
        }
        [Fact]
        public async Task RemoveCourseVersion_ReturnsError_WhenExceptionThrown()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception("Unexpected error"));

            // Act
            var result = await _service.RemoveCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Unexpected error", result.Message);
        }
        [Fact]
        public async Task AcceptCourseVersion_ReturnsSuccess_WhenValidInputs()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                CurrentStatus = StaticCourseVersionStatus.New
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersion);

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.Update(It.IsAny<CourseVersion>()))
                .Verifiable();

            _mockUnitOfWork.Setup(uow => uow.SaveAsync())
                .ReturnsAsync(1);

            _mockCourseVersionStatusService.Setup(s => s.CreateCourseVersionStatus(It.IsAny<ClaimsPrincipal>(), It.IsAny<CreateCourseVersionStatusDTO>()))
                .ReturnsAsync(new ResponseDTO { IsSuccess = true, StatusCode = 200 });

            _mockBackgroundJobClient.Setup(b => b.Enqueue(It.IsAny<Expression<Func<IEmailSender, Task>>>()))
                .Verifiable();

            // Act
            var result = await _service.AcceptCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Accept course version successfully", result.Message);
            _mockUnitOfWork.Verify();
            _mockBackgroundJobClient.Verify();
        }
        [Fact]
        public async Task AcceptCourseVersion_ReturnsNotFound_WhenCourseVersionDoesNotExist()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((CourseVersion)null);

            // Act
            var result = await _service.AcceptCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("Course version was not found", result.Message);
        }
        [Fact]
        public async Task AcceptCourseVersion_ReturnsError_WhenCourseVersionNotSubmitted()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                CurrentStatus = StaticCourseVersionStatus.New
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersion);

            // Act
            var result = await _service.AcceptCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(401, result.StatusCode);
            Assert.Equal("Course version have not been submit", result.Message);
        }
        [Fact]
        public async Task AcceptCourseVersion_ReturnsError_WhenCourseVersionAccepted()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                CurrentStatus = StaticCourseVersionStatus.Accepted
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersion);

            // Act
            var result = await _service.AcceptCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(401, result.StatusCode);
            Assert.Equal("Course version have been accepted", result.Message);
        }
        [Fact]
        public async Task AcceptCourseVersion_ReturnsError_WhenCourseVersionMerged()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                CurrentStatus = StaticCourseVersionStatus.Merged
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersion);

            // Act
            var result = await _service.AcceptCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(401, result.StatusCode);
            Assert.Equal("Course version have been merged", result.Message);
        }
        [Fact]
        public async Task AcceptCourseVersion_ReturnsError_WhenExceptionThrown()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception("Unexpected error"));

            // Act
            var result = await _service.AcceptCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Unexpected error", result.Message);
        }
        [Fact]
        public async Task RejectCourseVersion_ReturnsSuccess_WhenValidInputs()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                CurrentStatus = StaticCourseVersionStatus.New
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersion);

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.Update(It.IsAny<CourseVersion>()))
                .Verifiable();

            _mockUnitOfWork.Setup(uow => uow.SaveAsync())
                .ReturnsAsync(1);

            _mockCourseVersionStatusService.Setup(s => s.CreateCourseVersionStatus(It.IsAny<ClaimsPrincipal>(), It.IsAny<CreateCourseVersionStatusDTO>()))
                .ReturnsAsync(new ResponseDTO { IsSuccess = true, StatusCode = 200 });

            _mockBackgroundJobClient.Setup(b => b.Enqueue(It.IsAny<Expression<Func<IEmailSender, Task>>>()))
                .Verifiable();

            // Act
            var result = await _service.RejectCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Reject course version successfully", result.Message);
            _mockUnitOfWork.Verify();
            _mockBackgroundJobClient.Verify();
        }

        [Fact]
        public async Task RejectCourseVersion_ReturnsNotFound_WhenCourseVersionDoesNotExist()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((CourseVersion)null);

            // Act
            var result = await _service.RejectCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("Course version was not found", result.Message);
        }

        [Fact]
        public async Task RejectCourseVersion_ReturnsUnauthorized_WhenCourseVersionIsAccepted()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                CurrentStatus = StaticCourseVersionStatus.Accepted
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersion);

            // Act
            var result = await _service.RejectCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(401, result.StatusCode);
            Assert.Equal("Course version have been accepted", result.Message);
        }

        [Fact]
        public async Task RejectCourseVersion_ReturnsUnauthorized_WhenCourseVersionIsMerged()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                CurrentStatus = StaticCourseVersionStatus.Merged
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersion);

            // Act
            var result = await _service.RejectCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(401, result.StatusCode);
            Assert.Equal("Course version have been merged", result.Message);
        }

        [Fact]
        public async Task RejectCourseVersion_ReturnsUnauthorized_WhenCourseVersionIsRemoved()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                CurrentStatus = StaticCourseVersionStatus.Removed
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersion);

            // Act
            var result = await _service.RejectCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(401, result.StatusCode);
            Assert.Equal("Course version have been removed", result.Message);
        }

        [Fact]
        public async Task RejectCourseVersion_ReturnsServerError_WhenStatusServiceFails()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                CurrentStatus = StaticCourseVersionStatus.New
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersion);

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.Update(It.IsAny<CourseVersion>()))
                .Verifiable();

            _mockUnitOfWork.Setup(uow => uow.SaveAsync())
                .ReturnsAsync(1);

            _mockCourseVersionStatusService.Setup(s => s.CreateCourseVersionStatus(It.IsAny<ClaimsPrincipal>(), It.IsAny<CreateCourseVersionStatusDTO>()))
                .ReturnsAsync(new ResponseDTO { IsSuccess = false, StatusCode = 500 });

            // Act
            var result = await _service.RejectCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("An error occurred while processing your request.", result.Message); // Adjust this message according to your implementation
        }
        [Fact]
        public async Task SubmitCourseVersion_ReturnsSuccess_WhenValidInputs()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                CurrentStatus = StaticCourseVersionStatus.New
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersion);

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.Update(It.IsAny<CourseVersion>()))
                .Verifiable();

            _mockUnitOfWork.Setup(uow => uow.SaveAsync())
                .ReturnsAsync(1);

            _mockCourseVersionStatusService.Setup(s => s.CreateCourseVersionStatus(It.IsAny<ClaimsPrincipal>(), It.IsAny<CreateCourseVersionStatusDTO>()))
                .ReturnsAsync(new ResponseDTO { IsSuccess = true, StatusCode = 200 });

            _mockBackgroundJobClient.Setup(b => b.Enqueue(It.IsAny<Expression<Func<IEmailSender, Task>>>()))
                .Verifiable();

            // Act
            var result = await _service.SubmitCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Submit course version successfully", result.Message);
            _mockUnitOfWork.Verify();
            _mockBackgroundJobClient.Verify();
        }

        [Fact]
        public async Task SubmitCourseVersion_ReturnsNotFound_WhenCourseVersionDoesNotExist()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((CourseVersion)null);

            // Act
            var result = await _service.SubmitCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("Course version was not found", result.Message);
        }

        [Fact]
        public async Task SubmitCourseVersion_ReturnsUnauthorized_WhenCourseVersionIsSubmitted()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                CurrentStatus = StaticCourseVersionStatus.Submitted
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersion);

            // Act
            var result = await _service.SubmitCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(401, result.StatusCode);
            Assert.Equal("Course version have been submitted", result.Message);
        }

        [Fact]
        public async Task SubmitCourseVersion_ReturnsUnauthorized_WhenCourseVersionIsAccepted()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                CurrentStatus = StaticCourseVersionStatus.Accepted
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersion);

            // Act
            var result = await _service.SubmitCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(401, result.StatusCode);
            Assert.Equal("Course version have been accepted", result.Message);
        }

        [Fact]
        public async Task SubmitCourseVersion_ReturnsUnauthorized_WhenCourseVersionIsMerged()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                CurrentStatus = StaticCourseVersionStatus.Merged
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersion);

            // Act
            var result = await _service.SubmitCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(401, result.StatusCode);
            Assert.Equal("Course version have been merged", result.Message);
        }

        [Fact]
        public async Task SubmitCourseVersion_ReturnsUnauthorized_WhenCourseVersionIsRemoved()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                CurrentStatus = StaticCourseVersionStatus.Removed
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersion);

            // Act
            var result = await _service.SubmitCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(401, result.StatusCode);
            Assert.Equal("Course version have been removed", result.Message);
        }

        [Fact]
        public async Task SubmitCourseVersion_ReturnsServerError_WhenStatusServiceFails()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                CurrentStatus = StaticCourseVersionStatus.New
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersion);

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.Update(It.IsAny<CourseVersion>()))
                .Verifiable();

            _mockUnitOfWork.Setup(uow => uow.SaveAsync())
                .ReturnsAsync(1);

            _mockCourseVersionStatusService.Setup(s => s.CreateCourseVersionStatus(It.IsAny<ClaimsPrincipal>(), It.IsAny<CreateCourseVersionStatusDTO>()))
                .ReturnsAsync(new ResponseDTO { IsSuccess = false, StatusCode = 500 });

            // Act
            var result = await _service.SubmitCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("An error occurred while processing your request.", result.Message); // Adjust this message according to your implementation
        }
        [Fact]
        public async Task MergeCourseVersion_ReturnsSuccess_WhenValidInputs()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var courseId = Guid.NewGuid();
            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                CourseId = courseId,
                CurrentStatus = StaticCourseVersionStatus.Submitted
            };
            var course = new Course
            {
                Id = courseId,
                CourseVersionId = Guid.Empty
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersion);
            _mockUnitOfWork.Setup(uow => uow.CourseRepository.GetAsync(It.IsAny<Expression<Func<Course, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(course);

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.Update(It.IsAny<CourseVersion>()))
                .Verifiable();
            _mockUnitOfWork.Setup(uow => uow.CourseRepository.Update(It.IsAny<Course>()))
                .Verifiable();
            _mockUnitOfWork.Setup(uow => uow.SaveAsync())
                .ReturnsAsync(1);

            _mockCourseVersionStatusService.Setup(s => s.CreateCourseVersionStatus(It.IsAny<ClaimsPrincipal>(), It.IsAny<CreateCourseVersionStatusDTO>()))
                .ReturnsAsync(new ResponseDTO { IsSuccess = true, StatusCode = 200 });

            // Act
            var result = await _service.MergeCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Submit course version successfully", result.Message);
            _mockUnitOfWork.Verify();
        }

        [Fact]
        public async Task MergeCourseVersion_ReturnsNotFound_WhenCourseVersionDoesNotExist()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((CourseVersion)null);

            // Act
            var result = await _service.MergeCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("Course version was not found", result.Message);
        }

        [Fact]
        public async Task MergeCourseVersion_ReturnsNotFound_WhenCourseDoesNotExist()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var courseId = Guid.NewGuid();
            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                CourseId = courseId,
                CurrentStatus = StaticCourseVersionStatus.Submitted
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersion);
            _mockUnitOfWork.Setup(uow => uow.CourseRepository.GetAsync(It.IsAny<Expression<Func<Course, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((Course)null);

            // Act
            var result = await _service.MergeCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("Course was not found", result.Message);
        }

        [Fact]
        public async Task MergeCourseVersion_ReturnsUnauthorized_WhenCourseVersionIsNew()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                CurrentStatus = StaticCourseVersionStatus.New
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersion);

            // Act
            var result = await _service.MergeCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(401, result.StatusCode);
            Assert.Equal("Course version have not been submit", result.Message);
        }

        [Fact]
        public async Task MergeCourseVersion_ReturnsUnauthorized_WhenCourseVersionIsRejected()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                CurrentStatus = StaticCourseVersionStatus.Rejected
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersion);

            // Act
            var result = await _service.MergeCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(401, result.StatusCode);
            Assert.Equal("Course version have been rejected", result.Message);
        }

        [Fact]
        public async Task MergeCourseVersion_ReturnsUnauthorized_WhenCourseVersionIsSubmitted()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                CurrentStatus = StaticCourseVersionStatus.Submitted
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersion);

            // Act
            var result = await _service.MergeCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(401, result.StatusCode);
            Assert.Equal("Course version have been submitted", result.Message);
        }

        [Fact]
        public async Task MergeCourseVersion_ReturnsUnauthorized_WhenCourseVersionIsMerged()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                CurrentStatus = StaticCourseVersionStatus.Merged
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersion);

            // Act
            var result = await _service.MergeCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(401, result.StatusCode);
            Assert.Equal("Course version have been merged", result.Message);
        }

        [Fact]
        public async Task MergeCourseVersion_ReturnsUnauthorized_WhenCourseVersionIsRemoved()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                CurrentStatus = StaticCourseVersionStatus.Removed
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersion);

            // Act
            var result = await _service.MergeCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(401, result.StatusCode);
            Assert.Equal("Course version have been removed", result.Message);
        }

        [Fact]
        public async Task MergeCourseVersion_ReturnsServerError_WhenStatusServiceFails()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var courseId = Guid.NewGuid();
            var courseVersion = new CourseVersion
            {
                Id = courseVersionId,
                CourseId = courseId,
                CurrentStatus = StaticCourseVersionStatus.Submitted
            };
            var course = new Course
            {
                Id = courseId,
                CourseVersionId = Guid.Empty
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersion);
            _mockUnitOfWork.Setup(uow => uow.CourseRepository.GetAsync(It.IsAny<Expression<Func<Course, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(course);

            _mockUnitOfWork.Setup(uow => uow.CourseVersionRepository.Update(It.IsAny<CourseVersion>()))
                .Verifiable();
            _mockUnitOfWork.Setup(uow => uow.CourseRepository.Update(It.IsAny<Course>()))
                .Verifiable();
            _mockUnitOfWork.Setup(uow => uow.SaveAsync())
                .ReturnsAsync(1);

            _mockCourseVersionStatusService.Setup(s => s.CreateCourseVersionStatus(It.IsAny<ClaimsPrincipal>(), It.IsAny<CreateCourseVersionStatusDTO>()))
                .ReturnsAsync(new ResponseDTO { IsSuccess = false, StatusCode = 500, Message = "Internal Server Error" });

            // Act
            var result = await _service.MergeCourseVersion(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Internal Server Error", result.Message);
        }
        [Fact]
        public async Task GetCourseVersionsComments_ReturnsNoComments_WhenNoCommentsExist()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            _mockUnitOfWork.Setup(uow => uow.CourseVersionCommentRepository.GetAllAsync(It.IsAny<Expression<Func<CourseVersionComment, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(Enumerable.Empty<CourseVersionComment>());

            // Act
            var result = await _service.GetCourseVersionsComments(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId, null, null, null, 1, 10);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(204, result.StatusCode);
            Assert.Null(result.Result);
            Assert.Equal("There are no comments", result.Message);
        }

        [Fact]
        public async Task GetCourseVersionsComments_ReturnsFilteredComments_WhenValidFilterQuery()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var comments = new List<CourseVersionComment>
        {
            new CourseVersionComment { Id = Guid.NewGuid(), Comment = "Great course", CreatedBy = "User1", UpdatedBy = "User2", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now, Status = 1 },
            new CourseVersionComment { Id = Guid.NewGuid(), Comment = "Needs improvement", CreatedBy = "User3", UpdatedBy = "User4", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now, Status = 2 }
        };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionCommentRepository.GetAllAsync(It.IsAny<Expression<Func<CourseVersionComment, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(comments);

            // Act
            var result = await _service.GetCourseVersionsComments(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId, "comment", "Great", null, 1, 10);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            var commentsDto = (List<GetAllCommentsDTO>)result.Result;
            Assert.Single(commentsDto);
            Assert.Equal("Great course", commentsDto[0].Comment);
        }

        [Fact]
        public async Task GetCourseVersionsComments_ReturnsSortedComments_WhenValidSortQuery()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var comments = new List<CourseVersionComment>
        {
            new CourseVersionComment { Id = Guid.NewGuid(), Comment = "B", CreatedBy = "User1", UpdatedBy = "User2", CreatedTime = DateTime.Now.AddHours(1), UpdatedTime = DateTime.Now, Status = 1 },
            new CourseVersionComment { Id = Guid.NewGuid(), Comment = "A", CreatedBy = "User3", UpdatedBy = "User4", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now, Status = 2 }
        };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionCommentRepository.GetAllAsync(It.IsAny<Expression<Func<CourseVersionComment, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(comments);

            // Act
            var result = await _service.GetCourseVersionsComments(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId, null, null, "comment", 1, 10);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            var commentsDto = (List<GetAllCommentsDTO>)result.Result;
            Assert.Equal("A", commentsDto[0].Comment);
            Assert.Equal("B", commentsDto[1].Comment);
        }

        [Fact]
        public async Task GetCourseVersionsComments_ReturnsPagedComments_WhenPaginationIsApplied()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var comments = new List<CourseVersionComment>
        {
            new CourseVersionComment { Id = Guid.NewGuid(), Comment = "Comment1", CreatedBy = "User1", UpdatedBy = "User2", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now, Status = 1 },
            new CourseVersionComment { Id = Guid.NewGuid(), Comment = "Comment2", CreatedBy = "User3", UpdatedBy = "User4", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now, Status = 2 },
            new CourseVersionComment { Id = Guid.NewGuid(), Comment = "Comment3", CreatedBy = "User5", UpdatedBy = "User6", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now, Status = 1 }
        };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionCommentRepository.GetAllAsync(It.IsAny<Expression<Func<CourseVersionComment, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(comments);

            // Act
            var result = await _service.GetCourseVersionsComments(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId, null, null, null, 1, 2);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            var commentsDto = (List<GetAllCommentsDTO>)result.Result;
            Assert.Equal(2, commentsDto.Count);
            Assert.Equal("Comment1", commentsDto[0].Comment);
            Assert.Equal("Comment2", commentsDto[1].Comment);
        }

        [Fact]
        public async Task GetCourseVersionsComments_ReturnsFilteredAndSortedComments_WhenBothApplied()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var comments = new List<CourseVersionComment>
        {
            new CourseVersionComment { Id = Guid.NewGuid(), Comment = "Comment A", CreatedBy = "User1", UpdatedBy = "User2", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now, Status = 1 },
            new CourseVersionComment { Id = Guid.NewGuid(), Comment = "Comment B", CreatedBy = "User3", UpdatedBy = "User4", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now, Status = 1 },
            new CourseVersionComment { Id = Guid.NewGuid(), Comment = "Comment C", CreatedBy = "User5", UpdatedBy = "User6", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now, Status = 2 }
        };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionCommentRepository.GetAllAsync(It.IsAny<Expression<Func<CourseVersionComment, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(comments);

            // Act
            var result = await _service.GetCourseVersionsComments(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId, "status", "1", "comment", 1, 10);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            var commentsDto = (List<GetAllCommentsDTO>)result.Result;
            Assert.Equal(2, commentsDto.Count);
            Assert.Equal("Comment A", commentsDto[0].Comment);
            Assert.Equal("Comment B", commentsDto[1].Comment);
        }

        [Fact]
        public async Task GetCourseVersionsComments_ReturnsServerError_WhenExceptionThrown()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();

            _mockUnitOfWork.Setup(uow => uow.CourseVersionCommentRepository.GetAllAsync(It.IsAny<Expression<Func<CourseVersionComment, bool>>>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _service.GetCourseVersionsComments(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId, null, null, null, 1, 10);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Database error", result.Message);
        }

        [Fact]
        public async Task GetCourseVersionsComments_ReturnsEmptyList_WhenInvalidFilterQuery()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var comments = new List<CourseVersionComment>
        {
            new CourseVersionComment { Id = Guid.NewGuid(), Comment = "Valid Comment", CreatedBy = "User1", UpdatedBy = "User2", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now, Status = 1 }
        };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionCommentRepository.GetAllAsync(It.IsAny<Expression<Func<CourseVersionComment, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(comments);

            // Act
            var result = await _service.GetCourseVersionsComments(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId, "comment", "Invalid Query", null, 1, 10);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            var commentsDto = (List<GetAllCommentsDTO>)result.Result;
            Assert.Empty(commentsDto);
        }

        [Fact]
        public async Task GetCourseVersionsComments_ReturnsEmptyList_WhenInvalidSortQuery()
        {
            // Arrange
            var userId = "user123";
            var courseVersionId = Guid.NewGuid();
            var comments = new List<CourseVersionComment>
        {
            new CourseVersionComment { Id = Guid.NewGuid(), Comment = "Comment B", CreatedBy = "User1", UpdatedBy = "User2", CreatedTime = DateTime.Now.AddHours(1), UpdatedTime = DateTime.Now, Status = 1 },
            new CourseVersionComment { Id = Guid.NewGuid(), Comment = "Comment A", CreatedBy = "User3", UpdatedBy = "User4", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now, Status = 1 }
        };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionCommentRepository.GetAllAsync(It.IsAny<Expression<Func<CourseVersionComment, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(comments);

            // Act
            var result = await _service.GetCourseVersionsComments(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), courseVersionId, null, null, "invalidsort", 1, 10);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            var commentsDto = (List<GetAllCommentsDTO>)result.Result;
            Assert.Equal(2, commentsDto.Count);
            Assert.Equal("Comment A", commentsDto[0].Comment);
            Assert.Equal("Comment B", commentsDto[1].Comment);
        }
        [Fact]
        public async Task GetCourseVersionComment_ReturnsNotFound_WhenCommentDoesNotExist()
        {
            // Arrange
            var userId = "user123";
            var commentId = Guid.NewGuid();
            _mockUnitOfWork.Setup(uow => uow.CourseVersionCommentRepository.GetCourseVersionCommentById(commentId))
                .ReturnsAsync((CourseVersionComment)null);

            // Act
            var result = await _service.GetCourseVersionComment(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), commentId);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("Course version was not found", result.Message);
            Assert.Equal("", result.Result);
        }

        [Fact]
        public async Task GetCourseVersionComment_ReturnsCourseVersionComment_WhenCommentExists()
        {
            // Arrange
            var userId = "user123";
            var commentId = Guid.NewGuid();
            var comment = new CourseVersionComment
            {
                Id = commentId,
                Comment = "Sample Comment",
                CreatedBy = "User1",
                UpdatedBy = "User2",
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now,
                Status = 1
            };
            var commentDto = new GetCourseCommnetDTO
            {
                Comment = "Sample Comment",
                CreateBy = "User1",
                UpdateBy = "User2",
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                Status = 1
            };

            _mockUnitOfWork.Setup(uow => uow.CourseVersionCommentRepository.GetCourseVersionCommentById(commentId))
                .ReturnsAsync(comment);
            _mockMapper.Setup(m => m.Map<GetCourseCommnetDTO>(comment)).Returns(commentDto);

            // Act
            var result = await _service.GetCourseVersionComment(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), commentId);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Get course version successfully", result.Message);
            Assert.Equal(commentDto, result.Result);
        }

        [Fact]
        public async Task GetCourseVersionComment_ReturnsServerError_WhenExceptionThrown()
        {
            // Arrange
            var userId = "user123";
            var commentId = Guid.NewGuid();

            _mockUnitOfWork.Setup(uow => uow.CourseVersionCommentRepository.GetCourseVersionCommentById(commentId))
                .ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _service.GetCourseVersionComment(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) })), commentId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Database error", result.Message);
            Assert.Null(result.Result);
        }

        [Fact]
        public async Task EditCourseVersionComment_CourseVersionCommentNotFound_Returns400()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var editCourseVersionCommentsDTO = new EditCourseVersionCommentsDTO { Id = Guid.NewGuid(), Comment = "Updated comment" };

            _mockUnitOfWork.Setup(u => u.CourseVersionCommentRepository.GetAsync(It.IsAny<Expression<Func<CourseVersionComment, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((CourseVersionComment)null);

            // Act
            var result = await _service.EditCourseVersionComment(claimsPrincipal, editCourseVersionCommentsDTO);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.False(result.IsSuccess);
            Assert.Equal("CourseVersionId Invalid", result.Message);
        }

        [Fact]
        public async Task EditCourseVersionComment_SuccessfullyEditsComment_Returns200()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var editCourseVersionCommentsDTO = new EditCourseVersionCommentsDTO { Id = Guid.NewGuid(), Comment = "Updated comment" };

            var courseVersionComment = new CourseVersionComment
            {
                Id = editCourseVersionCommentsDTO.Id,
                Comment = "Original comment",
                CreatedBy = "admin@domain.com",
                CreatedTime = DateTime.UtcNow.AddDays(-1),
                UpdatedBy = null,
                UpdatedTime = null,
                Status = 0
            };

            var admin = new ApplicationUser { Email = "admin@domain.com" };


            _mockUnitOfWork.Setup(u => u.CourseVersionCommentRepository.GetAsync(It.IsAny<Expression<Func<CourseVersionComment, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersionComment);
            _mockUnitOfWork.Setup(um => um.UserManagerRepository.FindByIdAsync(userId)).ReturnsAsync(admin);

            _mockUnitOfWork.Setup(u => u.CourseVersionCommentRepository.Update(It.IsAny<CourseVersionComment>()));
            _mockUnitOfWork.Setup(u => u.SaveAsync()).ReturnsAsync(1);

            // Act
            var result = await _service.EditCourseVersionComment(claimsPrincipal, editCourseVersionCommentsDTO);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.True(result.IsSuccess);
            Assert.Equal("Comment Edited successfully", result.Message);

            _mockUnitOfWork.Verify(u => u.CourseVersionCommentRepository.Update(It.Is<CourseVersionComment>(c =>
                c.Id == editCourseVersionCommentsDTO.Id &&
                c.Comment == editCourseVersionCommentsDTO.Comment &&
                c.UpdatedBy == admin.Email &&
                c.Status == 1)), Times.Once);

            _mockUnitOfWork.Verify(u => u.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task EditCourseVersionComment_UserNotFound_Returns404()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var editCourseVersionCommentsDTO = new EditCourseVersionCommentsDTO { Id = Guid.NewGuid(), Comment = "Updated comment" };

            var courseVersionComment = new CourseVersionComment
            {
                Id = editCourseVersionCommentsDTO.Id,
                Comment = "Original comment",
                CreatedBy = "admin@domain.com",
                CreatedTime = DateTime.UtcNow.AddDays(-1),
                UpdatedBy = null,
                UpdatedTime = null,
                Status = 0
            };

            _mockUnitOfWork.Setup(u => u.CourseVersionCommentRepository.GetAsync(It.IsAny<Expression<Func<CourseVersionComment, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersionComment);
            _mockUnitOfWork.Setup(um => um.UserManagerRepository.FindByIdAsync(userId)).ReturnsAsync((ApplicationUser)null);
            // Act
            var result = await _service.EditCourseVersionComment(claimsPrincipal, editCourseVersionCommentsDTO);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);
            Assert.False(result.IsSuccess);
            Assert.Equal("User not found", result.Message);
        }

        [Fact]
        public async Task EditCourseVersionComment_InvalidCourseVersionCommentId_Returns400()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var editCourseVersionCommentsDTO = new EditCourseVersionCommentsDTO { Id = Guid.Empty, Comment = "Updated comment" };


            _mockUnitOfWork.Setup(u => u.CourseVersionCommentRepository.GetAsync(It.IsAny<Expression<Func<CourseVersionComment, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((CourseVersionComment)null);
            // Act
            var result = await _service.EditCourseVersionComment(claimsPrincipal, editCourseVersionCommentsDTO);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.False(result.IsSuccess);
            Assert.Equal("CourseVersionId Invalid", result.Message);
        }

        [Fact]
        public async Task EditCourseVersionComment_EmptyComment_Returns400()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var editCourseVersionCommentsDTO = new EditCourseVersionCommentsDTO { Id = Guid.NewGuid(), Comment = "" };

            var courseVersionComment = new CourseVersionComment
            {
                Id = editCourseVersionCommentsDTO.Id,
                Comment = "Original comment",
                CreatedBy = "admin@domain.com",
                CreatedTime = DateTime.UtcNow.AddDays(-1),
                UpdatedBy = null,
                UpdatedTime = null,
                Status = 0
            };

            var admin = new ApplicationUser { Email = "admin@domain.com" };

            _mockUnitOfWork.Setup(u => u.CourseVersionCommentRepository.GetAsync(It.IsAny<Expression<Func<CourseVersionComment, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersionComment);
            _mockUnitOfWork.Setup(um => um.UserManagerRepository.FindByIdAsync(userId)).ReturnsAsync(admin);

            // Act
            var result = await _service.EditCourseVersionComment(claimsPrincipal, editCourseVersionCommentsDTO);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.False(result.IsSuccess);
            Assert.Equal("Comment cannot be empty", result.Message);
        }

        [Fact]
        public async Task EditCourseVersionComment_UnauthorizedUser_Returns403()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId),
            new Claim(ClaimTypes.Role, "User")
        };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var editCourseVersionCommentsDTO = new EditCourseVersionCommentsDTO { Id = Guid.NewGuid(), Comment = "Updated comment" };

            var courseVersionComment = new CourseVersionComment
            {
                Id = editCourseVersionCommentsDTO.Id,
                Comment = "Original comment",
                CreatedBy = "admin@domain.com",
                CreatedTime = DateTime.UtcNow.AddDays(-1),
                UpdatedBy = null,
                UpdatedTime = null,
                Status = 0
            };

            _mockUnitOfWork.Setup(u => u.CourseVersionCommentRepository.GetAsync(It.IsAny<Expression<Func<CourseVersionComment, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseVersionComment);

            // Act
            var result = await _service.EditCourseVersionComment(claimsPrincipal, editCourseVersionCommentsDTO);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(403, result.StatusCode);
            Assert.False(result.IsSuccess);
            Assert.Equal("Unauthorized user", result.Message);
        }
        [Fact]
        public async Task RemoveCourseVersionComment_CommentNotFound_Returns400()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var commentId = Guid.NewGuid();

            _mockUnitOfWork.Setup(u => u.CourseVersionCommentRepository.GetAsync(
                It.IsAny<Expression<Func<CourseVersionComment, bool>>>(),
                It.IsAny<string>()))
                .ReturnsAsync((CourseVersionComment)null);

            // Act
            var result = await _service.RemoveCourseVersionComment(claimsPrincipal, commentId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.False(result.IsSuccess);
            Assert.Equal("CourseVersionId Invalid", result.Message);
        }

        [Fact]
        public async Task RemoveCourseVersionComment_CommentRemovedSuccessfully_Returns200()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var commentId = Guid.NewGuid();

            var courseVersionComment = new CourseVersionComment
            {
                Id = commentId,
                Comment = "Original comment",
                CreatedBy = "admin@domain.com",
                CreatedTime = DateTime.UtcNow.AddDays(-1),
                UpdatedBy = null,
                UpdatedTime = null,
                Status = 0
            };

            var admin = new ApplicationUser { Email = "admin@domain.com" };

            _mockUnitOfWork.Setup(u => u.CourseVersionCommentRepository.GetAsync(
                It.IsAny<Expression<Func<CourseVersionComment, bool>>>(),
                It.IsAny<string>()))
                .ReturnsAsync(courseVersionComment);
            _mockUnitOfWork.Setup(um => um.UserManagerRepository.FindByIdAsync(userId)).ReturnsAsync(admin);

            _mockUnitOfWork.Setup(u => u.CourseVersionCommentRepository.Update(It.IsAny<CourseVersionComment>()));
            _mockUnitOfWork.Setup(u => u.SaveAsync()).ReturnsAsync(1);

            // Act
            var result = await _service.RemoveCourseVersionComment(claimsPrincipal, commentId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.True(result.IsSuccess);
            Assert.Equal("Comment Removed successfully", result.Message);

            _mockUnitOfWork.Verify(u => u.CourseVersionCommentRepository.Update(It.Is<CourseVersionComment>(c =>
                c.Id == commentId &&
                c.UpdatedBy == admin.Email &&
                c.Status == 2)), Times.Once);

            _mockUnitOfWork.Verify(u => u.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task RemoveCourseVersionComment_UserNotFound_Returns404()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var commentId = Guid.NewGuid();

            var courseVersionComment = new CourseVersionComment
            {
                Id = commentId,
                Comment = "Original comment",
                CreatedBy = "admin@domain.com",
                CreatedTime = DateTime.UtcNow.AddDays(-1),
                UpdatedBy = null,
                UpdatedTime = null,
                Status = 0
            };

            _mockUnitOfWork.Setup(u => u.CourseVersionCommentRepository.GetAsync(
                It.IsAny<Expression<Func<CourseVersionComment, bool>>>(),
                It.IsAny<string>()))
                .ReturnsAsync(courseVersionComment);
            _mockUnitOfWork.Setup(um => um.UserManagerRepository.FindByIdAsync(userId)).ReturnsAsync((ApplicationUser)null);
            // Act
            var result = await _service.RemoveCourseVersionComment(claimsPrincipal, commentId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);
            Assert.False(result.IsSuccess);
            Assert.Equal("User not found", result.Message);
        }

        [Fact]
        public async Task RemoveCourseVersionComment_InvalidCommentId_Returns400()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var commentId = Guid.Empty;

            _mockUnitOfWork.Setup(u => u.CourseVersionCommentRepository.GetAsync(
                It.IsAny<Expression<Func<CourseVersionComment, bool>>>(),
                It.IsAny<string>()))
                .ReturnsAsync((CourseVersionComment)null);

            // Act
            var result = await _service.RemoveCourseVersionComment(claimsPrincipal, commentId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.False(result.IsSuccess);
            Assert.Equal("CourseVersionId Invalid", result.Message);
        }

        [Fact]
        public async Task RemoveCourseVersionComment_CommentAlreadyRemoved_Returns400()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var commentId = Guid.NewGuid();

            var courseVersionComment = new CourseVersionComment
            {
                Id = commentId,
                Comment = "Original comment",
                CreatedBy = "admin@domain.com",
                CreatedTime = DateTime.UtcNow.AddDays(-1),
                UpdatedBy = "admin@domain.com",
                UpdatedTime = DateTime.UtcNow.AddDays(-1),
                Status = 2 // Already removed
            };

            _mockUnitOfWork.Setup(u => u.CourseVersionCommentRepository.GetAsync(
                It.IsAny<Expression<Func<CourseVersionComment, bool>>>(),
                It.IsAny<string>()))
                .ReturnsAsync(courseVersionComment);

            // Act
            var result = await _service.RemoveCourseVersionComment(claimsPrincipal, commentId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.False(result.IsSuccess);
            Assert.Equal("Comment already removed", result.Message);
        }

        [Fact]
        public async Task RemoveCourseVersionComment_ExceptionThrown_Returns500()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var commentId = Guid.NewGuid();

            _mockUnitOfWork.Setup(u => u.CourseVersionCommentRepository.GetAsync(
                It.IsAny<Expression<Func<CourseVersionComment, bool>>>(),
                It.IsAny<string>()))
                .Throws(new Exception("Test Exception"));

            // Act
            var result = await _service.RemoveCourseVersionComment(claimsPrincipal, commentId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(500, result.StatusCode);
            Assert.False(result.IsSuccess);
            Assert.Equal("Test Exception", result.Message);
        }
        [Fact]
        public async Task UploadCourseVersionBackgroundImg_NoFileUploaded_Returns400()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var courseVersionId = Guid.NewGuid();

            var uploadCourseVersionBackgroundImg = new UploadCourseVersionBackgroundImg { File = null };

            // Act
            var result = await _service.UploadCourseVersionBackgroundImg(claimsPrincipal, courseVersionId, uploadCourseVersionBackgroundImg);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.False(result.IsSuccess);
            Assert.Equal("No file uploaded.", result.Message);
        }

        [Fact]
        public async Task UploadCourseVersionBackgroundImg_CourseVersionNotFound_Returns404()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var courseVersionId = Guid.NewGuid();
            var fileMock = new Mock<IFormFile>();
            var uploadCourseVersionBackgroundImg = new UploadCourseVersionBackgroundImg { File = fileMock.Object };

            _mockUnitOfWork.Setup(u => u.CourseVersionRepository.GetAsync(
                It.IsAny<Expression<Func<CourseVersion, bool>>>(),
                It.IsAny<string>())).ReturnsAsync((CourseVersion)null);

            // Act
            var result = await _service.UploadCourseVersionBackgroundImg(claimsPrincipal, courseVersionId, uploadCourseVersionBackgroundImg);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);
            Assert.False(result.IsSuccess);
            Assert.Equal("Course version not found.", result.Message);
        }

        [Fact]
        public async Task UploadCourseVersionBackgroundImg_FileUploadFailed_Returns500()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var courseVersionId = Guid.NewGuid();
            var fileMock = new Mock<IFormFile>();
            var uploadCourseVersionBackgroundImg = new UploadCourseVersionBackgroundImg { File = fileMock.Object };

            var courseVersion = new CourseVersion { Id = courseVersionId, CourseId = Guid.NewGuid() };
            var responseDto = new ResponseDTO { IsSuccess = false };

            _mockUnitOfWork.Setup(u => u.CourseVersionRepository.GetAsync(
                It.IsAny<Expression<Func<CourseVersion, bool>>>(),
                It.IsAny<string>())).ReturnsAsync(courseVersion);
            _mockFirebaseService.Setup(f => f.UploadImage(It.IsAny<IFormFile>(), It.IsAny<string>()))
                .ReturnsAsync(responseDto);

            // Act
            var result = await _service.UploadCourseVersionBackgroundImg(claimsPrincipal, courseVersionId, uploadCourseVersionBackgroundImg);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(500, result.StatusCode);
            Assert.False(result.IsSuccess);
            Assert.Equal("File upload failed.", result.Message);
        }

        [Fact]
        public async Task UploadCourseVersionBackgroundImg_FileUploadedSuccessfully_Returns200()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var courseVersionId = Guid.NewGuid();
            var fileMock = new Mock<IFormFile>();
            var uploadCourseVersionBackgroundImg = new UploadCourseVersionBackgroundImg { File = fileMock.Object };

            var courseVersion = new CourseVersion { Id = courseVersionId, CourseId = Guid.NewGuid() };
            var responseDto = new ResponseDTO { IsSuccess = true, Result = "http://example.com/image.jpg" };

            _mockUnitOfWork.Setup(u => u.CourseVersionRepository.GetAsync(
                It.IsAny<Expression<Func<CourseVersion, bool>>>(),
                It.IsAny<string>())).ReturnsAsync(courseVersion);
            _mockFirebaseService.Setup(f => f.UploadImage(It.IsAny<IFormFile>(), It.IsAny<string>()))
                .ReturnsAsync(responseDto);

            _mockUnitOfWork.Setup(u => u.CourseVersionRepository.Update(It.IsAny<CourseVersion>()));
            _mockUnitOfWork.Setup(u => u.SaveAsync()).ReturnsAsync(1);

            // Act
            var result = await _service.UploadCourseVersionBackgroundImg(claimsPrincipal, courseVersionId, uploadCourseVersionBackgroundImg);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.True(result.IsSuccess);
            Assert.Equal("Upload file successfully", result.Message);
            Assert.Equal("http://example.com/image.jpg", result.Result);

            _mockUnitOfWork.Verify(u => u.CourseVersionRepository.Update(It.Is<CourseVersion>(c =>
                c.Id == courseVersionId &&
                c.CourseImgUrl == "http://example.com/image.jpg")), Times.Once);

            _mockUnitOfWork.Verify(u => u.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task UploadCourseVersionBackgroundImg_ExceptionThrown_Returns500()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var courseVersionId = Guid.NewGuid();
            var fileMock = new Mock<IFormFile>();
            var uploadCourseVersionBackgroundImg = new UploadCourseVersionBackgroundImg { File = fileMock.Object };

            var courseVersion = new CourseVersion { Id = courseVersionId, CourseId = Guid.NewGuid() };

            _mockUnitOfWork.Setup(u => u.CourseVersionRepository.GetAsync(
                It.IsAny<Expression<Func<CourseVersion, bool>>>(),
                It.IsAny<string>())).ReturnsAsync(courseVersion);
            _mockFirebaseService.Setup(f => f.UploadImage(It.IsAny<IFormFile>(), It.IsAny<string>()))
                .Throws(new Exception("Test Exception"));

            // Act
            var result = await _service.UploadCourseVersionBackgroundImg(claimsPrincipal, courseVersionId, uploadCourseVersionBackgroundImg);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(500, result.StatusCode);
            Assert.False(result.IsSuccess);
            Assert.Equal("Test Exception", result.Message);
        }

        [Fact]
        public async Task UploadCourseVersionBackgroundImg_InvalidCourseVersionId_Returns400()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var courseVersionId = Guid.Empty; // Invalid ID
            var fileMock = new Mock<IFormFile>();
            var uploadCourseVersionBackgroundImg = new UploadCourseVersionBackgroundImg { File = fileMock.Object };

            // Act
            var result = await _service.UploadCourseVersionBackgroundImg(claimsPrincipal, courseVersionId, uploadCourseVersionBackgroundImg);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.False(result.IsSuccess);
            Assert.Equal("Course version not found.", result.Message);
        }

        [Fact]
        public async Task DisplayCourseVersionBackgroundImg_NoImageUrl_ReturnsNull()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var courseVersionId = Guid.NewGuid();
            var courseVersion = new CourseVersion { Id = courseVersionId, CourseImgUrl = null };

            _mockUnitOfWork.Setup(u => u.CourseVersionRepository.GetAsync(
                It.IsAny<Expression<Func<CourseVersion, bool>>>(),
                It.IsAny<string>())).ReturnsAsync(courseVersion);

            // Act
            var result = await _service.DisplayCourseVersionBackgroundImg(claimsPrincipal, courseVersionId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task DisplayCourseVersionBackgroundImg_ImageRetrievalFromFirebaseFails_ReturnsNull()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var courseVersionId = Guid.NewGuid();
            var courseVersion = new CourseVersion { Id = courseVersionId, CourseImgUrl = "http://example.com/image.jpg" };

            _mockUnitOfWork.Setup(u => u.CourseVersionRepository.GetAsync(
                It.IsAny<Expression<Func<CourseVersion, bool>>>(),
                It.IsAny<string>())).ReturnsAsync(courseVersion);
            _mockFirebaseService.Setup(f => f.GetImage(It.IsAny<string>()))
                .Throws(new Exception("Firebase error"));

            // Act
            var result = await _service.DisplayCourseVersionBackgroundImg(claimsPrincipal, courseVersionId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task DisplayCourseVersionBackgroundImg_ImageSuccessfullyRetrieved_ReturnsMemoryStream()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var courseVersionId = Guid.NewGuid();
            var courseVersion = new CourseVersion { Id = courseVersionId, CourseImgUrl = "http://example.com/image.jpg" };
            var memoryStream = new MemoryStream();

            _mockUnitOfWork.Setup(u => u.CourseVersionRepository.GetAsync(
                It.IsAny<Expression<Func<CourseVersion, bool>>>(),
                It.IsAny<string>())).ReturnsAsync(courseVersion);
            _mockFirebaseService.Setup(f => f.GetImage(It.IsAny<string>()))
                .ReturnsAsync(memoryStream);

            // Act
            var result = await _service.DisplayCourseVersionBackgroundImg(claimsPrincipal, courseVersionId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<MemoryStream>(result);
        }

        [Fact]
        public async Task DisplayCourseVersionBackgroundImg_ExceptionThrown_ReturnsNull()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var courseVersionId = Guid.NewGuid();
            var courseVersion = new CourseVersion { Id = courseVersionId, CourseImgUrl = "http://example.com/image.jpg" };

            _mockUnitOfWork.Setup(u => u.CourseVersionRepository.GetAsync(
                It.IsAny<Expression<Func<CourseVersion, bool>>>(),
                It.IsAny<string>())).ReturnsAsync(courseVersion);
            _mockFirebaseService.Setup(f => f.GetImage(It.IsAny<string>()))
                .Throws(new Exception("Test Exception"));

            // Act
            var result = await _service.DisplayCourseVersionBackgroundImg(claimsPrincipal, courseVersionId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task DisplayCourseVersionBackgroundImg_InvalidCourseVersionId_ReturnsNull()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var courseVersionId = Guid.Empty; // Invalid ID
            var courseVersion = new CourseVersion { Id = courseVersionId, CourseImgUrl = "http://example.com/image.jpg" };

            _mockUnitOfWork.Setup(u => u.CourseVersionRepository.GetAsync(
                It.IsAny<Expression<Func<CourseVersion, bool>>>(),
                It.IsAny<string>())).ReturnsAsync(courseVersion);

            // Act
            var result = await _service.DisplayCourseVersionBackgroundImg(claimsPrincipal, courseVersionId);

            // Assert
            Assert.Null(result);
        }
    }
}
