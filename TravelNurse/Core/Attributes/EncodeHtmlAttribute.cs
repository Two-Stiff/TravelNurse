using System.Text.Json.Serialization;
using Core.Utils;

namespace Core.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public class EncodeHtmlAttribute() : JsonConverterAttribute(typeof(HtmlEncodeConverter));