namespace assms.entities.DTOs.SubscriptionPlanDtos;

public class UpdateSubscriptionPlanDto
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal PricePerMonth { get; set; }
    public int MaxUsers { get; set; }
    public int MaxAssets { get; set; }
    public bool IsActive { get; set; } 
}