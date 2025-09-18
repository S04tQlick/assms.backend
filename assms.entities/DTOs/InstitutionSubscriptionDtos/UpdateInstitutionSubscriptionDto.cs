namespace assms.entities.DTOs.InstitutionSubscriptionDtos;

public class UpdateInstitutionSubscriptionDto
{
    public Guid PlanId { get; set; }
    
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public bool IsActive { get; set; }
    public bool AutoRenew { get; set; } 
}