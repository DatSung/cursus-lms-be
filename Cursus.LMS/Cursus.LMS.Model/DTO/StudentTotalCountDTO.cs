using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursus.LMS.Model.DTO
{
    public class StudentTotalCountDTO
    {
        public int Total { get; set; }
        public int Pending { get; set; } = 0;
        public int Enrolled { get; set; } = 0;
        public int Completed { get; set; } = 0;
        public int Canceled { get; set; } = 0;
    }
}
