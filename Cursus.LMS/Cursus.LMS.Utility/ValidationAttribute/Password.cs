using System.Text.RegularExpressions;

namespace Cursus.LMS.Utility.ValidationAttribute;

public class Password : System.ComponentModel.DataAnnotations.ValidationAttribute
{
    public Password()
    {
        ErrorMessage =
            "Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character.";
    }

    public override bool IsValid(object value)
    {
        if (value is string password)
        {
            return Regex.IsMatch(password, "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&#])[A-Za-z\\d@$!%*?&#]{8,}$");
        }
        return false;
    }
}