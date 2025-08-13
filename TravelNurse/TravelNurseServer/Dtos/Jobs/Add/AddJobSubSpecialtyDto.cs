using System.ComponentModel.DataAnnotations;

namespace TravelNurseServer.Dtos.Jobs.Add;

public class AddJobSubSpecialtyDto
{
    [Required]
    public int JobId { get; set; }
    
    [Required]
    public int SubSpecialtyId { get; set; }
    
    [Required]
    public bool IsRequired { get; set; }
}