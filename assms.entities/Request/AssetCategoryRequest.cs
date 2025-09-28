using assms.entities.Models;

namespace assms.entities.Request;

public class AssetCategoryRequest : BaseModel
{
    public Guid AssetTypeId { get; set; }
    public required string  AssetCategoryName { get; set; }
}