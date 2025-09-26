namespace assms.entities.Models;

public class MaintenanceReport : BaseModel
{
    public DateTime MaintenanceDate { get; set; }
    public Guid AssetId { get; set; }
    
    [ForeignKey(nameof(AssetId))]
    public AssetModel? Asset { get; set; }

    public required string MaintenanceType { get; set; }
    public required string Description { get; set; }
    public decimal MaintenanceCost { get; set; }
    public required string TechnicianName { get; set; }
}