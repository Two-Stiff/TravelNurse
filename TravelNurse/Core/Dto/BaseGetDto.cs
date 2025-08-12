namespace Core.Dto;


public class BaseGetDto
{
    public int Id { get; set; }
    // public DateTime CreatedOn { get; set; }
    // public DateTime ModifiedOn { get; set; }
    // public DateTime? DeletedOn { get; set; }  // Nullable in case it's not deleted
}