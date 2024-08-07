using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.Service;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Cursus.LMS.Tests
{
    public class CourseReportServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CourseReportService _courseReportService;

        public CourseReportServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            _courseReportService = new CourseReportService(_mockUnitOfWork.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetCourseReports_ShouldReturnCourseReports()
        {
            // Arrange
            var courseReports = new List<CourseReport>
            {
                new CourseReport { Id = Guid.NewGuid(), Message = "Report 1" },
                new CourseReport { Id = Guid.NewGuid(), Message = "Report 2" }
            };

            _mockUnitOfWork.Setup(u => u.CourseReportRepository.GetAllAsync(It.IsAny<Expression<Func<CourseReport, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(courseReports);

            _mockMapper.Setup(m => m.Map<List<CourseReportDTO>>(courseReports))
                .Returns(new List<CourseReportDTO>
                {
                    new CourseReportDTO { Id = courseReports[0].Id, Message = "Report 1" },
                    new CourseReportDTO { Id = courseReports[1].Id, Message = "Report 2" }
                });

            // Act
            var result = await _courseReportService.GetCourseReports(null, null, null, null, null, true, 1, 10);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Result);
        }

        [Fact]
        public async Task GetCourseReportById_ShouldReturnCourseReport()
        {
            // Arrange
            var courseReport = new CourseReport { Id = Guid.NewGuid(), Message = "Report" };

            _mockUnitOfWork.Setup(u => u.CourseReportRepository.GetById(It.IsAny<Guid>()))
                .ReturnsAsync(courseReport);

            _mockMapper.Setup(m => m.Map<CourseReportDTO>(courseReport))
                .Returns(new CourseReportDTO { Id = courseReport.Id, Message = "Report" });

            // Act
            var result = await _courseReportService.GetCourseReportById(courseReport.Id);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Result);
        }

        [Fact]
        public async Task CreateCourseReport_ShouldCreateCourseReport()
        {
            // Arrange
            var createCourseReportDTO = new CreateCourseReportDTO { CourseId = Guid.NewGuid(), StudentId = Guid.NewGuid(), Message = "New Report" };
            var course = new Course { Id = createCourseReportDTO.CourseId };
            var student = new Student { StudentId = createCourseReportDTO.StudentId };

            _mockUnitOfWork.Setup(u => u.CourseRepository.GetById(createCourseReportDTO.CourseId))
                .ReturnsAsync(course);
            _mockUnitOfWork.Setup(u => u.StudentRepository.GetById(createCourseReportDTO.StudentId))
                .ReturnsAsync(student);

            // Act
            var result = await _courseReportService.CreateCourseReport(createCourseReportDTO);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(201, result.StatusCode);
            Assert.NotNull(result.Result);
        }

        [Fact]
        public async Task UpdateCourseReport_ShouldUpdateCourseReport()
        {
            // Arrange
            var updateCourseReportDTO = new UpdateCourseReportDTO { Id = Guid.NewGuid(), Message = "Updated Report" };
            var courseReport = new CourseReport { Id = updateCourseReportDTO.Id, Message = "Old Report" };
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "1")
            }));

            _mockUnitOfWork.Setup(u => u.CourseReportRepository.GetById(updateCourseReportDTO.Id))
                .ReturnsAsync(courseReport);

            // Act
            var result = await _courseReportService.UpdateCourseReport(claimsPrincipal, updateCourseReportDTO);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Result);
        }

        [Fact]
        public async Task DeleteCourseReport_ShouldDeleteCourseReport()
        {
            // Arrange
            var courseReport = new CourseReport { Id = Guid.NewGuid(), Status = 1 };

            _mockUnitOfWork.Setup(u => u.CourseReportRepository.GetById(courseReport.Id))
                .ReturnsAsync(courseReport);

            // Act
            var result = await _courseReportService.DeleteCourseReport(courseReport.Id);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Null(result.Result);
        }

        [Fact]
        public async Task GetCourseReports_ShouldReturnNotFound_WhenNoCourseReports()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.CourseReportRepository.GetAllAsync(It.IsAny<Expression<Func<CourseReport, bool>>>(), It.IsAny<string>())).ReturnsAsync(new List<CourseReport>());

            // Act
            var result = await _courseReportService.GetCourseReports(null, null, null, null, null, true, 1, 10);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Empty((List<CourseReportDTO>)result.Result);
        }

        [Fact]
        public async Task GetCourseReportById_ShouldReturnNotFound_WhenCourseReportDoesNotExist()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.CourseReportRepository.GetById(It.IsAny<Guid>()))
                .ReturnsAsync((CourseReport)null);

            // Act
            var result = await _courseReportService.GetCourseReportById(Guid.NewGuid());

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Null(result.Result);
        }

        [Fact]
        public async Task CreateCourseReport_ShouldReturnNotFound_WhenCourseDoesNotExist()
        {
            // Arrange
            var createCourseReportDTO = new CreateCourseReportDTO { CourseId = Guid.NewGuid(), StudentId = Guid.NewGuid(), Message = "New Report" };

            _mockUnitOfWork.Setup(u => u.CourseRepository.GetById(createCourseReportDTO.CourseId))
                .ReturnsAsync((Course)null);

            // Act
            var result = await _courseReportService.CreateCourseReport(createCourseReportDTO);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Null(result.Result);
        }

        [Fact]
        public async Task UpdateCourseReport_ShouldReturnNotFound_WhenUserNotFound()
        {
            // Arrange
            var updateCourseReportDTO = new UpdateCourseReportDTO { Id = Guid.NewGuid(), Message = "Updated Report" };
            var claimsPrincipal = new ClaimsPrincipal();

            // Act
            var result = await _courseReportService.UpdateCourseReport(claimsPrincipal, updateCourseReportDTO);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Null(result.Result);
        }

        [Fact]
        public async Task DeleteCourseReport_ShouldReturnNotFound_WhenCourseReportDoesNotExist()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.CourseReportRepository.GetById(It.IsAny<Guid>()))
                .ReturnsAsync((CourseReport)null);

            // Act
            var result = await _courseReportService.DeleteCourseReport(Guid.NewGuid());

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Null(result.Result);
        }
    }
}
