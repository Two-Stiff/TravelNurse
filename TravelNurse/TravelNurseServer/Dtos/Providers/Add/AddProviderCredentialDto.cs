using Core.Utils;

namespace TravelNurseServer.Dtos.Providers.Add;

public class AddProviderCredentialDto
{
    public bool Compact { get; set; } = Constants.DefaultBoolean;
    
    public bool Certified { get; set; } = Constants.DefaultBoolean;
    
    public bool BoardEligible { get; set; } = Constants.DefaultBoolean;
    
    public bool IsDeaTransfer { get; set; } = Constants.DefaultBoolean;

    public bool IsDeaApply { get; set; } = Constants.DefaultBoolean;
    
    public string CertificationNames{ get; set; } = Constants.DefaultString;
    
    public List<int> CertificationIds { get; set; } = new List<int>();
    
    public string StateLicenseNames{ get; set; } = Constants.DefaultString;

    
    public List<int> StateLicenseIds { get; set; } = new List<int>();

    public string BoardNames{ get; set; } = Constants.DefaultString;

    
    public List<int> BoardIds { get; set; } = new List<int>();
}