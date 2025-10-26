namespace assms.entities.Models;

[Table("Institutions")]
public class InstitutionModel : BaseModel
{
    public required string Name { get; set; }
    public required string Country { get; set; }
    public required string Region { get; set; }
    public required string City { get; set; }
    public required string Email { get; set; }
    public bool IsActive { get; set; }
    public DateTime? SubscriptionExpiresAt { get; set; }
    public string? LogoUrl { get; set; }
    public string? SanityAssetId { get; set; }
    public string? SanityMimeType { get; set; }

    public ICollection<BranchModel>? Branches { get; init; }
    public ICollection<UserModel>? Users { get; init; }
    public ICollection<AssetModel>? Assets { get; init; }
}