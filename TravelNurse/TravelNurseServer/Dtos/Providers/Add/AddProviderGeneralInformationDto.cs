using System.ComponentModel.DataAnnotations;
using Core.Attributes;
using Core.Utils;
using TravelNurseServer.Helpers;

namespace TravelNurseServer.Dtos.Providers.Add;

public class AddProviderGeneralInformationDto
{
    [Required]
    public int ProviderId { get; set; }
    
    
    [Required]
    [NotEqual(-1, "Please select a value")]
    public int DisciplineId { get; set; } = -1;

    [Required]
    [NotEqual(-1, "Please select a value")]
    public int SpecialtyId { get; set; } = -1;
    
    public string SubSpecialtyNames{ get; set; } = Constants.DefaultString;

    public List<SelectOption> SelectedSubSpecialties { get; set; } = new List<SelectOption>();
    
    [Required]
    [PhoneNumber]
    public string PrimaryPhoneNumber { get; set; } = Constants.DefaultString;

    
    [Required]
    [StringLength(200)]
    [EmailAddress]
    public string Email { get; set; } = Constants.DefaultString;
    
    [Required]
    [StringLength(1000)]
    public string StreetAddress { get; set; } = Constants.DefaultString;
    
    [Required]
    [StringLength(300)]
    public string City { get; set; } = Constants.DefaultString;
    
    [Required]
    [StringLength(200)]
    public string ZipCode { get; set; } = Constants.DefaultString;
}