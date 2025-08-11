using System.ComponentModel.DataAnnotations;

namespace Core.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class PropertySetRequiredAttribute : ValidationAttribute
{
    private readonly string[] _props;

    public PropertySetRequiredAttribute(params  string[] props)
    {
        _props = props;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var properties = new List<object?>(_props);

        foreach (var prop in _props)
        {
            var property = validationContext.ObjectType.GetProperty(prop);

            if (property != null)
            {
                properties.Add(property.GetValue(value));
            }
            
        }
        
        return properties.TrueForAll(x => x == null) || properties.TrueForAll(x => x != null)
            ? ValidationResult.Success 
            : new ValidationResult($"All of these properties must either be provided or ignored: {string.Join(", ", _props)}");
        
    }
}  