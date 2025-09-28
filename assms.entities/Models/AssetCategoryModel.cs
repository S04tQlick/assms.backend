namespace assms.entities.Models;

[Table("AssetCategories")]
public class AssetCategoryModel : BaseModel
{
    public Guid AssetTypeId { get; set; }
    
    [ForeignKey(nameof(AssetTypeId))]
    public AssetTypeModel? AssetType { get; set; }
    public required string  AssetCategoryName { get; set; }

    public ICollection<AssetModel>? Assets { get; set; }
}