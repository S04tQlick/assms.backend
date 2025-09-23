using assms.entities.Models;

namespace assms.entities.Request;

public class BranchRequest : GeoBaseModel
{
    public required string Name { get; init; }
    public required string Country { get; init; }
    public required string Region { get; init; }
    public required string City { get; init; }
    public required string Address { get; init; }
    public  Guid InstitutionId { get; set; }
    public bool IsActive { get; set; }
}