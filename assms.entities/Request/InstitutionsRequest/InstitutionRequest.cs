namespace assms.entities.Request.InstitutionsRequest;

public class InstitutionRequest
{
    public required string Name { get; init; }
    public required string LogoUrl { get; init; }
    public required string Country { get; init; }
    public required string Region { get; init; }
    public required string City { get; init; }
    public required string Address { get; init; }
    public DateTime? SubscriptionExpiresAt { get; init; }
}