using System.Linq.Expressions;
using System.Reflection;


namespace TravelNurseServer.Helpers;

public static class ExpressionBuilder
{
    public static Expression<Func<T, bool>> BuildPredicate<T>(
        string propertyName,
        string? operationString,
        object? value)
    {
        var parameter = Expression.Parameter(typeof(T), "x");

        if (string.IsNullOrWhiteSpace(operationString))
            return Expression.Lambda<Func<T, bool>>(Expression.Constant(true), parameter);
        
        // isNullableRef check against the entity model to tell whether the property type is....for example: string or string?
        var (property, propertyType, isNullableRef) = BuildMemberAccess(parameter, propertyName);

        
        var isNullable = Nullable.GetUnderlyingType(propertyType) != null;
        var baseType = Nullable.GetUnderlyingType(propertyType) ?? propertyType;

        Expression? body = null;
        
        object? typedValue = value;

        if (baseType.IsEnum && value != null)
        {
            typedValue = Enum.ToObject(baseType, value);
        }

        
        if (value is List<int> intList)
        {
            if (operationString?.ToLowerInvariant() != "contains")
                throw new NotSupportedException("Only 'contains' operator is supported for collections of int.");

            var method = typeof(List<int>).GetMethod("Contains", new[] { typeof(int) });
            var valueExpr = Expression.Constant(intList);

            if (property.Type == typeof(int?))
            {
                // x.DisciplineId.HasValue
                var hasValue = Expression.Property(property, "HasValue");

                // x.DisciplineId.Value
                var valueProperty = Expression.Property(property, "Value");

                // list.Contains(x.DisciplineId.Value)
                var containsCall = Expression.Call(valueExpr, method!, valueProperty);

                // x.DisciplineId.HasValue && list.Contains(x.DisciplineId.Value)
                body = Expression.AndAlso(hasValue, containsCall);
            }
            else if (property.Type == typeof(int))
            {
                // list.Contains(x.DisciplineId)
                body = Expression.Call(valueExpr, method!, property);
            }
            else
            {
                throw new NotSupportedException($"Property type '{property.Type}' is not supported for List<int> Contains().");
            }
        }


        else
        {
            var constant = value != null
                ? Expression.Constant(Convert.ChangeType(value, baseType))
                : Expression.Constant(null, baseType);
            
            // DateTime handling
            if (baseType == typeof(DateTime))
            {
                var nullOrDefaultCheck =
                    Expression.Equal(property, Expression.Constant(default(DateTime), propertyType));

                body = operationString.ToLower() switch
                {
                    "is" => Expression.Equal(property, constant),
                    "is not" => Expression.NotEqual(property, constant),
                    "is after" => Expression.GreaterThan(property, constant),
                    "is on or after" => Expression.GreaterThanOrEqual(property, constant),
                    "is before" => Expression.LessThan(property, constant),
                    "is on or before" => Expression.LessThanOrEqual(property, constant),
                    "is empty" => isNullable
                        ? Expression.Equal(property, Expression.Constant(null, propertyType))
                        : nullOrDefaultCheck,
                    "is not empty" => isNullable
                        ? Expression.NotEqual(property, Expression.Constant(null, propertyType))
                        : Expression.Not(nullOrDefaultCheck),
                    _ => throw new NotSupportedException($"Operator '{operationString}' is not supported for DateTime.")
                };
            }
            else if (baseType.IsEnum)
            {
                // This will account for both Enum and Enum? types
                object? convertedValue = null;
                if (typedValue != null)
                    convertedValue = Enum.ToObject(baseType, typedValue);

                var constantExpr = Expression.Constant(convertedValue, propertyType);
                body = Expression.Equal(property, constantExpr);
            }
            else if (IsNumericType(baseType))
            {
                // default(numeric) == 0, 0M, etc. for non-nullable numbers
                var defaultCheck = Expression.Equal(
                    property, Expression.Constant(Activator.CreateInstance(baseType)!, propertyType));

                var isTypeNullable = isNullable && value == null;
                
                body = operationString switch
                {
                    "=" or "==" or "is" => isTypeNullable ? Expression.Equal(property, Expression.Constant(null, propertyType)) : Expression.Equal(property, constant),
                    "!=" or "is not" => Expression.NotEqual(property, constant),
                    ">" => Expression.GreaterThan(property, constant),
                    ">=" => Expression.GreaterThanOrEqual(property, constant),
                    "<" => Expression.LessThan(property, constant),
                    "<=" => Expression.LessThanOrEqual(property, constant),
                    "is empty" => isNullable
                        ? Expression.Equal(property, Expression.Constant(null, propertyType))
                        : defaultCheck,
                    "is not empty" => isNullable
                        ? Expression.NotEqual(property, Expression.Constant(null, propertyType))
                        : Expression.Not(defaultCheck)
                };
            }
            else if (baseType == typeof(bool))
            {
                body = operationString.ToLower() switch
                {
                    "is" => Expression.Equal(property, constant),
                    _ => throw new NotSupportedException($"Operator '{operationString}' is not supported for string.")
                };
            }
            // String handling
            else if (baseType == typeof(string))
            {
                MethodInfo? StringMethod(string name)
                {
                    return typeof(string).GetMethod(name, new[] { typeof(string) });
                }

                var toLowerMethod = typeof(string).GetMethod(nameof(string.ToLower), Type.EmptyTypes);

                if (value is string str && string.IsNullOrEmpty(str) && isNullableRef)
                {
                    body = Expression.Equal(property, Expression.Constant(null, typeof(string)));
                }
                else
                {
                    // Lowercase property
                    var propertyToLower = Expression.Call(property, toLowerMethod!);

                    // Lowercase constant value
                    var constantToLower = Expression.Constant((value?.ToString() ?? "").ToLower());

                    body = operationString.ToLower() switch
                    {
                        "equals" => Expression.Equal(propertyToLower, constantToLower),
                        "notequals" => Expression.NotEqual(propertyToLower, constantToLower),
                        "contains" => Expression.Call(propertyToLower, StringMethod(nameof(string.Contains))!, constantToLower),
                        "not contains" => Expression.Not(Expression.Call(propertyToLower, StringMethod(nameof(string.Contains))!, constantToLower)),
                        "startswith" => Expression.Call(propertyToLower, StringMethod(nameof(string.StartsWith))!, constantToLower),
                        "endswith" => Expression.Call(propertyToLower, StringMethod(nameof(string.EndsWith))!, constantToLower),
                        "is empty" => Expression.Call(typeof(string), nameof(string.IsNullOrEmpty), null, property),
                        "is not empty" => Expression.Not(Expression.Call(typeof(string), nameof(string.IsNullOrEmpty), null, property)),
                        _ => throw new NotSupportedException($"Operator '{operationString}' is not supported for string.")
                    };
                }
            }
           else
            {
                throw new NotSupportedException($"Type '{baseType.Name}' is not supported.");
            }
        }

        return Expression.Lambda<Func<T, bool>>(body!, parameter);
    }

    public static Expression<Func<T, bool>> AndAll<T>(params Expression<Func<T, bool>>[] predicates)
    {
        if (predicates.Length == 0)
            return x => true;

        var param = Expression.Parameter(typeof(T), "x");
        Expression? body = null;

        foreach (var predicate in predicates)
        {
            var replaced = new ParameterReplacer(param).Visit(predicate.Body);
            body = body == null ? replaced : Expression.AndAlso(body, replaced!);
        }

        return Expression.Lambda<Func<T, bool>>(body!, param);
    }
    
    public static (Expression Expression, Type Type, bool IsNullableReference) BuildMemberAccessV1(Expression root, string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            throw new ArgumentException("Property path must be non-empty.", nameof(path));

        var expr = root;
        var currentType = root.Type;
        var segments = path.Split('.');
        bool isNullableReference = false;

        var nullabilityContext = new NullabilityInfoContext();

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

                // Check nullability for reference types
                if (!currentType.IsValueType && currentType != typeof(string))
                {
                    var nullability = nullabilityContext.Create(propInfo);
                    isNullableReference = nullability.ReadState == NullabilityState.Nullable;
                }

                // Special case for string — use Roslyn nullability
                if (currentType == typeof(string))
                {
                    var nullability = nullabilityContext.Create(propInfo);
                    isNullableReference = nullability.ReadState == NullabilityState.Nullable;
                }

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

                return (expr, currentType, false);
            }

            throw new InvalidOperationException($"'{segment}' is not a property or field of '{currentType.Name}'.");
        }

        return (expr, currentType, isNullableReference);
    }

    
    public static (Expression Expression, Type Type, bool IsNullableReference) BuildMemberAccess(Expression root, string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            throw new ArgumentException("Property path must be non-empty.", nameof(path));

        // Special case for FullName
        if (string.Equals(path, "FullName", StringComparison.OrdinalIgnoreCase))
        {
            var firstName = Expression.Property(root, "FirstName");
            var lastName = Expression.Property(root, "LastName");
            var space = Expression.Constant(" ");

            // Use string.Concat with three parameters
            var concat = Expression.Call(
                typeof(string).GetMethod("Concat", new[] { typeof(string), typeof(string), typeof(string) })!,
                firstName, space, lastName
            );

            // Since FullName is computed from strings, we mark it as nullable
            return (concat, typeof(string), true);
        }

        var expr = root;
        var currentType = root.Type;
        var segments = path.Split('.');
        bool isNullableReference = false;

        var nullabilityContext = new NullabilityInfoContext();

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

                // Check nullability
                if (!currentType.IsValueType || currentType == typeof(string))
                {
                    var nullability = nullabilityContext.Create(propInfo);
                    isNullableReference = nullability.ReadState == NullabilityState.Nullable;
                }

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

                return (expr, currentType, false);
            }

            throw new InvalidOperationException($"'{segment}' is not a property or field of '{currentType.Name}'.");
        }

        return (expr, currentType, isNullableReference);
    }

    
    public static bool IsNumericType(Type t)
    {
        t = Nullable.GetUnderlyingType(t) ?? t; // unwrap Nullable<T>

        return t == typeof(byte) || t == typeof(sbyte) ||
               t == typeof(short) || t == typeof(ushort) ||
               t == typeof(int) || t == typeof(uint) ||
               t == typeof(long) || t == typeof(ulong) ||
               t == typeof(float) || t == typeof(double) ||
               t == typeof(decimal);
    }
}

internal class ParameterReplacer : ExpressionVisitor
{
    private readonly ParameterExpression _parameter;

    public ParameterReplacer(ParameterExpression parameter)
    {
        _parameter = parameter;
    }

    protected override Expression VisitParameter(ParameterExpression node)
    {
        return _parameter;
    }
}