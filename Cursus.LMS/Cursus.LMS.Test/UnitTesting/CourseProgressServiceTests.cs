using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Service.Service;
using Moq;
using Xunit;

namespace Cursus.LMS.Test.UnitTesting
{
    public class CourseProgressServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IStudentCourseService> _mockStudentCourseService;
        private readonly Mock<IEmailService> _mockEmailService;
        private readonly CourseProgressService _courseProgressService;

        public CourseProgressServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockEmailService = new Mock<IEmailService>();
            _mockStudentCourseService = new Mock<IStudentCourseService>();
            _courseProgressService = new CourseProgressService(_mockUnitOfWork.Object,_mockStudentCourseService.Object,_mockEmailService.Object);
        }

        [Fact]
        public async Task CreateProgress_ShouldReturnSuccess_WhenProgressCreated()
        {
            // Arrange
            var createProgressDto = new CreateProgressDTO { StudentCourseId = Guid.NewGuid() };
            var studentCourse = new StudentCourse { Id = createProgressDto.StudentCourseId, CourseId = Guid.NewGuid() };

            _mockUnitOfWork.Setup(u => u.StudentCourseRepository.GetAsync(It.IsAny<Expression<Func<StudentCourse, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(studentCourse);
            _mockUnitOfWork.Setup(u => u.CourseProgressRepository.GetAsync(It.IsAny<Expression<Func<CourseProgress, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((CourseProgress)null);
            _mockUnitOfWork.Setup(u => u.CourseRepository.GetAsync(It.IsAny<Expression<Func<Course, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(new Course { CourseVersionId = Guid.NewGuid() });
            _mockUnitOfWork.Setup(u => u.CourseSectionVersionRepository.GetAllAsync(It.IsAny<Expression<Func<CourseSectionVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(new List<CourseSectionVersion>());
            _mockUnitOfWork.Setup(u => u.SectionDetailsVersionRepository.GetAllAsync(It.IsAny<Expression<Func<SectionDetailsVersion, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(new List<SectionDetailsVersion>());

            // Act
            var result = await _courseProgressService.CreateProgress(createProgressDto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Create course progress successfully", result.Message);
        }

        [Fact]
        public async Task CreateProgress_ShouldReturnNotFound_WhenStudentCourseDoesNotExist()
        {
            // Arrange
            var createProgressDto = new CreateProgressDTO { StudentCourseId = Guid.NewGuid() };

            _mockUnitOfWork.Setup(u => u.StudentCourseRepository.GetAsync(It.IsAny<Expression<Func<StudentCourse, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((StudentCourse)null);

            // Act
            var result = await _courseProgressService.CreateProgress(createProgressDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("Student course was not found", result.Message);
        }

        [Fact]
        public async Task CreateProgress_ShouldReturnBadRequest_WhenCourseProgressExists()
        {
            // Arrange
            var createProgressDto = new CreateProgressDTO { StudentCourseId = Guid.NewGuid() };
            var studentCourse = new StudentCourse { Id = createProgressDto.StudentCourseId, CourseId = Guid.NewGuid() };

            _mockUnitOfWork.Setup(u => u.StudentCourseRepository.GetAsync(It.IsAny<Expression<Func<StudentCourse, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(studentCourse);
            _mockUnitOfWork.Setup(u => u.CourseProgressRepository.GetAsync(It.IsAny<Expression<Func<CourseProgress, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(new CourseProgress());

            // Act
            var result = await _courseProgressService.CreateProgress(createProgressDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Course progress has been existed", result.Message);
        }

        [Fact]
        public async Task UpdateProgress_ShouldReturnSuccess_WhenProgressUpdated()
        {
            // Arrange
            var updateProgressDto = new UpdateProgressDTO { CourseId = Guid.NewGuid(), StudentId = Guid.NewGuid(), SectionId = Guid.NewGuid(), DetailsId = Guid.NewGuid() };
            var studentCourse = new StudentCourse { Id = Guid.NewGuid(), CourseId = updateProgressDto.CourseId, StudentId = updateProgressDto.StudentId };
            var courseProgress = new CourseProgress { StudentCourseId = studentCourse.Id, CourseId = studentCourse.CourseId, SectionId = updateProgressDto.SectionId, DetailsId = updateProgressDto.DetailsId };

            _mockUnitOfWork.Setup(u => u.StudentCourseRepository.GetAsync(It.IsAny<Expression<Func<StudentCourse, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(studentCourse);
            _mockUnitOfWork.Setup(u => u.CourseProgressRepository.GetAsync(It.IsAny<Expression<Func<CourseProgress, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseProgress);

            // Act
            var result = await _courseProgressService.UpdateProgress(new ClaimsPrincipal(), updateProgressDto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Update progress successfully", result.Message);
        }

        [Fact]
        public async Task UpdateProgress_ShouldReturnNotFound_WhenStudentCourseDoesNotExist()
        {
            // Arrange
            var updateProgressDto = new UpdateProgressDTO { CourseId = Guid.NewGuid(), StudentId = Guid.NewGuid() };

            _mockUnitOfWork.Setup(u => u.StudentCourseRepository.GetAsync(It.IsAny<Expression<Func<StudentCourse, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((StudentCourse)null);

            // Act
            var result = await _courseProgressService.UpdateProgress(new ClaimsPrincipal(),updateProgressDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("Student course was not found", result.Message);
        }

        [Fact]
        public async Task UpdateProgress_ShouldReturnNotFound_WhenCourseProgressDoesNotExist()
        {
            // Arrange
            var updateProgressDto = new UpdateProgressDTO { CourseId = Guid.NewGuid(), StudentId = Guid.NewGuid(), SectionId = Guid.NewGuid(), DetailsId = Guid.NewGuid() };
            var studentCourse = new StudentCourse { Id = Guid.NewGuid(), CourseId = updateProgressDto.CourseId, StudentId = updateProgressDto.StudentId };

            _mockUnitOfWork.Setup(u => u.StudentCourseRepository.GetAsync(It.IsAny<Expression<Func<StudentCourse, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(studentCourse);
            _mockUnitOfWork.Setup(u => u.CourseProgressRepository.GetAsync(It.IsAny<Expression<Func<CourseProgress, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((CourseProgress)null);

            // Act
            var result = await _courseProgressService.UpdateProgress(new ClaimsPrincipal(),updateProgressDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("Course progress was not found", result.Message);
        }

        [Fact]
        public async Task GetProgress_ShouldReturnSuccess_WhenProgressRetrieved()
        {
            // Arrange
            var getProgressDto = new GetProgressDTO { CourseId = Guid.NewGuid(), StudentId = Guid.NewGuid(), SectionId = Guid.NewGuid(), DetailsId = Guid.NewGuid() };
            var studentCourse = new StudentCourse { Id = Guid.NewGuid(), CourseId = getProgressDto.CourseId, StudentId = getProgressDto.StudentId };
            var courseProgress = new CourseProgress { StudentCourseId = studentCourse.Id, CourseId = studentCourse.CourseId, SectionId = getProgressDto.SectionId, DetailsId = getProgressDto.DetailsId };

            _mockUnitOfWork.Setup(u => u.StudentCourseRepository.GetAsync(It.IsAny<Expression<Func<StudentCourse, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(studentCourse);
            _mockUnitOfWork.Setup(u => u.CourseProgressRepository.GetAsync(It.IsAny<Expression<Func<CourseProgress, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseProgress);

            // Act
            var result = await _courseProgressService.GetProgress(getProgressDto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Get course progress successfully", result.Message);
            Assert.Equal(courseProgress, result.Result);
        }

        [Fact]
        public async Task GetProgress_ShouldReturnNotFound_WhenStudentCourseDoesNotExist()
        {
            // Arrange
            var getProgressDto = new GetProgressDTO { CourseId = Guid.NewGuid(), StudentId = Guid.NewGuid() };

            _mockUnitOfWork.Setup(u => u.StudentCourseRepository.GetAsync(It.IsAny<Expression<Func<StudentCourse, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((StudentCourse)null);

            // Act
            var result = await _courseProgressService.GetProgress(getProgressDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("Student course was not found", result.Message);
        }

        [Fact]
        public async Task GetProgress_ShouldReturnNotFound_WhenCourseProgressDoesNotExist()
        {
            // Arrange
            var getProgressDto = new GetProgressDTO { CourseId = Guid.NewGuid(), StudentId = Guid.NewGuid(), SectionId = Guid.NewGuid(), DetailsId = Guid.NewGuid() };
            var studentCourse = new StudentCourse { Id = Guid.NewGuid(), CourseId = getProgressDto.CourseId, StudentId = getProgressDto.StudentId };

            _mockUnitOfWork.Setup(u => u.StudentCourseRepository.GetAsync(It.IsAny<Expression<Func<StudentCourse, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(studentCourse);
            _mockUnitOfWork.Setup(u => u.CourseProgressRepository.GetAsync(It.IsAny<Expression<Func<CourseProgress, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((CourseProgress)null);

            // Act
            var result = await _courseProgressService.GetProgress(getProgressDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("Course progress was not found", result.Message);
        }

        [Fact]
        public async Task GetPercentage_ShouldReturnSuccess_WhenPercentageRetrieved()
        {
            // Arrange
            var getPercentageDto = new GetPercentageDTO { CourseId = Guid.NewGuid(), StudentId = Guid.NewGuid() };
            var studentCourse = new StudentCourse { Id = Guid.NewGuid(), CourseId = getPercentageDto.CourseId, StudentId = getPercentageDto.StudentId };
            var courseProgressList = new List<CourseProgress>
            {
                new CourseProgress { IsCompleted = true },
                new CourseProgress { IsCompleted = true },
                new CourseProgress { IsCompleted = false }
            };

            _mockUnitOfWork.Setup(u => u.StudentCourseRepository.GetAsync(It.IsAny<Expression<Func<StudentCourse, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(studentCourse);
            _mockUnitOfWork.Setup(u => u.CourseProgressRepository.GetAllAsync(It.IsAny<Expression<Func<CourseProgress, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseProgressList);

            // Act
            var result = await _courseProgressService.GetPercentage(getPercentageDto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Get percentage successfully", result.Message);
            Assert.Equal(66, result.Result);
        }

        [Fact]
        public async Task GetPercentage_ShouldReturnNotFound_WhenStudentCourseDoesNotExist()
        {
            // Arrange
            var getPercentageDto = new GetPercentageDTO { CourseId = Guid.NewGuid(), StudentId = Guid.NewGuid() };

            _mockUnitOfWork.Setup(u => u.StudentCourseRepository.GetAsync(It.IsAny<Expression<Func<StudentCourse, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((StudentCourse)null);

            // Act
            var result = await _courseProgressService.GetPercentage(getPercentageDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("Student course was not found", result.Message);
        }

        [Fact]
        public async Task GetPercentage_ShouldReturnSuccess_WhenNoCourseProgress()
        {
            // Arrange
            var getPercentageDto = new GetPercentageDTO { CourseId = Guid.NewGuid(), StudentId = Guid.NewGuid() };
            var studentCourse = new StudentCourse { Id = Guid.NewGuid(), CourseId = getPercentageDto.CourseId, StudentId = getPercentageDto.StudentId };

            _mockUnitOfWork.Setup(u => u.StudentCourseRepository.GetAsync(It.IsAny<Expression<Func<StudentCourse, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(studentCourse);
            _mockUnitOfWork.Setup(u => u.CourseProgressRepository.GetAllAsync(It.IsAny<Expression<Func<CourseProgress, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(new List<CourseProgress>());

            // Act
            var result = await _courseProgressService.GetPercentage(getPercentageDto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Get percentage successfully", result.Message);
            Assert.Equal(0, result.Result);
        }
    }
}
