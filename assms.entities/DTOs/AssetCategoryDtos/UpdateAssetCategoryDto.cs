namespace assms.entities.DTOs.AssetCategoryDtos;

public class UpdateAssetCategoryDto
{
    public required string AssetCategoryName { get; set; }
    public Guid AssetTypeId { get; set; } 
}