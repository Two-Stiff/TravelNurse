using System.ComponentModel.DataAnnotations;
using Core.Dto;

namespace TravelNurseServer.Dtos.Common.Get;

public class GetDisciplineDto
{
    public string? Abbreviation { get; set; }
    
    public string? Name { get; set; }

    public bool IsForProvider { get; set; }
}