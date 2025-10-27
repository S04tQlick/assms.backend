namespace assms.entities.Response.AssetCategoryResponse;

public class AssetCategoryRowModel
{
    public required Guid Id { get; set; }
    public required string  AssetCategoryName { get; set; }
    public Guid AssetTypeId { get; set; }
}