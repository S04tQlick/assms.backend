namespace assms.api.DAL.Repositories.AssetTypeRepository;

public interface IAssetTypeRepository
{
    Task<IEnumerable<AssetTypeRowModel>> GetAllAsync();
    Task<AssetTypeRowModel> GetByIdAsync(Guid id);
    Task<IEnumerable<AssetTypeRowModel>> GetAllByDateAsync(DateTime date);
    Task<int> CreateAssetTypeAsync(AssetTypeRequest request);
    Task<int> UpdateAssetTypeAsync(AssetTypeRequest request);
    Task<int> DeleteAssetTypeAsync(Guid rowId);
}