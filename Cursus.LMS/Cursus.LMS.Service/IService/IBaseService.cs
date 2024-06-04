using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface IBaseService
{
    Task<ResponseDTO?> SendAsync(RequestDTO requestDto, string? apiKey);
}