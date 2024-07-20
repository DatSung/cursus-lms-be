using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursus.LMS.Model.DTO
{
    public class InstructorPayoutDTO
    {
        public Guid InstructorId { get; set; }
        public string FullName { get; set; }
        public double PayoutBalance { get; set; }
    }
}
