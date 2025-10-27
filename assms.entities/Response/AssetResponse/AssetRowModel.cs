namespace assms.entities.Response.AssetResponse;

public class AssetRowModel
{
    public required Guid Id { get; set; }
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

    // Optionally include navigation collections if needed
    public int BranchCount { get; set; }
    //public int UserCount { get; set; }
    public int VendorCount { get; set; }
    public int AssetCategoryCount { get; set; }
    public int AssetTypeCount { get; set; }
    public int InstitutionCount { get; set; }
}