using assms.entities.Models;

namespace assms.entities.Response.InstitutionsResponse;

public class InstitutionRowModel : BaseModel
{
    public required string Name { get; set; }
    public required string LogoUrl { get; set; }
    public required string Country { get; set; }
    public required string Region { get; set; }
    public required string City { get; set; }
    public required string Address { get; set; }
    public bool IsActive { get; set; }
    public DateTime SubscriptionExpiresAt { get; set; }

    // Optionally include navigation collections if needed
    public int BranchCount { get; set; }
    public int UserCount { get; set; }
    public int AssetCount { get; set; }
}