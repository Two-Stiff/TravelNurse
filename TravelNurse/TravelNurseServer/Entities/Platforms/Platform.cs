using System.ComponentModel.DataAnnotations;
using Core;
using Core.Utils;

namespace TravelNurseServer.Entities.Platforms;

public class Platform : Entity
{
    [MaxLength(1000)]
    public string Name { get; set; } = Constants.DefaultString;
}