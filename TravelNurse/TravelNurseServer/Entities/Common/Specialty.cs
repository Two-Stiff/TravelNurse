using System.ComponentModel.DataAnnotations;
using Core;
using Core.Utils;

namespace TravelNurseServer.Entities.Common;

public class Specialty : Entity
{
    [MaxLength(1000)]
    public string Name { get; set; } = Constants.DefaultString;

    [MaxLength(4000)]
    public string Description { get; set; } = Constants.DefaultString;
    
    public bool IsActive { get; set; } = Constants.DefaultBoolean;
    
    public List<DisciplineSpecialty>? DisciplineSpecialties { get; set; }
    
    public List<SubSpecialty>? SubSpecialties { get; set; }
}