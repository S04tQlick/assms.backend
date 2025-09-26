namespace assms.entities.Models;

public class AssetImage : BaseModel
{
    public Guid AssetId { get; set; }
    
    [ForeignKey(nameof(AssetId))]
    public AssetModel? Asset { get; set; }

    public required string Url { get; set; }
    public bool IsHeadOffice { get; set; } = false;
}