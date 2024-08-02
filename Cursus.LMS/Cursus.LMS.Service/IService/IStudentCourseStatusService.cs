using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface IStudentCourseStatusService
{
    Task<ResponseDTO> GetStudentCoursesStatus(Guid studentCourseId);
    Task<ResponseDTO> GetStudentCourseStatus(Guid studentCourseStatusId);
    Task<ResponseDTO> CreateStudentCourseStatus(CreateStudentCourseStatusDTO createStudentCourseStatusDto);
}