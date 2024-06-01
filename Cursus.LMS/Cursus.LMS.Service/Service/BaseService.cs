using System.Net;
using System.Text;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Cursus.LMS.Service.Service;

public class BaseService : IBaseService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BaseService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<ResponseDTO?> SendAsync(RequestDTO RequestDTO, string? apiKey)
    {
        try
        {
            HttpClient client = _httpClientFactory.CreateClient("CursusLMS");
            HttpRequestMessage message = new();
            message.Headers.Add("Accept", "application/json");

            // Token here
            if (!string.IsNullOrEmpty(apiKey))
            {
                var token = apiKey;
                message.Headers.Add("Authorization", $"Bearer {token}");
            }

            message.RequestUri = new Uri(RequestDTO.Url);

            if (RequestDTO.Data is not null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(RequestDTO.Data), Encoding.UTF8,
                    "application/json");
            }

            HttpResponseMessage? responseMessage = null;

            switch (RequestDTO.ApiType)
            {
                case StaticEnum.ApiType.GET:
                {
                    message.Method = HttpMethod.Get;
                    break;
                }
                case StaticEnum.ApiType.POST:
                {
                    message.Method = HttpMethod.Post;
                    break;
                }
                case StaticEnum.ApiType.PUT:
                {
                    message.Method = HttpMethod.Put;
                    break;
                }
                case StaticEnum.ApiType.DELETE:
                {
                    message.Method = HttpMethod.Delete;
                    break;
                }
            }

            responseMessage = await client.SendAsync(message);

            switch (responseMessage.StatusCode)
            {
                case HttpStatusCode.NotFound:
                {
                    return new()
                    {
                        IsSuccess = false,
                        Message = "Not Found",
                    };
                }
                case HttpStatusCode.Forbidden:
                {
                    return new()
                    {
                        IsSuccess = false,
                        Message = "Forbidden",
                    };
                }
                case HttpStatusCode.Unauthorized:
                {
                    return new()
                    {
                        IsSuccess = false,
                        Message = "Unauthorized",
                    };
                }
                case HttpStatusCode.BadRequest:
                {
                    return new()
                    {
                        IsSuccess = false,
                        Message = "BadRequest",
                    };
                }
                case HttpStatusCode.InternalServerError:
                {
                    return new()
                    {
                        IsSuccess = false,
                        Message = "InternalServerError",
                    };
                }
                default:
                {
                    var apiContent = await responseMessage.Content.ReadAsStringAsync();

                    var apiResponseDTO = JsonConvert.DeserializeObject<ResponseDTO>(apiContent);
                    return apiResponseDTO;
                }
            }
        }
        catch (Exception e)
        {
            return new()
            {
                Message = e.Message.ToString(),
                IsSuccess = false
            };
        }
    }
}