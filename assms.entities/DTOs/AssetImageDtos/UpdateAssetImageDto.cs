namespace assms.entities.DTOs.AssetImageDtos;

public class UpdateAssetImageDto
{
    public required string Url { get; set; }
    public bool IsHeadOffice { get; set; } = false;
}