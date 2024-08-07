using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Cursus.LMS.Utility.Constants;
using Microsoft.AspNetCore.Authorization;
using StaticFileExtensions = Cursus.LMS.Utility.Constants.StaticFileExtensions;

namespace Cursus.LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseVersionController : ControllerBase
    {
        private readonly ICourseVersionService _courseVersionService;
        private readonly ICourseSectionVersionService _courseSectionVersionService;
        private readonly ISectionDetailsVersionService _sectionDetailsVersionService;

        public CourseVersionController(ICourseVersionService courseVersionService,
            ICourseSectionVersionService courseSectionVersionService,
            ISectionDetailsVersionService sectionDetailsVersionService)
        {
            _courseVersionService = courseVersionService;
            _courseSectionVersionService = courseSectionVersionService;
            _sectionDetailsVersionService = sectionDetailsVersionService;
        }

        #region Course Version

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ResponseDTO>> GetCourseVersions
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
            var responseDto = await _courseVersionService.GetCourseVersions
            (
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
        [Route("{courseId:guid}")]
        [Authorize]
        public async Task<ActionResult<ResponseDTO>> GetCourseVersion([FromRoute] Guid courseId)
        {
            var responseDto = await _courseVersionService.GetCourseVersion(User, courseId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("create")]
        [Authorize(Roles = StaticUserRoles.Instructor)]
        public async Task<ActionResult<ResponseDTO>> CreateCourseAndVersion
        (
            CreateNewCourseAndVersionDTO createNewCourseAndVersionDto
        )
        {
            var responseDto = await _courseVersionService.CreateCourseAndVersion(User, createNewCourseAndVersionDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("clone")]
        [Authorize(Roles = StaticUserRoles.Instructor)]
        public async Task<ActionResult<ResponseDTO>> CloneCourseVersion
        (
            [FromBody] CloneCourseVersionDTO cloneCourseVersionDto
        )
        {
            var responseDto = await _courseVersionService.CloneCourseVersion(User, cloneCourseVersionDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPut]
        [Route("edit")]
        [Authorize(Roles = StaticUserRoles.Instructor)]
        public async Task<ActionResult<ResponseDTO>> EditCourseVersion
        (
            [FromBody] EditCourseVersionDTO editCourseVersionDto)
        {
            var responseDto = await _courseVersionService.EditCourseVersion(User, editCourseVersionDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpDelete]
        [Route("remove/{courseId:guid}")]
        [Authorize(Roles = StaticUserRoles.Instructor)]
        public async Task<ActionResult<ResponseDTO>> RemoveCourseVersion([FromRoute] Guid courseId)
        {
            var responseDto = await _courseVersionService.RemoveCourseVersion(User, courseId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("accept/{courseId:guid}")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> AcceptCourseVersion([FromRoute] Guid courseId)
        {
            var responseDto = await _courseVersionService.AcceptCourseVersion(User, courseId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("reject/{courseId:guid}")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> RejectCourseVersion([FromRoute] Guid courseId)
        {
            var responseDto = await _courseVersionService.RejectCourseVersion(User, courseId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("submit/{courseId:guid}")]
        [Authorize(Roles = StaticUserRoles.Instructor)]
        public async Task<ActionResult<ResponseDTO>> SubmitCourseVersion([FromRoute] Guid courseId)
        {
            var responseDto = await _courseVersionService.SubmitCourseVersion(User, courseId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("merge/{courseId:guid}")]
        [Authorize(Roles = StaticUserRoles.Instructor)]
        public async Task<ActionResult<ResponseDTO>> MergeCourseVersion([FromRoute] Guid courseId)
        {
            var responseDto = await _courseVersionService.MergeCourseVersion(User, courseId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("background/{courseVersionId:guid}")]
        [Authorize(Roles = StaticUserRoles.Instructor)]
        public async Task<ActionResult<ResponseDTO>> UploadCourseVersionBackground
        (
            [FromRoute] Guid courseVersionId,
            UploadCourseVersionBackgroundImg uploadCourseVersionBackgroundImg
        )
        {
            var responseDto =
                await _courseVersionService.UploadCourseVersionBackgroundImg
                (
                    User,
                    courseVersionId,
                    uploadCourseVersionBackgroundImg
                );
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("background/{courseVersionId:guid}")]
        public async Task<ActionResult> DisplayCourseVersionBackground
        (
            [FromRoute] Guid courseVersionId
        )
        {
            var responseDto = await _courseVersionService.DisplayCourseVersionBackgroundImg(User, courseVersionId);
            if (responseDto is null)
            {
                return null;
            }

            return File(responseDto, "image/png");
        }

        #endregion

        #region Course Version Comment

        [HttpGet]
        [Route("comment/")]
        [Authorize(Roles = StaticUserRoles.AdminInstructor)]
        public async Task<ActionResult<ResponseDTO>> GetCourseVersionsComments
        (
            [FromQuery] [Required] Guid courseVersionId,
            [FromQuery] string? filterOn,
            [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10
        )
        {
            var responseDto = await _courseVersionService.GetCourseVersionsComments
            (
                User,
                courseVersionId,
                filterOn,
                filterQuery,
                sortBy,
                pageNumber,
                pageSize
            );

            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("comment/{commentId:guid}")]
        [Authorize(Roles = StaticUserRoles.AdminInstructor)]
        public async Task<ActionResult<ResponseDTO>> GetCourseVersionComment([FromRoute] Guid commentId)
        {
            var responseDto = await _courseVersionService.GetCourseVersionComment(User, commentId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("comment")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> CreateCourseVersionComment
        (
            CreateCourseVersionCommentsDTO createCourseVersionCommentsDto
        )
        {
            var responseDto =
                await _courseVersionService.CreateCourseVersionComment(User, createCourseVersionCommentsDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPut]
        [Route("comment")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> EditCourseVersionComment
        (
            EditCourseVersionCommentsDTO editCourseVersionCommentsDto
        )
        {
            var responseDto = await _courseVersionService.EditCourseVersionComment(User, editCourseVersionCommentsDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpDelete]
        [Route("comment/{commentId:guid}")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> RemoveCourseVersionComment(
            [FromRoute] Guid commentId)
        {
            var responseDto =
                await _courseVersionService.RemoveCourseVersionComment(User, commentId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        #endregion

        #region Course Section Version

        [HttpGet]
        [Route("section")]
        [Authorize]
        public async Task<ActionResult<ResponseDTO>> GetCourseSections
        (
            [FromQuery] [Required] Guid? courseVersionId,
            [FromQuery] string? filterOn,
            [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy,
            [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 5
        )
        {
            var responseDto = await _courseSectionVersionService.GetCourseSections
            (
                User,
                courseVersionId,
                filterOn,
                filterQuery,
                sortBy,
                pageNumber,
                pageSize
            );

            return StatusCode(responseDto.StatusCode, responseDto);
        }


        [HttpGet]
        [Route("section/{sectionId:guid}")]
        [Authorize]
        public async Task<ActionResult<ResponseDTO>> GetCourseSection([FromRoute] Guid sectionId)
        {
            var responseDto = await _courseSectionVersionService.GetCourseSection(User, sectionId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("section")]
        [Authorize(Roles = StaticUserRoles.Instructor)]
        public async Task<ActionResult<ResponseDTO>> CreateCourseSection
        (
            CreateCourseSectionVersionDTO createCourseSectionVersionDto
        )
        {
            var responseDto =
                await _courseSectionVersionService.CreateCourseSection(User, createCourseSectionVersionDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPut]
        [Route("section")]
        [Authorize(Roles = StaticUserRoles.Instructor)]
        public async Task<ActionResult<ResponseDTO>> EditCourseSection
        (
            EditCourseSectionVersionDTO createCourseSectionVersionDto
        )
        {
            var responseDto = await _courseSectionVersionService.EditCourseSection(User, createCourseSectionVersionDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpDelete]
        [Route("section/{sectionId}")]
        [Authorize(Roles = StaticUserRoles.Instructor)]
        public async Task<ActionResult<ResponseDTO>> DeleteCourseSection
        (
            [FromRoute] Guid sectionId
        )
        {
            var responseDto =
                await _courseSectionVersionService.RemoveCourseSection(User, sectionId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        #endregion

        #region Section Details Version

        [HttpGet]
        [Route("section/details")]
        [Authorize]
        public async Task<ActionResult<ResponseDTO>> GetSectionsDetailsVersions
        (
            [FromQuery] Guid? courseSectionId,
            [FromQuery] string? filterOn,
            [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy,
            [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 5
        )
        {
            var responseDto = await _sectionDetailsVersionService.GetSectionsDetailsVersions
            (
                User,
                courseSectionId,
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
        [Route("section/details/{detailsId:guid}")]
        [Authorize]
        public async Task<ActionResult<ResponseDTO>> GetSectionsDetailsVersion([FromRoute] Guid detailsId)
        {
            var responseDto = await _sectionDetailsVersionService.GetSectionDetailsVersion(User, detailsId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("section/details")]
        [Authorize(Roles = StaticUserRoles.Instructor)]
        public async Task<ActionResult<ResponseDTO>> CreateSectionDetailsVersion(
            [FromBody] CreateSectionDetailsVersionDTO createSectionDetailsVersionDto)
        {
            var responseDto =
                await _sectionDetailsVersionService.CreateSectionDetailsVersion(User, createSectionDetailsVersionDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPut]
        [Route("section/details")]
        [Authorize(Roles = StaticUserRoles.Instructor)]
        public async Task<ActionResult<ResponseDTO>> EditSectionDetailsVersion(
            [FromBody] EditSectionDetailsVersionDTO editSectionDetailsVersionDto)
        {
            var responseDto =
                await _sectionDetailsVersionService.EditSectionDetailsVersion(User, editSectionDetailsVersionDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpDelete]
        [Route("section/details/{detailsId:guid}")]
        [Authorize(Roles = StaticUserRoles.Instructor)]
        public async Task<ActionResult<ResponseDTO>> RemoveSectionDetailsVersion([FromRoute] Guid detailsId)
        {
            var responseDto =
                await _sectionDetailsVersionService.RemoveSectionDetailsVersion(User, detailsId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("section/details/content/{detailsId:guid}")]
        [Authorize(Roles = StaticUserRoles.Instructor)]
        public async Task<ActionResult<ResponseDTO>> UploadSectionDetailsVersionContent
        (
            [FromRoute] Guid detailsId,
            UploadSectionDetailsVersionContentDTO uploadSectionDetailsVersionContentDto
        )
        {
            var responseDto =
                await _sectionDetailsVersionService.UploadSectionDetailsVersionContent
                (
                    User,
                    detailsId,
                    uploadSectionDetailsVersionContentDto
                );
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("section/details/content/")]
        public async Task<IActionResult> DisplaySectionDetailsVersionContent
        (
            [FromQuery] Guid sectionDetailsVersionId,
            [FromQuery] string userId,
            [FromQuery] string type
        )
        {
            var contentResponseDto =
                await _sectionDetailsVersionService.DisplaySectionDetailsVersionContent
                (
                    sectionDetailsVersionId,
                    userId,
                    type
                );

            if (contentResponseDto.Stream is null)
            {
                return NotFound(contentResponseDto.Message);
            }

            if (contentResponseDto.ContentType is StaticFileExtensions.Mov or StaticFileExtensions.Mp4)
            {
                return File(contentResponseDto.Stream, contentResponseDto.ContentType);
            }

            return File(contentResponseDto.Stream, contentResponseDto.ContentType, contentResponseDto.FileName);
        }

        #endregion
    }
}