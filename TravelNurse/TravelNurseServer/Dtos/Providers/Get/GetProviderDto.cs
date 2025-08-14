using Core.Dto;
using Core.Utils;
using TravelNurseServer.Dtos.Common.Get;
using TravelNurseServer.Enums;

namespace TravelNurseServer.Dtos.Providers.Get;

public class GetProviderDto : BaseGetDto

{
    public string? PreferredFirstName { get; set; }
    
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    
    public string? FullName { get; set; }
    
    public string? MaidenName { get; set; }
    public string? PrimaryPhoneNumber { get; set; }
    
    public string? AlternativePhoneNumber { get; set; }
    public bool IsPrimaryPhoneNumberInService { get; set; }
    
    public bool IsAlternativePhoneNumberInService { get; set; }
    
    public string? Email { get; set; }
    
    public string? AlternateEmail { get; set; }
    public DateTime DateOfBirth { get; set; }
    
    public string? LastFourSsn { get; set; }
    
    public string? PermanentNotes { get; set; }
    
    public string? PermanentPayrollNotes { get; set; }
    
    public string? ResumeNotes { get; set; }
    
    public string? PaycomEeCode { get; set; }
    
    public Guid UserId { get; set; }
    
    public string? Username { get; set; }
    
    public string? StreetAddress { get; set; }
    
    public string? City { get; set; }
    
    public int? StateId { get; set; }
    
    public GetStateDto? State { get; set; }
    
    public string? ZipCode { get; set; }
    
    public string? TemporaryStreetAddress { get; set; }
    
    public string? TemporaryCity { get; set; }
    
    public int? TemporaryStateId { get; set; }
    
    public GetStateDto? TemporaryState { get; set; }
    
    public string? TemporaryZipCode { get; set; } = Constants.DefaultString;
    
    public DateTime AvailabilityDate { get; set; }
    
    public string? ReferredBy { get; set; }
    
    public DateTime ReferralDate { get; set; }
    
    public bool ForceNextLogout { get; set; }
    
    public int? RecruiterId { get; set; }
    
    
    public int DisciplineId { get; set; }
    
    public GetDisciplineDto? Discipline { get; set; }
    
    public int SpecialtyId { get; set; }
    
    public GetSpecialtyDto? Specialty { get; set; }
    
    public ProviderStatus? Status { get; set; }

    public List<GetSubSpecialtyDto>? SubSpecialties { get; set; } = new List<GetSubSpecialtyDto>();
    
    public bool IsPriority { get; set; }
    
}