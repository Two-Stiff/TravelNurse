using Core.Utils;

namespace TravelNurseServer.Helpers;

public class SelectOption
{
    public int Id { get; set; } = Constants.DefaultInt;

    public string Name { get; set; } = Constants.DefaultString;

    public bool Selected { get; set; } = Constants.DefaultBoolean;
    
    public bool Disabled { get; set; } = Constants.DefaultBoolean;
}