using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.Service;
using Moq;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace Cursus.LMS.Test.UnitTesting
{
    public class CompanyServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CompanyService _companyService;

        public CompanyServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            _companyService = new CompanyService(_mockUnitOfWork.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetCompany_ShouldReturnCompany_WhenCompanyExists()
        {
            // Arrange
            var company = new Company { Id = Guid.NewGuid() };

            _mockUnitOfWork.Setup(u => u.CompanyRepository.GetAsync(It.IsAny<Expression<Func<Company, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(company);

            // Act
            var result = await _companyService.GetCompany();

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Get company successfully", result.Message);
            Assert.Equal(company, result.Result);
        }

        [Fact]
        public async Task GetCompany_ShouldReturnNotFound_WhenCompanyDoesNotExist()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.CompanyRepository.GetAsync(It.IsAny<Expression<Func<Company, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((Company)null);

            // Act
            var result = await _companyService.GetCompany();

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("Company not found", result.Message);
        }

        [Fact]
        public async Task GetCompany_ShouldReturnInternalServerError_WhenExceptionIsThrown()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.CompanyRepository.GetAsync(It.IsAny<Expression<Func<Company, bool>>>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _companyService.GetCompany();

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Database error", result.Message);
        }

        [Fact]
        public async Task UpdateCompany_ShouldReturnSuccess_WhenCompanyIsUpdated()
        {
            // Arrange
            var companyDto = new UpdateCompanyDTO { Id = Guid.NewGuid() };
            var company = new Company { Id = companyDto.Id };

            _mockUnitOfWork.Setup(u => u.CompanyRepository.GetAsync(It.IsAny<Expression<Func<Company, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(company);

            // Act
            var result = await _companyService.UpdateCompany(companyDto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Company updated successfully", result.Message);

            _mockUnitOfWork.Verify(u => u.CompanyRepository.Update(It.IsAny<Company>()), Times.Once);
            _mockUnitOfWork.Verify(u => u.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task UpdateCompany_ShouldReturnNotFound_WhenCompanyDoesNotExist()
        {
            // Arrange
            var companyDto = new UpdateCompanyDTO { Id = Guid.NewGuid() };

            _mockUnitOfWork.Setup(u => u.CompanyRepository.GetAsync(It.IsAny<Expression<Func<Company, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync((Company)null);

            // Act
            var result = await _companyService.UpdateCompany(companyDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("Company not found", result.Message);
        }

        [Fact]
        public async Task UpdateCompany_ShouldReturnInternalServerError_WhenExceptionIsThrown()
        {
            // Arrange
            var companyDto = new UpdateCompanyDTO { Id = Guid.NewGuid() };
            var company = new Company { Id = companyDto.Id };

            _mockUnitOfWork.Setup(u => u.CompanyRepository.GetAsync(It.IsAny<Expression<Func<Company, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(company);
            _mockUnitOfWork.Setup(u => u.SaveAsync())
                .ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _companyService.UpdateCompany(companyDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Database error", result.Message);
        }
    }
}
