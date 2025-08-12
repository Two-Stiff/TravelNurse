using System.ComponentModel;

namespace TravelNurse.Components.Common.Enums;

public enum QueryParamTypeEnum
{
    [Description("Number")] 
    Number = 0,
    
    [Description("String")] 
    String = 1,
    
    [Description("Boolean")] 
    Boolean = 2,
    
    [Description("DateIsOnBefore")] 
    DateIsOnBefore = 3,
    
    [Description("DateIsOnAfter")] 
    DateIsOnAfter = 4,
    
    [Description("MultiSelect")] 
    MultiSelect = 5,
    
    [Description("Enum")] 
    Enum = 6,
}