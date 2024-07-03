using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace Cursus.LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = StaticUserRoles.Admin)]
    public class EmailTemplateController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;
        private readonly IEmailSender _emailSender;

        public EmailTemplateController(IUnitOfWork unitOfWork, IEmailService emailService, IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _emailService = emailService;
            _emailSender = emailSender;
        }

        /// <summary>
        /// Lấy tất cả các mẫu email.
        /// </summary>
        /// <returns>Danh sách các mẫu email.</returns>
        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> GetAllEmailTemplates(
            [FromQuery] string? filterOn,
            [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy,
            [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            // var emailTemplates = await _unitOfWork.EmailTemplateRepository.GetAllAsync();
            var responseDto =
                await _emailService.GetAll(User, filterOn, filterQuery, sortBy, isAscending, pageNumber, pageSize);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        /// <summary>
        /// Lấy mẫu email theo ID.
        /// </summary>
        /// <param name="id">ID của mẫu email.</param>
        /// <returns>Mẫu email tương ứng với ID.</returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ResponseDTO>> GetEmailTemplateById(Guid id)
        {
            var emailTemplate = await _unitOfWork.EmailTemplateRepository.GetAsync(x => x.Id == id);
            if (emailTemplate == null)
            {
                return NotFound(new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Email template was not found"
                });
            }

            return Ok(new ResponseDTO
            {
                Result = emailTemplate,
                IsSuccess = true,
                Message = "Get email template successfully"
            });
        }

        /// <summary>
        /// Cập nhật nội dung của một mẫu email.
        /// </summary>
        /// <param name="id">ID của mẫu email.</param>
        /// <param name="updateEmailTemplateDTO">Dữ liệu cập nhật cho mẫu email.</param>
        /// <returns>Kết quả cập nhật.</returns>
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ResponseDTO>> UpdateEmailTemplate(Guid id,
            UpdateEmailTemplateDTO updateEmailTemplateDTO)
        {
            var emailTemplate = await _unitOfWork.EmailTemplateRepository.GetAsync(x => x.Id == id);

            if (emailTemplate == null)
            {
                return NotFound(new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Email template was not found"
                });
            }

            // Cập nhật nội dung mẫu email từ DTO
            emailTemplate.TemplateName = updateEmailTemplateDTO.TemplateName;
            emailTemplate.SenderName = updateEmailTemplateDTO.SenderName;
            emailTemplate.SenderEmail = updateEmailTemplateDTO.SenderEmail;
            emailTemplate.Category = updateEmailTemplateDTO.Category;
            emailTemplate.SubjectLine = updateEmailTemplateDTO.SubjectLine;
            emailTemplate.PreHeaderText = updateEmailTemplateDTO.PreHeaderText;
            emailTemplate.PersonalizationTags = updateEmailTemplateDTO.PersonalizationTags;
            emailTemplate.BodyContent = updateEmailTemplateDTO.BodyContent;
            emailTemplate.FooterContent = updateEmailTemplateDTO.FooterContent;
            emailTemplate.CallToAction = updateEmailTemplateDTO.CallToAction;
            emailTemplate.Language = updateEmailTemplateDTO.Language;
            emailTemplate.RecipientType = updateEmailTemplateDTO.RecipientType;

            _unitOfWork.EmailTemplateRepository.Update(emailTemplate);
            await _unitOfWork.SaveAsync();

            return Ok(new ResponseDTO
            {
                Result = emailTemplate,
                IsSuccess = true,
                Message = "Update email template successfully"
            });
        }

        /// <summary>
        /// Không cho phép xóa mẫu email.
        /// </summary>
        /// <param name="id">ID của mẫu email.</param>
        /// <returns>Thông báo lỗi.</returns>
        [HttpDelete("{id:guid}")]
        public ActionResult<ResponseDTO> DeleteEmailTemplate(Guid id)
        {
            return BadRequest(new ResponseDTO
            {
                IsSuccess = false,
                Message = "You have no permission to deleted email"
            });
        }

        /// <summary>
        /// Không cho phép tạo mới mẫu email.
        /// </summary>
        /// <param name="createEmailTemplateDTO">Dữ liệu tạo mới mẫu email.</param>
        /// <returns>Thông báo lỗi.</returns>
        [HttpPost]
        public ActionResult<ResponseDTO> CreateEmailTemplate(CreateEmailTemplateDTO createEmailTemplateDTO)
        {
            return BadRequest(new ResponseDTO
            {
                IsSuccess = false,
                Message = "You have no permission to create email"
            });
        }

        [HttpGet("notice-for-admin-about-new-course")]
        public async Task<ActionResult<ResponseDTO>> SendEmailForAdminAboutNewCourse(string toMail)
        {
            var response = new ResponseDTO();

            try
            {
                bool result = await _emailSender.SendEmailForAdminAboutNewCourse(toMail);
                response.IsSuccess = result;
                response.Message = result ? "Email sent successfully." : "Failed to send email.";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }


        [HttpGet("Approved-notice-for-instructor-about-new-course")]
        public async Task<ActionResult<ResponseDTO>> SendApproveEmailForInstructorAboutNewCourse(string toMail)
        {
            var response = new ResponseDTO();

            try
            {
                bool result = await _emailSender.SendApproveEmailForInstructorAboutNewCourse(toMail);
                response.IsSuccess = result;
                response.Message = result ? "Email sent successfully." : "Failed to send email.";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet("Rejected-notice-for-instructor-about-new-course")]
        public async Task<ActionResult<ResponseDTO>> SendRejectEmailForInstructorAboutNewCourse(string toMail)
        {
            var response = new ResponseDTO();

            try
            {
                bool result = await _emailSender.SendRejectEmailForInstructorAboutNewCourse(toMail);
                response.IsSuccess = result;
                response.Message = result ? "Email sent successfully." : "Failed to send email.";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }
    }
}