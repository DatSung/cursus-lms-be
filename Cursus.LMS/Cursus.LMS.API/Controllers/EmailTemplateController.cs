using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Cursus.LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = StaticUserRoles.Admin)]
    public class EmailTemplateController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmailTemplateController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Lấy tất cả các mẫu email.
        /// </summary>
        /// <returns>Danh sách các mẫu email.</returns>
        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> GetAllEmailTemplates()
        {
            var emailTemplates = await _unitOfWork.EmailTemplateRepository.GetAllAsync();
            return Ok(new ResponseDTO
            {
                Result = emailTemplates,
                IsSuccess = true,
                Message = "Lấy danh sách mẫu email thành công."
            });
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
                    Message = "Không tìm thấy mẫu email."
                });
            }

            return Ok(new ResponseDTO
            {
                Result = emailTemplate,
                IsSuccess = true,
                Message = "Lấy mẫu email thành công."
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
                    Message = "Không tìm thấy mẫu email."
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
                Message = "Cập nhật mẫu email thành công."
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
                Message = "Không thể xóa mẫu email."
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
                Message = "Không thể tạo mới mẫu email."
            });
        }
    }
}