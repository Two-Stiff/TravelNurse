using System.ComponentModel.DataAnnotations;
using Core.Dto;

namespace TravelNurseServer.Dtos.Platforms.Get;

public class GetPlatformDto : BaseGetDto
{
    [Required]
    public string Name { get; set; }
}