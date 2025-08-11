using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Core.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public class ListRangeAttribute : ValidationAttribute
{
    private readonly int _maximum;
    private readonly int _minimum;
    private readonly string _propertyName;

    public ListRangeAttribute(int minimum, int maximum, string propertyName)
    {
        _minimum = minimum;
        _maximum = maximum;
        _propertyName = propertyName;
    }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        var list = value as IList;

        if (list == null)
        {
            return ValidationResult.Success;
        }

        if (list.Count < _minimum)
        {
            return new  ValidationResult($"{_propertyName} must contain at least {_minimum} item");
        }
        
        if (list.Count > _maximum)
        {
            return new  ValidationResult($"{_propertyName} must contain a maximum of {_minimum} items");
        }
        
        return ValidationResult.Success;
    }
}