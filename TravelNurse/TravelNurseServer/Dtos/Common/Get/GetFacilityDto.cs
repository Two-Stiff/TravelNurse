using System.ComponentModel.DataAnnotations;
using Core.Dto;

namespace TravelNurseServer.Dtos.Common.Get;

public class GetFacilityDto : BaseGetDto

{
    [Required]
    public string? Name { get; set; }

    [Required]
    public string? StreetAddress { get; set; }

    [Required]
    public string? City { get; set; }

    [Required]
    public string? ZipCode { get; set; }

    [Required]
    public string? PhoneNumber { get; set; }

    [Required]
    public string? MailingAddress { get; set; }

    [Required]
    public string? MailingCity { get; set; }

    [Required]
    public string? MailingZipCode { get; set; }

    [Required]
    public string? Fax { get; set; }

    [Required]
    public string? BillingName { get; set; }

    [Required]
    public string? WebsiteLink { get; set; }

    [Required]
    public string? PermanentNote { get; set; }

    [Required]
    public string? PayrollBillingNote { get; set; }

    [Required]
    public int BedSize { get; set; }

    [Required]
    public bool AutoOffer { get; set; }

    [Required]
    public bool AcceptsTravelers { get; set; }

    [Required]
    public bool IsAdvancedPractice { get; set; }

    [Required]
    public bool InheritsSubmittalRequirements { get; set; }

    [Required]
    public bool InheritsTimecardProcedures { get; set; }

    [Required]
    public bool InheritsBillingProcedures { get; set; }

    [Required]
    public bool InheritsHolidayProcedures { get; set; }

    [Required]
    public DateTime LastWorkOrderDate { get; set; }

    [Required]
    public DateTime LastNoteDate { get; set; }

    [Required]
    public DateTime ExpirationDate { get; set; }

    
    [Required]
    public int StateId { get; set; }

    public GetStateDto? State { get; set; }

    public int? MailingStateId { get; set; }

    public GetStateDto? MailingState { get; set; }
    
    [Required]
    public string? DoNotRehireReason { get; set; }
    
}