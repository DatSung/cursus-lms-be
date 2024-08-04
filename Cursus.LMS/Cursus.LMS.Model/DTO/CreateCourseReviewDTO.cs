using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cursus.LMS.Model.DTO
{
    public class CreateCourseReviewDTO
    {
        [Required]
        public Guid CourseId { get; set; }

        [JsonIgnore]
        public Guid StudentId { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rate must be between 1 and 5")]
        public float Rate { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Message cannot exceed 500 characters")]
        public string Message { get; set; }

    }
}
