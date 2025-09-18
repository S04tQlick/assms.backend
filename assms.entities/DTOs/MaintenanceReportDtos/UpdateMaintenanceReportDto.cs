namespace assms.entities.DTOs.MaintenanceReportDtos;

public class UpdateMaintenanceReportDto
{
    public DateTime MaintenanceDate { get; set; }
    public Guid AssetId { get; set; }

    public required string MaintenanceType { get; set; }
    public required string Description { get; set; }
    public decimal MaintenanceCost { get; set; }
    public required string TechnicianName { get; set; } 
}