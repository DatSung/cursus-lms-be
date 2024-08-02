using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cursus.LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = StaticUserRoles.Admin)]
    public class WebsiteController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly ITermOfUseService _termOfUseService;
        private readonly IPrivacyService _privacyService;

        public WebsiteController
        (
            ICompanyService companyService,
            ITermOfUseService termOfUseService,
            IPrivacyService privacyService
        )
        {
            _companyService = companyService;
            _termOfUseService = termOfUseService;
            _privacyService = privacyService;
        }

        #region Company

        [HttpGet("company")]
        public async Task<ActionResult<ResponseDTO>> GetCompany()
        {
            var responseDto = await _companyService.GetCompany();
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPut("company")]
        public async Task<ActionResult<ResponseDTO>> UpdateCompany([FromBody] UpdateCompanyDTO companyDto)
        {
            var responseDto = await _companyService.UpdateCompany(companyDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        #endregion

        #region Privacy

        [HttpGet("privacy")]
        public async Task<ActionResult<ResponseDTO>> GetPrivacies()
        {
            var responseDto = await _privacyService.GetPrivacies();
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet("privacy/{id:guid}")]
        public async Task<ActionResult<ResponseDTO>> GetPrivacy(Guid id)
        {
            var responseDto = await _privacyService.GetPrivacy(id);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost("privacy")]
        public async Task<ActionResult<ResponseDTO>> CreatePrivacy([FromBody] CreatePrivacyDTO privacyDto)
        {
            var responseDto = await _privacyService.CreatePrivacy(privacyDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPut("privacy")]
        public async Task<ActionResult<ResponseDTO>> UpdatePrivacy([FromBody] UpdatePrivacyDTO privacyDto)
        {
            var responseDto = await _privacyService.UpdatePrivacy(privacyDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpDelete("privacy/{id:guid}")]
        public async Task<ActionResult<ResponseDTO>> DeletePrivacy(Guid id)
        {
            var responseDto = await _privacyService.DeletePrivacy(id);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        #endregion

        #region TermOfUse

        [HttpGet("term-of-use")]
        public async Task<ActionResult<ResponseDTO>> GetTermOfUses()
        {
            var responseDto = await _termOfUseService.GetTermOfUses();
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet("term-of-use/{id:guid}")]
        public async Task<ActionResult<ResponseDTO>> GetTermOfUse(Guid id)
        {
            var responseDto = await _termOfUseService.GetTermOfUse(id);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost("term-of-use")]
        public async Task<ActionResult<ResponseDTO>> CreateTermOfUse([FromBody] CreateTermOfUseDTO termOfUseDto)
        {
            var responseDto = await _termOfUseService.CreateTermOfUse(termOfUseDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPut("term-of-use")]
        public async Task<ActionResult<ResponseDTO>> UpdateTermOfUse([FromBody] UpdateTermOfUseDTO termOfUseDto)
        {
            var responseDto = await _termOfUseService.UpdateTermOfUse(termOfUseDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpDelete("term-of-use/{id:guid}")]
        public async Task<ActionResult<ResponseDTO>> DeleteTermOfUse(Guid id)
        {
            var responseDto = await _termOfUseService.DeleteTermOfUse(id);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        #endregion
    }
}