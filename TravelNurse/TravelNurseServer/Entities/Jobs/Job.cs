using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core;
using Core.Utils;
using Microsoft.EntityFrameworkCore;
using TravelNurseServer.Entities.Common;
using TravelNurseServer.Enums;

namespace TravelNurseServer.Entities.Jobs;

public class Job : Entity
{
    [MaxLength(1000)]
    public string? JobTitle { get; set; } = Constants.DefaultString;

    [MaxLength(8000)]
    public string? UniqueNotes { get; set; } = Constants.DefaultString;

    [MaxLength(100)]
    public string? PlatformJobId { get; set; } = Constants.DefaultString;


    public bool Active
    {
        get { return ExpiresOn > DateTime.UtcNow; }
    }
    
    public JobStatus? JobStatus { get; set; }

    public JobType? JobType { get; set; } // Navigation property

    public bool HousingProvided { get; set; } = Constants.DefaultBoolean;

    public bool HideExternally { get; set; } = Constants.DefaultBoolean;

    public int ContractLengthWeeks { get; set; } = Constants.DefaultInt;

    public DateTime StartDate { get; set; } = Constants.DefaultDateTime;

    public DateTime ExpiresOn { get; set; } = Constants.DefaultDateTime;
    
    public DateTime RepostedOn { get; set; } = Constants.DefaultDateTime;

    public int? ClientManagerId { get; set; } // FK
    

    public int? FacilityId { get; set; } //FK
    
    public Facility? Facility { get; set; }

    public int? DisciplineId { get; set; } //FK

    public Discipline? Discipline { get; set; }

    public int? SpecialtyId { get; set; } //FK

    [NotMapped]
    public Specialty? Specialty { get; set; }
    
    public List<JobSubSpecialty>? JobSubSpecialties { get; set; }
    
    public bool IsFellowshipRequired { get; set; } = Constants.DefaultBoolean;
    

    [Precision(18, 2)]
    public decimal JobStrength { get; set; } = Constants.DefaultDecimal;
    
    public bool HideCity { get; set; } = Constants.DefaultBoolean;
    
    public bool AutoPosted { get; set; } = Constants.DefaultBoolean;
    
    public bool AllowsAutoposterUpdate { get; set; } = Constants.DefaultBoolean;

    // [NotMapped]
    // public JobBillingInformation JobBillingInformation { get; set; } // Navigation property
    //
    // [NotMapped]
    // public JobPayInformation JobPayInformation { get; set; } // Navigation property
    //
    // [NotMapped]
    // public JobShiftInformation JobShiftInformation { get; set; } // Navigation property
    //
    // [NotMapped]
    // public JobQuotingInformation JobQuotingInformation { get; set; } // Navigation property

    [MaxLength(8000)]
    public string? Requirements { get; set; }

    /// <summary>
    ///     Indicates if the facility status of the job is ContractInHand at the time of creation
    ///     If Job on creation is not contract in hand, Job is a Fishing Trip
    /// </summary>
    public bool IsNoContractInHandOnCreation { get; set; } = Constants.DefaultBoolean;

    /// <summary>
    ///     This property allows a job to be synced to sense through a Hangfire job.
    /// </summary>
    public bool SyncToSense { get; set; } = Constants.DefaultBoolean;

    /// <summary>
    ///     This property allows us to determine when this table was last synced to sense.
    /// </summary>
    public DateTime LastSyncToSense { get; set; } = Constants.DefaultDateTime;
    
    
    // public int? JobCertificationTypeId { get; set; } // FK
    //
    // public JobCertificationType JobCertificationType { get; set; } // Navigation property
    //
    // public int? JobLicenseTypeId { get; set; }
    //
    // public JobLicenseType JobLicenseType { get; set; } // FK 
    
}