using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cursus.LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly ICourseReviewService _courseReviewService;
        private readonly ICourseReportService _courseReportService;

        public CourseController
        (
            ICourseService courseService,
            ICourseReviewService courseReviewService,
            ICourseReportService courseReportService
        )
        {
            _courseService = courseService;
            _courseReviewService = courseReviewService;
            _courseReportService = courseReportService;
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
        [Authorize(Roles = StaticUserRoles.AdminInstructor)]
        public async Task<ActionResult<ResponseDTO>> ActivateCourse([FromRoute] Guid courseId)
        {
            var responseDto = await _courseService.ActivateCourse(User, courseId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("deactivate-course/{courseId:guid}")]
        [Authorize(Roles = StaticUserRoles.AdminInstructor)]
        public async Task<ActionResult<ResponseDTO>> DeactivateCourse([FromRoute] Guid courseId)
        {
            var responseDto = await _courseService.DeactivateCourse(User, courseId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }


        [HttpGet]
        [Route("get-course-reviews")]
        [Authorize]
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
        [Authorize]
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
        [Authorize(Roles = StaticUserRoles.Student)]
        public async Task<ActionResult<ResponseDTO>> CreateCourseReview(
            [FromBody] CreateCourseReviewDTO createCourseReviewDTO)
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
        [Authorize]
        public async Task<ActionResult<ResponseDTO>> UpdateCourseReview(
            [FromBody] UpdateCourseReviewDTO updateCourseReviewDTO)
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
                var responseDto = await _courseReviewService.UpdateCourseReview(User,updateCourseReviewDTO);
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
        [Authorize]
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


        [HttpPut]
        [Route("Mark-course-review")]
        [Authorize(Roles = StaticUserRoles.Instructor) ]
        public async Task<ActionResult<ResponseDTO>> MarkCourseReview(Guid id)
        {
            try
            {
                var responseDto = await _courseReviewService.MarkCourseReview(id);
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


        [HttpGet]
        [Route("get-course-reports")]
        [Authorize]
        public async Task<ActionResult<ResponseDTO>> GetCourseReports(
            [FromQuery] Guid? courseId,
            [FromQuery] string? filterOn,
            [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy,
            [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 5
        )
        {
            var responseDto = await _courseReportService.GetCourseReports(
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
        [Route("get-course-report/{id}")]
        [Authorize]
        public async Task<ActionResult<ResponseDTO>> GetCourseReport(Guid id)
        {
            try
            {
                var responseDto = await _courseReportService.GetCourseReportById(id);
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
        [Route("create-course-report")]
        [Authorize(Roles = StaticUserRoles.Student)]
        public async Task<ActionResult<ResponseDTO>> CreateCourseReport(
            [FromBody] CreateCourseReportDTO createCourseReportDTO)
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
                var responseDto = await _courseReportService.CreateCourseReport(createCourseReportDTO);
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
        [Route("update-course-report")]
        [Authorize]
        public async Task<ActionResult<ResponseDTO>> UpdateCourseReport(
            [FromBody] UpdateCourseReportDTO updateCourseReportDTO)
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
                var responseDto = await _courseReportService.UpdateCourseReport(User,updateCourseReportDTO);
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
        [Route("delete-course-report/{id}")]
        [Authorize]
        public async Task<ActionResult<ResponseDTO>> DeleteCourseReport(Guid id)
        {
            try
            {
                var responseDto = await _courseReportService.DeleteCourseReport(id);
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

        [HttpGet]
        [Route("get-top-purchased-courses")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> GetTopPurchasedCourses
        (
            [FromQuery] int? year,
            [FromQuery] int? month,
            [FromQuery] int? quarter,
            [FromQuery] int top,
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            [FromQuery] string? byCategoryName
        )
        {
            var responseDto = await _courseService.GetTopPurchasedCourses
                (
                    year,
                    month,
                    quarter,
                    top,
                    pageNumber,
                    pageSize,
                    byCategoryName
                );
            return StatusCode(responseDto.StatusCode, responseDto);
        }
        
        [HttpGet]
        [Route("get-least-purchased-courses")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> GetLeastPurchasedCourses
        (
            [FromQuery] int? year,
            [FromQuery] int? month,
            [FromQuery] int? quarter,
            [FromQuery] int top,
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            [FromQuery] string? byCategoryName
        )
        {
            var responseDto = await _courseService.GetLeastPurchasedCourses
                (
                    year,
                    month,
                    quarter,
                    top,
                    pageNumber,
                    pageSize,
                    byCategoryName
                );
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("enroll-course")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> EnrollCourse([FromBody] EnrollCourseDTO enrollCourseDto)
        {
            var responseDto = await _courseService.EnrollCourse(User, enrollCourseDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("new-suggest-courses/{studentId}")]
        public async Task<ActionResult> SuggestCourses(Guid studentId)
        {
            var response = await _courseService.SuggestCourse(studentId);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Bookmarked/{studentId}")]
        public async Task<IActionResult> GetAllBookMarkedCoursesByID(Guid studentId, [FromQuery] string sortOrder = "desc")
        {
            var response = await _courseService.GetAllBookMarkedCoursesByID(studentId, sortOrder);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        [Route("courses-bookmarked")]
        public async Task<ActionResult> CreateBookMarkedCourse(CreateCourseBookmarkDTO createCourseBookmarkDTO)
        {
            var response = await _courseService.CreateBookMarkedCourse(User, createCourseBookmarkDTO);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete]
        [Route("courses-bookmarked/{Id}")]
        public async Task<ActionResult> DeleteBookMarkedCourse(Guid Id)
        {
            var response = await _courseService.DeleteBookMarkedCourse(Id);
            return StatusCode(response.StatusCode, response);
        }
    }
}