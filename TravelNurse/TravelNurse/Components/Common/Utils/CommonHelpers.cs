using System.Text.RegularExpressions;

namespace TravelNurse.Components.Common.Utils;

public static class CommonHelpers
{
    public static string SplitCamelCase(object? input)
    {
        if (input == null) return string.Empty;

        var inputString = input is Enum ? input.ToString() : input?.ToString();

        if (string.IsNullOrWhiteSpace(inputString))
            return string.Empty;

        // Handle camel case, PascalCase, and acronyms like "HTTPResponseCode"
        var result = Regex.Replace(inputString, @"(?<=[a-z])(?=[A-Z])", " ");
        result = Regex.Replace(result, @"(?<=[A-Z])(?=[A-Z][a-z])", " ");

        return result.Trim();
    }

}