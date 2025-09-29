namespace assms.api.DAL.Repositories.AssetRepository;

public interface IAssetRepository
{
    Task<IEnumerable<AssetRowModel>> GetAllAsync();
    Task<IEnumerable<AssetRowModel>> GetAllByDateAsync(DateTime date);
    Task<int> CreateAssetAsync(AssetRequest request);
    Task<int> UpdateAssetAsync(AssetRequest request);
    Task<int> DeleteAssetAsync(Guid rowId);
}