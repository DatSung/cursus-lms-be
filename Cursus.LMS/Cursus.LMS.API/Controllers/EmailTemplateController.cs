using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cursus.LMS.Utility.Constants;

namespace Cursus.LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = StaticUserRoles.Student)]
    public class EmailTemplateController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmailTemplateController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get all the email templates.
        /// </summary>
        /// <returns>List of email templates.</returns>
        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> GetAllEmailTemplates()
        {
            var emailTemplates = await _unitOfWork.EmailTemplateRepository.GetAllAsync();
            return Ok(new ResponseDTO
            {
                Result = emailTemplates,
                IsSuccess = true,
                Message = "Get a list of successful email templates."
            });
        }

        /// <summary>
        /// Get email templates by ID.
        /// </summary>
        /// <param name="id">ID of the email template.</param>
        /// <returns>The email template corresponds to the ID.</returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ResponseDTO>> GetEmailTemplateById(Guid id)
        {
            var emailTemplate = await _unitOfWork.EmailTemplateRepository.GetAsync(x => x.Id == id);
            if (emailTemplate == null)
            {
                return NotFound(new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Email template not found."
                });
            }

            return Ok(new ResponseDTO
            {
                Result = emailTemplate,
                IsSuccess = true,
                Message = "Get email template successfully."
            });
        }

        /// <summary>
        /// Update the content of an email template.
        /// </summary>
            /// <param name="id">ID of the email template.</param>
        /// <param name="updateEmailTemplateDTO">Updated data for email templates.</param>
        /// <returns>Updated results.</returns>
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ResponseDTO>> UpdateEmailTemplate(Guid id, UpdateEmailTemplateDTO updateEmailTemplateDTO)
        {
            var emailTemplate = await _unitOfWork.EmailTemplateRepository.GetAsync(x => x.Id == id);

            if (emailTemplate == null)
            {
                return NotFound(new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Email template not found."
                });
            }

            // Update email template content from DTO
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
                Message = "Email template updated successfully."
            });
        }

        /// <summary>
        /// Deletion of email templates is not allowed.
        /// </summary>
        /// <param name="id">ID of the email template.</param>
        /// <returns>Error message.</returns>
        [HttpDelete("{id:guid}")]
        public ActionResult<ResponseDTO> DeleteEmailTemplate(Guid id)
        {
            return BadRequest(new ResponseDTO
            {
                IsSuccess = false,
                Message = "The email template cannot be deleted."
            });
        }

        /// <summary>
        /// Creating new email templates is not allowed.
        /// </summary>
        /// <param name="createEmailTemplateDTO">Data to create new email templates.</param>
        /// <returns>Error message.</returns>
        [HttpPost]
        public ActionResult<ResponseDTO> CreateEmailTemplate(CreateEmailTemplateDTO createEmailTemplateDTO)
        {
            return BadRequest(new ResponseDTO
            {
                IsSuccess = false,
                Message = "Unable to create new email template."
            });
        }
    }
}