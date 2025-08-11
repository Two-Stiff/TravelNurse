using System.ComponentModel.DataAnnotations;

namespace Core.Exceptions;

public class InvalidObjectException : Exception
{
    public List<ValidationResult> ValidationResults { get; }
    
    public InvalidObjectException(
        string reason, List<ValidationResult> validationResults
        ): base(GenerateErrorMessage(reason, validationResults))
    {
        ValidationResults = validationResults;
    }


    private static string GenerateErrorMessage(string reason, List<ValidationResult> validationResults)
    {
        var errorMsg = validationResults.Select(x => x.ErrorMessage).OfType<string>();

        return $"{reason} \n The following exceptions occured: \n {string.Join(", \n", errorMsg)}";
    }
}