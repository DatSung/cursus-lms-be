using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.Model.DTO
{
    public class GetCourseReviewDTO : BaseEntity<string, string, int>
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
        public int Rate { get; set; }
        public string Message { get; set; }
        public bool IsMarked { get; set; }
        public int Status { get; set; }
    }
}
