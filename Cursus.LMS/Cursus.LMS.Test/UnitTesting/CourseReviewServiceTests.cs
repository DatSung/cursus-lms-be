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
using Cursus.LMS.Service.IService;
using Cursus.LMS.Service.Service;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Cursus.LMS.Tests
{
    public class CourseReviewServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ICourseService> _mockCourseService;
        private readonly CourseReviewService _courseReviewService;

        public CourseReviewServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            _mockCourseService = new Mock<ICourseService>();
            _courseReviewService = new CourseReviewService(
                _mockUnitOfWork.Object,
                _mockMapper.Object,
                _mockCourseService.Object
            );
        }

        // Test for GetCourseReviews
        [Fact]
        public async Task GetCourseReviews_ReturnsCourseReviews_WhenCourseIdIsValid()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();
            var courseServiceMock = new Mock<ICourseService>();
            var service = new CourseReviewService(unitOfWorkMock.Object, mapperMock.Object, courseServiceMock.Object);
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, "test_user") }));
            var courseId = Guid.NewGuid();
            var reviews = new List<CourseReview>
    {
        new CourseReview { CourseId = courseId, Message = "Good course", Rate = 5 },
        new CourseReview { CourseId = courseId, Message = "Average course", Rate = 3 }
    };
            unitOfWorkMock.Setup(u => u.CourseReviewRepository.GetAllAsync(It.IsAny<Expression<Func<CourseReview, bool>>>(), It.IsAny<string>()))
                          .ReturnsAsync(reviews);
            mapperMock.Setup(m => m.Map<List<GetCourseReviewDTO>>(It.IsAny<List<CourseReview>>()))
                      .Returns(new List<GetCourseReviewDTO> { new GetCourseReviewDTO { Message = "Good course", Rate = 5 }, new GetCourseReviewDTO { Message = "Average course", Rate = 3 } });

            // Act
            var result = await service.GetCourseReviews(claimsPrincipal, courseId, null, null, null, null, 1, 10);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Result);
        }

        [Fact]
        public async Task GetCourseReviews_ReturnsBadRequest_WhenCourseIdIsNull()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();
            var courseServiceMock = new Mock<ICourseService>();
            var service = new CourseReviewService(unitOfWorkMock.Object, mapperMock.Object, courseServiceMock.Object);
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, "test_user") }));

            // Act
            var result = await service.GetCourseReviews(claimsPrincipal, null, null, null, null, null, 1, 10);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(400, result.StatusCode);
            Assert.Null(result.Result);
        }

        [Fact]
        public async Task GetCourseReviews_ReturnsNotFound_WhenNoReviewsExist()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();
            var courseServiceMock = new Mock<ICourseService>();
            var service = new CourseReviewService(unitOfWorkMock.Object, mapperMock.Object, courseServiceMock.Object);
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, "test_user") }));
            var courseId = Guid.NewGuid();
            var reviews = new List<CourseReview>();
            unitOfWorkMock.Setup(u => u.CourseReviewRepository.GetAllAsync(It.IsAny<Expression<Func<CourseReview, bool>>>(), It.IsAny<string>()))
                          .ReturnsAsync(reviews);

            // Act
            var result = await service.GetCourseReviews(claimsPrincipal, courseId, null, null, null, null, 1, 10);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Empty((List<CourseReview>)result.Result);
        }

        // Test for GetCourseReviewById
        [Fact]
        public async Task GetCourseReviewById_ReturnsCourseReview_WhenIdIsValid()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();
            var courseServiceMock = new Mock<ICourseService>();
            var service = new CourseReviewService(unitOfWorkMock.Object, mapperMock.Object, courseServiceMock.Object);
            var courseReview = new CourseReview { Id = Guid.NewGuid(), Message = "Great course", Rate = 5 };
            unitOfWorkMock.Setup(u => u.CourseReviewRepository.GetById(It.IsAny<Guid>()))
                          .ReturnsAsync(courseReview);

            // Act
            var result = await service.GetCourseReviewById(courseReview.Id);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Result);
        }

        [Fact]
        public async Task GetCourseReviewById_ReturnsNotFound_WhenCourseReviewDoesNotExist()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();
            var courseServiceMock = new Mock<ICourseService>();
            var service = new CourseReviewService(unitOfWorkMock.Object, mapperMock.Object, courseServiceMock.Object);
            var id = Guid.NewGuid();
            unitOfWorkMock.Setup(u => u.CourseReviewRepository.GetById(It.IsAny<Guid>()))
                          .ReturnsAsync((CourseReview)null);

            // Act
            var result = await service.GetCourseReviewById(id);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Null(result.Result);
        }

        [Fact]
        public async Task GetCourseReviewById_ReturnsInternalServerError_WhenExceptionOccurs()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();
            var courseServiceMock = new Mock<ICourseService>();
            var service = new CourseReviewService(unitOfWorkMock.Object, mapperMock.Object, courseServiceMock.Object);
            var id = Guid.NewGuid();
            unitOfWorkMock.Setup(u => u.CourseReviewRepository.GetById(It.IsAny<Guid>()))
                          .ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await service.GetCourseReviewById(id);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Null(result.Result);
        }



        [Fact]
        public async Task CreateCourseReview_ReturnsNotFound_WhenCourseDoesNotExist()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();
            var courseServiceMock = new Mock<ICourseService>();
            var service = new CourseReviewService(unitOfWorkMock.Object, mapperMock.Object, courseServiceMock.Object);
            var createCourseReviewDTO = new CreateCourseReviewDTO { CourseId = Guid.NewGuid(), StudentId = Guid.NewGuid(), Rate = 5, Message = "Excellent" };
            unitOfWorkMock.Setup(u => u.CourseRepository.GetById(It.IsAny<Guid>()))
                          .ReturnsAsync((Course)null);

            // Act
            var result = await service.CreateCourseReview(new ClaimsPrincipal(), createCourseReviewDTO);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Null(result.Result);
        }

        [Fact]
        public async Task CreateCourseReview_ReturnsNotFound_WhenStudentDoesNotExist()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();
            var courseServiceMock = new Mock<ICourseService>();
            var service = new CourseReviewService(unitOfWorkMock.Object, mapperMock.Object, courseServiceMock.Object);
            var createCourseReviewDTO = new CreateCourseReviewDTO { CourseId = Guid.NewGuid(), StudentId = Guid.NewGuid(), Rate = 5, Message = "Excellent" };
            unitOfWorkMock.Setup(u => u.CourseRepository.GetById(It.IsAny<Guid>()))
                          .ReturnsAsync(new Course { Id = createCourseReviewDTO.CourseId });
            unitOfWorkMock.Setup(u => u.StudentRepository.GetById(It.IsAny<Guid>()))
                          .ReturnsAsync((Student)null);

            // Act
            var result = await service.CreateCourseReview(new ClaimsPrincipal(), createCourseReviewDTO);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Null(result.Result);
        }

    }
}
