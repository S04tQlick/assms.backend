namespace assms.entities.DTOs.AssetImageDtos;

public class CreateAssetImageDto
{
    public Guid AssetId { get; set; }
    public required string Url { get; set; }
    public bool IsHeadOffice { get; set; } = false;
}