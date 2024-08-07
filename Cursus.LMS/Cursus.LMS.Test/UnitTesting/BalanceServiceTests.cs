using System;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.Service;
using Cursus.LMS.Service.IService;
using System.Linq.Expressions;

namespace Cursus.LMS.Service.Tests
{
    public class BalanceServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly BalanceService _balanceService;

        public BalanceServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _balanceService = new BalanceService(_mockUnitOfWork.Object);
        }

        [Fact]
        public async Task UpsertBalance_ShouldAddNewBalance_WhenBalanceDoesNotExist()
        {
            // Arrange
            var upsertBalanceDto = new UpsertBalanceDTO
            {
                UserId = "upsertBalance ID",
                TotalBalance = 100,
                AvailableBalance = 50,
                PayoutBalance = 30
            };

            _mockUnitOfWork.Setup(u => u.BalanceRepository.GetAsync(It.IsAny<Expression<Func<Balance, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((Balance)null);

            _mockUnitOfWork.Setup(u => u.BalanceRepository.AddAsync(It.IsAny<Balance>()))
                .Returns(Task.CompletedTask);

            _mockUnitOfWork.Setup(u => u.SaveAsync())
                .ReturnsAsync(1);

            // Act
            var result = await _balanceService.UpsertBalance(upsertBalanceDto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            _mockUnitOfWork.Verify(u => u.BalanceRepository.AddAsync(It.IsAny<Balance>()), Times.Once);
            _mockUnitOfWork.Verify(u => u.SaveAsync(), Times.Once);
        }





        [Fact]
        public async Task UpsertBalance_ShouldReturnError_WhenExceptionThrown()
        {
            // Arrange
            var upsertBalanceDto = new UpsertBalanceDTO
            {
                UserId = "upsertBalance ID",
                TotalBalance = 100,
                AvailableBalance = 50,
                PayoutBalance = 30
            };

            _mockUnitOfWork.Setup(u => u.BalanceRepository.GetAsync(It.IsAny<Expression<Func<Balance, bool>>>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _balanceService.UpsertBalance(upsertBalanceDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Database error", result.Message);
        }
    }
}
