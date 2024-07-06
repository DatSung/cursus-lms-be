using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cursus.LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> GetCourses
        (
            [FromQuery] Guid? instructorId,
            [FromQuery] string? filterOn,
            [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy,
            [FromQuery] bool? isAscending,
            [FromQuery] double? fromPrice,
            [FromQuery] double? toPrice,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 5
        )
        {
            var responseDto = await _courseService.GetCourses
            (
                User,
                instructorId,
                filterOn,
                filterQuery,
                fromPrice,
                toPrice,
                sortBy,
                isAscending,
                pageNumber,
                pageSize
            );
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("{courseId:guid}")]
        public async Task<ActionResult<ResponseDTO>> GetCourse([FromRoute] Guid courseId)
        {
            var responseDto = await _courseService.GetCourse(User, courseId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("activate-course/{courseId:guid}")]
        public async Task<ActionResult<ResponseDTO>> ActivateCourse([FromRoute] Guid courseId)
        {
            var responseDto = await _courseService.ActivateCourse(User, courseId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("deactivate-course/{courseId:guid}")]
        public async Task<ActionResult<ResponseDTO>> DeactivateCourse([FromRoute] Guid courseId)
        {
            var responseDto = await _courseService.DeactivateCourse(User, courseId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }
    }
}