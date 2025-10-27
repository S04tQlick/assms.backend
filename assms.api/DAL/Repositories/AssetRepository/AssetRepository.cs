namespace assms.api.DAL.Repositories.AssetRepository;

public class AssetRepository(IQueryHandler<AssetModel> queryHandler) : IAssetRepository
{
    public async Task<IEnumerable<AssetRowModel>> GetAllAsync()
    {
        var response = await queryHandler.GetAllAsync(
            //(AssetModel i) => i.AssetTypes!,
            //(AssetModel i) => i.Institutions!,
            //(AssetModel i) => i.Branches!,
            //(AssetModel i) => i.AssetCategories!,
            //(AssetModel i) => i.Vendors!
        );

        return response.Select(x => new AssetRowModel
        {
            Id = x.Id,
            AssetName = x.AssetName,
            PurchaseDate = x.PurchaseDate,
            PurchasePrice = x.PurchasePrice,
            VendorId = x.VendorId,
            WarrantyStartDate = x.WarrantyStartDate,
            WarrantyEndDate = x.WarrantyEndDate,
            Manufacturer = x.Manufacturer,
            ModelNumber = x.ModelNumber,
            Location = x.Location,
            AssignedTo = x.AssignedTo,
            DepreciationMethod = x.DepreciationMethod,
            AccumulatedDepreciation = x.AccumulatedDepreciation,
            MaintenanceType = x.MaintenanceType,
            BookValue = x.BookValue,
            Status = x.Status,
            Region = x.Region,
            Country = x.Country,

            AssetCategoryId = x.AssetCategoryId,
            AssetTypeId = x.AssetTypeId,
            BranchId = x.BranchId,
            InstitutionId = x.InstitutionId,

            //BranchCount = x.Branches?.Count ?? 0,
            //AssetCategoryCount = x.AssetCategories?.Count ?? 0,
            //AssetTypeCount = x.Vendors?.Count ?? 0,
            //VendorCount = x.Vendors?.Count ?? 0,
            //InstitutionCount = x.Institutions?.Count ?? 0
        }).ToList();
    }

    public async Task<IEnumerable<AssetRowModel>> GetAllByDateAsync(DateTime date)
    {
        var response = await queryHandler.GetAllByDateAsync(
            date
            //(AssetModel i) => i.AssetTypes!,
            //(AssetModel i) => i.Institutions!,
            //(AssetModel i) => i.Branches!,
            //(AssetModel i) => i.AssetCategories!,
            //(AssetModel i) => i.Vendors!
        );

        return response.Select(x => new AssetRowModel
        {
            Id = x.Id,
            AssetName = x.AssetName,
            PurchaseDate = x.PurchaseDate,
            PurchasePrice = x.PurchasePrice,
            VendorId = x.VendorId,
            WarrantyStartDate = x.WarrantyStartDate,
            WarrantyEndDate = x.WarrantyEndDate,
            Manufacturer = x.Manufacturer,
            ModelNumber = x.ModelNumber,
            Location = x.Location,
            AssignedTo = x.AssignedTo,
            DepreciationMethod = x.DepreciationMethod,
            AccumulatedDepreciation = x.AccumulatedDepreciation,
            MaintenanceType = x.MaintenanceType,
            BookValue = x.BookValue,
            Status = x.Status,
            Region = x.Region,
            Country = x.Country,
            AssetCategoryId = x.AssetCategoryId,
            AssetTypeId = x.AssetTypeId,
            BranchId = x.BranchId,
            InstitutionId = x.InstitutionId,

            //BranchCount = x.Branches?.Count ?? 0,
            //AssetCategoryCount = x.AssetCategories?.Count ?? 0,
            //AssetTypeCount = x.Vendors?.Count ?? 0,
            //VendorCount = x.Vendors?.Count ?? 0,
            //InstitutionCount = x.Institutions?.Count ?? 0
        }).ToList();
    }

    public async Task<AssetResponse> GetAssetDataAsync(Guid rowId)
    {
        var row = await GetRowDataAsync(rowId);

        if (row is null)
            throw new KeyNotFoundException(MessageConstants.NotFoundRecord);

        return new AssetResponse
        {
            AssetName = row.AssetName,
            PurchaseDate = row.PurchaseDate,
            PurchasePrice = row.PurchasePrice,
            VendorId = row.VendorId,
            WarrantyStartDate = row.WarrantyStartDate,
            WarrantyEndDate = row.WarrantyEndDate,
            Manufacturer = row.Manufacturer,
            ModelNumber = row.ModelNumber,
            Location = row.Location,
            AssignedTo = row.AssignedTo,
            DepreciationMethod = row.DepreciationMethod,
            AccumulatedDepreciation = row.AccumulatedDepreciation,
            MaintenanceType = row.MaintenanceType,
            BookValue = row.BookValue,
            Status = row.Status,
            Region = row.Region,
            Country = row.Country,
            AssetCategoryId = row.AssetCategoryId,
            AssetTypeId = row.AssetTypeId,
        };
    }

    public async Task<int> CreateAssetAsync(AssetRequest request)
    {
        var exists = await queryHandler.ExistsAsync(e =>
            EF.Functions.ILike(e.AssetName, request.AssetName) &&
            (e.CreatedAt == request.CreatedAt) &&
            EF.Functions.ILike(e.Region, request.Region) &&
            EF.Functions.ILike(e.Country, request.Country));

        if (exists)
            throw new Exception("Asset already exists.");

        return await queryHandler.CreateAsync(new AssetModel
        {
            InstitutionId = request.InstitutionId,
            BranchId = request.BranchId,
            AssetName = request.AssetName,
            PurchaseDate = request.PurchaseDate,
            PurchasePrice = request.PurchasePrice,
            VendorId = request.VendorId,
            WarrantyStartDate = request.WarrantyStartDate,
            WarrantyEndDate = request.WarrantyEndDate,
            Manufacturer = request.Manufacturer,
            ModelNumber = request.ModelNumber,
            Location = request.Location,
            AssignedTo = request.AssignedTo,
            DepreciationMethod = request.DepreciationMethod,
            AccumulatedDepreciation = request.AccumulatedDepreciation,
            MaintenanceType = request.MaintenanceType,
            BookValue = request.BookValue,
            Status = request.Status,
            Region = request.Region,
            Country = request.Country,
            AssetCategoryId = request.AssetCategoryId,
            AssetTypeId = request.AssetTypeId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        });
    }

    public async Task<int> UpdateAssetAsync(AssetRequest request)
    {
        var row = await GetRowDataAsync(request.Id);
        if (row is null)
            throw new Exception(MessageConstants.NotFoundRecord);

        row.AssetName = request.AssetName;
        row.PurchaseDate = request.PurchaseDate;
        row.PurchasePrice = request.PurchasePrice;
        row.VendorId = request.VendorId;
        row.WarrantyStartDate = request.WarrantyStartDate;
        row.WarrantyEndDate = request.WarrantyEndDate;
        row.Manufacturer = request.Manufacturer;
        row.ModelNumber = request.ModelNumber;
        row.Location = request.Location;
        row.AssignedTo = request.AssignedTo;
        row.DepreciationMethod = request.DepreciationMethod;
        row.AccumulatedDepreciation = request.AccumulatedDepreciation;
        row.MaintenanceType = request.MaintenanceType;
        row.BookValue = request.BookValue;
        row.Status = request.Status;
        row.Region = request.Region;
        row.Country = request.Country;
        row.AssetCategoryId = request.AssetCategoryId;
        row.AssetTypeId = request.AssetTypeId;
        row.UpdatedAt = DateTime.UtcNow;

        return await queryHandler.UpdateAsync(row);
    }

    public async Task<int> DeleteAssetAsync(Guid rowId) =>
        await queryHandler.DeleteAsync(rowId);

    private async Task<AssetModel?> GetRowDataAsync(Guid rowId) =>
        await queryHandler.GetByIdAsync(rowId);
}