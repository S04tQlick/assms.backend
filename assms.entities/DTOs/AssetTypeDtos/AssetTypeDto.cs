using assms.entities.DTOs.AssetCategoryDtos;
using assms.entities.DTOs.AssetsDtos;

namespace assms.entities.DTOs.AssetTypeDtos;

public class AssetTypeDto
{
    public Guid Id { get; set; }
    public required string AssetTypeName { get; set; }

    public List<AssetCategoryDto>? Categories { get; set; }
    public List<AssetDto>? Assets { get; set; } 
}