using System.ComponentModel.DataAnnotations;
using Core;
using Core.Utils;
using Microsoft.EntityFrameworkCore;
using TravelNurseServer.Entities.Jobs;

namespace TravelNurseServer.Entities.Common;

public class Facility : Entity
{
    [MaxLength(1000)]
    public string Name { get; set; } = Constants.DefaultString;
    
    [MaxLength(1000)]
    public string StreetAddress { get; set; } = Constants.DefaultString;
    
    [MaxLength(100)]
    public string City { get; set; } = Constants.DefaultString;
    
    [MaxLength(20)]
    public string ZipCode { get; set; } = Constants.DefaultString;
    
    [Precision(18, 2)]
    public decimal Latitude { get; set; } = Constants.DefaultDecimal;
    
    [Precision(18, 2)]
    public decimal Longitude { get; set; } = Constants.DefaultDecimal;
    
    [MaxLength(100)]
    public string PhoneNumber { get; set; } = Constants.DefaultString;
    
    [MaxLength(1000)]
    public string MailingAddress { get; set; } = Constants.DefaultString;
    
    [MaxLength(1000)]
    public string MailingCity { get; set; } = Constants.DefaultString;
    
    [MaxLength(20)]
    public string MailingZipCode { get; set; } = Constants.DefaultString;
    
    [MaxLength(100)]
    public string Fax { get; set; } = Constants.DefaultString;
    
    [MaxLength(1000)]
    public string BillingName { get; set; } = Constants.DefaultString;
    
    [MaxLength(1000)]
    public string WebsiteLink { get; set; } = Constants.DefaultString;
    
    public int BedSize { get; set; } = Constants.DefaultInt;
    
    public bool AutoOffer { get; set; } = Constants.DefaultBoolean;
    
    public bool AcceptsTravelers { get; set; } = Constants.DefaultBoolean;
    
    public bool SupplementalNursingOverride { get; set; } = Constants.DefaultBoolean;
    
    /// <summary>
    ///     Whether this is a locums facility or not
    /// </summary>
    public bool IsAdvancedPractice { get; set; } = Constants.DefaultBoolean;
    
    [MaxLength(8000)]
    public string PermanentNote { get; set; } = Constants.DefaultString;
    
    [MaxLength(2000)]
    public string PayrollBillingNote { get; set; } = Constants.DefaultString;
    
    public DateTime LastWorkOrderDate { get; set; } = Constants.DefaultDateTime;
    
    public DateTime LastNoteDate { get; set; } = Constants.DefaultDateTime;
    
    public int? StateId { get; set; } //FK
    
    public State? State { get; set; }
    
    public int? MailingStateId { get; set; } //FK
    
    public State? MailingState { get; set; }
    
    public List<Job>? Jobs { get; set; }
    
    [MaxLength(1000)]
    public string DoNotRehireReason { get; set; } = Constants.DefaultString;
    
}