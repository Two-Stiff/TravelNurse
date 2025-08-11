using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Core.Attributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
public class AllowedExtensionAttribute : ValidationAttribute
{
    private readonly string[]  _allowedExtensions;
    
    public AllowedExtensionAttribute(params string[] allowedExtensions)
    {
        _allowedExtensions =  allowedExtensions
            .Select(x => x.ToLower()).ToArray();    
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success;
        }

        var fileName = value.ToString();

        if (value is IFormFile file)
        {
            fileName = file.FileName;
        }
        var extension = Path.GetExtension(fileName);
        
        return _allowedExtensions.Contains(extension.ToLower())
            ? ValidationResult.Success
            : new ValidationResult("File is not a valid extension.");
    }
}