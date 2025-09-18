namespace assms.entities.DTOs.PaymentDtos;

public class UpdatePaymentDto
{
    public string Status { get; set; } = "Pending"; // typically updated by webhook/callback 
}