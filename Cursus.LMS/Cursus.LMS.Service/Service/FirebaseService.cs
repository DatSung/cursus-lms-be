using System.Net;
using System.Security.Claims;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;

namespace Cursus.LMS.Service.Service;

public class FirebaseService : IFirebaseService
{
    private readonly StorageClient _storageClient;
    private readonly string _bucketName = "cursus-lms-storage.appspot.com";


    public FirebaseService(StorageClient storageClient)
    {
        _storageClient = storageClient;
    }

    // public async Task<ResponseDTO> UploadImage(IFormFile file)
    // {
    //     if (file is null || file.Length == 0)
    //     {
    //         return new ResponseDTO()
    //         {
    //             IsSuccess = false,
    //             StatusCode = 400,
    //             Message = "File is empty!"
    //         };
    //     }
    //
    //     var fileName = $"{Guid.NewGuid()}_{file.FileName}";
    //     var filePath = Path.Combine(Path.GetTempPath(), fileName);
    //
    //     using (var stream = new FileStream(filePath, FileMode.Create))
    //     {
    //         await file.CopyToAsync(stream);
    //     }
    //
    //     using (var fileStream = new FileStream(filePath, FileMode.Open))
    //     {
    //         await _storageClient.UploadObjectAsync(_bucketName, fileName, null, fileStream);
    //     }
    //
    //     System.IO.File.Delete(filePath);
    //
    //     var url = $"https://storage.googleapis.com/{_bucketName}/{fileName}";
    //
    //     return new ResponseDTO()
    //     {
    //         IsSuccess = true,
    //         StatusCode = 200,
    //         Result = url,
    //         Message = "Upload image successfully!"
    //     };
    // }

    public async Task<ResponseDTO> UploadUserAvatar(IFormFile file)
    {
        if (file is null || file.Length == 0)
        {
            return new ResponseDTO()
            {
                IsSuccess = false,
                StatusCode = 400,
                Message = "File is empty!"
            };
        }

        var fileName = $"{Guid.NewGuid()}_{file.FileName}";

        var filePath = $"UserAvatars/{fileName}";

        string url;

        await using (var stream = file.OpenReadStream())
        {
            var result = await _storageClient.UploadObjectAsync(_bucketName, filePath, null, stream);
        }

        return new ResponseDTO()
        {
            IsSuccess = true,
            StatusCode = 200,
            Result = filePath,
            Message = "Upload image successfully!"
        };
    }

    public async Task<MemoryStream> GetImage(string filePath)
    {
        MemoryStream memoryStream = new MemoryStream();

        await _storageClient.DownloadObjectAsync(_bucketName, filePath, memoryStream);

        memoryStream.Seek(0, SeekOrigin.Begin);

        return memoryStream;
    }
}