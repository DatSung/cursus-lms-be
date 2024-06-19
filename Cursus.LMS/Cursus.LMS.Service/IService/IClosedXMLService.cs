using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface IClosedXMLService
{
    Task ExportInstructorExcel(List<InstructorInfoDTO> instructorInfoDtos);
}