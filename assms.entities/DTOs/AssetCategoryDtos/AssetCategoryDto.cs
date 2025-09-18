using assms.entities.DTOs.AssetsDtos;

namespace assms.entities.DTOs.AssetCategoryDtos;

public class AssetCategoryDto
{
    public Guid Id { get; set; }
    public required string AssetCategoryName { get; set; }
    
    public Guid AssetTypeId { get; set; }
    public string? AssetTypeName { get; set; }

    public List<AssetDto>? Assets { get; set; } 
}