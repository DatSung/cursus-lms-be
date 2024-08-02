using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursus.LMS.Model.DTO
{
    public class GetCourseSectionDTO
    {
        public Guid? CourseVersionId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int CurrentStatus { get; set; }
    }
}