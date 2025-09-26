namespace assms.entities.Models;

[Table("Branches")]
public class BranchModel : GeoBaseModel
{
    public Guid InstitutionId { get; set; }
    
    [ForeignKey(nameof(InstitutionId))]
    public InstitutionModel? Institution { get; set; }

    public required string Name { get; set; }
    public required string Address { get; set; }
    public required string City { get; set; }
    public required string Region { get; set; }
    public required string Country { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<UserModel>? Users { get; set; }
    public ICollection<AssetModel>? Assets { get; set; }
}