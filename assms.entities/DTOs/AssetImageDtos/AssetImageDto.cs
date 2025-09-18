namespace assms.entities.DTOs.AssetImageDtos;

public class AssetImageDto
{
    public Guid Id { get; set; }
    public Guid AssetId { get; set; }
    public required string Url { get; set; }
    public bool IsHeadOffice { get; set; }

    // Optional: expose some asset info (instead of full object)
    public string? AssetName { get; set; } 
}