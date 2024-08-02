using System.Security.Claims;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cursus.LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IAuthService _authService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(IEmailService emailService, IAuthService authService,
            UserManager<ApplicationUser> userManager)
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
        [Route("student/sign-up")]
        public async Task<ActionResult<ResponseDTO>> SignUpStudent([FromBody] RegisterStudentDTO registerStudentDTO)
        {
            var responseDto = new ResponseDTO();
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
        [Route("instructor/sign-up")]
        public async Task<ActionResult<ResponseDTO>> SignUpInstructor(
            [FromBody] SignUpInstructorDTO signUpInstructorDto)
        {
            var result = await _authService.SignUpInstructor(signUpInstructorDto);
            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// This API for feature upload instructor degree
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("instructor/degree")]
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
        [Route("instructor/degree")]
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
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="Download"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("instructor/degree/display/{userId}")]
        public async Task<IActionResult> DisplayInstructorDegree([FromRoute] string userId,
            [FromQuery] bool Download = false)
        {
            var degreeResponseDto = await _authService.DisplayInstructorDegree(userId);
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
        [Route("user/avatar")]
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
        [Route("user/avatar")]
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
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("user/avatar/display/{userId}")]
        public async Task<IActionResult> DisplayUserAvatar([FromRoute] string userId)
        {
            var stream = await _authService.DisplayUserAvatar(userId);
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
            var result = await _authService.ResetPassword(resetPasswordDto.Email, resetPasswordDto.Token,
                resetPasswordDto.Password);
            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// This API for case verify email.
        /// </summary>
        /// <param name="emailRequest"></param>
        /// <returns>ResponseDTO</returns>
        [HttpPost]
        [Route("send-verify-email")]
        public async Task<ActionResult<ResponseDTO>> SendVerifyEmail([FromBody] SendVerifyEmailDTO email)
        {
            var user = await _userManager.FindByEmailAsync(email.Email);
            if (user.EmailConfirmed)
            {
                return new ResponseDTO()
                {
                    IsSuccess = true,
                    Message = "Your email has been confirmed",
                    StatusCode = 200,
                    Result = email
                };
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var confirmationLink =
                $"https://cursuslms.xyz/user/sign-in/verify-email?userId={user.Id}&token={Uri.EscapeDataString(token)}";

            var responseDto = await _authService.SendVerifyEmail(user.Email, confirmationLink);

            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("verify-email")]
        [ActionName("verify-email")]
        public async Task<ActionResult<ResponseDTO>> VerifyEmail(
            [FromQuery] string userId,
            [FromQuery] string token)
        {
            var responseDto = await _authService.VerifyEmail(userId, token);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        /// <summary>
        /// This API for case change password.
        /// </summary>
        /// <returns>ResponseDTO</returns>
        [HttpPost]
        [Route("change-password")]
        [Authorize]
        public async Task<ActionResult<ResponseDTO>> ChangePassword(ChangePasswordDTO changePasswordDto)
        {
            // Lấy Id người dùng hiện tại.
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var response = await _authService.ChangePassword(userId, changePasswordDto.OldPassword,
                changePasswordDto.NewPassword, changePasswordDto.ConfirmNewPassword);

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
        public async Task<ActionResult<ResponseDTO>> SignIn([FromBody] SignDTO signDto)
        {
            var responseDto = await _authService.SignIn(signDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }


        [HttpPost]
        [Route("refresh")]
        public async Task<ActionResult<ResponseDTO>> Refresh([FromBody] JwtTokenDTO token)
        {
            var responseDto = await _authService.Refresh(token.RefreshToken);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("check-email-exist")]
        public async Task<ActionResult<ResponseDTO>> CheckEmailExist([FromBody] string email)
        {
            var responseDto = await _authService.CheckEmailExist(email);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("check-phone-number-exist")]
        public async Task<ActionResult<ResponseDTO>> CheckPhoneNumberExist([FromBody] string phoneNumber)
        {
            var responseDto = await _authService.CheckPhoneNumberExist(phoneNumber);
            return StatusCode(responseDto.StatusCode, responseDto);
        }


        [HttpPost]
        [Route("student/profile")]
        [Authorize]
        public async Task<ActionResult<ResponseDTO>> CompleteStudentProfile(
            CompleteStudentProfileDTO completeStudentProfileDto)
        {
            var responseDto = await _authService.CompleteStudentProfile(User, completeStudentProfileDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("instructor/profile")]
        [Authorize]
        public async Task<ActionResult<ResponseDTO>> CompleteInstructorProfile(
            CompleteInstructorProfileDTO completeInstructorProfileDto)
        {
            var responseDto = await _authService.CompleteInstructorProfile(User, completeInstructorProfileDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("google/sign-in")]
        public async Task<ActionResult<ResponseDTO>> SignInByGoogle(SignInByGoogleDTO signInByGoogleDto)
        {
            var response = await _authService.SignInByGoogle(signInByGoogleDto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        [Route("user/info")]
        public async Task<ActionResult<ResponseDTO>> GetUserInfo()
        {
            var response = await _authService.GetUserInfo(User);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut]
        [Route("student/profile")]
        public async Task<ActionResult<ResponseDTO>> UpdateStudent([FromBody] UpdateStudentProfileDTO studentDto)
        {
            var responseDto = await _authService.UpdateStudent(studentDto, User);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPut]
        [Route("instructor/profile")]
        public async Task<ActionResult<ResponseDTO>> UpdateInstructor(
            [FromBody] UpdateIntructorProfileDTO instructorDto)
        {
            var responseDto = await _authService.UpdateInstructor(instructorDto, User);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("lock")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> LockUser([FromBody] LockUserDTO lockUserDto)
        {
            var responseDto = await _authService.LockUser(lockUserDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("unlock")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> UnlockUser([FromBody] LockUserDTO lockUserDto)
        {
            var responseDto = await _authService.UnlockUser(lockUserDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }
    }
}