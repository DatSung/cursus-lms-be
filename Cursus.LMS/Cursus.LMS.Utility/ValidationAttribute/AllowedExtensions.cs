using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Cursus.LMS.Utility.ValidationAttribute;

public class AllowedExtensions : System.ComponentModel.DataAnnotations.ValidationAttribute
{
    private readonly string[] _extensions;

    public AllowedExtensions(string[] extensions)
    {
        _extensions = extensions;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var file = value as IFormFile;

        if (file != null)
        {
            var extension = Path.GetExtension(file.FileName);
            if (!_extensions.Contains(extension.ToLower()))
            {
                return new ValidationResult("This photo extension is not allowed!");
            }
        }

        return ValidationResult.Success;
    }
}