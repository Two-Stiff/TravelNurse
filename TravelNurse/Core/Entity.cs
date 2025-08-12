using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Core;

public interface IIdentified
{
    public int Id { get; set; }
}

[Index(nameof(Id))]
public class Entity : IIdentified
{
    [Key]
    public int Id { get; set; }
    
    // public DateTime CreatedOn { get; set; }
    //
    // public DateTime ModifiedOn { get; set; }
    //
    // public DateTime DeletedOn { get; set; }
    
}