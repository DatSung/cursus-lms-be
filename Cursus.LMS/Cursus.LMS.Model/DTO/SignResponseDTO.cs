using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cursus.LMS.Model.DTO
{
    public class SignResponseDTO
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
        // public UserInfoDTO UserInfoDTO { get; set; }
        // public string Message { get; set; }
    }
}