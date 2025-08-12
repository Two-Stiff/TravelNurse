using System.ComponentModel.DataAnnotations;
using Core;
using Core.Utils;
using Microsoft.EntityFrameworkCore;
using TravelNurseServer.Entities.Common;

namespace TravelNurseServer.Entities.Providers;

[Index(nameof(FirstName), nameof(LastName), nameof(DeletedOn))]
public class Provider : Entity
{
    [MaxLength(1000)]
    public string PreferredFirstName { get; set; } = Constants.DefaultString;

    [MaxLength(1000)]
    public string FirstName { get; set; } = Constants.DefaultString;

    [MaxLength(1000)]
    public string LastName { get; set; } = Constants.DefaultString;

    [MaxLength(1000)]
    public string MaidenName { get; set; } = Constants.DefaultString;

    [MaxLength(200)]
    public string PrimaryPhoneNumber { get; set; } = Constants.DefaultString;

    [MaxLength(200)]
    public string AlternativePhoneNumber { get; set; } = Constants.DefaultString;
    
    public bool IsPrimaryPhoneNumberInService { get; set; } = true;

    public bool IsAlternativePhoneNumberInService { get; set; } = true;

    [MaxLength(1000)]
    public string Email { get; set; } = Constants.DefaultString;

    [MaxLength(1000)]
    public string AlternateEmail { get; set; } = Constants.DefaultString;

    public DateTime DateOfBirth { get; set; } = Constants.DefaultDateTime;

    [MaxLength(200)]
    public string? Ssn { get; set; }

    [MaxLength(4)]
    public string LastFourSsn { get; set; } = Constants.DefaultString;

    [MaxLength(10)]
    public string PaycomEeCode { get; set; } = Constants.DefaultString;
    
    public Guid UserId { get; set; } = Constants.DefaultGuid;

    [MaxLength(128)]
    public string Username { get; set; } = Constants.DefaultString;
    
    [MaxLength(1000)]
    public string StreetAddress { get; set; } = Constants.DefaultString;

    [MaxLength(300)]
    public string City { get; set; } = Constants.DefaultString;

    public int? StateId { get; set; } //FK

    public State? State { get; set; }

    [MaxLength(200)]
    public string ZipCode { get; set; } = Constants.DefaultString;

    [MaxLength(1000)]
    public string TemporaryStreetAddress { get; set; } = Constants.DefaultString;

    [MaxLength(200)]
    public string TemporaryCity { get; set; } = Constants.DefaultString;

    public int? TemporaryStateId { get; set; } //FK

    public State? TemporaryState { get; set; }

    [MaxLength(200)]
    public string TemporaryZipCode { get; set; } = Constants.DefaultString;

    public DateTime AvailabilityDate { get; set; } = Constants.DefaultDateTime;
    
    [MaxLength(2000)]
    public string ReferredBy { get; set; } = Constants.DefaultString;

    public DateTime ReferralDate { get; set; } = Constants.DefaultDateTime;
    
    public DateTime SensitiveDataModifiedOn { get; set; } = Constants.DefaultDateTime; 
    
    public bool ForceNextLogout { get; set; } = Constants.DefaultBoolean;
    
    public int? TravelerId { get; set; }
    
    public int? LastRecruiterId { get; set; } //FK
    
    
    public int? DisciplineId { get; set; } //FK

    public Discipline? Discipline { get; set; }
    
    public bool IsPriority { get; set; } = Constants.DefaultBoolean;
}