using System.ComponentModel.DataAnnotations;

namespace TravelNurseServer.Dtos.Common.Get;

public class GetDisciplineSpecialtyDto
{
    public int DisciplineId { get; set; }
    
    public int SpecialtyId { get; set; }
    
    public GetSpecialtyDto? Specialty { get; set; }
}