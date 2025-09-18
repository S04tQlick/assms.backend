namespace assms.entities.DTOs.PaymentDtos;

public class CreatePaymentDto
{
    public Guid InstitutionId { get; set; }
    public Guid SubscriptionId { get; set; }

    public required string Gateway { get; set; }
    public required string TransactionRef { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "USD"; 
}