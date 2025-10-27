namespace assms.api.DAL.Repositories.AssetCategoryRepository;

public class AssetCategoryRepository(IQueryHandler<AssetCategoryModel> queryHandler) : IAssetCategoryRepository
{
    public async Task<IEnumerable<AssetCategoryRowModel>> GetAllAsync()
    {
        var response = await queryHandler.GetAllAsync(
            (AssetCategoryModel i) => i.Assets!
        );

        return response.Select(x => new AssetCategoryRowModel
        {
            AssetCategoryName= x.AssetCategoryName,
            AssetTypeId= x.AssetTypeId,
        }).ToList();
    }

    public async Task<IEnumerable<AssetCategoryRowModel>> GetAllByDateAsync(DateTime date)
    {
        var response = await queryHandler.GetAllByDateAsync(
            date,
            (AssetCategoryModel i) => i.Assets!
        );

        return response.Select(x => new AssetCategoryRowModel
        {
            AssetCategoryName= x.AssetCategoryName,
            AssetTypeId= x.AssetTypeId,
        }).ToList();
    }

    public async Task<AssetCategoryResponse> GetAssetCategoryDataAsync(Guid rowId)
    {
        var row = await GetRowDataAsync(rowId);

        if (row is null)
            throw new KeyNotFoundException(MessageConstants.NotFoundRecord);

        return new AssetCategoryResponse
        {
            AssetCategoryName = row.AssetCategoryName,
            AssetTypeId = row.AssetTypeId,
            AssetCount = row.Assets?.Count ?? 0
        };
    }

    public async Task<int> CreateAssetCategoryAsync(AssetCategoryRequest request)
    {
        var exists = await queryHandler.ExistsAsync(e =>
            EF.Functions.ILike(e.AssetCategoryName, request.AssetCategoryName) &&
            EF.Functions.ILike(e.AssetTypeId.ToString(), request.AssetTypeId.ToString()));

        if (exists)
            throw new Exception("AssetCategory already exists.");

        return await queryHandler.CreateAsync(new AssetCategoryModel
        {
            AssetCategoryName = request.AssetCategoryName,
            AssetTypeId = request.AssetTypeId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        });
    }

    public async Task<int> UpdateAssetCategoryAsync(AssetCategoryRequest request)
    {
        var row = await GetRowDataAsync(request.Id);
        if (row is null)
            throw new Exception(MessageConstants.NotFoundRecord);

        row.AssetCategoryName = request.AssetCategoryName;
        row.AssetTypeId = request.AssetTypeId;
        row.UpdatedAt = DateTime.UtcNow;

        return await queryHandler.UpdateAsync(row);
    }

    public async Task<int> DeleteAssetCategoryAsync(Guid rowId) =>
        await queryHandler.DeleteAsync(rowId);

    private async Task<AssetCategoryModel?> GetRowDataAsync(Guid rowId) =>
        await queryHandler.GetByIdAsync(rowId);
}

































