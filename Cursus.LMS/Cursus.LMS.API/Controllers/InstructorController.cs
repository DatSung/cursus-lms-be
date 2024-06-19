using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cursus.LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService _instructorService;

        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> GetAllInstructor
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
                await _instructorService.GetAll(User, filterOn, filterQuery, sortBy, isAscending, pageNumber, pageSize);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<ResponseDTO>> GetInstructorById([FromRoute] Guid id)
        {
            var responseDto = await _instructorService.GetById(id);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPut]
        public async Task<ActionResult<ResponseDTO>> UpdateInstructorById([FromBody] UpdateInstructorDTO instructorDto)
        {
            var responseDto = await _instructorService.UpdateById(instructorDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("accept/{instructorId:guid}")]
        public async Task<ActionResult<ResponseDTO>> AcceptInstructor([FromRoute] Guid instructorId)
        {
            var responseDto = await _instructorService.AcceptInstructor(User, instructorId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("reject/{instructorId:guid}")]
        public async Task<ActionResult<ResponseDTO>> RejectInstructor([FromRoute] Guid instructorId)
        {
            var responseDto = await _instructorService.RejectInstructor(User, instructorId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }
    }
}