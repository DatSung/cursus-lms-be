using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Service.Service;
using Cursus.LMS.Utility.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cursus.LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsService _studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        [HttpGet]
        [Authorize(Roles = StaticUserRoles.Admin)]
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
                await _studentsService.GetAllStudent(User, filterOn, filterQuery, sortBy, isAscending, pageNumber, pageSize);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("{studentId:guid}")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> GetStudentById([FromRoute] Guid studentId)
        {
            var responseDto = await _studentsService.GetById(studentId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }
        [HttpPut]
        [Authorize(Roles = StaticUserRoles.Admin)]
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
        [Route("total-courses/{studentId:guid}")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> GetTotalCoursesStudentById([FromRoute] Guid studentId)
        {
            var responseDto = await _studentsService.GetStudentTotalCourses(studentId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }
    }
}
