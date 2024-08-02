using System.ComponentModel.DataAnnotations;
using Cursus.LMS.Utility.ValidationAttribute;
using Microsoft.AspNetCore.Http;

namespace Cursus.LMS.Model.DTO;

public class UploadSectionDetailsVersionContentDTO
{
    [Required]
    [MaxFileSize(100)]
    [AllowedExtensions(new string[] { ".docx", ".pdf", ".mp4", ".mov" })]
    public IFormFile File { get; set; }
}