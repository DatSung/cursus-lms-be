using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.Service;
using Moq;
using Xunit;

namespace Cursus.LMS.Test.UnitTesting
{
    public class CourseVersionStatusServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly CourseVersionStatusService _service;

        public CourseVersionStatusServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
            _service = new CourseVersionStatusService(_unitOfWorkMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetCourseVersionStatus_CourseVersionStatusNotFound_Returns404Response()
        {
            // Arrange
            var courseVersionStatusId = Guid.NewGuid();
            _unitOfWorkMock.Setup(u => u.CourseVersionStatusRepository.GetCourseVersionStatusByIdAsync(courseVersionStatusId))
                           .ReturnsAsync((CourseVersionStatus)null);

            // Act
            var result = await _service.GetCourseVersionStatus(new ClaimsPrincipal(), courseVersionStatusId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Null(result.Result);
            Assert.Equal("Course version status was not found", result.Message);
        }

        [Fact]
        public async Task GetCourseVersionStatus_CourseVersionStatusFound_Returns200Response()
        {
            // Arrange
            var courseVersionStatusId = Guid.NewGuid();
            var courseVersionStatus = new CourseVersionStatus { Id = courseVersionStatusId };
            var courseVersionStatusDto = new GetCourseVersionStatusDTO { Id = courseVersionStatusId };

            _unitOfWorkMock.Setup(u => u.CourseVersionStatusRepository.GetCourseVersionStatusByIdAsync(courseVersionStatusId))
                           .ReturnsAsync(courseVersionStatus);
            _mapperMock.Setup(m => m.Map<GetCourseVersionStatusDTO>(courseVersionStatus))
                       .Returns(courseVersionStatusDto);

            // Act
            var result = await _service.GetCourseVersionStatus(new ClaimsPrincipal(), courseVersionStatusId);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(courseVersionStatusDto, result.Result);
            Assert.Equal("Get course version status successfully", result.Message);
        }

        [Fact]
        public async Task GetCourseVersionStatus_ExceptionThrown_Returns500Response()
        {
            // Arrange
            var courseVersionStatusId = Guid.NewGuid();
            _unitOfWorkMock.Setup(u => u.CourseVersionStatusRepository.GetCourseVersionStatusByIdAsync(courseVersionStatusId))
                           .ThrowsAsync(new Exception("Test exception"));

            // Act
            var result = await _service.GetCourseVersionStatus(new ClaimsPrincipal(), courseVersionStatusId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Null(result.Result);
            Assert.Equal("Test exception", result.Message);
        }
        [Fact]
        public async Task CreateCourseVersionStatus_ValidInput_Returns200Response()
        {
            // Arrange
            var createCourseVersionStatusDto = new CreateCourseVersionStatusDTO
            {
                Status = 1,
                CourseVersionId = Guid.NewGuid()
            };

            _unitOfWorkMock.Setup(u => u.CourseVersionStatusRepository.AddAsync(It.IsAny<CourseVersionStatus>()))
                           .Returns(Task.CompletedTask);
            _unitOfWorkMock.Setup(u => u.SaveAsync()).ReturnsAsync(1);

            // Act
            var result = await _service.CreateCourseVersionStatus(new ClaimsPrincipal(), createCourseVersionStatusDto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Result);
            Assert.Equal("Create course version status successfully", result.Message);

            _unitOfWorkMock.Verify(u => u.CourseVersionStatusRepository.AddAsync(It.IsAny<CourseVersionStatus>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task CreateCourseVersionStatus_ExceptionThrown_Returns500Response()
        {
            // Arrange
            var createCourseVersionStatusDto = new CreateCourseVersionStatusDTO
            {
                Status = 1,
                CourseVersionId = Guid.NewGuid()
            };

            _unitOfWorkMock.Setup(u => u.CourseVersionStatusRepository.AddAsync(It.IsAny<CourseVersionStatus>()))
                           .ThrowsAsync(new Exception("Test exception"));

            // Act
            var result = await _service.CreateCourseVersionStatus(new ClaimsPrincipal(), createCourseVersionStatusDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Null(result.Result);
            Assert.Equal("Test exception", result.Message);

            _unitOfWorkMock.Verify(u => u.CourseVersionStatusRepository.AddAsync(It.IsAny<CourseVersionStatus>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.SaveAsync(), Times.Never);
        }
    }
}
