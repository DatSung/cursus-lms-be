using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Service.Service;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Threading.Tasks;

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


        #region Course Comment

        [HttpGet]
        [Route("comment/")]
        public async Task<ActionResult<ResponseDTO>> GetCourseVersionsComments
        (
            [FromQuery][Required] Guid courseVersionId,
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
            var responseDto = await _courseVersionService.CreateCourseVersionComment(User, createCourseVersionCommentsDTO);
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
        public async Task<ActionResult<ResponseDTO>> RemoveCourseVersionComment(RemoveCourseVersionCommentDTO removeCourseVersionCommentDTO)
        {
            var responseDto = await _courseVersionService.RemoveCourseVersionComment(User, removeCourseVersionCommentDTO);
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