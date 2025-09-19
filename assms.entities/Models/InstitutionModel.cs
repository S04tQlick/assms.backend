namespace assms.entities.Models;

public class InstitutionModel : GeoBaseModel
{
    public required string Name { get; init; }
    public required string LogoUrl { get; init; }
    public required string Country { get; init; }
    public required string Region { get; init; }
    public required string City { get; init; }
    public required string Address { get; init; }
    public bool IsActive { get; init; }
    public DateTime? SubscriptionExpiresAt { get; init; }

    public ICollection<Branch>? Branches { get; init; }
    public ICollection<User>? Users { get; init; }
    public ICollection<Asset>? Assets { get; init; }
}