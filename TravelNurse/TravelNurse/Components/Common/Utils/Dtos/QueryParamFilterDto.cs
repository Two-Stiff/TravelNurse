using Core.Utils;

namespace TravelNurse.Components.Common.Utils.Dtos;

public class QueryParamFilterDto
{
    public string PropertyName { get; set; } = Constants.DefaultString;
    
    public List<string> MatchingFilterNames { get; set; } = new List<string>();
}