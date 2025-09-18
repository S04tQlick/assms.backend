namespace assms.entities.DTOs.NotificationDtos;

public class UpdateNotificationDto
{
    public required string Message { get; set; }
    public required string Type { get; set; }
    public bool IsRead { get; set; } 
}