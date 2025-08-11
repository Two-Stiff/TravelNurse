using System.ComponentModel.DataAnnotations;

namespace Core.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class OnlyOneAllowedAttribute : ValidationAttribute
{
    private readonly string[] _props;

    public OnlyOneAllowedAttribute(params string[] props)
    {
        _props = props;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var count = 0;

        foreach (var prop in _props)
        {
            var property = validationContext.ObjectType.GetProperty(prop);

            if (property != null)
            {
                var propertyValue = property.GetValue(value);

                if (propertyValue != null)
                {
                    count++;
                }
            }
        }

        return count <= 1
            ? ValidationResult.Success
            : new ValidationResult($"Only one of these properties are allow {string.Join(",", _props)}");
    }
}