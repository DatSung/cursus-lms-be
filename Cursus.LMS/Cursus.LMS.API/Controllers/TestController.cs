using System.Security.Claims;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Service.Service;
using Cursus.LMS.Utility.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cursus.LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IFirebaseService _firebaseService;
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;

        public TestController(IFirebaseService firebaseService, IAuthService authService, ITokenService tokenService)
        {
            _firebaseService = firebaseService;
            _authService = authService;
            _tokenService = tokenService;
        }
        
    }
}