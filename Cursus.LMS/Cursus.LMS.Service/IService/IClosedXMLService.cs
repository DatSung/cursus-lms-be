using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface IClosedXMLService
{
    Task<string> ExportInstructorExcel(List<InstructorInfoDTO> instructorInfoDtos);
    Task<string> ExportStudentExcel(List<StudentFullInfoDTO> studentFullInfoDTOs);

}