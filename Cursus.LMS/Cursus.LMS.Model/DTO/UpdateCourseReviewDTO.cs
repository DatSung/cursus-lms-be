using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursus.LMS.Model.DTO
{
    public class UpdateCourseReviewDTO
    {
        public Guid Id { get; set; }
        public int Rate { get; set; }
        public string Message { get; set; }
    }
}
