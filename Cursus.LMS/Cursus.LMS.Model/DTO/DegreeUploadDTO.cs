using System.ComponentModel.DataAnnotations;
using Cursus.LMS.Utility.ValidationAttribute;
using Microsoft.AspNetCore.Http;

namespace Cursus.LMS.Model.DTO;

public class DegreeUploadDTO
{
    [Required]
    [MaxFileSize(5)]
    [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".pdf" })]
    public IFormFile File { get; set; }
}