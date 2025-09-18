namespace assms.entities.DTOs.MaintenanceReportDtos;

public class MaintenanceReportDto
{
    public Guid Id { get; set; }
    public DateTime MaintenanceDate { get; set; }

    public Guid AssetId { get; set; }
    public string? AssetName { get; set; }

    public string MaintenanceType { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal MaintenanceCost { get; set; }
    public string TechnicianName { get; set; } = default!; 
}