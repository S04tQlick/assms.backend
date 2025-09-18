namespace assms.entities.DTOs.MaintenanceDueDtos;

public class CreateMaintenanceReportDto
{
    public Guid AssetId { get; set; }
    public DateTime MaintenanceDate { get; set; }
    public required string MaintenanceType { get; set; }
    public decimal MaintenanceCost { get; set; }
    public required string TechnicianName { get; set; }
    public required string Description { get; set; }
}