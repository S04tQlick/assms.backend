using assms.entities.Models;

namespace assms.entities.Response.VendorResponse;

public class VendorRowModel : BaseModel
{
    public required string Name { get; set; }
    public required string ContactName { get; set; }
    public required string ContactPhone { get; set; }
    public required string ContactEmail { get; set; }
    public required string Address { get; set; }
}