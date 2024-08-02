using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursus.LMS.Model.DTO
{
    public class UpdateStudentCommentDTO
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
    }
}
