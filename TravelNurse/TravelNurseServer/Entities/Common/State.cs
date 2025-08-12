using System.ComponentModel.DataAnnotations;
using Core;
using Core.Utils;

namespace TravelNurseServer.Entities.Common;

// Base on this entity file, generate me sql scripts to insert all 50 states in the US
public class State : Entity
{
    [MaxLength(100)]
    public string Name { get; set; } = Constants.DefaultString;
    
    [MaxLength(3)]
    public string Abbreviation { get; set; } = Constants.DefaultString;
    
}