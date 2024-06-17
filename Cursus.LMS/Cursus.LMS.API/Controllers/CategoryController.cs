using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cursus.LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> GetAll
        (
            [FromQuery] string? filterOn,
            [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy,
            [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10
        )
        {
            var responseDto =
                await _categoryService.GetAll(User, filterOn, filterQuery, sortBy, isAscending, pageNumber, pageSize);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<ResponseDTO>> Search
        (
            [FromQuery] string? filterOn,
            [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy,
            [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10
        )
        {
            var responseDto = await _categoryService.Search(User, filterOn, filterQuery, sortBy, isAscending,
                pageNumber, pageSize);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("get-sub-category/{id:guid}")]
        public async Task<ActionResult<ResponseDTO>> GetSubCategory([FromRoute] Guid id)
        {
            var responseDto = await _categoryService.GetSubCategory(id);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("get-parent-category/{id:guid}")]
        public async Task<ActionResult<ResponseDTO>> GetParentCategory([FromRoute] Guid id)
        {
            var responseDto = await _categoryService.GetParentCategory(id);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<ResponseDTO>> GetById([FromRoute] Guid id)
        {
            var responeDto = await _categoryService.Get(id);
            return StatusCode(responeDto.StatusCode, responeDto);
        }


        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> Create(CreateCategoryDTO createCategoryDto)
        {
            return Ok();
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<ActionResult<ResponseDTO>> Update([FromRoute] Guid id,
            [FromBody] UpdateCategoryDTO updateCategoryDto)
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