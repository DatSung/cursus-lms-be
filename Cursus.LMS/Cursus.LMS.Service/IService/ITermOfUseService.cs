using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface ITermOfUseService
{
    Task<ResponseDTO> GetTermOfUses();
    Task<ResponseDTO> GetTermOfUse(Guid id);
    Task<ResponseDTO> CreateTermOfUse(CreateTermOfUseDTO termOfUseDto);
    Task<ResponseDTO> UpdateTermOfUse(UpdateTermOfUseDTO termOfUseDto);
    Task<ResponseDTO> DeleteTermOfUse(Guid id);
}