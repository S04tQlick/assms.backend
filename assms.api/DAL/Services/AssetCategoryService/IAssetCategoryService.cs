namespace assms.api.DAL.Services.AssetCategoryService;

public interface IAssetCategoryService
{
    Task<BaseActionResponse<IEnumerable<AssetCategoryRowModel>>> GetAllAsync();
    Task<BaseActionResponse<IEnumerable<AssetCategoryRowModel>>> GetAllByDateAsync(DateTime date);
    Task<BaseActionResponse<int>> CreateAsync(AssetCategoryRequest request);
    Task<BaseActionResponse<int>> UpdateAsync(AssetCategoryRequest request);
    Task<BaseActionResponse<int>> DeleteAsync(Guid id);
}