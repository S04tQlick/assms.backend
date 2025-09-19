namespace assms.entities.Models;

public class InstitutionSubscription : BaseModel
{
    public Guid InstitutionId { get; set; }
    [ForeignKey(nameof(InstitutionId))]
    public InstitutionModel? Institution { get; set; }

    public Guid PlanId { get; set; }
    [ForeignKey(nameof(PlanId))]
    public SubscriptionPlan? Plan { get; set; } 

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public bool IsActive { get; set; } = true;
    public bool AutoRenew { get; set; } = false;
}