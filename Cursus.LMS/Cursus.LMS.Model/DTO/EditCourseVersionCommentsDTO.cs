using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursus.LMS.Model.DTO
{
    public class EditCourseVersionCommentsDTO
    {
        public string Comment {  get; set; }
        public Guid Id { get; set; }
    }
}
