namespace assms.entities.Models;

public class AssetCategory : BaseModel
{
    public Guid AssetTypeId { get; set; }
    
    [ForeignKey(nameof(AssetTypeId))]
    public AssetType? AssetType { get; set; }
    public required string  AssetCategoryName { get; set; }

    public ICollection<Asset>? Assets { get; set; }
}