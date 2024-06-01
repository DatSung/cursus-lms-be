using Cursus.LMS.Model.DTO;
using Microsoft.AspNetCore.Http;

namespace Cursus.LMS.Service.IService;

public interface IFirebaseService
{
    // Task<ResponseDTO> UploadImage(IFormFile file);
    Task<ResponseDTO> UploadUserAvatar(IFormFile file);
    Task<MemoryStream> GetImage(string filePath);
    
}