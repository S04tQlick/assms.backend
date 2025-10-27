using assms.entities.Models;

namespace assms.entities.Response.BranchResponse;

public class BranchRowModel : GeoBaseModel
{
    public required string Name { get; set; }
    public required string Country { get; set; }
    public required string Region { get; set; }
    public required string City { get; set; }
    public required string Address { get; set; }
    public Guid InstitutionId { get; set; }
    public bool IsActive { get; set; }

    // Optionally include navigation collections if needed
    public int UserCount { get; set; }
    public int AssetCount { get; set; }
}