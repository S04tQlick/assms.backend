namespace assms.api.DAL.Repositories.AssetCategoryRepository;

public interface IAssetCategoryRepository
{
    Task<IEnumerable<AssetCategoryRowModel>> GetAllAsync();
    Task<IEnumerable<AssetCategoryRowModel>> GetAllByDateAsync(DateTime date);
    Task<int> CreateAssetCategoryAsync(AssetCategoryRequest request);
    Task<int> UpdateAssetCategoryAsync(AssetCategoryRequest request);
    Task<int> DeleteAssetCategoryAsync(Guid rowId);
}