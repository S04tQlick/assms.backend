namespace assms.entities.DTOs.SubscriptionPlanDtos;

public class SubscriptionPlanDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal PricePerMonth { get; set; }
    public int MaxUsers { get; set; }
    public int MaxAssets { get; set; }
    public bool IsActive { get; set; } 
}