using System.Text.RegularExpressions;

namespace Core.Data.Validation;

public static class RegexValidation
{
    // private const string PhoneRegex = @"^(?([0-9]{3}))?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
    private const string EmailRegex = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+.[A-Za-z]{2,4}$";

    private const string PhoneRegex = @"^\+?\d{1,3}?[-.\s]?(\(?\d{1,4}\)?)[-.\s]?\d{1,4}[-.\s]?\d{1,9}$";
    
    public static bool IsValidPhoneNumber(string phoneNumber)
    {
        return Regex.IsMatch(phoneNumber, PhoneRegex);
    }
    
    public static bool IsValidEmail(string email)
    {
        return Regex.IsMatch(email, EmailRegex);
    }
}