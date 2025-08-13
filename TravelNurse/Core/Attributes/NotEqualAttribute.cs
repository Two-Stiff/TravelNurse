using System.ComponentModel.DataAnnotations;

namespace Core.Attributes;

public class NotEqualAttribute : ValidationAttribute
{
    private readonly object _disallowed;

    // ───────────────────────────────────────────────────────────────
    // 1) Ctor that takes VALUE only  → keeps old behaviour
    // 2) Ctor that takes VALUE + CUSTOM MESSAGE
    // ───────────────────────────────────────────────────────────────

    public NotEqualAttribute(object disallowed)
    {
        _disallowed = disallowed;
        ErrorMessage = $"Value must not be equal to {_disallowed}.";
    }

    public NotEqualAttribute(object disallowed, string errorMessage)
        : this(disallowed) // chain to set _disallowed, default msg
    {
        if (!string.IsNullOrWhiteSpace(errorMessage))
            ErrorMessage = errorMessage; // override with caller‑supplied text
    }

    /// <summary>
    ///     Only used when either side is float/double.
    ///     Default is 1 × 10⁻⁹.
    /// </summary>
    public double Tolerance { get; init; } = 1e-9;

    // ───────────────────────────────────────────────────────────────
    // Core validation logic (unchanged from previous answer)
    // ───────────────────────────────────────────────────────────────
    public override bool IsValid(object? value)
    {
        if (value is null) return true; // let [Required] handle it

        if (IsNumeric(value) && IsNumeric(_disallowed))
        {
            // Floating‑point → tolerance compare
            if (value is float or double || _disallowed is float or double)
            {
                var v1 = Convert.ToDouble(value);
                var v2 = Convert.ToDouble(_disallowed);
                return Math.Abs(v1 - v2) > Tolerance; // valid ⇔ not “equal”
            }

            // Integral / decimal → exact compare
            var d1 = Convert.ToDecimal(value);
            var d2 = Convert.ToDecimal(_disallowed);
            return d1 != d2;
        }

        // Non‑numeric → fallback
        try
        {
            var converted = Convert.ChangeType(_disallowed, value.GetType());
            return !Equals(value, converted);
        }
        catch
        {
            return true; // different types → considered unequal
        }
    }

    private static bool IsNumeric(object obj)
    {
        return obj switch
        {
            byte or sbyte or short or ushort or int or uint or long or ulong
                or float or double or decimal => true,
            _ => false
        };
    }
}