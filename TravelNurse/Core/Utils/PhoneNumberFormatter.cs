using System.Text;

namespace Core.Utils;

public static class PhoneNumberFormatter
{
    public static string Trim(string phoneNumber)
    {
        if (string.IsNullOrEmpty(phoneNumber))
        {
            return string.Empty;
        }
        
        var phoneNumberArr =  phoneNumber.ToCharArray();
        var phoneNumberStringBuilder = new StringBuilder();

        foreach (var character in phoneNumberArr)
        {
            if (char.IsDigit(character))
            {
                phoneNumberStringBuilder.Append(character);
            }
        }
        
        return phoneNumberStringBuilder.ToString();
    }
    
    public static string Format(string phoneNumber)
    {
        if (string.IsNullOrEmpty(phoneNumber) || phoneNumber.Length != 10)
        {
            return phoneNumber;
        }
        
        var phoneNumberArr = phoneNumber.ToCharArray();

        if (phoneNumberArr.Any(x => !char.IsDigit(x)))
        {
            return phoneNumber;
        }

        return $"({phoneNumber.Substring(0,3)}) {phoneNumber.Substring(3, 3)}-{phoneNumber.Substring(6,4)}";
    }
}