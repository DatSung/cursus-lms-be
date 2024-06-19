using System.Text.Json.Serialization;

namespace Cursus.LMS.Model.DTO;

public class ResponseDTO
{
    [JsonPropertyName("result")]
    public object? Result { get; set; }

    [JsonPropertyName("isSuccess")]
    public bool IsSuccess { get; set; } = true;

    [JsonPropertyName("statusCode")]
    public int StatusCode { get; set; } = 200;

    [JsonPropertyName("message")]
    public string Message { get; set; }
}