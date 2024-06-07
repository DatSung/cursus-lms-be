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
    }
}
