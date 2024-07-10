using System.ComponentModel.DataAnnotations;
using Cursus.LMS.Utility.ValidationAttribute;
using Microsoft.AspNetCore.Http;

namespace Cursus.LMS.Model.DTO;

public class UploadCourseVersionBackgroundImg
{
    [Required]
    [MaxFileSize(5)]
    [AllowedExtensions(new string[] { ".img", ".png", ".jpg" })]
    public IFormFile File { get; set; }
}