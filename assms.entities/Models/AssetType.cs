namespace assms.entities.Models;

public class AssetType : BaseModel
{
    public required string AssetTypeName { get; set; }

    public ICollection<AssetCategory>? Categories { get; set; }
    public ICollection<Asset>? Assets { get; set; }
}