using System.ComponentModel.DataAnnotations;
using Cursus.LMS.Utility.ValidationAttribute;
using Microsoft.AspNetCore.Http;

namespace Cursus.LMS.Model.DTO;

public class AvatarUploadDTO
{
    [Required]
    [MaxFileSize(1)]
    [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
    public IFormFile File { get; set; }
}