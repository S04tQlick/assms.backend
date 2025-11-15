using Microsoft.AspNetCore.Http.HttpResults;

namespace assms.api.DAL.Repositories.AssetTypeRepository;

public class AssetTypeRepository(IQueryHandler<AssetTypeModel> queryHandler) : IAssetTypeRepository
{
    public async Task<IEnumerable<AssetTypeRowModel>> GetAllAsync()
    {
        var response = await queryHandler.GetAllAsync((AssetTypeModel i) => i.Assets!
        );

        return response.Select(x => new AssetTypeRowModel
        {
            Id = x.Id,
            AssetTypeName = x.AssetTypeName,
        }).ToList();
    }

    public async Task<AssetTypeRowModel> GetByIdAsync(Guid id)
    {
        var response = await queryHandler.GetByIdAsync(id,
            (AssetTypeModel i) => i.Assets!
        );

        if (response is null)
            throw new KeyNotFoundException(MessageConstants.NotFoundRecord);

        return new AssetTypeRowModel
        {
            Id= response.Id,
            AssetTypeName= response.AssetTypeName,
        };
    }

    public async Task<IEnumerable<AssetTypeRowModel>> GetAllByDateAsync(DateTime date)
    {
        var response = await queryHandler.GetAllByDateAsync(
            date,
            (AssetTypeModel i) => i.Assets!
        );

        return response.Select(x => new AssetTypeRowModel
        {
            Id= x.Id,
            AssetTypeName= x.AssetTypeName,
        }).ToList();
    }

    public async Task<AssetTypeResponse> GetAssetTypeDataAsync(Guid rowId)
    {
        var row = await GetRowDataAsync(rowId);

        if (row is null)
            throw new KeyNotFoundException(MessageConstants.NotFoundRecord);

        return new AssetTypeResponse
        {
            AssetTypeName = row.AssetTypeName,
        };
    }

    public async Task<int> CreateAssetTypeAsync(AssetTypeRequest request)
    {
        var exists = await queryHandler.ExistsAsync(e =>
            EF.Functions.ILike(e.AssetTypeName, request.AssetTypeName));

        if (exists)
            throw new DuplicateException("Asset type already exists.");

        return await queryHandler.CreateAsync(new AssetTypeModel
        {
            AssetTypeName = request.AssetTypeName,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        });
    }

    public async Task<int> UpdateAssetTypeAsync(AssetTypeRequest request)
    {
        var row = await GetRowDataAsync(request.Id);
        if (row is null)
            throw new Exception(MessageConstants.NotFoundRecord);

        row.Id= request.Id;
        row.AssetTypeName = request.AssetTypeName;
        row.UpdatedAt = DateTime.UtcNow;

        return await queryHandler.UpdateAsync(row);
    }

    public async Task<int> DeleteAssetTypeAsync(Guid rowId) =>
        await queryHandler.DeleteAsync(rowId);

    private async Task<AssetTypeModel?> GetRowDataAsync(Guid rowId) =>
        await queryHandler.GetByIdAsync(rowId);
}