using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursus.LMS.Model.DTO
{
    public class CreateCourseReportDTO
    {
        [Required]
        public Guid CourseId { get; set; }

        [Required]
        public Guid StudentId { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Message cannot exceed 500 characters")]
        public string Message { get; set; }
    }
}
