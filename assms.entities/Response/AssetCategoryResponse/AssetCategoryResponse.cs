namespace assms.entities.Response.AssetCategoryResponse;

public class AssetCategoryResponse
{
    public  Guid AssetCategoryId { get; set; }
    public Guid AssetTypeId { get; set; }
    public required string  AssetCategoryName { get; set; }

    // Optionally include navigation collections if needed
    public int AssetCount { get; set; }
}