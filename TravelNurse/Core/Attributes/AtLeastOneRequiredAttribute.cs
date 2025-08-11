using System.ComponentModel.DataAnnotations;

namespace Core.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class AtLeastOneRequiredAttribute : ValidationAttribute
{
    private string[]? _props;

    public AtLeastOneRequiredAttribute(params string[] props)
    {
        _props  = props;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (_props == null || _props.Length == 0)
        {
            _props = validationContext.ObjectType.GetProperties().Select(x => x.Name).ToArray();
        }
        
        return _props.Select(prop => validationContext.ObjectType.GetProperty(prop))
            .Select(property => property?.GetValue(value))
            .Any(propertyValue => propertyValue != null)
            ? ValidationResult.Success
            : new ValidationResult($"At least one of these properties must be set {string.Join(", ", _props)}");
            ;
    }
}