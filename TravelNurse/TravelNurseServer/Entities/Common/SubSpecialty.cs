using System.ComponentModel.DataAnnotations;
using Core;
using Core.Utils;

namespace TravelNurseServer.Entities.Common;

public class SubSpecialty : Entity
{
    [MaxLength(1000)]
    public string Name { get; set; } = Constants.DefaultString;

    public bool? HasFellowShip { get; set; } = Constants.DefaultBoolean;
    
    public int SpecialtyId { get; set; } // FK
    
    public Specialty? Specialty { get; set; } 
}