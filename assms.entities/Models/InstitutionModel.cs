namespace assms.entities.Models;

[Table("Institutions")]
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
    public ICollection<UserModel>? Users { get; init; }
    public ICollection<AssetModel>? Assets { get; init; }
}