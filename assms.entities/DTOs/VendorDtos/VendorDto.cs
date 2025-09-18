using assms.entities.DTOs.AssetsDtos;

namespace assms.entities.DTOs.VendorDtos;

public class VendorDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string ContactName { get; set; }
    public required string ContactPhone { get; set; }
    public required string ContactEmail { get; set; }
    public required string Address { get; set; }

    public List<AssetDto>? Assets { get; set; } 
}