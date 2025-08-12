using Core.Utils;

namespace TravelNurseServer.Dtos.TablePaginationParams;

public class DataGridFilterDto
{
    public string PropertyName { get; set; } = Constants.DefaultString;
    
    public string Operator { get; set; } = Constants.DefaultString;

    public object? Value { get; set; }
}