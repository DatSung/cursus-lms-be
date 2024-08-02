using Cursus.LMS.Model.DTO;
using Microsoft.AspNetCore.Http;

namespace Cursus.LMS.Service.IService;

public interface IFirebaseService
{
    // Task<ResponseDTO> UploadImage(IFormFile file);
    Task<ResponseDTO> UploadImage(IFormFile file, string folder);
    Task<MemoryStream> GetImage(string filePath);
    Task<ResponseDTO> UploadVideo(IFormFile file, Guid? courseId);
    Task<ResponseDTO> UploadSlide(IFormFile file, Guid? courseId);
    Task<ResponseDTO> UploadDoc(IFormFile file, Guid? courseId);
    Task<MemoryStream> GetContent(string? filePath);
}