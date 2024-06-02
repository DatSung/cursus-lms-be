using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Cursus.LMS.Utility.ValidationAttribute;

public class MaxFileSize : System.ComponentModel.DataAnnotations.ValidationAttribute
{
    private readonly int _maxFileSize;
    public MaxFileSize(int maxFileSize)
    {
        _maxFileSize = maxFileSize;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var file = value as IFormFile;

        if (file != null)
        {

            if (file.Length > (_maxFileSize * 2048 * 2048))
            {
                return new ValidationResult($"Maximum allowed file size is {_maxFileSize} MB.");
            }
        }

        return ValidationResult.Success;
    }
}