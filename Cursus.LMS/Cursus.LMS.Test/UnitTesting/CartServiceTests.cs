using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Xunit;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.Service;
using System.Linq.Expressions;

public class CartServiceTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<IMapper> _mockMapper;
    private readonly CartService _cartService;

    public CartServiceTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockMapper = new Mock<IMapper>();
        _cartService = new CartService(_mockUnitOfWork.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task GetCart_ShouldReturnCart_WhenStudentAndCartExist()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, "studentId")
        }));

        var student = new Student { StudentId = Guid.NewGuid() };
        var cartHeader = new CartHeader { Id = Guid.NewGuid(), StudentId = student.StudentId, TotalPrice = 100 };
        var cartDetails = new List<CartDetails>
        {
            new CartDetails { CourseId = Guid.NewGuid(), CoursePrice = 50 }
        };

        var cartHeaderDto = new CartHeaderDTO { CartDetailsDtos = new List<CartDetailsDTO>() };
        _mockUnitOfWork.Setup(u => u.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), It.IsAny<string>())).ReturnsAsync(student);
        _mockUnitOfWork.Setup(u => u.CartHeaderRepository.GetAsync(It.IsAny<Expression<Func<CartHeader, bool>>>(), It.IsAny<string>())).ReturnsAsync(cartHeader);
        _mockUnitOfWork.Setup(u => u.CartDetailsRepository.GetAllAsync(It.IsAny<Expression<Func<CartDetails, bool>>>(), It.IsAny<string>())).ReturnsAsync(cartDetails);
        _mockMapper.Setup(m => m.Map<CartHeaderDTO>(It.IsAny<CartHeader>())).Returns(cartHeaderDto);
        _mockMapper.Setup(m => m.Map<IEnumerable<CartDetailsDTO>>(It.IsAny<IEnumerable<CartDetails>>())).Returns(cartHeaderDto.CartDetailsDtos);

        // Act
        var result = await _cartService.GetCart(user);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.NotNull(result.Result);
    }

    [Fact]
    public async Task AddToCart_ShouldAddCourse_WhenCourseIsValid()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, "studentId")
        }));

        var student = new Student { StudentId = Guid.NewGuid() };
        var course = new Course { Id = Guid.NewGuid(), CourseVersionId = Guid.NewGuid() };
        var courseVersion = new CourseVersion { Id = (Guid)course.CourseVersionId, Price = 100, Title = "Course Title" };
        var addToCartDto = new AddToCartDTO { CourseId = course.Id };
        var cartHeader = new CartHeader { Id = Guid.NewGuid(), StudentId = student.StudentId, TotalPrice = 0 };

        _mockUnitOfWork.Setup(u => u.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), It.IsAny<string>())).ReturnsAsync(student);
        _mockUnitOfWork.Setup(u => u.CourseRepository.GetAsync(It.IsAny<Expression<Func<Course, bool>>>(), It.IsAny<string>())).ReturnsAsync(course);
        _mockUnitOfWork.Setup(u => u.CourseVersionRepository.GetAsync(It.IsAny<Expression<Func<CourseVersion, bool>>>(), It.IsAny<string>())).ReturnsAsync(courseVersion);
        _mockUnitOfWork.Setup(u => u.CartHeaderRepository.GetAsync(It.IsAny<Expression<Func<CartHeader, bool>>>(), It.IsAny<string>())).ReturnsAsync(cartHeader);
        _mockUnitOfWork.Setup(u => u.CartDetailsRepository.GetAsync(It.IsAny<Expression<Func<CartDetails, bool>>>(), It.IsAny<string>())).ReturnsAsync((CartDetails)null);
        _mockUnitOfWork.Setup(u => u.SaveAsync()).ReturnsAsync(1);
        _mockUnitOfWork.Setup(u => u.StudentCourseRepository.GetAsync(It.IsAny<Expression<Func<StudentCourse, bool>>>(), It.IsAny<string>())).ReturnsAsync((StudentCourse)null);

        // Act
        var result = await _cartService.AddToCart(user, addToCartDto);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public async Task RemoveFromCart_ShouldRemoveCourse_WhenCourseExists()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, "studentId")
        }));

        var student = new Student { StudentId = Guid.NewGuid() };
        var cartHeader = new CartHeader { Id = Guid.NewGuid(), StudentId = student.StudentId, TotalPrice = 100 };
        var cartDetails = new CartDetails { Id = Guid.NewGuid(), CourseId = Guid.NewGuid(), CoursePrice = 50, CartHeaderId = cartHeader.Id };

        _mockUnitOfWork.Setup(u => u.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), It.IsAny<string>())).ReturnsAsync(student);
        _mockUnitOfWork.Setup(u => u.CartHeaderRepository.GetAsync(It.IsAny<Expression<Func<CartHeader, bool>>>(), It.IsAny<string>())).ReturnsAsync(cartHeader);
        _mockUnitOfWork.Setup(u => u.CartDetailsRepository.GetAsync(It.IsAny<Expression<Func<CartDetails, bool>>>(), It.IsAny<string>())).ReturnsAsync(cartDetails);
        _mockUnitOfWork.Setup(u => u.SaveAsync()).ReturnsAsync(1);

        // Act
        var result = await _cartService.RemoveFromCart(user, cartDetails.CourseId);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public async Task GetCart_ShouldReturnNotFound_WhenStudentDoesNotExist()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, "nonExistentStudentId")
        }));

        _mockUnitOfWork.Setup(u => u.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), It.IsAny<string>())).ReturnsAsync((Student)null);

        // Act
        var result = await _cartService.GetCart(user);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
        Assert.Equal("Student was not found", result.Message);
    }

    [Fact]
    public async Task AddToCart_ShouldReturnNotFound_WhenCourseDoesNotExist()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, "studentId")
        }));

        var student = new Student { StudentId = Guid.NewGuid() };
        var addToCartDto = new AddToCartDTO { CourseId = Guid.NewGuid() };

        _mockUnitOfWork.Setup(u => u.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), It.IsAny<string>())).ReturnsAsync(student);
        _mockUnitOfWork.Setup(u => u.CourseRepository.GetAsync(It.IsAny<Expression<Func<Course, bool>>>(), It.IsAny<string>())).ReturnsAsync((Course)null);

        // Act
        var result = await _cartService.AddToCart(user, addToCartDto);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
        Assert.Equal("Course was not found", result.Message);
    }

    [Fact]
    public async Task RemoveFromCart_ShouldReturnNotFound_WhenCartHeaderDoesNotExist()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, "studentId")
        }));

        var student = new Student { StudentId = Guid.NewGuid() };
        var courseId = Guid.NewGuid();

        _mockUnitOfWork.Setup(u => u.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), It.IsAny<string>())).ReturnsAsync(student);
        _mockUnitOfWork.Setup(u => u.CartHeaderRepository.GetAsync(It.IsAny<Expression<Func<CartHeader, bool>>>(), It.IsAny<string>())).ReturnsAsync((CartHeader)null);

        // Act
        var result = await _cartService.RemoveFromCart(user, courseId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
        Assert.Equal("Your cart is empty", result.Message);
    }

    [Fact]
    public async Task RemoveFromCart_ShouldReturnNotFound_WhenCourseDoesNotExistInCart()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, "studentId")
        }));

        var student = new Student { StudentId = Guid.NewGuid() };
        var cartHeader = new CartHeader { Id = Guid.NewGuid(), StudentId = student.StudentId, TotalPrice = 100 };
        var courseId = Guid.NewGuid();

        _mockUnitOfWork.Setup(u => u.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), It.IsAny<string>())).ReturnsAsync(student);
        _mockUnitOfWork.Setup(u => u.CartHeaderRepository.GetAsync(It.IsAny<Expression<Func<CartHeader, bool>>>(), It.IsAny<string>())).ReturnsAsync(cartHeader);
        _mockUnitOfWork.Setup(u => u.CartDetailsRepository.GetAsync(It.IsAny<Expression<Func<CartDetails, bool>>>(), It.IsAny<string>())).ReturnsAsync((CartDetails)null);

        // Act
        var result = await _cartService.RemoveFromCart(user, courseId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
        Assert.Equal("Your course does not exist in cart", result.Message);
    }
}
