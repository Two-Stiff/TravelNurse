using TravelNurseServer.Dtos.TablePaginationParams;
using TravelNurseServer.Helpers;

namespace TravelNurse.Components.MudFilters;

public static class CustomFilterHelper
{
    public static void ProcessMultiSelectFilter(
        HashSet<SelectOption> selectOptions, string propertyName,
        List<DataGridFilterDto> filterOptions
    )
    {
        if (selectOptions.Count != 0)
        {
            var idList = new List<int>();
            var filterObj = new DataGridFilterDto
            {
                PropertyName = propertyName,
                Operator = "contains"
            };

            foreach (var item in selectOptions)
            {
                idList.Add(item.Id);
            }

            filterObj.Value = idList;
            filterOptions.Add(filterObj);
        }
    }
}