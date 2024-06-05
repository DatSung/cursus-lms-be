// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Cursus.LMS.Model.DTO;
// using Cursus.LMS.Service.IService;
// using System;
// using System.Threading.Tasks;
// using Cursus.LMS.Service.Service;
//
// namespace Cursus.LMS.API.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class EmailSenderController : ControllerBase
//     {
//         private readonly EmailSender _emailSender;
//         private readonly IAuthService _authService;
//
//         public EmailSenderController(EmailSender emailSender, IAuthService authService)
//         {
//             _emailSender = emailSender;
//             _authService = authService;
//         }
//
//         [HttpPost]
//         public IActionResult SendEmail([FromBody] EmailRequest emailRequest)
//         {
//             ResponseDTO response = new ResponseDTO();
//
//             try
//             {
//                 if (emailRequest.Role.Contains("INSTRUCTOR"))
//                 {
//                     _emailSender.SendEmailForInstructor(emailRequest.ToMail);
//                     response.Message = "Instructor notified, waiting for email from Admin!";
//                 }
//                 else
//                 {
//                     _emailSender.SendVerifyEmail(emailRequest.ToMail);
//                     response.Message = "Email sent successfully for student.";
//                 }
//
//                 response.IsSuccess = true;
//                 return Ok(response);
//             }
//             catch (Exception ex)
//             {
//                 response.IsSuccess = false;
//                 response.Message = $"Failed to send email: {ex.Message}";
//                 return StatusCode(StatusCodes.Status500InternalServerError, response);
//             }
//         }
//
//         [HttpPost]
//         [Authorize(Roles = "admin")]
//         [Route("approve-email")]
//         public async Task<IActionResult> ApproveEmail(string email)
//         {
//             ResponseDTO response = new ResponseDTO();
//
//             try
//             {
//                 // Check if the user exists and has the role of instructor
//                 var user = await _authService.GetUserByEmail(email);
//                 if (user != null && user.Roles.Contains("INSTRUCTOR"))
//                 {
//                     // Send email for instructor approval
//                     _emailSender.SendEmailForInstructorApproval(email);
//                     response.Message = $"Email for {email} has been sent for approval.";
//                     response.IsSuccess = true;
//                     return Ok(response);
//                 }
//                 else
//                 {
//                     response.IsSuccess = false;
//                     response.Message = $"User with email {email} either does not exist or is not an instructor.";
//                     return BadRequest(response);
//                 }
//             }
//             catch (Exception ex)
//             {
//                 response.IsSuccess = false;
//                 response.Message = $"Failed to approve email: {ex.Message}";
//                 return StatusCode(StatusCodes.Status500InternalServerError, response);
//             }
//         }
//     }
// }