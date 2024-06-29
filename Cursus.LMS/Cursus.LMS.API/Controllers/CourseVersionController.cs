using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [Route("create-new-version")]
        public async Task<ActionResult<ResponseDTO>> CreateNewCourseAndVersion
        (
            CreateNewCourseAndVersionDTO createNewCourseAndVersionDto
        )
        {
            var responseDto = await _courseVersionService.CreateNewCourseAndVersion(User, createNewCourseAndVersionDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("clone-new-version")]
        public async Task<ActionResult<ResponseDTO>> CloneNewCourseVersion
        (
            [FromBody] CloneNewCourseVersionDTO cloneNewCourseVersionDto
        )
        {
            var responseDto = await _courseVersionService.CloneNewCourseVersion(User, cloneNewCourseVersionDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpDelete]
        [Route("{courseVersionId:guid}")]
        public async Task<ResponseDTO> RemoveCourseVersion([FromRoute] Guid courseVersionId)
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
        public async Task<ResponseDTO> EditCourseVersion()
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
        [Route("accept-course-version/{courseVersionId:guid}")]
        public async Task<ResponseDTO> AcceptCourseVersion([FromRoute] Guid courseVersionId)
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
        [Route("reject-course-version/{courseVersionId:guid}")]
        public async Task<ResponseDTO> RejectCourseVersion([FromRoute] Guid courseVersionId)
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
        [Route("submit-course-version/{courseVersionId:guid}")]
        public async Task<ResponseDTO> SubmitCourseVersion([FromRoute] Guid courseVersionId)
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

        #endregion


        #region Course Comment

        [HttpGet]
        [Route("comment/")]
        public async Task<ResponseDTO> GetCourseVersionComments
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
        [Route("comment/{commentId:guid}")]
        public async Task<ResponseDTO> GetCourseVersionComment([FromRoute] Guid commentId)
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
        [Route("comment")]
        public async Task<ResponseDTO> CreateCourseVersionComment()
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
        [Route("comment")]
        public async Task<ResponseDTO> EditCourseVersionComment()
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
        [Route("comment/{commentId:guid}")]
        public async Task<ResponseDTO> RemoveCourseVersionComment([FromRoute] Guid commentId)
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