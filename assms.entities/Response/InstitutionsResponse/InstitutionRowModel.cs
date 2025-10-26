namespace assms.entities.Response.InstitutionsResponse;

public class InstitutionRowModel
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Country { get; set; }
    public required string Region { get; set; }
    public required string City { get; set; }
    public required string Email { get; set; }
    public bool IsActive { get; set; }
    public DateTime SubscriptionExpiresAt { get; set; }

    // Optionally include navigation collections if needed
    public int BranchCount { get; set; }
    public int UserCount { get; set; }
    public int AssetCount { get; set; }
}