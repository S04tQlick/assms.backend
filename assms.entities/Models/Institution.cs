namespace assms.entities.Models;

public class Institution : GeoBaseModel
{
    public required string Name { get; set; }
    public string? LogoUrl { get; set; }
    public required string Country { get; set; }
    public required string Region { get; set; }
    public required string City { get; set; }
    public required string Address { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime? SubscriptionExpiresAt { get; set; }

    public ICollection<Branch>? Branches { get; set; }
    public ICollection<User>? Users { get; set; }
    public ICollection<Asset>? Assets { get; set; }
}