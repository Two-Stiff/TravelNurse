using MudBlazor;
using TravelNurse.Components.Common.Enums;
using TravelNurse.Components.Common.Utils.Dtos;
using TravelNurse.Components.Common.Utils.StaticType;
using TravelNurseServer.Dtos.Jobs.Get;
using TravelNurseServer.Dtos.TablePaginationParams;
using TravelNurseServer.Helpers;

namespace TravelNurse.Components.Src.Tables;


public static class JobsTableFilter
{
    public const string JobTitle = "JobTitle";
    public const string Requirements = "Requirements";
    public const string JobType = "JobType";
    public const string HousingProvided = "HousingProvided";
    public const string HideExternally = "HideExternally";
    public const string ContractLengthWeeks = "ContractLengthWeeks";
    
    public const string StartDate = "StartDate";
    public const string StartDateBefore = "StartDateBefore";
    public const string StartDateAfter = "StartDateAfter";
    
    public const string ExpiresOn = "ExpiresOn";
    public const string ExpiredOnDateBefore = "ExpiredOnDateBefore";
    public const string ExpiredOnDateAfter = "ExpiredOnDateAfter";
    public const string DisciplineId = "DisciplineId";
    public const string PlatformId = "PlatformId";
}

public class JobTableStore
{
    
    public MudDataGrid<GetJobDto> DataGrid = new();
    
    public readonly GridDataRequestDto<GetJobDto> RequestDto = new();

    public List<SelectOption> JobTypeEnumOptions = new List<SelectOption>();
    
    public readonly FilterDefinition<GetJobDto> FilterDefinition = new();
    
    public bool JobTitleFilterOpen { get; set; }
    public bool JobRequirementFilterOpen { get; set; }
    public bool HousingProvidedFilterOpen { get; set; }
    public bool HideExternallyFilterOpen { get; set; }
    public bool JobTypeFilterOpen { get; set; }
    public bool ContractLengthFilterOpen { get; set; }
    
    public bool StartDateFilterOpen { get; set; }
    
    public bool ExpireOnFilterOpen { get; set; }
    
    // Discipline Filter States
    public bool DisciplineFilterOpen { get; set; }
    public List<SelectOption> Disciplines { get; set; } = new();
    public void OpenDisciplineFilter() => DisciplineFilterOpen = !DisciplineFilterOpen;
    public HashSet<SelectOption> SelectedDisciplineFilterItems { get; set; } = new();
    
    // Platform custom filter states
    public bool PlatformFilterOpen { get; set; }
    public List<SelectOption> Platforms { get; set; } = new();
    public void OpenPlatformFilter() => PlatformFilterOpen = !PlatformFilterOpen;
    public HashSet<SelectOption> SelectedPlatformFilterItems { get; set; } = new();
    
    
    // Query Param
    public readonly List<QueryParamFilterDto> QueryParamFilters =
    [
        new()
        {
            PropertyName = JobsTableFilter.JobTitle,
            MatchingFilterNames = [JobsTableFilter.JobTitle]
        },

        new()
        {
            PropertyName = JobsTableFilter.Requirements,
            MatchingFilterNames = [JobsTableFilter.Requirements]
        },

        new()
        {
            PropertyName = JobsTableFilter.JobType,
            MatchingFilterNames = [JobsTableFilter.JobType]
        },

        new()
        {
            PropertyName = JobsTableFilter.HousingProvided,
            MatchingFilterNames = [JobsTableFilter.HousingProvided]
        },

        new()
        {
            PropertyName = JobsTableFilter.HideExternally,
            MatchingFilterNames = [JobsTableFilter.HideExternally]
        },

        new()
        {
            PropertyName = JobsTableFilter.ContractLengthWeeks,
            MatchingFilterNames = [JobsTableFilter.ContractLengthWeeks]
        },


        new()
        {
            // This setup is crucial for table filters that has multiple filter names associated to it...
            // For example: before date and after date filter
            PropertyName = JobsTableFilter.StartDate,
            MatchingFilterNames = [JobsTableFilter.StartDateBefore, JobsTableFilter.StartDateAfter]
        },

        new()
        {
            // This setup is crucial for table filters that has multiple filter names associated to it...
            // For example: before date and after date filter
            PropertyName = JobsTableFilter.ExpiresOn,
            MatchingFilterNames = [JobsTableFilter.ExpiredOnDateBefore, JobsTableFilter.ExpiredOnDateAfter]
        }

    ];
    
    public readonly List<QueryParamDto> QueryParamFilterList =
    [
        new()
        {
            PropertyName = JobsTableFilter.JobTitle,
            Operator = FilterOperatorType.StringContains,
            Type = QueryParamTypeEnum.String
        },

        new()
        {
            PropertyName = JobsTableFilter.Requirements,
            Operator = FilterOperatorType.StringContains,
            Type = QueryParamTypeEnum.String
        },

        new()
        {
            PropertyName = JobsTableFilter.JobType,
            Operator = FilterOperatorType.EnumEqual,
            Type = QueryParamTypeEnum.Enum
        },

        new()
        {
            PropertyName = JobsTableFilter.HousingProvided,
            Operator = FilterOperatorType.BooleanEqual,
            Type = QueryParamTypeEnum.Boolean
        },

        new()
        {
            PropertyName = JobsTableFilter.HideExternally,
            Operator = FilterOperatorType.BooleanEqual,
            Type = QueryParamTypeEnum.Boolean
        },

        new()
        {
            PropertyName = JobsTableFilter.ContractLengthWeeks,
            Operator = FilterOperatorType.NumberEqual,
            Type = QueryParamTypeEnum.Number
        },


        new()
        {
            PropertyName = JobsTableFilter.StartDateBefore,
            Operator = FilterOperatorType.DateIsOnOrBefore,
            Type = QueryParamTypeEnum.DateIsOnBefore
        },

        new()
        {
            PropertyName = JobsTableFilter.StartDateAfter,
            Operator = FilterOperatorType.DateIsOnOrAfter,
            Type = QueryParamTypeEnum.DateIsOnAfter
        },


        new()
        {
            PropertyName = JobsTableFilter.ExpiredOnDateBefore,
            Operator = FilterOperatorType.DateIsOnOrBefore,
            Type = QueryParamTypeEnum.DateIsOnBefore
        },

        new()
        {
            PropertyName = JobsTableFilter.ExpiredOnDateAfter,
            Operator = FilterOperatorType.DateIsOnOrAfter,
            Type = QueryParamTypeEnum.DateIsOnAfter
        }

    ];
}