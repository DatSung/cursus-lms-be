using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace Cursus.LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpGet]
        [Route("company")]
        public async Task<ActionResult<ResponseDTO>> GetCompany()
        {
            return null;
        }

        [HttpPut]
        [Route("company")]
        public async Task<ActionResult<ResponseDTO>> UpdateCompany()
        {
            return null;
        }

        [HttpGet]
        [Route("privacy")]
        public async Task<ActionResult<ResponseDTO>> GetPrivacies()
        {
            return null;
        }

        [HttpGet]
        [Route("privacy/{id:guid}")]
        public async Task<ActionResult<ResponseDTO>> GetPrivacy(Guid id)
        {
            return null;
        }

        [HttpPost]
        [Route("privacy")]
        public async Task<ActionResult<ResponseDTO>> CreatePrivacy()
        {
            return null;
        }

        [HttpPut]
        [Route("privacy")]
        public async Task<ActionResult<ResponseDTO>> UpdatePrivacy()
        {
            return null;
        }

        [HttpDelete]
        [Route("privacy/{id:guid}")]
        public async Task<ActionResult<ResponseDTO>> DeletePrivacy(Guid id)
        {
            return null;
        }

        [HttpGet]
        [Route("term-of-use")]
        public async Task<ActionResult<ResponseDTO>> GetTermOfUses()
        {
            return null;
        }

        [HttpGet]
        [Route("term-of-use/{id:guid}")]
        public async Task<ActionResult<ResponseDTO>> GetTermOfUse(Guid id)
        {
            return null;
        }

        [HttpPost]
        [Route("term-of-use")]
        public async Task<ActionResult<ResponseDTO>> CreateTermOfUse()
        {
            return null;
        }

        [HttpPut]
        [Route("term-of-use")]
        public async Task<ActionResult<ResponseDTO>> UpdateTermOfUse()
        {
            return null;
        }

        [HttpDelete]
        [Route("term-of-use/{id:guid}")]
        public async Task<ActionResult<ResponseDTO>> DeleteTermOfUse(Guid id)
        {
            return null;
        }
    }
}