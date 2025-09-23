using assms.entities.Models;

namespace assms.entities.Request;

public class InstitutionRequest : BaseModel
{
    public required string Name { get; init; }
    public required string LogoUrl { get; init; }
    public required string Country { get; init; }
    public required string Region { get; init; }
    public required string City { get; init; }
    public required string Address { get; init; }
    public DateTime? SubscriptionExpiresAt { get; init; }
    public  bool IsActive { get; init; }
}