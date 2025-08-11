using System.ComponentModel.DataAnnotations;
using Core.Data.Validation;

namespace Core.Attributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
public class PhoneNumberAttribute: ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null || string.IsNullOrEmpty(value.ToString()))
        {
            return ValidationResult.Success;
        }

        var isPhoneNumber = RegexValidation.IsValidPhoneNumber(value.ToString()!);
        
        return isPhoneNumber ? ValidationResult.Success : new ValidationResult($"The phone number {value} is not valid.");
    }
}