using Cursus.LMS.DataAccess.IRepository;
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
        private ICourseReviewService _courseReviewService;

        public CourseController(ICourseService courseService,ICourseReviewService courseReviewService)
        {
            _courseService = courseService;
            _courseReviewService = courseReviewService;
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

        [HttpGet]
        [Route("get-course-reviews")]
        public async Task<ActionResult<ResponseDTO>> GetCourseReviews
        (
            [FromQuery] Guid? courseId,
            [FromQuery] string? filterOn,
            [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy,
            [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 5
        )
        {
            var responseDto = await _courseReviewService.GetCourseReviews(
                User,
                courseId,
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
        [Route("get-course-review/{id}")]
        public async Task<ActionResult<ResponseDTO>> GetCourseReview(Guid id)
        {
            try
            {
                var responseDto = await _courseReviewService.GetCourseReviewById(id);
                return StatusCode(responseDto.StatusCode, responseDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDTO
                {
                    Message = ex.Message,
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 500
                });
            }
        }

        [HttpPost]
        [Route("create-course-review")]
        public async Task<ActionResult<ResponseDTO>> CreateCourseReview([FromBody] CreateCourseReviewDTO createCourseReviewDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseDTO
                {
                    Message = "Invalid data",
                    Result = ModelState,
                    IsSuccess = false,
                    StatusCode = 400
                });
            }

            try
            {
                var responseDto = await _courseReviewService.CreateCourseReview(createCourseReviewDTO);
                return StatusCode(responseDto.StatusCode, responseDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDTO
                {
                    Message = ex.Message,
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 500
                });
            }
        }
        [HttpPut]
        [Route("update-course-review")]
        public async Task<ActionResult<ResponseDTO>> UpdateCourseReview([FromBody] UpdateCourseReviewDTO updateCourseReviewDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseDTO
                {
                    Message = "Invalid data",
                    Result = ModelState,
                    IsSuccess = false,
                    StatusCode = 400
                });
            }

            try
            {
                var responseDto = await _courseReviewService.UpdateCourseReview(updateCourseReviewDTO);
                return StatusCode(responseDto.StatusCode, responseDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDTO
                {
                    Message = ex.Message,
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 500
                });
            }
        }

        [HttpDelete]
        [Route("delete-course-review/{id}")]
        public async Task<ActionResult<ResponseDTO>> DeleteCourseReview(Guid id)
        {
            try
            {
                var responseDto = await _courseReviewService.DeleteCourseReview(id);
                return StatusCode(responseDto.StatusCode, responseDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDTO
                {
                    Message = ex.Message,
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 500
                });
            }
        }


    }
}