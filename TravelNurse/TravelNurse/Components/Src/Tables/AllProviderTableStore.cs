using MudBlazor;
using TravelNurse.Components.Common.Enums;
using TravelNurse.Components.Common.Utils.Dtos;
using TravelNurse.Components.Common.Utils.StaticType;
using TravelNurseServer.Dtos.Providers.Get;
using TravelNurseServer.Dtos.TablePaginationParams;
using TravelNurseServer.Helpers;

// using TravelNurseServer.Dtos.

namespace TravelNurse.Components.Src.Tables;


public static class AllProviderTableFilter
{
    public const string FirstName = "FirstName";
    public const string LastName = "LastName";
    public const string IsPrimaryPhoneNumberInService = "IsPrimaryPhoneNumberInService";
    public const string DateOfBirth = "DateOfBirth";
    public const string DateOfBirthBefore = "DateOfBirthBefore";
    public const string DateOfBirthAfter = "DateOfBirthAfter";
}

public class AllProviderTableStore
{
    public MudDataGrid<GetProviderDto> DataGrid = new();
    
    public readonly GridDataRequestDto<GetProviderDto> RequestDto = new();
    public List<DataGridFilterDto> FilterOptions { get; set; } = new();
    
    public readonly FilterDefinition<GetProviderDto> FilterDefinition = new();

    
    // Discipline Filter States
    public bool DisciplineFilterOpen { get; set; }
    public List<SelectOption> Disciplines { get; set; } = new();
    public void OpenDisciplineFilter() => DisciplineFilterOpen = !DisciplineFilterOpen;
    public HashSet<SelectOption> SelectedDisciplineFilterItems { get; set; } = new();
    
    public bool FirstNameFilterOpen { get; set; }
    public bool LastNameOpen { get; set; }
    
    public bool IsPrimaryPhoneNumberInServiceFilterOpen { get; set; }
    
    public bool DateOfBirthFilterOpen { get; set; }
    
    // Query Param
    public readonly List<QueryParamFilterDto> QueryParamFilters =
    [
        new()
        {
            PropertyName = AllProviderTableFilter.FirstName,
            MatchingFilterNames = [AllProviderTableFilter.FirstName]
        },

        new()
        {
            PropertyName = AllProviderTableFilter.LastName,
            MatchingFilterNames = [AllProviderTableFilter.LastName]
        },

        new()
        {
            PropertyName = AllProviderTableFilter.IsPrimaryPhoneNumberInService,
            MatchingFilterNames = [AllProviderTableFilter.IsPrimaryPhoneNumberInService]
        },

        new()
        {
            // This setup is crucial for table filters that has multiple filter names associated to it...
            // For example: before date and after date filter
            PropertyName = AllProviderTableFilter.DateOfBirth,
            MatchingFilterNames = [AllProviderTableFilter.DateOfBirthBefore, AllProviderTableFilter.DateOfBirthAfter]
        }

    ];
    
    public readonly List<QueryParamDto> QueryParamFilterList =
    [
        new()
        {
            PropertyName = AllProviderTableFilter.FirstName,
            Operator = FilterOperatorType.StringContains,
            Type = QueryParamTypeEnum.String
        },

        new()
        {
            PropertyName = AllProviderTableFilter.LastName,
            Operator = FilterOperatorType.StringContains,
            Type = QueryParamTypeEnum.String
        },

        new()
        {
            PropertyName = AllProviderTableFilter.IsPrimaryPhoneNumberInService,
            Operator = FilterOperatorType.BooleanEqual,
            Type = QueryParamTypeEnum.Boolean
        },

        new()
        {
            PropertyName = AllProviderTableFilter.DateOfBirthBefore,
            Operator = FilterOperatorType.DateIsOnOrBefore,
            Type = QueryParamTypeEnum.DateIsOnBefore
        },

        new()
        {
            PropertyName = AllProviderTableFilter.DateOfBirthAfter,
            Operator = FilterOperatorType.DateIsOnOrAfter,
            Type = QueryParamTypeEnum.DateIsOnAfter
        }

    ];
}
