using MudBlazor;

namespace TravelNurseServer.Dtos.TablePaginationParams;

public class GridDataRequestDto<T>
{
    public int Page { get; set; } = 0;
    public int PageSize { get; set; } = 10; 
    
    public ICollection<IFilterDefinition<T>> Filter { get; set; }
}