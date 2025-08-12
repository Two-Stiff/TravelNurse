using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core;
using TravelNurseServer.Entities.Common;

namespace TravelNurseServer.Entities.Jobs;

public class JobSubSpecialty : Entity
{
    [Required]
    public int JobId { get; set; }
    
    [Required]
    public int SubSpecialtyId { get; set; } // FK
    
    [Required]
    public bool IsRequired { get; set; }
    
    [NotMapped]
    public SubSpecialty? SubSpecialty { get; set; }
}