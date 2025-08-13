using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Core.Attributes;
using Core.Utils;
using TravelNurseServer.Helpers;

namespace TravelNurseServer.Dtos.Jobs.Add;

public class AddJobDto
{
    [Required][StringLength(1000)] public string JobTitle { get; set; } = Constants.DefaultString;

    [StringLength(8000)] public string UniqueNotes { get; set; } = Constants.DefaultString;
    
    [Required][NotNull] public bool? AllowsAutoposterUpdate { get; set; } = Constants.DefaultBoolean;

    [Required][NotNull] public bool? Active { get; set; } = Constants.DefaultBoolean;

    [Required][NotNull] public bool? HousingProvided { get; set; } = Constants.DefaultBoolean;

    [Required][NotNull] public bool? AutoPosted { get; set; } = Constants.DefaultBoolean;

    [Required][NotNull] public bool? HideExternally { get; set; } = Constants.DefaultBoolean;

    [Required][NotNull] public int? ContractLengthWeeks { get; set; }

    [Required][NotNull] public DateTime? StartDate { get; set; }

    [Required][NotNull] public DateTime? ExpiresOn { get; set; }

    [Required]
    [NotEqual(-1, "Please select a value")]
    public int ClientManagerId { get; set; } = -1;

    public int NationalAccountManagerId { get; set; } = -1;

    [Required]
    [NotEqual(-1, "Please select a value")]
    public int PlatformId { get; set; } = -1;

    [Required] public int FacilityId { get; set; }

    [Required] public string FacilityName { get; set; } = Constants.DefaultString;

    [Required]
    [NotEqual(-1, "Please select a value")]
    public int DisciplineId { get; set; } = -1;

    [Required]
    [NotEqual(-1, "Please select a value")]
    public int SpecialtyId { get; set; } = -1;


    public string SubSpecialtyNames { get; set; } = Constants.DefaultString;

    public List<SelectOption> SelectedSubSpecialties { get; set; } = new List<SelectOption>();


    // Enum
    [Required]
    [NotEqual(-1, "Please select a value")]
    public int JobType { get; set; } = -1;
    
    
}