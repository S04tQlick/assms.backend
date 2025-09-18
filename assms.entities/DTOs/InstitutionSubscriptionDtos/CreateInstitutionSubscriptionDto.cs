namespace assms.entities.DTOs.InstitutionSubscriptionDtos;

public class CreateInstitutionSubscriptionDto
{
    public Guid InstitutionId { get; set; }
    public Guid PlanId { get; set; }
    
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public bool AutoRenew { get; set; } = false; 
}