using System.Security.Claims;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
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
        private readonly IEmailSender _emailSender;
        private ResponseDTO responseDto = new ResponseDTO();
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(IEmailService emailService, IAuthService authService,
            UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            _emailService = emailService;
            _authService = authService;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        /// <summary>
        /// This API for feature Sign Up For Student.
        /// </summary>
        /// <returns>ResponseDTO</returns>
        [HttpPost]
        [Route("sign-up-student")]
        public async Task<ActionResult<ResponseDTO>> SignUpStudent([FromBody] RegisterStudentDTO registerStudentDTO)
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
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="Download"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("display-instructor-degree/{userId}")]
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
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("display-user-avatar/{userId}")]
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
                $"http://localhost:30475/sign-in/verify-email?userId={user.Id}&token={Uri.EscapeDataString(token)}";

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
            return StatusCode(this.responseDto.StatusCode, responseDto);
        }

        // // <summary>
        // /// This API for case student sign in by google.
        // /// </summary>
        // /// <returns></returns>
        // [HttpPost]
        // [Route("student-signin-by-google")]
        // public async Task<ActionResult<SignResponseDTO>> StudentSignInByGoogle(
        //     [FromBody] StudentSignInByGoogleDTO studentSignInByGoogleDto)
        // {
        //     return await _authService.StudentSignInByGoogle(studentSignInByGoogleDto);
        // }
        //
        // [HttpPost]
        // [Route("instructor-signin-by-google")]
        // public async Task<ActionResult<SignResponseDTO>> InstructorSignInByGoogle(
        //     [FromBody] InstructorSignInByGoogleDTO instructorSignInByGoogleDto)
        // {
        //     return await _authService.InstructorSignInByGoogle(instructorSignInByGoogleDto);
        // }

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
            return StatusCode(this.responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("check-phone-number-exist")]
        public async Task<ActionResult<ResponseDTO>> CheckPhoneNumberExist([FromBody] string phoneNumber)
        {
            var responseDto = await _authService.CheckPhoneNumberExist(phoneNumber);
            return StatusCode(this.responseDto.StatusCode, responseDto);
        }


        [HttpPost]
        [Route("complete-student-profile")]
        [Authorize]
        public async Task<ActionResult<ResponseDTO>> CompleteStudentProfile(
            CompleteStudentProfileDTO completeStudentProfileDto)
        {
            var responseDto = await _authService.CompleteStudentProfile(User, completeStudentProfileDto);
            return StatusCode(this.responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("complete-instructor-profile")]
        [Authorize]
        public async Task<ActionResult<ResponseDTO>> CompleteInstructorProfile(
            CompleteInstructorProfileDTO completeInstructorProfileDto)
        {
            var responseDto = await _authService.CompleteInstructorProfile(User, completeInstructorProfileDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("sign-in-by-google")]
        public async Task<ActionResult<ResponseDTO>> SignInByGoogle(SignInByGoogleDTO signInByGoogleDto)
        {
            var response = await _authService.SignInByGoogle(signInByGoogleDto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        [Route("get-user-info")]
        public async Task<ActionResult<ResponseDTO>> GetUserInfo()
        {
            var response = await _authService.GetUserInfo(User);
            return StatusCode(response.StatusCode, response);
        }
    }
}