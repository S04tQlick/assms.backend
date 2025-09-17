namespace assms.entities.Models;

public abstract class BaseModel
{
    [Column("Id")]
    public Guid Id { get; init; }

    [Column("CreatedAt")]
    public DateTime CreatedAt { get; init; }

    [Column("UpdatedAt")]
    public DateTime UpdatedAt { get; set; }
}