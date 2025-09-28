using assms.entities.Models;

namespace assms.entities.Request;

public class AssetTypeRequest : BaseModel
{
    public required string  AssetTypeName { get; set; }
}