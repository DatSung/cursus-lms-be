using Moq;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursus.LMS.DataAccess.IProvider;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.API.Controllers;
using Cursus.LMS.Service.Service;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Model.Domain;
using AutoMapper;
using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cursus.LMS.Test.ServiceTest
{
    public class AuthServiceTest
    {
        private readonly Mock<RoleManager<IdentityRole>> _roleManagerMock;
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IEmailService> _emailServiceMock;
        private readonly Mock<IFirebaseService> _firebaseServiceMock;
        private readonly Mock<IHttpContextAccessor> _httpContextAccessorMock;
        private readonly Mock<IEmailSender> _emailSenderMock;
        private readonly Mock<ITokenService> _tokenServiceMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IRequestUserProvider> _requestUserProviderMock;
        private readonly AuthService _authService;

        public AuthServiceTest()
        {
            _roleManagerMock = new Mock<RoleManager<IdentityRole>>(
                new Mock<IRoleStore<IdentityRole>>().Object, null, null, null, null);

            _configurationMock = new Mock<IConfiguration>();
            _mapperMock = new Mock<IMapper>();
            _emailServiceMock = new Mock<IEmailService>();
            _firebaseServiceMock = new Mock<IFirebaseService>();
            _httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            _emailSenderMock = new Mock<IEmailSender>();
            _tokenServiceMock = new Mock<ITokenService>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _requestUserProviderMock = new Mock<IRequestUserProvider>();

            _authService = new AuthService(
                _roleManagerMock.Object,
                _configurationMock.Object,
                _mapperMock.Object,
                _emailServiceMock.Object,
                _firebaseServiceMock.Object,
                _httpContextAccessorMock.Object,
                _emailSenderMock.Object,
                _tokenServiceMock.Object,
                _unitOfWorkMock.Object,
                _requestUserProviderMock.Object);
        }

        [Fact]
        public async Task SignUpStudent_ShouldReturnError_WhenEmailIsAlreadyUsed()
        {
            // Đầu vào: RegisterStudentDTO có email đã tồn tại trong hệ thống (FindByEmailAsync sẽ trả về ApplicationUser nếu Email = "test@example.com")
            var registerStudentDTO = new RegisterStudentDTO { Email = "test@example.com" };
            _requestUserProviderMock.Setup(x => x.FindByEmailAsync(registerStudentDTO.Email))
                .ReturnsAsync(new ApplicationUser());

            // Act
            var result = await _authService.SignUpStudent(registerStudentDTO);

            // Kết quả mong muốn: Trả về ResponseDTO với IsSuccess là false và thông báo "Email is using by another user"
            Assert.False(result.IsSuccess);
            Assert.Equal("Email is using by another user", result.Message);
        }

        [Fact]
        public async Task SignUpStudent_ShouldReturnError_WhenPhoneNumberIsAlreadyUsed()
        {
            // Đầu vào: RegisterStudentDTO có số điện thoại đã tồn tại trong hệ thống
            var registerStudentDTO = new RegisterStudentDTO { Email = "test@example.com", PhoneNumber = "1234567890" };
            _requestUserProviderMock.Setup(x => x.FindByEmailAsync(registerStudentDTO.Email))
                .ReturnsAsync((ApplicationUser?)null);
            _requestUserProviderMock.Setup(x => x.IsPhoneNumberExistsAsync(registerStudentDTO.PhoneNumber))
                .ReturnsAsync(true);

            // Act
            var result = await _authService.SignUpStudent(registerStudentDTO);

            // Kết quả mong muốn: Trả về ResponseDTO với IsSuccess là false và thông báo "Phone number is using by another user"
            Assert.False(result.IsSuccess);
            Assert.Equal("Phone number is using by another user", result.Message);
        }


    }
}
