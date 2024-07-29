using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursus.LMS.Model.DTO
{
    public class StudentFullInfoDTO
    {
        public Guid? StudentId { get; set; }
        public string UserId { get; set; }
        public string? FullName { get; set; }
        public string? University { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
    }
}
