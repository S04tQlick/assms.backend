namespace assms.entities.Models;

public class PaymentWebhookLog
{
    public Guid Id { get; set; }
    public string Gateway { get; set; } = string.Empty;
    public string Payload { get; set; } = string.Empty; // raw JSON
    public DateTime ReceivedAt { get; set; } = DateTime.UtcNow; 
}