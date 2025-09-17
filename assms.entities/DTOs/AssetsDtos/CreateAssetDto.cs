namespace assms.entities.DTOs.AssetsDtos;

public class CreateAssetDto
{
 public Guid InstitutionId { get; set; }
 public Guid BranchId { get; set; }
 public required string AssetName { get; set; }
 public Guid AssetTypeId { get; set; }
 public Guid AssetCategoryId { get; set; }
 public Guid VendorId { get; set; }
 public decimal PurchasePrice { get; set; }
 public DateTime PurchaseDate { get; set; }
 public required string VendorContact { get; set; }
 public required string Manufacturer { get; set; }
 public required string ModelNumber { get; set; }
 public required string Location { get; set; }
 public required string Country { get; set; }
 public required string BranchName { get; set; }
 public required string AssignedTo { get; set; }
 public required string DepreciationMethod { get; set; }
 public required string MaintenanceType { get; set; }
}