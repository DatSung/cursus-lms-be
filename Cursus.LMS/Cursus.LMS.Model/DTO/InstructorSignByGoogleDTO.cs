using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursus.LMS.Model.DTO
{
    public class InstructorSignByGoogleDTO
    {
        public string GoogleToken { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string? PhoneNumber { get; set; }

        [Required] public string? Gender { get; set; }


        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }

        [Required] public string? Country { get; set; }
        [Required] public string? Address { get; set; }
        [Required] public string TaxNumber { get; set; }

        [Required] public string CardNumber { get; set; }
    }
}
