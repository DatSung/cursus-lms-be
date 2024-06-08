using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursus.LMS.Model.DTO
{
    public class InstructorSignInByGoogleDTO
    {
        [Required]
        public string GoogleToken { get; set; }
       
    }
}
