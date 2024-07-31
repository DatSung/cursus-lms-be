using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface IPrivacyService
{
    Task<ResponseDTO> GetPrivacies();
    Task<ResponseDTO> GetPrivacy(Guid id);
    Task<ResponseDTO> CreatePrivacy(CreatePrivacyDTO privacyDto);
    Task<ResponseDTO> UpdatePrivacy(UpdatePrivacyDTO privacyDto);
    Task<ResponseDTO> DeletePrivacy(Guid id);
}