namespace assms.entities.Models;

[Table("Assets")]
public class AssetModel : BaseModel
{
    public Guid InstitutionId { get; set; }
    [ForeignKey(nameof(InstitutionId))]
    public InstitutionModel? InstitutionModel { get; set; }
    public Guid BranchId { get; set; }
    [ForeignKey(nameof(BranchId))]
    public BranchModel? BranchModel { get; set; }

    public required string AssetName { get; set; }
    public Guid AssetTypeId { get; set; }
    [ForeignKey(nameof(AssetTypeId))]
    public AssetTypeModel? AssetTypeModel { get; set; }
    public Guid AssetCategoryId { get; set; }
    [ForeignKey(nameof(AssetCategoryId))]
    public AssetCategoryModel? AssetCategoryModel { get; set; }

    public DateTime PurchaseDate { get; set; }
    public decimal PurchasePrice { get; set; }
    public Guid VendorId { get; set; }
    [ForeignKey(nameof(VendorId))]
    public VendorModel? Vendor { get; set; }
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

    
    //public ICollection<BranchModel>? Branches { get; set; }
    //public ICollection<InstitutionModel>? Institutions { get; set; }
    //public ICollection<AssetTypeModel>? AssetTypes { get; set; }
    //public ICollection<AssetCategoryModel>? AssetCategories { get; set; }
    //public ICollection<VendorModel>? Vendors { get; set; }
    
    public ICollection<AssetImage>? Images { get; set; }
    public ICollection<MaintenanceDue>? MaintenanceDueItems { get; set; }
    public ICollection<MaintenanceReport>? MaintenanceReports { get; set; }
}