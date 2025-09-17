namespace assms.entities.Models;

public class Payment : BaseModel
{
    public Guid InstitutionId { get; set; }

    [ForeignKey(nameof(InstitutionId))] 
    public Institution? Institution { get; set; } 

    public Guid SubscriptionId { get; set; }
    [ForeignKey(nameof(SubscriptionId))]
    public InstitutionSubscription? Subscription { get; set; }
    
    public string Gateway { get; set; } = string.Empty; // Stripe, Paystack, Flutterwave, Momo
    public string TransactionRef { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "USD"; // or GHS, NGN, KES
    public string Status { get; set; } = "Pending"; // Pending, Success, Failed
}