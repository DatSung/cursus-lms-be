using System.Security.Claims;
using System.Text;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.ValidationAttribute;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cursus.LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IAuthService _authService;
        private ResponseDTO responseDto = new ResponseDTO();
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(IEmailService emailService, IAuthService authService,UserManager<ApplicationUser> userManager)
        {
            _emailService = emailService;
            _authService = authService;
            _userManager = userManager;
        }

        /// <summary>
        /// This API for feature Sign Up For Student.
        /// </summary>
        /// <returns>ResponseDTO</returns>
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
                responseDto.Message = e.Message;
            }

            return Ok(responseDto);
        }

        /// <summary>
        /// This API for feature Sign Up For Instructor.
        /// </summary>
        /// <returns>ResponseDTO</returns>
        [HttpPost]
        [Route("sign-up-instructor")]
        public async Task<ActionResult<ResponseDTO>> SignUpInstructor([FromBody] InstructorDTO instructorDto)
        {
            var result = await _authService.SignUpInstructor(instructorDto);
            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// This API for feature upload instructor degree
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("upload-instructor-degree")]
        [Authorize]
        public async Task<ActionResult<ResponseDTO>> UploadInstructorDegree(DegreeUploadDTO degreeUploadDto)
        {
            var response = await _authService.UploadInstructorDegree(degreeUploadDto.File, User);
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// This API for feature get instructor degree image
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-instructor-degree")]
        [Authorize]
        public async Task<IActionResult> GetInstructorDegree([FromQuery] bool Download = false)
        {
            var degreeResponseDto = await _authService.GetInstructorDegree(User);
            if (degreeResponseDto.Stream is null)
            {
                return NotFound("User avatar does not exist!");
            }

            if (Download)
            {
                return File(degreeResponseDto.Stream, degreeResponseDto.ContentType, degreeResponseDto.FileName);
            }

            return File(degreeResponseDto.Stream, degreeResponseDto.ContentType);
        }

        /// <summary>
        /// This API for feature upload user avatar
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("upload-user-avatar")]
        [Authorize]
        public async Task<ActionResult<ResponseDTO>> UploadUserAvatar(AvatarUploadDTO avatarUploadDto)
        {
            var response = await _authService.UploadUserAvatar(avatarUploadDto.File, User);
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// This API for feature get user avatar
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-user-avatar")]
        [Authorize]
        public async Task<IActionResult> GetUserAvatar()
        {
            var stream = await _authService.GetUserAvatar(User);
            if (stream is null)
            {
                return NotFound("User avatar does not exist!");
            }

            return File(stream, "image/png");
        }

        /// <summary>
        /// This API for case forgot password.
        /// </summary>
        /// <returns>ResponseDTO</returns>
        [HttpPost]
        [Route("forgot-password")]
        public async Task<ActionResult<ResponseDTO>> ForgotPassword([FromBody] ForgotPasswordDTO forgotPasswordDto)
        {
            var result = await _authService.ForgotPassword(forgotPasswordDto);
            return StatusCode(result.StatusCode, result);
        }
        
        /// <summary>
        /// This API for case reset password.
        /// </summary>
        /// <returns>ResponseDTO</returns>
        [HttpPost("reset-password")]
        public async Task<ActionResult<ResponseDTO>> ResetPassword([FromBody] ResetPasswordDTO resetPasswordDto)
        {
            var result = await _authService.ResetPassword(resetPasswordDto.Email, resetPasswordDto.Token,resetPasswordDto.Password);
            return StatusCode(result.StatusCode, result);
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
        public async Task<ActionResult<ResponseDTO>> ChangePassword(ChangePasswordDTO changePasswordDto)
        {
            // Lấy Id người dùng hiện tại.
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var response = await _authService.ChangePassword(userId, changePasswordDto.OldPassword, changePasswordDto.NewPassword, changePasswordDto.ConfirmNewPassword);

            if (response.IsSuccess)
            {
                return Ok(response.Message);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }


        /// <summary>
        /// This API for case sign in.
        /// </summary>
        /// <returns>ResponseDTO</returns>
        [HttpPost]
        [Route("sign-in")]
        public async Task<ActionResult<SignResponseDTO>> SignIn([FromBody] SignDTO signDto)
        {
            var SignResult = await _authService.SignIn(signDto);
            if (SignResult == null)
            {
                return BadRequest("Your Email or Password is incorrect ");
            }

            return Ok(SignResult);
        }
    }
}