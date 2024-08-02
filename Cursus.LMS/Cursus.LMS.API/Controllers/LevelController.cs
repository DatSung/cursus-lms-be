using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cursus.LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        private readonly ILevelService _levelService;

        public LevelController(ILevelService levelService)
        {
            _levelService = levelService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> GetLevels
        (
            [FromQuery] string? filterOn,
            [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy,
            [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 0,
            [FromQuery] int pageSize = 0
        )
        {
            var responseDto = await _levelService.GetLevels
            (
                User,
                filterOn,
                filterQuery,
                sortBy,
                isAscending,
                pageNumber,
                pageSize
            );
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("{levelId:guid}")]
        public async Task<ActionResult<ResponseDTO>> GetLevel
        (
            [FromRoute] Guid levelId
        )
        {
            var responseDto = await _levelService.GetLevel(User, levelId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> CreateLevel
        (
            [FromBody] CreateLevelDTO createLevelDto
        )
        {
            var responseDto = await _levelService.CreateLevel(User, createLevelDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPut]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> UpdateLevel
        (
            [FromBody] UpdateLevelDTO updateLevelDto
        )
        {
            var responseDto = await _levelService.UpdateLevel(User, updateLevelDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpDelete]
        [Route("{levelId:guid}")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> DeleteLevel
        (
            [FromRoute] Guid levelId
        )
        {
            var responseDto = await _levelService.DeleteLevel(User, levelId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }
    }
}
