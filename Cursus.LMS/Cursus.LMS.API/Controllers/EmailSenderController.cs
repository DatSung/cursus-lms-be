using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendEmailWithGoogleSMTP;
using Cursus.LMS.Service.IService;
using System;
using System.Threading.Tasks;

namespace Cursus.LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailSenderController : ControllerBase
    {
        private readonly EmailSender _emailSender;
        private readonly IAuthService _authService;

        public EmailSenderController(EmailSender emailSender, IAuthService authService)
        {
            _emailSender = emailSender;
            _authService = authService;
        }

        [HttpPost]
        public IActionResult SendEmail([FromBody] EmailRequest emailRequest)
        {
            try
            {
                if (emailRequest.Role.Contains("Instructor") || emailRequest.Role.Contains("1"))
                {
                    _emailSender.SendEmailForInstructor(emailRequest.ToMail);
                    return Ok("Instructor notified, waiting for email from Admin!");
                }
                else
                {
                    _emailSender.SendEmail(emailRequest.ToMail);
                    return Ok("Email sent successfully.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to send email: {ex.Message}");
            }
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [Route("approve-email")]
        public async Task<IActionResult> ApproveEmail(string email)
        {
            try
            {
                // Check if the user exists and has the role of instructor
                var user = await _authService.GetUserByEmail(email);
                if (user != null && user.Roles.Contains("Instructor"))
                {
                    // Send email for instructor approval
                    _emailSender.SendEmailForInstructorApproval(email);
                    return Ok($"Email for {email} has been sent for approval.");
                }
                else
                {
                    return BadRequest($"User with email {email} either does not exist or is not an instructor.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to approve email: {ex.Message}");
            }
        }
    }
}
