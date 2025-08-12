using Core.Utils;
using TravelNurse.Components.Common.Enums;

namespace TravelNurse.Components.Common.Utils.Dtos;

public class QueryParamDto
{
    public string PropertyName { get; set; } = Constants.DefaultString;

    public string Operator { get; set; } = Constants.DefaultString;

    public QueryParamTypeEnum Type { get; set; }
}