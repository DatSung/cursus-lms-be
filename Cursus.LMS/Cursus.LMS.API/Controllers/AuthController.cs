using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cursus.LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IAuthService _authService;
        private ResponseDTO responseDto = new ResponseDTO();

        public AuthController(IEmailService emailService, IAuthService authService)
        {
            _emailService = emailService;
            _authService = authService;
        }

        [HttpPost]
        [Route("sign-up-student")]
        public async Task<ActionResult<ResponseDTO>> SignUpStudent()
        {
            try
            {
            }
            catch (Exception e)
            {
                responseDto.IsSuccess = false;
            }

            return Ok(responseDto);
        }
    }
}