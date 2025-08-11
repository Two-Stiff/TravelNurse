namespace Core.Attributes;

/// <summary>
/// This attribute is used to enable hard delete for an entity instead of soft delete
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class EnableHardDeleteAttribute : Attribute{}