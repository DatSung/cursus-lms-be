using System.Security.Claims;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cursus.LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService _instructorService;
        private readonly IPaymentService _paymentService;

        public InstructorController(IInstructorService instructorService, IPaymentService paymentService)
        {
            _instructorService = instructorService;
            _paymentService = paymentService;
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
        [Route("course/total/{instructorId:guid}")]
        public async Task<ActionResult<ResponseDTO>> GetTotalCoursesInstructorById([FromRoute] Guid instructorId)
        {
            var responseDto = await _instructorService.GetInstructorTotalCourses(instructorId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("rating/total/{instructorId:guid}")]
        public async Task<ActionResult<ResponseDTO>> GetTotalRatingInstructorById([FromRoute] Guid instructorId)
        {
            var responseDto = await _instructorService.GetInstructorTotalRating(instructorId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPut]
        [Authorize(Roles = StaticUserRoles.AdminInstructor)]
        public async Task<ActionResult<ResponseDTO>> UpdateInstructorById([FromBody] UpdateInstructorDTO instructorDto)
        {
            var responseDto = await _instructorService.UpdateById(instructorDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("accept/{instructorId:guid}")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> AcceptInstructor([FromRoute] Guid instructorId)
        {
            var responseDto = await _instructorService.AcceptInstructor(User, instructorId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("reject/{instructorId:guid}")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> RejectInstructor([FromRoute] Guid instructorId)
        {
            var responseDto = await _instructorService.RejectInstructor(User, instructorId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }


        // Comment for instructor

        [HttpGet]
        [Route("comment/{instructorId:guid}")]
        [Authorize(Roles = StaticUserRoles.AdminInstructor)]
        public async Task<ActionResult<ResponseDTO>> GetAllInstructorComment
        (
            [FromRoute] Guid instructorId,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10
        )
        {
            var responseDto = await _instructorService.GetAllInstructorComment(instructorId, pageNumber, pageSize);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("comment/")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> CreateInstructorComment
        (
            CreateInstructorCommentDTO createInstructorComment)
        {
            var responseDto = await _instructorService.CreateInstructorComment(User, createInstructorComment);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPut]
        [Route("comment/")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> UpdateInstructorComment
        (
            UpdateInstructorCommentDTO updateInstructorComment)
        {
            var responseDto = await _instructorService.UpdateInstructorComment(User, updateInstructorComment);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpDelete]
        [Route("comment/{commentId:guid}")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> DeleteInstructorComment
        (
            [FromRoute] Guid commentId
        )

        {
            var responseDto = await _instructorService.DeleteInstructorComment(commentId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("export/{month:int}/{year:int}")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> ExportInstructor
        (
            [FromRoute] int month,
            [FromRoute] int year
        )
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            BackgroundJob.Enqueue<IInstructorService>(job => job.ExportInstructors(userId, month, year));
            return Ok();
        }

        [HttpGet]
        [Route("download/{fileName}")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ClosedXMLResponseDTO>> DownloadInstructor
        (
            [FromRoute] string fileName
        )
        {
            var closedXmlResponseDto = await _instructorService.DownloadInstructors(fileName);
            var stream = closedXmlResponseDto.Stream;
            var contentType = closedXmlResponseDto.ContentType;

            if (stream is null || contentType is null)
            {
                return NotFound();
            }

            return File(stream, contentType, fileName);
        }

        [HttpGet]
        [Route("payout/top")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> GetTopInstructorsByPayout
        (
            [FromQuery] int topN,
            [FromQuery] int? filterYear,
            [FromQuery] int? filterMonth,
            [FromQuery] int? filterQuarter
        )
        {
            var responseDto = await _paymentService.GetTopInstructorsByPayout
            (
                topN,
                filterYear,
                filterMonth,
                filterQuarter
            );
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("payout/least")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> GetLeastInstructorsByPayout
        (
            [FromQuery] int topN,
            [FromQuery] int? filterYear,
            [FromQuery] int? filterMonth,
            [FromQuery] int? filterQuarter
        )
        {
            var responseDto = await _paymentService.GetLeastInstructorsByPayout
            (
                topN,
                filterYear,
                filterMonth,
                filterQuarter
            );
            return StatusCode(responseDto.StatusCode, responseDto);
        }
    }
}