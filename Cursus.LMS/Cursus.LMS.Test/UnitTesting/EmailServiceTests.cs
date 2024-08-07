using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace Cursus.LMS.Test.UnitTesting
{
    public class EmailServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;
        private readonly EmailService _service;

        public EmailServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
            _configurationMock = new Mock<IConfiguration>();
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);
            _service = new EmailService(_configurationMock.Object, _unitOfWorkMock.Object, _mapperMock.Object, _userManagerMock.Object);
        }

        [Fact]
        public async Task GetAll_NoFilters_ReturnsAllEmailTemplates()
        {
            // Arrange
            var emailTemplates = new List<EmailTemplate>
            {
                new EmailTemplate { TemplateName = "Template1", SenderName = "Sender1", SenderEmail = "sender1@example.com", Category = "Category1" },
                new EmailTemplate { TemplateName = "Template2", SenderName = "Sender2", SenderEmail = "sender2@example.com", Category = "Category2" }
            };

            _unitOfWorkMock.Setup(u => u.EmailTemplateRepository.GetAllAsync(It.IsAny<Expression<Func<EmailTemplate, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(emailTemplates);

            _mapperMock.Setup(m => m.Map<List<EmailTemplate>>(It.IsAny<List<EmailTemplate>>()))
                .Returns(emailTemplates);

            // Act
            var result = await _service.GetAll(new ClaimsPrincipal(), null, null, null, null, 0, 0);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Result);
            Assert.Equal(2, ((List<EmailTemplate>)result.Result).Count);
            Assert.Equal("Get all email template successfully", result.Message);
        }

        [Fact]
        public async Task GetAll_FilterOnTemplateName_ReturnsFilteredEmailTemplates()
        {
            // Arrange
            var emailTemplates = new List<EmailTemplate>
            {
                new EmailTemplate { TemplateName = "Template1", SenderName = "Sender1", SenderEmail = "sender1@example.com", Category = "Category1" },
                new EmailTemplate { TemplateName = "Template2", SenderName = "Sender2", SenderEmail = "sender2@example.com", Category = "Category2" }
            };

            _unitOfWorkMock.Setup(u => u.EmailTemplateRepository.GetAllAsync(It.IsAny<Expression<Func<EmailTemplate, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(emailTemplates);

            _mapperMock.Setup(m => m.Map<List<EmailTemplate>>(It.IsAny<List<EmailTemplate>>()))
                .Returns(emailTemplates.Where(x => x.TemplateName.Contains("Template1")).ToList());

            // Act
            var result = await _service.GetAll(new ClaimsPrincipal(), "TemplateName", "Template1", null, null, 0, 0);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Result);
            Assert.Single((List<EmailTemplate>)result.Result);
            Assert.Equal("Get all email template successfully", result.Message);
        }

        [Fact]
        public async Task GetAll_NoEmailTemplatesFound_Returns404Response()
        {
            // Arrange
            _unitOfWorkMock.Setup(u => u.EmailTemplateRepository.GetAllAsync(It.IsAny<Expression<Func<EmailTemplate, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(new List<EmailTemplate>());

            // Act
            var result = await _service.GetAll(new ClaimsPrincipal(), null, null, null, null, 0, 0);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.Null(result.Result);
            Assert.Equal("There are no emailTemplates", result.Message);
        }

        [Fact]
        public async Task GetAll_ExceptionThrown_Returns500Response()
        {
            // Arrange
            _unitOfWorkMock.Setup(u => u.EmailTemplateRepository.GetAllAsync(It.IsAny<Expression<Func<EmailTemplate, bool>>>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception("Test exception"));

            // Act
            var result = await _service.GetAll(new ClaimsPrincipal(), null, null, null, null, 0, 0);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(500, result.StatusCode);
            Assert.Null(result.Result);
            Assert.Equal("Test exception", result.Message);
        }







    }
}
