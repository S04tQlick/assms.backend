namespace assms.entities.DTOs.MaintenanceDueDtos;

public class MaintenanceReportDto
{
    public Guid Id { get; set; }
    public DateTime MaintenanceDate { get; set; }
    public required string MaintenanceType { get; set; }
    public decimal MaintenanceCost { get; set; }
    public required string TechnicianName { get; set; }
}