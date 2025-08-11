namespace Core.Attributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class PatchIgnoreAttribute : Attribute{};
