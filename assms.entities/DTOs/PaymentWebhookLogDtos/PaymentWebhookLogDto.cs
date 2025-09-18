namespace assms.entities.DTOs.PaymentWebhookLogDtos;

public class PaymentWebhookLogDto
{
    public Guid Id { get; set; }
    public string Gateway { get; set; } = string.Empty;
    public string Payload { get; set; } = string.Empty; // raw JSON
    public DateTime ReceivedAt { get; set; } 
}