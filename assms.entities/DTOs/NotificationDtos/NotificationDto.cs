namespace assms.entities.DTOs.NotificationDtos;

public class NotificationDto
{
    public Guid Id { get; set; }

    public Guid InstitutionId { get; set; }
    public string? InstitutionName { get; set; }

    public string? Message { get; set; }
    public string? Type { get; set; } // e.g., Payment, Subscription, System

    public DateTime SentAt { get; set; }
    public bool IsRead { get; set; } 
}