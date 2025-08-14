namespace TravelNurse.Components.Common.Utils.Dtos;

public class TabComponentDto
{
    public string Name { get; set; } = string.Empty;
    
    public Type Component { get; set; } = default!;
    
    public Dictionary<string, object>? Parameters { get; set; }
}