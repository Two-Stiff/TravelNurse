using System.Linq.Expressions;
using System.Reflection;
using TravelNurseServer.Helpers;

namespace TravelNurse.Components.Common.Utils;

public static class SelectOptionHelper
{
    public static List<SelectOption> ConvertToSelectOptionsByNameProperty<T>(
        string propertyName, string propertyId, List<T>? apiResult, bool? addDefaultOption)
    {
        var options = new List<SelectOption>();

        if (addDefaultOption == true)
        {
            options.Add(new SelectOption()
            {
                Id = -1,
                Name = "Please select an option",
                Selected = false,
                Disabled = true
            });
        }

        if (apiResult == null || !apiResult.Any())
            return options;

        var parameter = Expression.Parameter(typeof(T), "x");

        // Build expressions
        var (nameExpr, nameType) = BuildExpression(parameter, propertyName);
        var (idExpr, idType) = BuildExpression(parameter, propertyId);

        // Compile lambdas
        var nameLambda = Expression.Lambda(nameExpr, parameter).Compile();
        var idLambda = Expression.Lambda(idExpr, parameter).Compile();

        // Generate SelectOption list
        var selectOptions = apiResult.Select(item =>
        {
            var idVal = idLambda.DynamicInvoke(item);
            var nameVal = nameLambda.DynamicInvoke(item);

            return new SelectOption
            {
                Id = Convert.ToInt32(idVal), // assumes id is int or convertible
                Name = nameVal?.ToString() ?? string.Empty,
                Selected = false
            };
        }).ToList();


        return options.Concat(selectOptions).ToList();
    }

    public static List<SelectOption> ConvertEnumToSelectOptions<T>()
        where T : Enum
    {
        var data = Enum.GetValues(typeof(T)).Cast<T>()
            .Select(e => new SelectOption
            {
                Id = Convert.ToInt32(e),
                Name = e.ToString() ?? string.Empty,
                Selected = false
            })
            .ToList();

        data.Add(new SelectOption
        {
            Id = -1,
            Name = "Please select an option",
            Selected = false,
            Disabled = true
        });
        return data;
    }

    public static int StripCharsIfContainsDigits(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return -1;

        if (input.Any(char.IsDigit))
        {
            return int.Parse(input.Where(char.IsDigit).ToArray());
        }

        return -1;
    }

    public static (Expression Expression, Type Type) BuildExpression(Expression root, string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            throw new ArgumentException("Property path must be non-empty.", nameof(path));

        var expr = root;
        var currentType = root.Type;
        var segments = path.Split('.');

        for (var i = 0; i < segments.Length; i++)
        {
            var segment = segments[i];
            currentType = Nullable.GetUnderlyingType(currentType) ?? currentType;

            var propInfo = currentType.GetProperty(segment,
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);

            if (propInfo != null)
            {
                expr = Expression.Property(expr, propInfo);
                currentType = propInfo.PropertyType;
                continue;
            }

            var fieldInfo = currentType.GetField(segment,
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);

            if (fieldInfo != null)
            {
                expr = Expression.Field(expr, fieldInfo);
                currentType = fieldInfo.FieldType;
                continue;
            }

            if (currentType.IsEnum)
            {
                if (!Enum.IsDefined(currentType, segment))
                    throw new InvalidOperationException(
                        $"'{segment}' is not a valid enum value for '{currentType.Name}'.");

                var enumVal = Enum.Parse(currentType, segment, true);
                expr = Expression.Constant(enumVal, currentType);

                if (i < segments.Length - 1)
                    throw new InvalidOperationException($"Cannot access beyond enum value '{segment}'.");

                return (expr, currentType);
            }

            throw new InvalidOperationException($"'{segment}' is not a property or field of '{currentType.Name}'.");
        }

        return (expr, currentType);
    }

    public static List<SelectOption> AddNullDefaultOption(List<SelectOption> list)
    {
        list.Add(new SelectOption()
        {
            Id = -1,
            Name = "Please select an option",
            Selected = false,
            Disabled = true
        });

        return list;
    }
}