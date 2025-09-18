namespace assms.entities.DTOs.PaymentWebhookLogDtos;

public class CreatePaymentWebhookLogDto
{
    public required string Gateway { get; set; }
    public required string Payload { get; set; } 
}