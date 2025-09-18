namespace assms.entities.DTOs.InstitutionSubscriptionDtos;

public class InstitutionSubscriptionDto
{
    public Guid Id { get; set; }
    public Guid InstitutionId { get; set; }
    public string? InstitutionName { get; set; }

    public Guid PlanId { get; set; }
    public string? PlanName { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public bool IsActive { get; set; }
    public bool AutoRenew { get; set; } 
}