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
        [Route("{instructorId:guid}")]
        public async Task<ActionResult<ResponseDTO>> GetInstructorById([FromRoute] Guid instructorId)
        {
            var responseDto = await _instructorService.GetById(instructorId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("total-courses/{instructorId:guid}")]
        public async Task<ActionResult<ResponseDTO>> GetTotalCoursesInstructorById([FromRoute] Guid instructorId)
        {
            var responseDto = await _instructorService.GetInstructorTotalCourses(instructorId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("total-rating/{instructorId:guid}")]
        public async Task<ActionResult<ResponseDTO>> GetTotalRatingInstructorById([FromRoute] Guid instructorId)
        {
            var responseDto = await _instructorService.GetInstructorTotalRating(instructorId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("total-earned-money/{instructorId:guid}")]
        public async Task<ActionResult<ResponseDTO>> GetTotalEarnedMoneyInstructorById([FromRoute] Guid instructorId)
        {
            var responseDto = await _instructorService.GetInstructorEarnedMoney(instructorId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("total-payout-money/{instructorId:guid}")]
        public async Task<ActionResult<ResponseDTO>> GetTotalPayoutMoneyInstructorById([FromRoute] Guid instructorId)
        {
            var responseDto = await _instructorService.GetInstructorPayoutMoney(instructorId);
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


        // Comment for instructor

        [HttpGet]
        [Route("comment/{instructorId:guid}")]
        public async Task<ActionResult<ResponseDTO>> GetAllInstructorComment([FromRoute] Guid instructorId)
        {
            var responseDto = await _instructorService.GetAllInstructorComment(instructorId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("comment/")]
        public async Task<ActionResult<ResponseDTO>> CreateInstructorComment
        (
            CreateInstructorComment createInstructorComment)
        {
            var responseDto = await _instructorService.CreateInstructorComment(User, createInstructorComment);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPut]
        [Route("comment/")]
        public async Task<ActionResult<ResponseDTO>> UpdateInstructorComment
        (
            UpdateInstructorComment updateInstructorComment)
        {
            var responseDto = await _instructorService.UpdateInstructorComment(User, updateInstructorComment);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpDelete]
        [Route("comment/{commentId:guid}")]
        public async Task<ActionResult<ResponseDTO>> DeleteInstructorComment
        (
            [FromRoute] Guid commentId)
        {
            var responseDto = await _instructorService.DeleteInstructorComment(User, commentId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }
    }
}