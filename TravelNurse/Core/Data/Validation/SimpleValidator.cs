using System.ComponentModel.DataAnnotations;
using Core.Exceptions;

namespace Core.Data.Validation;

public static class SimpleValidator
{
    public static bool Validate(object targetObject, out List<ValidationResult> validationResults)
    {
        var context = new ValidationContext(targetObject, null, null);
        
        validationResults = new List<ValidationResult>();
        
        var isValid = Validator.TryValidateObject(targetObject, context, validationResults, true);
        
        return isValid;
    }

    public static void AssertObjectIsValid(object targetObject, string? failureMessage = null)
    {
        var isValid = Validate(targetObject, out var validationResults);

        if (!isValid)
        {
            throw new InvalidObjectException(failureMessage ?? "Object is not in a valid state", validationResults);
        }
    }
}