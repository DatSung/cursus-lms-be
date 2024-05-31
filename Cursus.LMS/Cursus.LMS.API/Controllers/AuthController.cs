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

            /// <summary>
            /// This API for feature Sign Up For Student.
            /// </summary>
            /// <returns>ResponseDTO</returns>
            [HttpPost]
            [Route("sign-up-student")]
            public async Task<ActionResult<ResponseDTO>> SignUpStudent([FromForm] RegisterStudentDTO registerStudentDTO)
            {

                if (!ModelState.IsValid)
                {
                    responseDto.IsSuccess = false;
                    responseDto.Message = "Invalid input data.";
                    responseDto.Result = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                    return BadRequest(responseDto);
                }
                try
                {
                    var result = await _authService.SignUpStudent(registerStudentDTO);
                    if (result.IsSuccess)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return BadRequest(result);
                    }
                }
                catch (Exception e)
                {
                    responseDto.IsSuccess = false;
                    responseDto.Message = e.Message;
                    return StatusCode(StatusCodes.Status500InternalServerError, responseDto);
                }
               }

        /// <summary>
        /// This API for feature Sign Up For Instructor.
        /// </summary>
        /// <returns>ResponseDTO</returns>
        [HttpPost]
        [Route("sign-up-instructor")]
        public async Task<ActionResult<ResponseDTO>> SignUpInStructor()
        {
            
            try
            {
            }
            catch (Exception e)
            {
                responseDto.IsSuccess = false;
                responseDto.Message = e.Message;
            }

            return Ok(responseDto);
        }


        /// <summary>
        /// This API for case forgot password.
        /// </summary>
        /// <returns>ResponseDTO</returns>
        [HttpPost]
        [Route("forgot-password")]
        public async Task<ActionResult<ResponseDTO>> ForgotPassword()
        {
            try
            {
            }
            catch (Exception e)
            {
                responseDto.IsSuccess = false;
                responseDto.Message = e.Message;
            }

            return Ok(responseDto);
        }

        /// <summary>
        /// This API for case verify email.
        /// </summary>
        /// <returns>ResponseDTO</returns>
        [HttpPost]
        [Route("verify-email")]
        public async Task<ActionResult<ResponseDTO>> VerifyEmail()
        {
            try
            {
            }
            catch (Exception e)
            {
                responseDto.IsSuccess = false;
                responseDto.Message = e.Message;
            }

            return Ok(responseDto);
        }

        /// <summary>
        /// This API for case change password.
        /// </summary>
        /// <returns>ResponseDTO</returns>
        [HttpPost]
        [Route("change-password")]
        public async Task<ActionResult<ResponseDTO>> ChangePassword()
        {
            try
            {
            }
            catch (Exception e)
            {
                responseDto.IsSuccess = false;
                responseDto.Message = e.Message;
            }

            return Ok(responseDto);
        }

        /// <summary>
        /// This API for case sign in.
        /// </summary>
        /// <returns>ResponseDTO</returns>
        [HttpPost]
        [Route("sign-in")]
        public async Task<ActionResult<ResponseDTO>> SignIn()
        {
            try
            {
            }
            catch (Exception e)
            {
                responseDto.IsSuccess = false;
                responseDto.Message = e.Message;
            }

            return Ok(responseDto);
        }
    }
}