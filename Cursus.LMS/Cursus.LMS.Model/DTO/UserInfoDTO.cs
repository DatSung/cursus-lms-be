using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursus.LMS.Model.DTO
{
    public class UserInfoDTO
    {
        public string Id { get; set; }
        public Guid? StudentId { get; set; }
        public Guid? InstructorId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool isUploadDegree { get; set; }
        public bool? isAccepted { get; set; } = false;
        public IEnumerable<string> Roles { get; set; }
    }
}