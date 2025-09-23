namespace assms.entities.Models;

public class Asset : BaseModel
{
    public Guid InstitutionId { get; set; }
    
    [ForeignKey(nameof(InstitutionId))]
    public InstitutionModel? Institution { get; set; }
    public Guid BranchId { get; set; }
    [ForeignKey(nameof(BranchId))]
    public BranchModel? Branch { get; set; }

    public required string AssetName { get; set; }
    public Guid AssetTypeId { get; set; }
    [ForeignKey(nameof(AssetTypeId))]
    public AssetType? AssetType { get; set; }
    public Guid AssetCategoryId { get; set; }
    [ForeignKey(nameof(AssetCategoryId))]
    public AssetCategory? AssetCategory { get; set; }

    public DateTime? PurchaseDate { get; set; }
    public decimal? PurchasePrice { get; set; }
    public Guid VendorId { get; set; }
    [ForeignKey(nameof(VendorId))]
    public Vendor? Vendor { get; set; }
    
    public required string VendorContact { get; set; }
    public DateTime? WarrantyStartDate { get; set; }
    public DateTime? WarrantyEndDate { get; set; }
    public required string Manufacturer { get; set; }
    public required string ModelNumber { get; set; }
    public required string Location { get; set; }
    public required string Status { get; set; }
    public required string Country { get; set; }
    public string? Region { get; set; }
    public required string BranchName { get; set; }
    public required string AssignedTo { get; set; }
    public required string DepreciationMethod { get; set; }
    public decimal AccumulatedDepreciation { get; set; }
    public decimal BookValue { get; set; }
    public required string MaintenanceType { get; set; }

    public ICollection<AssetImage>? Images { get; set; }
    public ICollection<MaintenanceDue>? MaintenanceDueItems { get; set; }
    public ICollection<MaintenanceReport>? MaintenanceReports { get; set; }
}