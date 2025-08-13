using Core.Dto;

namespace TravelNurseServer.Dtos.Common.Get;

public class GetSpecialtyDto : BaseGetDto
{
    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    public bool IsActive { get; set; }
}