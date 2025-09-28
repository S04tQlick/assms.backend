namespace assms.entities.Models;

[Table("AssetTypes")]
public class AssetTypeModel : BaseModel
{
    public required string AssetTypeName { get; set; }

    public ICollection<AssetCategoryModel>? Categories { get; set; }
    public ICollection<AssetModel>? Assets { get; set; }
}