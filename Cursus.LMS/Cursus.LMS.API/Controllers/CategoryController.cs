using Cursus.LMS.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cursus.LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> GetAll()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<ResponseDTO>> GetById([FromRoute] Guid id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> Create(CreateCategoryDTO createCategoryDto)
        {
            return Ok();
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<ActionResult<ResponseDTO>> Update([FromRoute] Guid id, [FromBody] UpdateCategoryDTO updateCategoryDto)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult<ResponseDTO>> Delete([FromRoute] Guid id)
        {
            return Ok();
        }
    }
}