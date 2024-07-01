using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Service.Service;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Threading.Tasks;
using Cursus.LMS.Utility.Constants;
using Microsoft.AspNetCore.Authorization;

namespace Cursus.LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseVersionController : ControllerBase
    {
        private readonly ICourseVersionService _courseVersionService;

        public CourseVersionController(ICourseVersionService courseVersionService)
        {
            _courseVersionService = courseVersionService;
        }


        #region Course Version

        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> GetCourseVersions
        (
            [FromQuery] Guid? courseId,
            [FromQuery] Guid? instructorId,
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
                instructorId,
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
        [Route("{courseVersionId:guid}")]
        public async Task<ActionResult<ResponseDTO>> GetCourseVersion([FromRoute] Guid courseVersionId)
        {
            var responseDto = await _courseVersionService.GetCourseVersion(User, courseVersionId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("create-course-version")]
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
        [Route("clone-course-version")]
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
        [Route("edit-course-version")]
        public async Task<ActionResult<ResponseDTO>> EditCourseVersion
        (
            [FromBody] EditCourseVersionDTO editCourseVersionDto)
        {
            var responseDto = await _courseVersionService.EditCourseVersion(User, editCourseVersionDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpDelete]
        [Route("remove-course-version{courseVersionId:guid}")]
        public async Task<ActionResult<ResponseDTO>> RemoveCourseVersion([FromRoute] Guid courseVersionId)
        {
            var responseDto = await _courseVersionService.RemoveCourseVersion(User, courseVersionId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("accept-course-version/{courseVersionId:guid}")]
        public async Task<ActionResult<ResponseDTO>> AcceptCourseVersion([FromRoute] Guid courseVersionId)
        {
            var responseDto = await _courseVersionService.AcceptCourseVersion(User, courseVersionId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("reject-course-version/{courseVersionId:guid}")]
        public async Task<ActionResult<ResponseDTO>> RejectCourseVersion([FromRoute] Guid courseVersionId)
        {
            var responseDto = await _courseVersionService.RejectCourseVersion(User, courseVersionId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("submit-course-version/{courseVersionId:guid}")]
        public async Task<ActionResult<ResponseDTO>> SubmitCourseVersion([FromRoute] Guid courseVersionId)
        {
            var responseDto = await _courseVersionService.SubmitCourseVersion(User, courseVersionId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("merge-course-version/{courseVersionId:guid}")]
        public async Task<ActionResult<ResponseDTO>> MergeCourseVersion([FromRoute] Guid courseVersionId)
        {
            var responseDto = await _courseVersionService.MergeCourseVersion(User, courseVersionId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        #endregion


        #region Course Comment

        [HttpGet]
        [Route("comment/")]
        public async Task<ResponseDTO> GetCourseVersions
        (
            [FromQuery] Guid? courseVersionId,
            [FromQuery] string? filterOn,
            [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 5
        )
        {
            /*var responseDto = await _courseVersionService.GetCourseVersions
                (
                    User,
                    courseVersionId,
                    filterOn,
                    filterQuery,
                    sortBy,
                    pageNumber,
                    pageSize
                );*/

            //return StatusCode(responseDto.StatusCode, responseDto);
            return null;
        }

        [HttpGet]
        [Route("comment/{courseVersionCommentId:guid}")]
        public async Task<ActionResult<ResponseDTO>> GetCourseVersionComment([FromRoute] Guid courseVersionCommentId)
        {
            var responseDto = await _courseVersionService.GetCourseVersionComment(User, courseVersionCommentId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("comment")]
        public async Task<ActionResult<ResponseDTO>> CreateCourseVersionComment
        (
            CreateCourseVersionCommentsDTO createCourseVersionCommentsDTO
        )
        {
            var responseDto =
                await _courseVersionService.CreateCourseVersionComment(User, createCourseVersionCommentsDTO);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPut]
        [Route("comment")]
        public async Task<ActionResult<ResponseDTO>> EditCourseVersionComment
        (
            EditCourseVersionCommentsDTO editCourseVersionCommentsDTO
        )
        {
            var responseDto = await _courseVersionService.EditCourseVersionComment(User, editCourseVersionCommentsDTO);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpDelete]
        [Route("comment/")]
        public async Task<ActionResult<ResponseDTO>> RemoveCourseVersionComment(
            RemoveCourseVersionCommentDTO removeCourseVersionCommentDTO)
        {
            var responseDto =
                await _courseVersionService.RemoveCourseVersionComment(User, removeCourseVersionCommentDTO);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        #endregion


        #region Course Section

        [HttpGet]
        [Route("section")]
        public async Task<ResponseDTO> GetCourseSections
        (
            [FromQuery] Guid? courseVersionId,
            [FromQuery] string? filterOn,
            [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy,
            [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 5
        )
        {
            try
            {
                return new ResponseDTO()
                {
                };
            }
            catch (Exception e)
            {
                return new ResponseDTO()
                {
                };
            }
        }


        [HttpGet]
        [Route("section/{sectionId:guid}")]
        public async Task<ResponseDTO> GetCourseSection([FromRoute] Guid sectionId)
        {
            try
            {
                return new ResponseDTO()
                {
                };
            }
            catch (Exception e)
            {
                return new ResponseDTO()
                {
                };
            }
        }

        [HttpPost]
        [Route("section")]
        public async Task<ResponseDTO> CreateCourseSection()
        {
            try
            {
                return new ResponseDTO()
                {
                };
            }
            catch (Exception e)
            {
                return new ResponseDTO()
                {
                };
            }
        }

        [HttpPut]
        [Route("section")]
        public async Task<ResponseDTO> EditCourseSection()
        {
            try
            {
                return new ResponseDTO()
                {
                };
            }
            catch (Exception e)
            {
                return new ResponseDTO()
                {
                };
            }
        }

        [HttpDelete]
        [Route("section/{sectionId:guid}")]
        public async Task<ResponseDTO> DeleteCourseSection([FromRoute] Guid sectionId)
        {
            try
            {
                return new ResponseDTO()
                {
                };
            }
            catch (Exception e)
            {
                return new ResponseDTO()
                    {
                    }
                    ;
            }
        }

        #endregion
    }
}