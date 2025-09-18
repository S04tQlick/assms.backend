namespace assms.entities.DTOs.NotificationDtos;

public class CreateNotificationDto
{
    public Guid InstitutionId { get; set; }
    public required string Message { get; set; }
    public required string Type { get; set; } 
}