namespace assms.entities.Models;

public class InstitutionModel : BaseModel
{
    public required string Name { get; set; }
    public required string LogoUrl { get; set; }
    public required string Country { get; set; }
    public required string Region { get; set; }
    public required string City { get; set; }
    public required string Address { get; set; }
    public bool IsActive { get; set; }
    public DateTime? SubscriptionExpiresAt { get; set; }

    public ICollection<BranchModel>? Branches { get; init; }
    public ICollection<User>? Users { get; init; }
    public ICollection<Asset>? Assets { get; init; }
}