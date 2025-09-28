using assms.entities.Models;

namespace assms.entities.Request;

public class AssetRequest : BaseModel
{
    public Guid InstitutionId { get; set; }
    public Guid BranchId { get; set; }
    public required string AssetName { get; set; }
    public Guid AssetTypeId { get; set; }
    public Guid AssetCategoryId { get; set; }
    public DateTime PurchaseDate { get; set; }
    public decimal PurchasePrice { get; set; }
    public Guid VendorId { get; set; }
    public DateTime WarrantyStartDate { get; set; }
    public DateTime WarrantyEndDate { get; set; }
    public required string Manufacturer { get; set; }
    public required string ModelNumber { get; set; }
    public required string Location { get; set; }
    public required string Status { get; set; }
    public required string Country { get; set; }
    public required string Region { get; set; }
    public required string AssignedTo { get; set; }
    public required string DepreciationMethod { get; set; }
    public decimal AccumulatedDepreciation { get; set; }
    public decimal BookValue { get; set; }
    public required string MaintenanceType { get; set; }
}