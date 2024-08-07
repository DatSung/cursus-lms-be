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
        private readonly ICourseProgressService _courseProgressService;

        public CourseController
        (
            ICourseService courseService,
            ICourseReviewService courseReviewService,
            ICourseReportService courseReportService, ICourseProgressService courseProgressService)
        {
            _courseService = courseService;
            _courseReviewService = courseReviewService;
            _courseReportService = courseReportService;
            _courseProgressService = courseProgressService;
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
        [Route("activate/{courseId:guid}")]
        [Authorize(Roles = StaticUserRoles.AdminInstructor)]
        public async Task<ActionResult<ResponseDTO>> ActivateCourse([FromRoute] Guid courseId)
        {
            var responseDto = await _courseService.ActivateCourse(User, courseId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("deactivate/{courseId:guid}")]
        [Authorize(Roles = StaticUserRoles.AdminInstructor)]
        public async Task<ActionResult<ResponseDTO>> DeactivateCourse([FromRoute] Guid courseId)
        {
            var responseDto = await _courseService.DeactivateCourse(User, courseId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }


        [HttpGet]
        [Route("review")]
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
        [Route("review/{reviewId:guid}")]
        [Authorize]
        public async Task<ActionResult<ResponseDTO>> GetCourseReview([FromRoute] Guid reviewId)
        {
            try
            {
                var responseDto = await _courseReviewService.GetCourseReviewById(reviewId);
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
        [Route("review")]
        [Authorize(Roles = StaticUserRoles.Student)]
        public async Task<ActionResult<ResponseDTO>> CreateCourseReview
        (
            [FromBody] CreateCourseReviewDTO createCourseReviewDto
        )
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
                var responseDto = await _courseReviewService.CreateCourseReview(User, createCourseReviewDto);
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
        [Route("review")]
        [Authorize(Roles = StaticUserRoles.Student)]
        public async Task<ActionResult<ResponseDTO>> UpdateCourseReview(
            [FromBody] UpdateCourseReviewDTO updateCourseReviewDto)
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
                var responseDto = await _courseReviewService.UpdateCourseReview(User, updateCourseReviewDto);
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
        [Route("review/{reviewId:guid}")]
        [Authorize]
        public async Task<ActionResult<ResponseDTO>> DeleteCourseReview([FromRoute] Guid reviewId)
        {
            try
            {
                var responseDto = await _courseReviewService.DeleteCourseReview(reviewId);
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
        [Route("review/mark/{reviewId:guid}")]
        [Authorize(Roles = StaticUserRoles.Instructor)]
        public async Task<ActionResult<ResponseDTO>> MarkCourseReview([FromRoute] Guid reviewId)
        {
            try
            {
                var responseDto = await _courseReviewService.MarkCourseReview(reviewId);
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
        [Route("report")]
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
        [Route("report/{reportId:guid}")]
        [Authorize]
        public async Task<ActionResult<ResponseDTO>> GetCourseReport([FromRoute] Guid reportId)
        {
            try
            {
                var responseDto = await _courseReportService.GetCourseReportById(reportId);
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
        [Route("report")]
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
        [Route("report")]
        [Authorize(Roles = StaticUserRoles.Student)]
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
                var responseDto = await _courseReportService.UpdateCourseReport(User, updateCourseReportDTO);
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
        [Route("report/{reportId:guid}")]
        [Authorize(Roles = StaticUserRoles.AdminStudent)]
        public async Task<ActionResult<ResponseDTO>> DeleteCourseReport([FromRoute] Guid reportId)
        {
            try
            {
                var responseDto = await _courseReportService.DeleteCourseReport(reportId);
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
        [Route("purchased/top")]
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
        [Route("purchased/least")]
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
        [Route("enroll")]
        [Authorize(Roles = StaticUserRoles.Student)]
        public async Task<ActionResult<ResponseDTO>> EnrollCourse([FromBody] EnrollCourseDTO enrollCourseDto)
        {
            var responseDto = await _courseService.EnrollCourse(User, enrollCourseDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("suggest/{studentId:guid}")]
        [Authorize(Roles = StaticUserRoles.Student)]
        public async Task<ActionResult> SuggestCourses([FromRoute] Guid studentId)
        {
            var response = await _courseService.SuggestCourse(studentId);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("bookmarked/{studentId:guid}")]
        [Authorize(Roles = StaticUserRoles.Student)]
        public async Task<IActionResult> GetAllBookMarkedCoursesById
        (
            [FromRoute] Guid studentId,
            [FromQuery] string sortOrder = "desc"
        )
        {
            var response = await _courseService.GetAllBookMarkedCoursesById(studentId, sortOrder);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        [Route("bookmarked")]
        [Authorize(Roles = StaticUserRoles.Student)]
        public async Task<ActionResult> CreateBookMarkedCourse(CreateCourseBookmarkDTO createCourseBookmarkDto)
        {
            var response = await _courseService.CreateBookMarkedCourse(User, createCourseBookmarkDto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete]
        [Route("bookmarked/{bookmarkedId:guid}")]
        [Authorize(Roles = StaticUserRoles.Student)]
        public async Task<ActionResult> DeleteBookMarkedCourse([FromRoute] Guid bookmarkedId)
        {
            var response = await _courseService.DeleteBookMarkedCourse(bookmarkedId);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut]
        [Route("progress")]
        [Authorize(Roles = StaticUserRoles.Student)]
        public async Task<ActionResult<ResponseDTO>> UpdateCourseProgress
        (
            [FromBody] UpdateProgressDTO updateProgressDto
        )
        {
            var responseDto = await _courseProgressService.UpdateProgress(User, updateProgressDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("progress")]
        [Authorize(Roles = StaticUserRoles.Student)]
        public async Task<ActionResult<ResponseDTO>> GetCourseProgress
        (
            [FromQuery] GetProgressDTO getProgressDto
        )
        {
            var responseDto = await _courseProgressService.GetProgress(getProgressDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("progress/percentage")]
        [Authorize(Roles = StaticUserRoles.Student)]
        public async Task<ActionResult<ResponseDTO>> GetProgressPercentage
        (
            [FromQuery] GetPercentageDTO getPercentageDto
        )
        {
            var responseDto = await _courseProgressService.GetPercentage(getPercentageDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("courses/suggest/best")]
        public async Task<ActionResult<ResponseDTO>> GetBestCoursesSuggestion()
        {
            var responseDto = await _courseService.GetBestCoursesSuggestion();
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("courses/trending/top")]
        public async Task<ActionResult<ResponseDTO>> GetTopCoursesByTrendingCategories()
        {
            var responseDto = await _courseService.GetTopCoursesByTrendingCategories();
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("courses/rate/top")]
        public async Task<ActionResult<ResponseDTO>> GetTopRatedCourses()
        {
            var responseDto = await _courseService.GetTopRatedCourses();
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("courses/rate/avg")]
        public async Task<ActionResult<ResponseDTO>> GetCourseRateAvg([FromQuery] Guid courseId)
        {
            var responseDto = await _courseService.GetCourseRateTotal(courseId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("courses/slot/total")]
        public async Task<ActionResult<ResponseDTO>> GetCourseSlotTotal([FromQuery] Guid courseId)
        {
            var responseDto = await _courseService.GetCourseSlotTotal(courseId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }
    }
}