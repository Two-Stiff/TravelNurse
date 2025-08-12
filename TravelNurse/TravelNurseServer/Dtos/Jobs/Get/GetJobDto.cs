using Core.Dto;
using TravelNurseServer.Dtos.Common.Get;
using TravelNurseServer.Enums;

namespace TravelNurseServer.Dtos.Jobs.Get;

public class GetJobDto : BaseGetDto
{
    public string? JobTitle { get; set; }
    
    public string? Requirements { get; set; }
    
    public JobType? JobType { get; set; }

    public bool HousingProvided { get; set; }
    
    public bool HideExternally { get; set; }
    
    public int ContractLengthWeeks { get; set; }
    
    public int DisciplineId { get; set; }
    
    public GetDisciplineDto? Discipline { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime ExpiresOn { get; set; }
    
    public int? PlatformId { get; set; }
}