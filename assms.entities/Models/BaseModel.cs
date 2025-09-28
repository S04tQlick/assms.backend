using assms.entities.Request;

namespace assms.entities.Models;

public abstract class BaseModel
{
    [Column("Id")] public Guid Id { get; set; } = Guid.NewGuid();

    [Column("CreatedAt")] public DateTime CreatedAt { get; set; }

    [Column("UpdatedAt")] public DateTime UpdatedAt { get; set; }
}