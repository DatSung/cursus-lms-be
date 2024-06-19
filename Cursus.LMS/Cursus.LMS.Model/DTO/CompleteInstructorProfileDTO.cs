﻿using System.ComponentModel.DataAnnotations;

namespace Cursus.LMS.Model.DTO;

public class CompleteInstructorProfileDTO
{
    [Required]
    [DataType(DataType.PhoneNumber)]
    [Phone]
    public string PhoneNumber { get; set; }

    [Required] public string Gender { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime BirthDate { get; set; }

    [Required] public string Country { get; set; }
    [Required] public string Address { get; set; }
    [Required] public string TaxNumber { get; set; }
    [Required] public string CardNumber { get; set; }
    [Required] public string CardProvider { get; set; }
    [Required] public string CardName { get; set; }
    [Required] public string Industry { get; set; }
    [Required] public string Introduction { get; set; }
    [Required] public string Degree { get; set; }
}