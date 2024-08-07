using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Service.Service;
using Cursus.LMS.Utility.Constants;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cursus.LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentsService _studentsService;

        public StudentController(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ResponseDTO>> GetAllStudent
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
                await _studentsService.GetAllStudent(User, filterOn, filterQuery, sortBy, isAscending, pageNumber,
                    pageSize);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("{studentId:guid}")]
        [Authorize]
        public async Task<ActionResult<ResponseDTO>> GetStudentById([FromRoute] Guid studentId)
        {
            var responseDto = await _studentsService.GetById(studentId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPut]
        [Authorize(Roles = StaticUserRoles.AdminStudent)]
        public async Task<ActionResult<ResponseDTO>> UpdateStudent([FromBody] UpdateStudentDTO updateStudentDTO)
        {
            var responseDto = await _studentsService.UpdateById(updateStudentDTO);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("activate/{studentId:guid}")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> ActivateStudent([FromRoute] Guid studentId)
        {
            var responseDto = await _studentsService.ActivateStudent(User, studentId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("deactivate/{studentId:guid}")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> DeactiveStudent([FromRoute] Guid studentId)
        {
            var responseDto = await _studentsService.DeactivateStudent(User, studentId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("course/total/{studentId:guid}")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> GetTotalCoursesStudentById([FromRoute] Guid studentId)
        {
            var responseDto = await _studentsService.GetStudentTotalCourses(studentId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("comment/{studentId:guid}")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> GetStudentComments
        (
            [FromRoute] Guid studentId,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10
        )
        {
            var responseDto = await _studentsService.GetAllStudentComment(studentId, pageNumber, pageSize);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("comment/")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> CreateStudentComment(
            CreateStudentCommentDTO createStudentCommentDto)
        {
            var responseDto = await _studentsService.CreateStudentComment(User, createStudentCommentDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPut]
        [Route("comment/")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> UpdateStudentComment(
            UpdateStudentCommentDTO updateStudentCommentDto)
        {
            var responseDto = await _studentsService.UpdateStudentComment(User, updateStudentCommentDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpDelete]
        [Route("comment/{commentId:guid}")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> DeleteStudentComment([FromRoute] Guid commentId)
        {
            var responseDto = await _studentsService.DeleteStudentComment(commentId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("export/{month:int}/{year:int}")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> ExportStudent
        (
            [FromRoute] int month,
            [FromRoute] int year
        )
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            BackgroundJob.Enqueue<IStudentsService>(job => job.ExportStudents(userId, month, year));
            return Ok();
        }

        [HttpGet]
        [Route("download/{fileName}")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<IActionResult> DownloadStudentExport([FromRoute] string fileName)
        {
            var closedXmlResponseDto = await _studentsService.DownloadStudents(fileName);
            var stream = closedXmlResponseDto.Stream;
            var contentType = closedXmlResponseDto.ContentType;

            if (stream is null || contentType is null)
            {
                return NotFound();
            }

            return File(stream, contentType, fileName);
        }

        [HttpGet]
        [Route("course/price/total/{studentId:guid}")]
        [Authorize(Roles = StaticUserRoles.AdminStudent)]
        public async Task<ActionResult<ResponseDTO>> TotalPricesCourseByStudentId([FromRoute] Guid studentId)
        {
            var responseDto = await _studentsService.TotalPricesCoursesByStudentId(studentId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("course")]
        [Authorize(Roles = StaticUserRoles.AdminStudent)]
        public async Task<ActionResult<ResponseDTO>> GetAllCoursesByStudentId([FromQuery] Guid studentId)
        {
            var courseByStudentDTO = new CourseByStudentDTO
            {
                StudentId = studentId
            };
            var responseDto = await _studentsService.GetAllCourseByStudentId(User, courseByStudentDTO);
    
            return StatusCode(responseDto.StatusCode, responseDto);
        }


        [HttpGet]
        [Route("course/enroll/total/{studentId:guid}")]
        [Authorize(Roles = StaticUserRoles.AdminStudent)]
        public async Task<ActionResult<ResponseDTO>> GetAllCoursesStudentEnrolled([FromRoute] Guid studentId)
        {
            var responseDto = await _studentsService.GetAllCourseStudentEnrolled(studentId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }
    }
}