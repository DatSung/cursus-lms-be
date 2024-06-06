using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
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

        [HttpPost]
        [Route("upload-user-avatar")]
        [Authorize]
        public async Task<ActionResult<ResponseDTO>> UploadUserAvatar(IFormFile? file)
        {
            var response = await _authService.UploadUserAvatar(file, User);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        [Route("get-image")]
        public async Task<IActionResult> GetImage()
        {
            string filePath = "UserAvatars/48fbb2d9-13f2-4bdf-a384-73e59342d57f_Screenshot 2024-04-03 205928.png";
            var stream = await _firebaseService.GetImage(filePath);
            return File(stream, "image/png");
        }
        
        [HttpGet]
        [Route("test-refresh-token")]
        public async Task<IActionResult> TestRefreshToken()
        {
            return Ok(_tokenService.GenerateJwtRefreshTokenAsync());
        }
    }
}