using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface ICompanyService
{
    Task<ResponseDTO> GetCompany();
    Task<ResponseDTO> UpdateCompany(UpdateCompanyDTO companyDto);
}