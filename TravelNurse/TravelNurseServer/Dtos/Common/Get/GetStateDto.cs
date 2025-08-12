using System.ComponentModel.DataAnnotations;

namespace TravelNurseServer.Dtos.Common.Get;

public class GetStateDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Abbreviation { get; set; }
    
}