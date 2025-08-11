namespace Core.Attributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
public class PdfConvertibleAttribute : AllowedExtensionAttribute
{
    public PdfConvertibleAttribute() : base(".pdf", ".jpg", ".jpeg", ".png", ".heic", ".webp", ".doc", ".docx") {}
}