using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Service.Service;
using Cursus.LMS.Utility.Constants;
using Moq;
using Xunit;

namespace Cursus.LMS.Tests
{
    public class CourseSectionVersionServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ISectionDetailsVersionService> _mockSectionDetailsVersionService;
        private readonly CourseSectionVersionService _service;

        public CourseSectionVersionServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            _mockSectionDetailsVersionService = new Mock<ISectionDetailsVersionService>();
            _service = new CourseSectionVersionService(
                _mockUnitOfWork.Object,
                _mockMapper.Object,
                _mockSectionDetailsVersionService.Object
            );
        }

        [Fact]
        public async Task CloneCourseSectionVersion_Success()
        {
            // Arrange
            var user = new ClaimsPrincipal();
            var dto = new CloneCourseSectionVersionDTO
            {
                OldCourseVersionId = Guid.NewGuid(),
                NewCourseVersionId = Guid.NewGuid()
            };

            _mockUnitOfWork.Setup(u => u.CourseSectionVersionRepository.GetCourseSectionVersionsOfCourseVersionAsync(dto.OldCourseVersionId, true))
                .ReturnsAsync(new List<CourseSectionVersion> { new CourseSectionVersion() });

            _mockSectionDetailsVersionService.Setup(s => s.CloneSectionsDetailsVersion(It.IsAny<ClaimsPrincipal>(), It.IsAny<CloneSectionsDetailsVersionDTO>()))
                .ReturnsAsync(new ResponseDTO { StatusCode = 200 });

            // Act
            var result = await _service.CloneCourseSectionVersion(user, dto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Clone course section of course version successfully", result.Message);
        }

        [Fact]
        public async Task CloneCourseSectionVersion_SectionNotFound()
        {
            // Arrange
            var user = new ClaimsPrincipal();
            var dto = new CloneCourseSectionVersionDTO
            {
                OldCourseVersionId = Guid.NewGuid(),
                NewCourseVersionId = Guid.NewGuid()
            };

            _mockUnitOfWork.Setup(u => u.CourseSectionVersionRepository.GetCourseSectionVersionsOfCourseVersionAsync(dto.OldCourseVersionId, true))
                .ReturnsAsync(new List<CourseSectionVersion>());

            // Act
            var result = await _service.CloneCourseSectionVersion(user, dto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("Section of course version was not found", result.Message);
        }

        [Fact]
        public async Task CloneCourseSectionVersion_ServiceError()
        {
            // Arrange
            var user = new ClaimsPrincipal();
            var dto = new CloneCourseSectionVersionDTO
            {
                OldCourseVersionId = Guid.NewGuid(),
                NewCourseVersionId = Guid.NewGuid()
            };

            _mockUnitOfWork.Setup(u => u.CourseSectionVersionRepository.GetCourseSectionVersionsOfCourseVersionAsync(dto.OldCourseVersionId, true))
                .ReturnsAsync(new List<CourseSectionVersion> { new CourseSectionVersion() });

            _mockSectionDetailsVersionService.Setup(s => s.CloneSectionsDetailsVersion(It.IsAny<ClaimsPrincipal>(), It.IsAny<CloneSectionsDetailsVersionDTO>()))
                .ReturnsAsync(new ResponseDTO { StatusCode = 500 });

            // Act
            var result = await _service.CloneCourseSectionVersion(user, dto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
        }

        [Fact]
        public async Task GetCourseSections_Success()
        {
            // Arrange
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Role, StaticUserRoles.Admin) }));
            var dto = Guid.NewGuid();

            _mockUnitOfWork.Setup(u => u.CourseSectionVersionRepository.GetAllAsync(It.IsAny<Expression<Func<CourseSectionVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(new List<CourseSectionVersion> { new CourseSectionVersion() });

            // Act
            var result = await _service.GetCourseSections(user, dto, null, null, null, 1, 10);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Get course sections version successfully", result.Message);
        }

        [Fact]
        public async Task GetCourseSections_NoSectionsFound()
        {
            // Arrange
            var user = new ClaimsPrincipal();
            var dto = Guid.NewGuid();

            _mockUnitOfWork.Setup(u => u.CourseSectionVersionRepository.GetAllAsync(It.IsAny<Expression<Func<CourseSectionVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(new List<CourseSectionVersion>());

            // Act
            var result = await _service.GetCourseSections(user, dto, null, null, null, 1, 10);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("There are no sectionVersions", result.Message);
        }

        [Fact]
        public async Task GetCourseSections_Error()
        {
            // Arrange
            var user = new ClaimsPrincipal();
            var dto = Guid.NewGuid();

            _mockUnitOfWork.Setup(u => u.CourseSectionVersionRepository.GetAllAsync(It.IsAny<Expression<Func<CourseSectionVersion, bool>>>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _service.GetCourseSections(user, dto, null, null, null, 1, 10);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Database error", result.Message);
        }

        [Fact]
        public async Task GetCourseSection_Success()
        {
            // Arrange
            var user = new ClaimsPrincipal();
            var courseSectionVersionId = Guid.NewGuid();
            var courseSectionVersion = new CourseSectionVersion();
            var courseSectionVersionDto = new GetCourseSectionDTO();

            _mockUnitOfWork.Setup(u => u.CourseSectionVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseSectionVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseSectionVersion);

            _mockMapper.Setup(m => m.Map<GetCourseSectionDTO>(courseSectionVersion))
                .Returns(courseSectionVersionDto);

            // Act
            var result = await _service.GetCourseSection(user, courseSectionVersionId);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Get course section version successfully", result.Message);
            Assert.Equal(courseSectionVersionDto, result.Result);
        }

        [Fact]
        public async Task GetCourseSection_NotFound()
        {
            // Arrange
            var user = new ClaimsPrincipal();
            var courseSectionVersionId = Guid.NewGuid();

            _mockUnitOfWork.Setup(u => u.CourseSectionVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseSectionVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((CourseSectionVersion)null);

            // Act
            var result = await _service.GetCourseSection(user, courseSectionVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("courseSection Version was not found", result.Message);
        }

        [Fact]
        public async Task GetCourseSection_Error()
        {
            // Arrange
            var user = new ClaimsPrincipal();
            var courseSectionVersionId = Guid.NewGuid();

            _mockUnitOfWork.Setup(u => u.CourseSectionVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseSectionVersion, bool>>>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _service.GetCourseSection(user, courseSectionVersionId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Database error", result.Message);
        }

        [Fact]
        public async Task CreateCourseSection_Success()
        {
            // Arrange
            var user = new ClaimsPrincipal();
            var dto = new CreateCourseSectionVersionDTO
            {
                CourseVersionId = Guid.NewGuid(),
                Title = "New Section",
                Description = "Description"
            };

            _mockUnitOfWork.Setup(u => u.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(new CourseVersion());

            // Act
            var result = await _service.CreateCourseSection(user, dto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Create new course section version successfully", result.Message);
        }

        [Fact]
        public async Task CreateCourseSection_InvalidCourseVersionId()
        {
            // Arrange
            var user = new ClaimsPrincipal();
            var dto = new CreateCourseSectionVersionDTO
            {
                CourseVersionId = Guid.NewGuid(),
                Title = "New Section",
                Description = "Description"
            };

            _mockUnitOfWork.Setup(u => u.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((CourseVersion)null);

            // Act
            var result = await _service.CreateCourseSection(user, dto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("Course version was not found", result.Message);
        }

        [Fact]
        public async Task CreateCourseSection_Error()
        {
            // Arrange
            var user = new ClaimsPrincipal();
            var dto = new CreateCourseSectionVersionDTO
            {
                CourseVersionId = Guid.NewGuid(),
                Title = "New Section",
                Description = "Description"
            };

            _mockUnitOfWork.Setup(u => u.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _service.CreateCourseSection(user, dto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Database error", result.Message);
        }
    }
}
