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
using Cursus.LMS.Utility.Constants;
using Moq;
using Xunit;

namespace Cursus.LMS.Test.UnitTesting
{
    public class OrderServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IOrderStatusService> _orderStatusServiceMock;
        private readonly Mock<IStripeService> _stripeServiceMock;
        private readonly Mock<IStudentCourseService> _studentCourseServiceMock;
        private readonly Mock<ITransactionService> _transactionServiceMock;
        private readonly Mock<ICourseService> _courseServiceMock;
        private readonly Mock<IBalanceService> _balanceService;
        private readonly OrderService _service;

        public OrderServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
            _orderStatusServiceMock = new Mock<IOrderStatusService>();
            _stripeServiceMock = new Mock<IStripeService>();
            _studentCourseServiceMock = new Mock<IStudentCourseService>();
            _transactionServiceMock = new Mock<ITransactionService>();
            _courseServiceMock = new Mock<ICourseService>();
            _balanceService = new Mock<IBalanceService>();

            _service = new OrderService(
                _unitOfWorkMock.Object,
                _mapperMock.Object,
                _orderStatusServiceMock.Object,
                _stripeServiceMock.Object,
                _studentCourseServiceMock.Object,
                _transactionServiceMock.Object,
                _courseServiceMock.Object,
                _balanceService.Object
            );
        }

        private ClaimsPrincipal GetUserPrincipal(string role, string userName = "testuser")
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
            };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            return new ClaimsPrincipal(identity);
        }

        [Fact]
        public async Task CreateOrder_StudentNotFound_ReturnsNotFound()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Student);

            _unitOfWorkMock.Setup(x => x.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((Student)null);

            // Act
            var result = await _service.CreateOrder(user);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("Student was not found", result.Message);
        }

        [Fact]
        public async Task CreateOrder_CartHeaderNotFound_CreatesCartHeaderAndReturnsBadRequest()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Student);
            var student = new Student { StudentId = Guid.NewGuid(), ApplicationUser = new ApplicationUser { Email = "test@example.com" } };

            _unitOfWorkMock.Setup(x => x.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(student);

            _unitOfWorkMock.Setup(x => x.CartHeaderRepository.GetAsync(It.IsAny<Expression<Func<CartHeader, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((CartHeader)null);

            _unitOfWorkMock.Setup(x => x.CartHeaderRepository.AddAsync(It.IsAny<CartHeader>()))
                .Returns(Task.CompletedTask);
            _unitOfWorkMock.Setup(x => x.SaveAsync())
                .ReturnsAsync(1);

            // Act
            var result = await _service.CreateOrder(user);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Cart was not found", result.Message);
        }

        [Fact]
        public async Task CreateOrder_EmptyCart_ReturnsBadRequest()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Student);
            var student = new Student { StudentId = Guid.NewGuid(), ApplicationUser = new ApplicationUser { Email = "test@example.com" } };
            var cartHeader = new CartHeader { Id = Guid.NewGuid(), StudentId = student.StudentId, TotalPrice = 0 };

            _unitOfWorkMock.Setup(x => x.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(student);
            _unitOfWorkMock.Setup(x => x.CartHeaderRepository.GetAsync(It.IsAny<Expression<Func<CartHeader, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(cartHeader);
            _unitOfWorkMock.Setup(x => x.CartDetailsRepository.GetAllAsync(It.IsAny<Expression<Func<CartDetails, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(new List<CartDetails>());

            // Act
            var result = await _service.CreateOrder(user);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Cart is empty", result.Message);
        }

        [Fact]
        public async Task CreateOrder_SuccessfulOrderCreation_ReturnsSuccess()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Student);
            var student = new Student { StudentId = Guid.NewGuid(), ApplicationUser = new ApplicationUser { Email = "test@example.com" } };
            var cartHeader = new CartHeader { Id = Guid.NewGuid(), StudentId = student.StudentId, TotalPrice = 100 };
            var cartDetails = new List<CartDetails>
    {
        new CartDetails { Id = Guid.NewGuid(), CourseId = Guid.NewGuid(), CoursePrice = 50, CourseTitle = "Course 1" },
        new CartDetails { Id = Guid.NewGuid(), CourseId = Guid.NewGuid(), CoursePrice = 50, CourseTitle = "Course 2" }
    };

            _unitOfWorkMock.Setup(x => x.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(student);
            _unitOfWorkMock.Setup(x => x.CartHeaderRepository.GetAsync(It.IsAny<Expression<Func<CartHeader, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(cartHeader);
            _unitOfWorkMock.Setup(x => x.CartDetailsRepository.GetAllAsync(It.IsAny<Expression<Func<CartDetails, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(cartDetails);

            _unitOfWorkMock.Setup(x => x.OrderHeaderRepository.AddAsync(It.IsAny<OrderHeader>()))
                .Returns(Task.CompletedTask);
            _unitOfWorkMock.Setup(x => x.OrderDetailsRepository.AddRangeAsync(It.IsAny<IEnumerable<OrderDetails>>()))
                .Returns(Task.CompletedTask);
            _unitOfWorkMock.Setup(x => x.CartDetailsRepository.RemoveRange(It.IsAny<IEnumerable<CartDetails>>()));
            _unitOfWorkMock.Setup(x => x.CartHeaderRepository.Update(It.IsAny<CartHeader>()));
            _unitOfWorkMock.Setup(x => x.SaveAsync())
                .ReturnsAsync(1);

            var orderHeader = new OrderHeader { Id = Guid.NewGuid() };
            _mapperMock.Setup(m => m.Map<GetOrderHeaderDTO>(It.IsAny<OrderHeader>()))
                .Returns(new GetOrderHeaderDTO { Id = orderHeader.Id });

            _orderStatusServiceMock.Setup(x => x.CreateOrderStatus(It.IsAny<ClaimsPrincipal>(), It.IsAny<CreateOrderStatusDTO>()))
                .ReturnsAsync(new ResponseDTO
                {
                    Message = "Order status created successfully",
                    Result = null,
                    IsSuccess = true,
                    StatusCode = 200
                });

            // Act
            var result = await _service.CreateOrder(user);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Result);
            var orderHeaderDto = result.Result as GetOrderHeaderDTO;
            Assert.NotNull(orderHeaderDto);
        }


        [Fact]
        public async Task CreateOrder_ExceptionThrown_ReturnsServerError()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Student);
            var student = new Student { StudentId = Guid.NewGuid(), ApplicationUser = new ApplicationUser { Email = "test@example.com" } };

            _unitOfWorkMock.Setup(x => x.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(student);

            _unitOfWorkMock.Setup(x => x.CartHeaderRepository.GetAsync(It.IsAny<Expression<Func<CartHeader, bool>>>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _service.CreateOrder(user);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Database error", result.Message);
        }

        [Fact]
        public async Task CreateOrder_OrderStatusCreationFails_ReturnsServerError()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Student);
            var student = new Student { StudentId = Guid.NewGuid(), ApplicationUser = new ApplicationUser { Email = "test@example.com" } };
            var cartHeader = new CartHeader { Id = Guid.NewGuid(), StudentId = student.StudentId, TotalPrice = 100 };
            var cartDetails = new List<CartDetails>
            {
                new CartDetails { Id = Guid.NewGuid(), CourseId = Guid.NewGuid(), CoursePrice = 50, CourseTitle = "Course 1" },
                new CartDetails { Id = Guid.NewGuid(), CourseId = Guid.NewGuid(), CoursePrice = 50, CourseTitle = "Course 2" }
            };

            _unitOfWorkMock.Setup(x => x.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(student);
            _unitOfWorkMock.Setup(x => x.CartHeaderRepository.GetAsync(It.IsAny<Expression<Func<CartHeader, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(cartHeader);
            _unitOfWorkMock.Setup(x => x.CartDetailsRepository.GetAllAsync(It.IsAny<Expression<Func<CartDetails, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(cartDetails);

            _unitOfWorkMock.Setup(x => x.OrderHeaderRepository.AddAsync(It.IsAny<OrderHeader>()))
                .Returns(Task.CompletedTask);
            _unitOfWorkMock.Setup(x => x.OrderDetailsRepository.AddRangeAsync(It.IsAny<IEnumerable<OrderDetails>>()))
                .Returns(Task.CompletedTask);
            _unitOfWorkMock.Setup(x => x.CartDetailsRepository.RemoveRange(It.IsAny<IEnumerable<CartDetails>>()));
            _unitOfWorkMock.Setup(x => x.CartHeaderRepository.Update(It.IsAny<CartHeader>()));
            _unitOfWorkMock.Setup(x => x.SaveAsync())
                .ReturnsAsync(1);

            var orderHeader = new OrderHeader { Id = Guid.NewGuid() };
            _mapperMock.Setup(m => m.Map<GetOrderHeaderDTO>(It.IsAny<OrderHeader>()))
                .Returns(new GetOrderHeaderDTO { Id = orderHeader.Id });

            _orderStatusServiceMock.Setup(x => x.CreateOrderStatus(It.IsAny<ClaimsPrincipal>(), It.IsAny<CreateOrderStatusDTO>()))
                .ThrowsAsync(new Exception("Failed to create order status"));

            // Act
            var result = await _service.CreateOrder(user);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Failed to create order status", result.Message);
        }
        [Fact]
        public async Task GetOrders_ReturnsFilteredOrdersByStatus()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Student);
            var orders = new List<OrderHeader>
    {
        new OrderHeader { Id = Guid.NewGuid(), CreatedTime = DateTime.UtcNow.AddDays(-1), OrderPrice = 100,  CreatedBy = "user1@example.com" },
        new OrderHeader { Id = Guid.NewGuid(), CreatedTime = DateTime.UtcNow, OrderPrice = 200, CreatedBy = "user2@example.com" }
    }.AsQueryable();

            _unitOfWorkMock.Setup(x => x.OrderHeaderRepository.GetAllAsync(It.IsAny<Expression<Func<OrderHeader, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(orders);

            // Act
            var result = await _service.GetOrders(
                user,
                null,
                "status",
                "Pending",
                null,
                null
            );

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            var response = result.Result as IEnumerable<OrderHeader>;
            Assert.NotNull(response);
            Assert.Single(response);
        }
        [Fact]
        public async Task GetOrders_ReturnsSortedOrdersByCreatedTime()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Student);
            var orders = new List<OrderHeader>
    {
        new OrderHeader { Id = Guid.NewGuid(), CreatedTime = DateTime.UtcNow, OrderPrice = 200, CreatedBy = "user2@example.com" },
        new OrderHeader { Id = Guid.NewGuid(), CreatedTime = DateTime.UtcNow.AddDays(-1), OrderPrice = 100, CreatedBy = "user1@example.com" }
    }.AsQueryable();

            _unitOfWorkMock.Setup(x => x.OrderHeaderRepository.GetAllAsync(It.IsAny<Expression<Func<OrderHeader, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(orders);

            // Act
            var result = await _service.GetOrders(
                user,
                null,
                null,
                null,
                "createdtime",
                true
            );

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            var response = result.Result as IEnumerable<OrderHeader>;
            Assert.NotNull(response);
            var orderList = response.ToList();
            Assert.Equal(2, orderList.Count);
            Assert.Equal(orderList.First().CreatedTime, orders.OrderBy(o => o.CreatedTime).First().CreatedTime);
        }
        [Fact]
        public async Task GetOrders_ReturnsPagedOrders()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Student);
            var orders = new List<OrderHeader>
    {
        new OrderHeader { Id = Guid.NewGuid(), CreatedTime = DateTime.UtcNow.AddDays(-3), OrderPrice = 300, CreatedBy = "user3@example.com" },
        new OrderHeader { Id = Guid.NewGuid(), CreatedTime = DateTime.UtcNow.AddDays(-2), OrderPrice = 200, CreatedBy = "user2@example.com" },
        new OrderHeader { Id = Guid.NewGuid(), CreatedTime = DateTime.UtcNow.AddDays(-1), OrderPrice = 100, CreatedBy = "user1@example.com" }
    }.AsQueryable();

            _unitOfWorkMock.Setup(x => x.OrderHeaderRepository.GetAllAsync(It.IsAny<Expression<Func<OrderHeader, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(orders);

            // Act
            var result = await _service.GetOrders(
                user,
                null,
                null,
                null,
                null,
                null,
                pageNumber: 1,
                pageSize: 2
            );

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            var response = result.Result as IEnumerable<OrderHeader>;
            Assert.NotNull(response);
            Assert.Equal(2, response.Count()); // Ensure only 2 orders are returned
        }
        [Fact]
        public async Task GetOrder_ReturnsOrderSuccessfully()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Student);
            var orderId = Guid.NewGuid();
            var student = new Student { UserId = "user1" };
            var orderHeader = new OrderHeader { Id = orderId, CreatedTime = DateTime.UtcNow, OrderPrice = 100 };
            var orderDetails = new List<OrderDetails>
    {
        new OrderDetails { Id = Guid.NewGuid(), CourseId = Guid.NewGuid(), OrderHeaderId = orderId, CoursePrice = 50, CourseTitle = "Course 1" }
    };

            _unitOfWorkMock.Setup(x => x.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(student);
            _unitOfWorkMock.Setup(x => x.OrderHeaderRepository.GetAsync(It.IsAny<Expression<Func<OrderHeader, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(orderHeader);
            _unitOfWorkMock.Setup(x => x.OrderDetailsRepository.GetAllAsync(It.IsAny<Expression<Func<OrderDetails, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(orderDetails);

            // Act
            var result = await _service.GetOrder(user, orderId);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            var response = result.Result as GetOrderHeaderDTO;
            Assert.NotNull(response);
            Assert.Equal(orderId, response.Id);
            Assert.Single(response.GetOrderDetails);
        }
        [Fact]
        public async Task GetOrder_ReturnsNotFoundIfStudentDoesNotExist()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Student);
            var orderId = Guid.NewGuid();

            _unitOfWorkMock.Setup(x => x.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((Student)null);

            // Act
            var result = await _service.GetOrder(user, orderId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Null(result.Result);
            Assert.Equal("Student was not found", result.Message);
        }
        [Fact]
        public async Task GetOrder_ReturnsNotFoundIfOrderDoesNotExist()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Student);
            var orderId = Guid.NewGuid();
            var student = new Student { UserId = "user1" };

            _unitOfWorkMock.Setup(x => x.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(student);
            _unitOfWorkMock.Setup(x => x.OrderHeaderRepository.GetAsync(It.IsAny<Expression<Func<OrderHeader, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((OrderHeader)null);

            // Act
            var result = await _service.GetOrder(user, orderId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Null(result.Result);
            Assert.Equal("Order was not found", result.Message);
        }
        [Fact]
        public async Task PayWithStripe_CreatesPaymentSessionSuccessfully()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Student);
            var orderId = Guid.NewGuid();
            var payWithStripeDto = new PayWithStripeDTO
            {
                OrderHeaderId = orderId,
                ApprovedUrl = "https://example.com/success",
                CancelUrl = "https://example.com/cancel"
            };

            var orderHeader = new OrderHeader { Id = orderId, Status = 0 };
            var orderDetails = new List<OrderDetails>
    {
        new OrderDetails { Id = Guid.NewGuid(), CourseId = Guid.NewGuid(), OrderHeaderId = orderId, CoursePrice = 100, CourseTitle = "Course 1" }
    };
            var stripeResponse = new ResponseDTO
            {
                IsSuccess = true,
                StatusCode = 200,
                Result = new ResponseStripeSessionDTO { StripeSessionId = "session_id" }
            };

            _unitOfWorkMock.Setup(x => x.OrderHeaderRepository.GetAsync(It.IsAny<Expression<Func<OrderHeader, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(orderHeader);
            _unitOfWorkMock.Setup(x => x.OrderDetailsRepository.GetAllAsync(It.IsAny<Expression<Func<OrderDetails, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(orderDetails);
            _stripeServiceMock.Setup(x => x.CreatePaymentSession(It.IsAny<CreateStripeSessionDTO>()))
                .ReturnsAsync(stripeResponse);

            // Act
            var result = await _service.PayWithStripe(user, payWithStripeDto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            var response = result.Result as ResponseStripeSessionDTO;
            Assert.NotNull(response);
            Assert.Equal("session_id", response.StripeSessionId);
        }
        [Fact]
        public async Task PayWithStripe_ReturnsNotFoundIfOrderDoesNotExist()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Student);
            var payWithStripeDto = new PayWithStripeDTO { OrderHeaderId = Guid.NewGuid() };

            _unitOfWorkMock.Setup(x => x.OrderHeaderRepository.GetAsync(It.IsAny<Expression<Func<OrderHeader, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((OrderHeader)null);

            // Act
            var result = await _service.PayWithStripe(user, payWithStripeDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Null(result.Result);
            Assert.Equal("Order was not found", result.Message);
        }
        [Fact]
        public async Task PayWithStripe_ReturnsAlreadyPaidIfOrderIsPaid()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Student);
            var orderId = Guid.NewGuid();
            var payWithStripeDto = new PayWithStripeDTO { OrderHeaderId = orderId };

            var orderHeader = new OrderHeader { Id = orderId, Status = 1 }; // Status 1 indicates paid

            _unitOfWorkMock.Setup(x => x.OrderHeaderRepository.GetAsync(It.IsAny<Expression<Func<OrderHeader, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(orderHeader);

            // Act
            var result = await _service.PayWithStripe(user, payWithStripeDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(400, result.StatusCode);
            Assert.Null(result.Result);
            Assert.Equal("Order was paid", result.Message);
        }
        [Fact]
        public async Task ValidateWithStripe_SuccessfullyValidatesPayment()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Student);
            var orderId = Guid.NewGuid();
            var stripeSessionId = "stripe_session_id";
            var validateWithStripeDto = new ValidateWithStripeDTO { OrderHeaderId = orderId };

            var orderHeader = new OrderHeader { Id = orderId, Status = 0, StripeSessionId = stripeSessionId, OrderPrice = 100 };
            var student = new Student { StudentId = Guid.NewGuid(), UserId = "user_id" };
            var stripeResponse = new ResponseDTO
            {
                IsSuccess = true,
                StatusCode = 200,
                Result = new ValidateStripeSessionDTO { Status = "succeeded", PaymentIntentId = "payment_intent_id" }
            };

            _unitOfWorkMock.Setup(x => x.OrderHeaderRepository.GetAsync(It.IsAny<Expression<Func<OrderHeader, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(orderHeader);
            _unitOfWorkMock.Setup(x => x.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(student);
            _stripeServiceMock.Setup(x => x.ValidatePaymentSession(It.IsAny<ValidateStripeSessionDTO>()))
                .ReturnsAsync(stripeResponse);

            _orderStatusServiceMock.Setup(x => x.CreateOrderStatus(It.IsAny<ClaimsPrincipal>(), It.IsAny<CreateOrderStatusDTO>()))
                .ReturnsAsync(new ResponseDTO { IsSuccess = true, StatusCode = 200 });
            _transactionServiceMock.Setup(x => x.CreateTransaction(It.IsAny<CreateTransactionDTO>()))
                .ReturnsAsync(new ResponseDTO { IsSuccess = true, StatusCode = 200 });

            // Act
            var result = await _service.ValidateWithStripe(user, validateWithStripeDto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Validate payment with stripe successfully", result.Message);
        }
        [Fact]
        public async Task ValidateWithStripe_ReturnsNotFoundIfOrderDoesNotExist()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Student);
            var validateWithStripeDto = new ValidateWithStripeDTO { OrderHeaderId = Guid.NewGuid() };

            _unitOfWorkMock.Setup(x => x.OrderHeaderRepository.GetAsync(It.IsAny<Expression<Func<OrderHeader, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((OrderHeader)null);

            // Act
            var result = await _service.ValidateWithStripe(user, validateWithStripeDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Null(result.Result);
            Assert.Equal("Order was not found", result.Message);
        }
        [Fact]
        public async Task ValidateWithStripe_ReturnsNotFoundIfStudentDoesNotExist()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Student);
            var orderId = Guid.NewGuid();
            var validateWithStripeDto = new ValidateWithStripeDTO { OrderHeaderId = orderId };

            var orderHeader = new OrderHeader { Id = orderId, Status = 0, StripeSessionId = "stripe_session_id" };
            _unitOfWorkMock.Setup(x => x.OrderHeaderRepository.GetAsync(It.IsAny<Expression<Func<OrderHeader, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(orderHeader);
            _unitOfWorkMock.Setup(x => x.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((Student)null);

            // Act
            var result = await _service.ValidateWithStripe(user, validateWithStripeDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Null(result.Result);
            Assert.Equal("Student was not found", result.Message);
        }
        [Fact]
        public async Task ValidateWithStripe_ReturnsProcessingIfStripeSessionNotSucceeded()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Student);
            var orderId = Guid.NewGuid();
            var validateWithStripeDto = new ValidateWithStripeDTO { OrderHeaderId = orderId };

            var orderHeader = new OrderHeader { Id = orderId, Status = 0, StripeSessionId = "stripe_session_id" };
            var student = new Student { StudentId = Guid.NewGuid(), UserId = "user_id" };
            var stripeResponse = new ResponseDTO
            {
                IsSuccess = true,
                StatusCode = 200,
                Result = new ValidateStripeSessionDTO { Status = "pending" }
            };

            _unitOfWorkMock.Setup(x => x.OrderHeaderRepository.GetAsync(It.IsAny<Expression<Func<OrderHeader, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(orderHeader);
            _unitOfWorkMock.Setup(x => x.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(student);
            _stripeServiceMock.Setup(x => x.ValidatePaymentSession(It.IsAny<ValidateStripeSessionDTO>()))
                .ReturnsAsync(stripeResponse);

            // Act
            var result = await _service.ValidateWithStripe(user, validateWithStripeDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Order still processing", result.Message);
        }
        [Fact]
        public async Task ValidateWithStripe_ReturnsErrorIfOrderStatusUpdateFails()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Student);
            var orderId = Guid.NewGuid();
            var validateWithStripeDto = new ValidateWithStripeDTO { OrderHeaderId = orderId };

            var orderHeader = new OrderHeader { Id = orderId, Status = 0, StripeSessionId = "stripe_session_id", OrderPrice = 100 };
            var student = new Student { StudentId = Guid.NewGuid(), UserId = "user_id" };
            var stripeResponse = new ResponseDTO
            {
                IsSuccess = true,
                StatusCode = 200,
                Result = new ValidateStripeSessionDTO { Status = "succeeded", PaymentIntentId = "payment_intent_id" }
            };

            _unitOfWorkMock.Setup(x => x.OrderHeaderRepository.GetAsync(It.IsAny<Expression<Func<OrderHeader, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(orderHeader);
            _unitOfWorkMock.Setup(x => x.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(student);
            _stripeServiceMock.Setup(x => x.ValidatePaymentSession(It.IsAny<ValidateStripeSessionDTO>()))
                .ReturnsAsync(stripeResponse);

            _orderStatusServiceMock.Setup(x => x.CreateOrderStatus(It.IsAny<ClaimsPrincipal>(), It.IsAny<CreateOrderStatusDTO>()))
                .ReturnsAsync(new ResponseDTO { IsSuccess = false, StatusCode = 500 });

            // Act
            var result = await _service.ValidateWithStripe(user, validateWithStripeDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Internal server error", result.Message);
        }
        [Fact]
        public async Task ValidateWithStripe_ReturnsErrorIfTransactionCreationFails()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Student);
            var orderId = Guid.NewGuid();
            var validateWithStripeDto = new ValidateWithStripeDTO { OrderHeaderId = orderId };

            var orderHeader = new OrderHeader { Id = orderId, Status = 0, StripeSessionId = "stripe_session_id", OrderPrice = 100 };
            var student = new Student { StudentId = Guid.NewGuid(), UserId = "user_id" };
            var stripeResponse = new ResponseDTO
            {
                IsSuccess = true,
                StatusCode = 200,
                Result = new ValidateStripeSessionDTO { Status = "succeeded", PaymentIntentId = "payment_intent_id" }
            };

            _unitOfWorkMock.Setup(x => x.OrderHeaderRepository.GetAsync(It.IsAny<Expression<Func<OrderHeader, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(orderHeader);
            _unitOfWorkMock.Setup(x => x.StudentRepository.GetAsync(It.IsAny<Expression<Func<Student, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(student);
            _stripeServiceMock.Setup(x => x.ValidatePaymentSession(It.IsAny<ValidateStripeSessionDTO>()))
                .ReturnsAsync(stripeResponse);

            _orderStatusServiceMock.Setup(x => x.CreateOrderStatus(It.IsAny<ClaimsPrincipal>(), It.IsAny<CreateOrderStatusDTO>()))
                .ReturnsAsync(new ResponseDTO { IsSuccess = true, StatusCode = 200 });
            _transactionServiceMock.Setup(x => x.CreateTransaction(It.IsAny<CreateTransactionDTO>()))
                .ReturnsAsync(new ResponseDTO { IsSuccess = false, StatusCode = 500 });

            // Act
            var result = await _service.ValidateWithStripe(user, validateWithStripeDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Internal server error", result.Message);
        }
        [Fact]
        public async Task ConfirmOrder_SuccessfullyConfirmsOrder()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Student);
            var orderId = Guid.NewGuid();
            var orderHeader = new OrderHeader
            {
                Id = orderId,
                Status = StaticStatus.Order.Paid,
                StudentId = Guid.NewGuid()
            };
            var orderDetails = new List<OrderDetails>
    {
        new OrderDetails { CourseId = Guid.NewGuid(), CoursePrice = 100, OrderHeaderId = orderId }
    };

            _unitOfWorkMock.Setup(x => x.OrderHeaderRepository.GetAsync(It.IsAny<Expression<Func<OrderHeader, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(orderHeader);
            _unitOfWorkMock.Setup(x => x.OrderDetailsRepository.GetAllAsync(It.IsAny<Expression<Func<OrderDetails, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(orderDetails);

            _orderStatusServiceMock.Setup(x => x.CreateOrderStatus(It.IsAny<ClaimsPrincipal>(), It.IsAny<CreateOrderStatusDTO>()))
                .ReturnsAsync(new ResponseDTO { IsSuccess = true, StatusCode = 200 });
            _studentCourseServiceMock.Setup(x => x.CreateStudentCourse(It.IsAny<ClaimsPrincipal>(), It.IsAny<EnrollCourseDTO>()))
                .ReturnsAsync(new ResponseDTO { IsSuccess = true, StatusCode = 200 });
            _courseServiceMock.Setup(x => x.UpsertCourseTotal(It.IsAny<UpsertCourseTotalDTO>()))
                .ReturnsAsync(new ResponseDTO { IsSuccess = true, StatusCode = 200 });

            // Act
            var result = await _service.ConfirmOrder(user, orderId);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Confirm order successfully", result.Message);
        }
        [Fact]
        public async Task ConfirmOrder_ReturnsNotFoundIfOrderDoesNotExist()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Student);
            var orderId = Guid.NewGuid();

            _unitOfWorkMock.Setup(x => x.OrderHeaderRepository.GetAsync(It.IsAny<Expression<Func<OrderHeader, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((OrderHeader)null);

            // Act
            var result = await _service.ConfirmOrder(user, orderId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("Order was not found", result.Message);
        }
        [Fact]
        public async Task ConfirmOrder_ReturnsBadRequestIfOrderNotPaid()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Student);
            var orderId = Guid.NewGuid();
            var orderHeader = new OrderHeader
            {
                Id = orderId,
                Status = StaticStatus.Order.Pending
            };

            _unitOfWorkMock.Setup(x => x.OrderHeaderRepository.GetAsync(It.IsAny<Expression<Func<OrderHeader, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(orderHeader);

            // Act
            var result = await _service.ConfirmOrder(user, orderId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Order was not paid", result.Message);
        }
        [Fact]
        public async Task ConfirmOrder_ReturnsNotFoundIfOrderDetailsAreEmpty()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Student);
            var orderId = Guid.NewGuid();
            var orderHeader = new OrderHeader
            {
                Id = orderId,
                Status = StaticStatus.Order.Paid,
                StudentId = Guid.NewGuid()
            };

            _unitOfWorkMock.Setup(x => x.OrderHeaderRepository.GetAsync(It.IsAny<Expression<Func<OrderHeader, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(orderHeader);
            _unitOfWorkMock.Setup(x => x.OrderDetailsRepository.GetAllAsync(It.IsAny<Expression<Func<OrderDetails, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(new List<OrderDetails>());

            // Act
            var result = await _service.ConfirmOrder(user, orderId);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Confirm order successfully", result.Message);
        }
        [Fact]
        public async Task ConfirmOrder_ReturnsErrorIfOrderStatusCreationFails()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Student);
            var orderId = Guid.NewGuid();
            var orderHeader = new OrderHeader
            {
                Id = orderId,
                Status = StaticStatus.Order.Paid,
                StudentId = Guid.NewGuid()
            };
            var orderDetails = new List<OrderDetails>
    {
        new OrderDetails { CourseId = Guid.NewGuid(), CoursePrice = 100, OrderHeaderId = orderId }
    };

            _unitOfWorkMock.Setup(x => x.OrderHeaderRepository.GetAsync(It.IsAny<Expression<Func<OrderHeader, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(orderHeader);
            _unitOfWorkMock.Setup(x => x.OrderDetailsRepository.GetAllAsync(It.IsAny<Expression<Func<OrderDetails, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(orderDetails);

            _orderStatusServiceMock.Setup(x => x.CreateOrderStatus(It.IsAny<ClaimsPrincipal>(), It.IsAny<CreateOrderStatusDTO>()))
                .ReturnsAsync(new ResponseDTO { IsSuccess = false, StatusCode = 500 });

            // Act
            var result = await _service.ConfirmOrder(user, orderId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Internal server error", result.Message);
        }
        [Fact]
        public async Task ConfirmOrder_ReturnsErrorIfStudentCourseCreationFails()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Student);
            var orderId = Guid.NewGuid();
            var orderHeader = new OrderHeader
            {
                Id = orderId,
                Status = StaticStatus.Order.Paid,
                StudentId = Guid.NewGuid()
            };
            var orderDetails = new List<OrderDetails>
    {
        new OrderDetails { CourseId = Guid.NewGuid(), CoursePrice = 100, OrderHeaderId = orderId }
    };

            _unitOfWorkMock.Setup(x => x.OrderHeaderRepository.GetAsync(It.IsAny<Expression<Func<OrderHeader, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(orderHeader);
            _unitOfWorkMock.Setup(x => x.OrderDetailsRepository.GetAllAsync(It.IsAny<Expression<Func<OrderDetails, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(orderDetails);

            _studentCourseServiceMock.Setup(x => x.CreateStudentCourse(It.IsAny<ClaimsPrincipal>(), It.IsAny<EnrollCourseDTO>()))
                .ReturnsAsync(new ResponseDTO { IsSuccess = false, StatusCode = 500 });

            // Act
            var result = await _service.ConfirmOrder(user, orderId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Internal server error", result.Message);
        }
        [Fact]
        public async Task ConfirmOrder_ReturnsErrorIfCourseTotalUpsertFails()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Student);
            var orderId = Guid.NewGuid();
            var orderHeader = new OrderHeader
            {
                Id = orderId,
                Status = StaticStatus.Order.Paid,
                StudentId = Guid.NewGuid()
            };
            var orderDetails = new List<OrderDetails>
    {
        new OrderDetails { CourseId = Guid.NewGuid(), CoursePrice = 100, OrderHeaderId = orderId }
    };

            _unitOfWorkMock.Setup(x => x.OrderHeaderRepository.GetAsync(It.IsAny<Expression<Func<OrderHeader, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(orderHeader);
            _unitOfWorkMock.Setup(x => x.OrderDetailsRepository.GetAllAsync(It.IsAny<Expression<Func<OrderDetails, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(orderDetails);

            _courseServiceMock.Setup(x => x.UpsertCourseTotal(It.IsAny<UpsertCourseTotalDTO>()))
                .ReturnsAsync(new ResponseDTO { IsSuccess = false, StatusCode = 500 });

            // Act
            var result = await _service.ConfirmOrder(user, orderId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Internal server error", result.Message);
        }
        [Fact]
        public async Task ConfirmOrder_ReturnsInternalServerErrorOnException()
        {
            // Arrange
            var user = GetUserPrincipal(StaticUserRoles.Student);
            var orderId = Guid.NewGuid();
            _unitOfWorkMock.Setup(x => x.OrderHeaderRepository.GetAsync(It.IsAny<Expression<Func<OrderHeader, bool>>>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _service.ConfirmOrder(user, orderId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Database error", result.Message);
        }

    }
}
