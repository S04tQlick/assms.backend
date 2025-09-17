namespace assms.entities.Models;

public class Notification : BaseModel
{
    // Institution this notification belongs to
    public Guid InstitutionId { get; set; }
    [ForeignKey(nameof(InstitutionId))]
    public Institution? Institution { get; set; }

    // Notification content
    public string? Message { get; set; } = string.Empty;
    public string? Type { get; set; } = string.Empty; // e.g., Payment, Subscription, System

    public DateTime SentAt { get; set; } = DateTime.UtcNow;

    public bool IsRead { get; set; } = false; 
}