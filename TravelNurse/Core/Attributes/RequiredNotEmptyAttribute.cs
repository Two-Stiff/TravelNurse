using System.ComponentModel.DataAnnotations;

namespace Core.Attributes;

public class RequiredNotEmptyAttribute : RequiredAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is string targetString)
        {
            return !string.IsNullOrEmpty(targetString);
        }

        return base.IsValid(value);
    }
}