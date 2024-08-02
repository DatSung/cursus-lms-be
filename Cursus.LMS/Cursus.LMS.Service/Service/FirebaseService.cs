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

    /// <summary>
    /// This method for upload image to firebase storage bucket
    /// </summary>
    /// <param name="file"></param>
    /// <param name="folder"></param>
    /// <returns></returns>
    public async Task<ResponseDTO> UploadImage(IFormFile file, string folder)
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

        var filePath = $"{folder}/{fileName}";

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

    /// <summary>
    /// This method for upload video to firebase storage bucket
    /// </summary>
    /// <param name="file"></param>
    /// <param name="folder"></param>
    /// <returns></returns>
    public async Task<ResponseDTO> UploadVideo(IFormFile file, Guid? courseId)
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

        var filePath = $"{"Course"}/{courseId}/{"Videos"}/{fileName}";

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
            Message = "Upload video successfully!"
        };
    }

    /// <summary>
    /// This method for upload video to firebase storage bucket
    /// </summary>
    /// <param name="file"></param>
    /// <param name="folder"></param>
    /// <returns></returns>
    public async Task<ResponseDTO> UploadSlide(IFormFile file, Guid? courseId)
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

        var filePath = $"{"Course"}/{courseId}/{"Slides"}/{fileName}";

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
            Message = "Upload slide successfully!"
        };
    }

    /// <summary>
    /// This method for upload video to firebase storage bucket
    /// </summary>
    /// <param name="file"></param>
    /// <param name="folder"></param>
    /// <returns></returns>
    public async Task<ResponseDTO> UploadDoc(IFormFile file, Guid? courseId)
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

        var filePath = $"{"Course"}/{courseId}/{"Docs"}/{fileName}";

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
            Message = "Upload doc successfully!"
        };
    }

    public async Task<MemoryStream> GetContent(string? filePath)
    {
        try
        {
            MemoryStream memoryStream = new MemoryStream();

            await _storageClient.DownloadObjectAsync(_bucketName, filePath, memoryStream);

            memoryStream.Seek(0, SeekOrigin.Begin);

            return memoryStream;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    /// <summary>
    /// This method for get an image from firebase storage bucket
    /// </summary>
    /// <param name="filePath">The path of the file</param>
    /// <returns></returns>
    public async Task<MemoryStream> GetImage(string filePath)
    {
        try
        {
            MemoryStream memoryStream = new MemoryStream();

            await _storageClient.DownloadObjectAsync(_bucketName, filePath, memoryStream);

            memoryStream.Seek(0, SeekOrigin.Begin);

            return memoryStream;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}