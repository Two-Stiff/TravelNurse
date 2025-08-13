using System.ComponentModel.DataAnnotations;
using Core.Dto;

namespace TravelNurseServer.Dtos.Common.Get;

public class GetDisciplineSpecialtyDto : BaseGetDto
{
    public int DisciplineId { get; set; }
    
    public int SpecialtyId { get; set; }
    
    public GetSpecialtyDto? Specialty { get; set; }
}