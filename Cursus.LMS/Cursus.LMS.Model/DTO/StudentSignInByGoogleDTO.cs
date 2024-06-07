using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Cursus.LMS.Model.DTO
{
    public class StudentSignInByGoogleDTO
    {
        public string GoogleToken { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Provided phone number is not valid.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Provided phone number not valid.")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Birth date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "CardNumber number is required.")]
        public string CardNumber { get; set; }

    }
}
