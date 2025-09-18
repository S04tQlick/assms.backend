namespace assms.entities.DTOs.PaymentDtos;

public class PaymentDto
{
    public Guid Id { get; set; }

    public Guid InstitutionId { get; set; }
    public string? InstitutionName { get; set; }

    public Guid SubscriptionId { get; set; }
    public string? SubscriptionPlanName { get; set; }

    public string Gateway { get; set; } = string.Empty; // Stripe, Paystack, etc.
    public string TransactionRef { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "USD";
    public string Status { get; set; } = "Pending"; // Pending, Success, Failed 
}