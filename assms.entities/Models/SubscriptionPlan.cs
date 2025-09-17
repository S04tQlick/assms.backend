namespace assms.entities.Models;

public class SubscriptionPlan : BaseModel
{
    public string Name { get; set; } = string.Empty;   // e.g., Basic, Pro, Enterprise
    public string Description { get; set; } = string.Empty;
    public decimal PricePerMonth { get; set; }
    public int MaxUsers { get; set; }
    public int MaxAssets { get; set; }
    public bool IsActive { get; set; } = true;
}