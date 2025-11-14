namespace assms.api.DAL.Services.AssetTypeService;

public interface IAssetTypeService
{
    Task<BaseActionResponse<IEnumerable<AssetTypeRowModel>>> GetAllAsync();
    Task<BaseActionResponse<AssetTypeRowModel>> GetByIdAsync(Guid id);
    Task<BaseActionResponse<IEnumerable<AssetTypeRowModel>>> GetAllByDateAsync(DateTime date);
    Task<BaseActionResponse<int>> CreateAsync(AssetTypeRequest request);
    Task<BaseActionResponse<int>> UpdateAsync(AssetTypeRequest request);
    Task<BaseActionResponse<int>> DeleteAsync(Guid id);
}