using Moq;
using Xunit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cursus.LMS.Service.Service;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Utility.Constants;
using Cursus.LMS.Model.Domain;
using System.Security.Claims;
using Cursus.LMS.Model.Domain;
using System.Linq.Expressions;
using Stripe;

namespace Cursus.LMS.Test.UnitTesting
{
    public class PaymentServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IBalanceService> _balanceServiceMock;
        private readonly Mock<ITransactionService> _transactionServiceMock;
        private readonly Mock<IStripeService> _stripeServiceMock;
        private readonly Mock<IEmailService> _emailService;
        private readonly PaymentService _paymentService;

        public PaymentServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _balanceServiceMock = new Mock<IBalanceService>();
            _transactionServiceMock = new Mock<ITransactionService>();
            _stripeServiceMock = new Mock<IStripeService>();
            _emailService = new Mock<IEmailService>();

            _paymentService = new PaymentService(
                _unitOfWorkMock.Object,
                _balanceServiceMock.Object,
                _transactionServiceMock.Object,
                _stripeServiceMock.Object,
                _emailService.Object
            );
        }

        [Fact]
        public async Task CreateStripeConnectedAccount_SuccessfullyCreatesAccount()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var user = new ApplicationUser { Id = userId, Email = "test@example.com" };
            var instructor = new Instructor { UserId = userId, IsAccepted = true, StripeAccountId = null };

            var createStripeDto = new CreateStripeConnectedAccountDTO { Email = user.Email };
            var responseStripeDto = new ResponseStripeConnectedAccountDTO { AccountId = "acct_123" };
            var responseDto = new ResponseDTO
            {
                IsSuccess = true,
                StatusCode = 200,
                Result = responseStripeDto
            };

            _unitOfWorkMock.Setup(x => x.UserManagerRepository.FindByIdAsync(userId))
                .ReturnsAsync(user);
            _unitOfWorkMock.Setup(x => x.InstructorRepository.GetAsync(It.IsAny<Expression<Func<Instructor, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(instructor);
            _stripeServiceMock.Setup(x => x.CreateConnectedAccount(createStripeDto))
                .ReturnsAsync(responseDto);

            // Act
            var result = await _paymentService.CreateStripeConnectedAccount(GetClaimsPrincipal(userId), createStripeDto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("acct_123", ((ResponseStripeConnectedAccountDTO)result.Result).AccountId);
            Assert.Equal("acct_123", instructor.StripeAccountId);
            _unitOfWorkMock.Verify(x => x.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task CreateStripeConnectedAccount_InstructorNotFound_ReturnsNotFound()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var user = new ApplicationUser { Id = userId };

            var createStripeDto = new CreateStripeConnectedAccountDTO { Email = "test@example.com" };

            _unitOfWorkMock.Setup(x => x.UserManagerRepository.FindByIdAsync(userId))
                .ReturnsAsync(user);
            _unitOfWorkMock.Setup(x => x.InstructorRepository.GetAsync(It.IsAny<Expression<Func<Instructor, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((Instructor)null);

            // Act
            var result = await _paymentService.CreateStripeConnectedAccount(GetClaimsPrincipal(userId), createStripeDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("Instructor was not found", result.Message);
        }

        [Fact]
        public async Task CreateStripeConnectedAccount_InstructorNotAccepted_ReturnsForbidden()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var user = new ApplicationUser { Id = userId };
            var instructor = new Instructor { UserId = userId, IsAccepted = false, StripeAccountId = null };

            var createStripeDto = new CreateStripeConnectedAccountDTO { Email = "test@example.com" };

            _unitOfWorkMock.Setup(x => x.UserManagerRepository.FindByIdAsync(userId))
                .ReturnsAsync(user);
            _unitOfWorkMock.Setup(x => x.InstructorRepository.GetAsync(It.IsAny<Expression<Func<Instructor, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(instructor);

            // Act
            var result = await _paymentService.CreateStripeConnectedAccount(GetClaimsPrincipal(userId), createStripeDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(403, result.StatusCode);
            Assert.Equal("Instructor was not allow to create stripe account", result.Message);
        }

        [Fact]
        public async Task CreateStripeConnectedAccount_InstructorAlreadyHasAccount_ReturnsBadRequest()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var user = new ApplicationUser { Id = userId };
            var instructor = new Instructor { UserId = userId, StripeAccountId = "acct_123" };

            var createStripeDto = new CreateStripeConnectedAccountDTO { Email = "test@example.com" };

            _unitOfWorkMock.Setup(x => x.UserManagerRepository.FindByIdAsync(userId))
                .ReturnsAsync(user);
            _unitOfWorkMock.Setup(x => x.InstructorRepository.GetAsync(It.IsAny<Expression<Func<Instructor, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(instructor);

            // Act
            var result = await _paymentService.CreateStripeConnectedAccount(GetClaimsPrincipal(userId), createStripeDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Instructor already has a stripe account", result.Message);
        }

        [Fact]
        public async Task CreateStripeConnectedAccount_StripeServiceError_ReturnsError()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var user = new ApplicationUser { Id = userId, Email = "test@example.com" };
            var instructor = new Instructor { UserId = userId, IsAccepted = true, StripeAccountId = null };

            var createStripeDto = new CreateStripeConnectedAccountDTO { Email = user.Email };
            var responseDto = new ResponseDTO
            {
                IsSuccess = false,
                StatusCode = 500
            };

            _unitOfWorkMock.Setup(x => x.UserManagerRepository.FindByIdAsync(userId))
                .ReturnsAsync(user);
            _unitOfWorkMock.Setup(x => x.InstructorRepository.GetAsync(It.IsAny<Expression<Func<Instructor, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(instructor);
            _stripeServiceMock.Setup(x => x.CreateConnectedAccount(createStripeDto))
                .ReturnsAsync(responseDto);

            // Act
            var result = await _paymentService.CreateStripeConnectedAccount(GetClaimsPrincipal(userId), createStripeDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Null(result.Result);
        }


        [Fact]
        public async Task CreateStripePayout_SuccessfullyCreatesPayout()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var instructor = new Instructor { UserId = userId, StripeAccountId = "acct_123" };
            var createPayoutDto = new CreateStripePayoutDTO
            {
                Amount = 1000,
                Currency = "usd"
            };
            var payout = new Payout { Status = "pending" };
            var responseDto = new ResponseDTO
            {
                IsSuccess = true,
                StatusCode = 200,
                Result = payout
            };

            _unitOfWorkMock.Setup(x => x.InstructorRepository.GetAsync(It.IsAny<Expression<Func<Instructor, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(instructor);
            _stripeServiceMock.Setup(x => x.CreatePayout(createPayoutDto))
                .ReturnsAsync(responseDto);
            _transactionServiceMock.Setup(x => x.CreateTransaction(It.IsAny<CreateTransactionDTO>()))
                .ReturnsAsync(responseDto); // Corrected to return a Task<ResponseDTO>
            _balanceServiceMock.Setup(x => x.UpsertBalance(It.IsAny<UpsertBalanceDTO>()))
                .ReturnsAsync(responseDto); // Corrected to return a Task<ResponseDTO>

            // Act
            var result = await _paymentService.CreateStripePayout(GetClaimsPrincipal(userId), createPayoutDto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("pending", ((Payout)result.Result!).Status);
            _transactionServiceMock.Verify(x => x.CreateTransaction(It.Is<CreateTransactionDTO>(dto => dto.Amount == 1000)), Times.Once);
            _balanceServiceMock.Verify(x => x.UpsertBalance(It.Is<UpsertBalanceDTO>(dto => dto.AvailableBalance == -1000 && dto.PayoutBalance == 1000)), Times.Once);
        }


        [Fact]
        public async Task CreateStripePayout_UserNotFound_ReturnsNotFound()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var createPayoutDto = new CreateStripePayoutDTO { Amount = 1000 };

            _unitOfWorkMock.Setup(x => x.InstructorRepository.GetAsync(It.IsAny<Expression<Func<Instructor, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((Instructor)null);

            // Act
            var result = await _paymentService.CreateStripePayout(GetClaimsPrincipal(userId), createPayoutDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("Instructor was not found", result.Message);
        }

        [Fact]
        public async Task CreateStripePayout_UserIdNull_ReturnsNotFound()
        {
            // Arrange
            var createPayoutDto = new CreateStripePayoutDTO { Amount = 1000 };

            // Act
            var result = await _paymentService.CreateStripePayout(GetClaimsPrincipal(null), createPayoutDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("User was not found", result.Message);
        }

        [Fact]
        public async Task CreateStripePayout_StripeServiceError_ReturnsError()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var instructor = new Instructor { UserId = userId, StripeAccountId = "acct_123" };
            var createPayoutDto = new CreateStripePayoutDTO { Amount = 1000 };
            var responseDto = new ResponseDTO
            {
                IsSuccess = false,
                StatusCode = 500
            };

            _unitOfWorkMock.Setup(x => x.InstructorRepository.GetAsync(It.IsAny<Expression<Func<Instructor, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(instructor);
            _stripeServiceMock.Setup(x => x.CreatePayout(createPayoutDto))
                .ReturnsAsync(responseDto);

            // Act
            var result = await _paymentService.CreateStripePayout(GetClaimsPrincipal(userId), createPayoutDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Null(result.Result);
        }

        [Fact]
        public async Task CreateStripePayout_PayoutNotPending_ReturnsResponse()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var instructor = new Instructor { UserId = userId, StripeAccountId = "acct_123" };
            var createPayoutDto = new CreateStripePayoutDTO { Amount = 1000 };
            var payout = new Payout { Status = "failed" };
            var responseDto = new ResponseDTO
            {
                IsSuccess = true,
                StatusCode = 200,
                Result = payout
            };

            _unitOfWorkMock.Setup(x => x.InstructorRepository.GetAsync(It.IsAny<Expression<Func<Instructor, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(instructor);
            _stripeServiceMock.Setup(x => x.CreatePayout(createPayoutDto))
                .ReturnsAsync(responseDto);

            // Act
            var result = await _paymentService.CreateStripePayout(GetClaimsPrincipal(userId), createPayoutDto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("failed", ((Payout)result.Result!).Status);
            _transactionServiceMock.Verify(x => x.CreateTransaction(It.IsAny<CreateTransactionDTO>()), Times.Never);
            _balanceServiceMock.Verify(x => x.UpsertBalance(It.IsAny<UpsertBalanceDTO>()), Times.Never);
        }

        private ClaimsPrincipal GetClaimsPrincipal(string userId)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId)
            };
            return new ClaimsPrincipal(new ClaimsIdentity(claims, "mock"));
        }
        [Fact]
        public async Task GetTopInstructorsByPayout_NoFilters_ReturnsTopInstructorsForCurrentYear()
        {
            // Arrange
            var transactions = new List<Transaction>
        {
            new Transaction { UserId = "1", Amount = 100, Type = StaticEnum.TransactionType.Payout, CreatedTime = new DateTime(DateTime.UtcNow.Year, 1, 15) },
            new Transaction { UserId = "2", Amount = 200, Type = StaticEnum.TransactionType.Payout, CreatedTime = new DateTime(DateTime.UtcNow.Year, 2, 20) }
        };

            _unitOfWorkMock.Setup(x => x.TransactionRepository.GetAllAsync(
                It.IsAny<Expression<Func<Transaction, bool>>>(),
                It.IsAny<string>()
            )).ReturnsAsync(transactions);

            // Act
            var result = await _paymentService.GetTopInstructorsByPayout();

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            var topInstructors = result.Result as List<dynamic>;
            Assert.NotNull(topInstructors);
            Assert.Single(topInstructors); // Assuming there are only 2 records
        }

        [Fact]
        public async Task GetTopInstructorsByPayout_WithYearFilter_ReturnsTopInstructorsForSpecifiedYear()
        {
            // Arrange
            var transactions = new List<Transaction>
        {
            new Transaction { UserId = "1", Amount = 150, Type = StaticEnum.TransactionType.Payout, CreatedTime = new DateTime(2023, 5, 15) }
        };

            _unitOfWorkMock.Setup(x => x.TransactionRepository.GetAllAsync(
                It.IsAny<Expression<Func<Transaction, bool>>>(),
                It.IsAny<string>()
            )).ReturnsAsync(transactions);

            // Act
            var result = await _paymentService.GetTopInstructorsByPayout(filterYear: 2023);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            var topInstructors = result.Result as List<dynamic>;
            Assert.NotNull(topInstructors);
            Assert.Single(topInstructors);
        }

        [Fact]
        public async Task GetTopInstructorsByPayout_WithMonthFilter_ReturnsTopInstructorsForSpecifiedMonth()
        {
            // Arrange
            var transactions = new List<Transaction>
        {
            new Transaction { UserId = "1", Amount = 200, Type = StaticEnum.TransactionType.Payout, CreatedTime = new DateTime(DateTime.UtcNow.Year, 8, 10) }
        };

            _unitOfWorkMock.Setup(x => x.TransactionRepository.GetAllAsync(
                It.IsAny<Expression<Func<Transaction, bool>>>(),
                It.IsAny<string>()
            )).ReturnsAsync(transactions);

            // Act
            var result = await _paymentService.GetTopInstructorsByPayout(filterMonth: 8);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            var topInstructors = result.Result as List<dynamic>;
            Assert.NotNull(topInstructors);
            Assert.Single(topInstructors);
        }

        [Fact]
        public async Task GetTopInstructorsByPayout_WithQuarterFilter_ReturnsTopInstructorsForSpecifiedQuarter()
        {
            // Arrange
            var transactions = new List<Transaction>
        {
            new Transaction { UserId = "1", Amount = 300, Type = StaticEnum.TransactionType.Payout, CreatedTime = new DateTime(DateTime.UtcNow.Year, 4, 15) }
        };

            _unitOfWorkMock.Setup(x => x.TransactionRepository.GetAllAsync(
                It.IsAny<Expression<Func<Transaction, bool>>>(),
                It.IsAny<string>()
            )).ReturnsAsync(transactions);

            // Act
            var result = await _paymentService.GetTopInstructorsByPayout(filterQuarter: 1);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            var topInstructors = result.Result as List<dynamic>;
            Assert.NotNull(topInstructors);
            Assert.Single(topInstructors);
        }

        [Fact]
        public async Task GetTopInstructorsByPayout_InvalidTopN_ThrowsArgumentException()
        {
            // Arrange
            var transactions = new List<Transaction>();

            _unitOfWorkMock.Setup(x => x.TransactionRepository.GetAllAsync(
                It.IsAny<Expression<Func<Transaction, bool>>>(),
                It.IsAny<string>()
            )).ReturnsAsync(transactions);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _paymentService.GetTopInstructorsByPayout(topN: 0));
        }

        [Fact]
        public async Task GetTopInstructorsByPayout_NoTransactions_ReturnsEmptyList()
        {
            // Arrange
            var transactions = new List<Transaction>();

            _unitOfWorkMock.Setup(x => x.TransactionRepository.GetAllAsync(
                It.IsAny<Expression<Func<Transaction, bool>>>(),
                It.IsAny<string>()
            )).ReturnsAsync(transactions);

            // Act
            var result = await _paymentService.GetTopInstructorsByPayout();

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Empty(result.Result as List<dynamic>);
        }
        [Fact]
        public async Task GetLeastInstructorsByPayout_NoFilters_ReturnsLeastInstructorsForCurrentYear()
        {
            // Arrange
            var transactions = new List<Transaction>
        {
            new Transaction { UserId = "1", Amount = 500, Type = StaticEnum.TransactionType.Payout, CreatedTime = new DateTime(DateTime.UtcNow.Year, 1, 15) },
            new Transaction { UserId = "2", Amount = 300, Type = StaticEnum.TransactionType.Payout, CreatedTime = new DateTime(DateTime.UtcNow.Year, 2, 20) }
        };

            _unitOfWorkMock.Setup(x => x.TransactionRepository.GetAllAsync(
                It.IsAny<Expression<Func<Transaction, bool>>>(),
                It.IsAny<string>()
            )).ReturnsAsync(transactions);

            // Act
            var result = await _paymentService.GetLeastInstructorsByPayout();

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            var leastInstructors = result.Result as List<dynamic>;
            Assert.NotNull(leastInstructors);
            Assert.Equal(2, leastInstructors.Count); // Assuming 2 records
        }

        [Fact]
        public async Task GetLeastInstructorsByPayout_WithYearFilter_ReturnsLeastInstructorsForSpecifiedYear()
        {
            // Arrange
            var transactions = new List<Transaction>
        {
            new Transaction { UserId = "1", Amount = 100, Type = StaticEnum.TransactionType.Payout, CreatedTime = new DateTime(2023, 5, 15) }
        };

            _unitOfWorkMock.Setup(x => x.TransactionRepository.GetAllAsync(
                It.IsAny<Expression<Func<Transaction, bool>>>(),
                It.IsAny<string>()
            )).ReturnsAsync(transactions);

            // Act
            var result = await _paymentService.GetLeastInstructorsByPayout(filterYear: 2023);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            var leastInstructors = result.Result as List<dynamic>;
            Assert.NotNull(leastInstructors);
            Assert.Single(leastInstructors);
        }

        [Fact]
        public async Task GetLeastInstructorsByPayout_WithMonthFilter_ReturnsLeastInstructorsForSpecifiedMonth()
        {
            // Arrange
            var transactions = new List<Transaction>
        {
            new Transaction { UserId = "1", Amount = 200, Type = StaticEnum.TransactionType.Payout, CreatedTime = new DateTime(DateTime.UtcNow.Year, 8, 10) }
        };

            _unitOfWorkMock.Setup(x => x.TransactionRepository.GetAllAsync(
                It.IsAny<Expression<Func<Transaction, bool>>>(),
                It.IsAny<string>()
            )).ReturnsAsync(transactions);

            // Act
            var result = await _paymentService.GetLeastInstructorsByPayout(filterMonth: 8);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            var leastInstructors = result.Result as List<dynamic>;
            Assert.NotNull(leastInstructors);
            Assert.Single(leastInstructors);
        }

        [Fact]
        public async Task GetLeastInstructorsByPayout_WithQuarterFilter_ReturnsLeastInstructorsForSpecifiedQuarter()
        {
            // Arrange
            var transactions = new List<Transaction>
        {
            new Transaction { UserId = "1", Amount = 150, Type = StaticEnum.TransactionType.Payout, CreatedTime = new DateTime(DateTime.UtcNow.Year, 4, 15) }
        };

            _unitOfWorkMock.Setup(x => x.TransactionRepository.GetAllAsync(
                It.IsAny<Expression<Func<Transaction, bool>>>(),
                It.IsAny<string>()
            )).ReturnsAsync(transactions);

            // Act
            var result = await _paymentService.GetLeastInstructorsByPayout(filterQuarter: 1);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            var leastInstructors = result.Result as List<dynamic>;
            Assert.NotNull(leastInstructors);
            Assert.Single(leastInstructors);
        }

        [Fact]
        public async Task GetLeastInstructorsByPayout_InvalidTopN_ThrowsArgumentException()
        {
            // Arrange
            var transactions = new List<Transaction>();

            _unitOfWorkMock.Setup(x => x.TransactionRepository.GetAllAsync(
                It.IsAny<Expression<Func<Transaction, bool>>>(),
                It.IsAny<string>()
            )).ReturnsAsync(transactions);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _paymentService.GetLeastInstructorsByPayout(topN: 0));
        }

        [Fact]
        public async Task GetLeastInstructorsByPayout_NoTransactions_ReturnsEmptyList()
        {
            // Arrange
            var transactions = new List<Transaction>();

            _unitOfWorkMock.Setup(x => x.TransactionRepository.GetAllAsync(
                It.IsAny<Expression<Func<Transaction, bool>>>(),
                It.IsAny<string>()
            )).ReturnsAsync(transactions);

            // Act
            var result = await _paymentService.GetLeastInstructorsByPayout();

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Empty(result.Result as List<dynamic>);
        }
    }
}
