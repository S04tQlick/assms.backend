namespace assms.entities.DTOs.AssetCategoryDtos;

public class CreateAssetCategoryDto
{
    public required string AssetCategoryName { get; set; }
    public Guid AssetTypeId { get; set; }
}