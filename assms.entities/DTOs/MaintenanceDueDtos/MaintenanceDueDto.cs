namespace assms.entities.DTOs.MaintenanceDueDtos;

public class MaintenanceDueDto
{
    public Guid Id { get; set; }
    public DateTime DueDate { get; set; }
    public required string MaintenanceType { get; set; }
    public required string TechnicianName { get; set; }
    public bool NotificationSent { get; set; } 
}