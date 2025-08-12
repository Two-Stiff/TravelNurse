using System.ComponentModel.DataAnnotations;
using Core;
using Core.Utils;

namespace TravelNurseServer.Entities.Common;

// Base on this entity class. For each of the name in the array above, create me a sql script to insert those items
public class Discipline : Entity
{
    [MaxLength(10)]
    public string Abbreviation { get; set; } = Constants.DefaultString;

    [MaxLength(500)]
    public string Name { get; set; } = Constants.DefaultString;
    
    public bool IsForProvider { get; set; } = Constants.DefaultBoolean;
    
    public DateTime CreatedOn { get; set; } = Constants.DefaultDateTime;
    
    public DateTime ModifiedOn { get; set; } = Constants.DefaultDateTime;
    
    public DateTime DeletedOn { get; set; } = Constants.DefaultDateTime;
}