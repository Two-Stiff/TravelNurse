using MudBlazor;
using TravelNurse.Components.Common.Enums;
using TravelNurse.Components.Common.Utils;
using TravelNurseServer.Helpers;
using TravelNurseServer.Services;

namespace TravelNurse.Components.Common.Services;

public interface IDataFetchService
{
    Task<List<SelectOption>> GetLocumSelectOptions(DataFetchEnum type, int? id, string? text, bool? addDefaultOption);
}

public class DataFetchService : IDataFetchService
{
    private readonly IDisciplineService _disciplineService;
    private readonly IFacilityService _facilityService;
    private readonly IPlatformService _platformService;
    private readonly ISnackbar _snackbar;

    public DataFetchService(
        IDisciplineService disciplineService,
        IFacilityService facilityService,
        IPlatformService platformService,
        ISnackbar snackbar
    )
    {
        _snackbar = snackbar;
        _facilityService  = facilityService;
        _platformService = platformService;
        _disciplineService = disciplineService;
    }

    public async Task<List<SelectOption>> GetLocumSelectOptions(DataFetchEnum type, int? id, string? text, bool? addDefaultOption = false)
    {
        var list = new List<SelectOption>();
        try
        {
            list = await LocumFetchHelper(type, id, text, addDefaultOption);
        }
        catch (Exception e)
        {
            _snackbar.Add(e.Message, Severity.Error);
        }

        return list;
    }

    private async Task<List<SelectOption>> LocumFetchHelper(
        DataFetchEnum type, int? id, string? text, bool? addDefaultOption)
    {
        var list = new List<SelectOption>();
        switch (type)
        {
            case DataFetchEnum.Disciplines:
                var disciplines = await _disciplineService.GetDisciplines();
                list = SelectOptionHelper.ConvertToSelectOptionsByNameProperty("Name", "Id", disciplines, addDefaultOption);
                return list;
            
            case DataFetchEnum.Platforms:
                var platforms = await _platformService.GetPlatform();
                list = SelectOptionHelper.ConvertToSelectOptionsByNameProperty("Name", "Id", platforms, addDefaultOption);
                return list;
            
            case DataFetchEnum.Facilities:
                var facilities = await _facilityService.GetFacilities(text ?? "");
                list = SelectOptionHelper.ConvertToSelectOptionsByNameProperty("Name", "Id", facilities, addDefaultOption);
                return list;

            case DataFetchEnum.Specialties:
                var specialties = await _disciplineService.GetDisciplineSpecialties(id ?? 0);
                list = SelectOptionHelper.ConvertToSelectOptionsByNameProperty("Specialty.Name", "Specialty.Id",
                    specialties, addDefaultOption);
                return list;

            case DataFetchEnum.SubSpecialties:
                var subSpecialties = await _disciplineService.GetSubSpecialties(id ?? 0);
                list = SelectOptionHelper.ConvertToSelectOptionsByNameProperty("Name", "Id",
                    subSpecialties, addDefaultOption);
                return list;

            // case DataFetchEnum.JobBoardCertificationTypes:
            //     var jobBoardCertificationTypes = await _jobBoardService.GetJobCertificationTypes();
            //     list = SelectOptionHelper.ConvertToSelectOptionsByNameProperty("Name", "Id",
            //         jobBoardCertificationTypes, addDefaultOption);
            //     return list;
            //
            // case DataFetchEnum.JobBoardLicenseTypes:
            //     var jobBoardLicenseTypes = await _jobBoardService.GetJobLicenseTypes();
            //     list = SelectOptionHelper.ConvertToSelectOptionsByNameProperty("Name", "Id",
            //         jobBoardLicenseTypes, addDefaultOption);
            //     return list;

            // case DataFetchEnum.Contacts:
            //     var contacts = await _contactService.GetContacts("");
            //     foreach (var contact in contacts)
            //         list.Add(new SelectOption
            //         {
            //             Id = contact.Id,
            //             Name = $"{contact.FirstName} {contact.LastName}",
            //             Selected = false
            //         });
            //     return list;

            // case DataFetchEnum.RateTypes:
            //     var rates = await _ratingTypeService.GetRateTypes();
            //     foreach (var rate in rates)
            //     {
            //         list.Add(new SelectOption
            //         {
            //             Id = rate.Id,
            //             Name = $"{rate.ShiftEnum.GetDisplayName()} {rate.PeriodEnum.GetDisplayName()}",
            //             Selected = false
            //         });
            //     }
            //     return list;

            default:
                return new List<SelectOption>();
        }
    }
}