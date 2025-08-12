namespace TravelNurseServer.Dtos.DataGridDtos;

public class DataGridListItemDto<T>
{
    public List<T> Items { get; set; } = new List<T>();
    public int ItemTotalCount { get; set; } = 0; // The total count of items before paging
}