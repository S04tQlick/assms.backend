namespace assms.entities.Models;

public class MaintenanceDue : BaseModel
{
    public DateTime DueDate { get; set; }
    public Guid AssetId { get; set; }
    
    [ForeignKey(nameof(AssetId))]
    public Asset? Asset { get; set; }

    public required string MaintenanceType { get; set; }
    public string? Description { get; set; }
    public required string TechnicianName { get; set; }
    public bool NotificationSent { get; set; } = false;
}