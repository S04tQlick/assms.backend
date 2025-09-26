namespace assms.entities.Models;

public class Vendor : BaseModel
{
    public required string Name { get; set; }
    public required string ContactName { get; set; }
    public required string ContactPhone { get; set; }
    public required string ContactEmail { get; set; }
    public required string Address { get; set; }

    public ICollection<AssetModel>? Assets { get; set; }
}