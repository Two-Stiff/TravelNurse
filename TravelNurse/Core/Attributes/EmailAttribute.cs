using System.ComponentModel.DataAnnotations;
using Core.Data.Validation;

namespace Core.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public class EmailAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success;
        }

        if (value is string stringValue)
        {
            if (string.IsNullOrEmpty(stringValue))
            {
                return ValidationResult.Success;
            }
            
            var isEmail = RegexValidation.IsValidEmail(stringValue);

            return isEmail
                ? ValidationResult.Success
                : new ValidationResult($"The email {stringValue} is not valid");
        }

        if (value is IEnumerable<string> emails)
        {
            if (!emails.Any())
            {
                return ValidationResult.Success;
            }
            
            var invalidEmail = emails.Where(email => !RegexValidation.IsValidEmail(email)).ToList();

            return invalidEmail.Any()
                ? new ValidationResult($"{string.Join(", ", invalidEmail)} are not valid")
                : ValidationResult.Success;
        }
        
        throw new Exception($"Type {value.GetType().FullName} is not a valid type for email attribute");
        
    }
}