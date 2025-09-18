namespace assms.entities.DTOs.MaintenanceDueDtos;

public class CreateMaintenanceDueDto
{
    public Guid AssetId { get; set; }
    public DateTime DueDate { get; set; }
    public required string MaintenanceType { get; set; }
    public required string TechnicianName { get; set; }
}