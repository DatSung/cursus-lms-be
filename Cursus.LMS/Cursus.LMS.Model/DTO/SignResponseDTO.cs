using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursus.LMS.Model.DTO
{
    public class SignResponseDTO
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}