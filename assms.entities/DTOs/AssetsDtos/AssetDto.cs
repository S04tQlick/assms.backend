namespace assms.entities.DTOs.AssetsDtos;

public class AssetDto
{
    public Guid Id { get; set; }
    public required string AssetName { get; set; }
    public required string AssetType { get; set; }
    public required string AssetCategory { get; set; }
    public required string Vendor { get; set; }
    public decimal PurchasePrice { get; set; }
    public DateTime? PurchaseDate { get; set; }
    public required string Status { get; set; }
}