using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Core.Attributes;

public class MaxFileSizeAttribute : ValidationAttribute
{
    private readonly int _maxFileSize;
    
    public MaxFileSizeAttribute(int maxFileSize)
    {
        _maxFileSize  = maxFileSize;
    }

    public override bool IsValid(object? value)
    {
        if (value == null)
        {
            return true;
        }

        var file = value as IFormFile;

        if (file == null)
        {
            return false;
        }
        
        return file.Length <= _maxFileSize;
    }

    public override string FormatErrorMessage(string name)
    {
        return base.FormatErrorMessage(_maxFileSize.ToString());
    }
}