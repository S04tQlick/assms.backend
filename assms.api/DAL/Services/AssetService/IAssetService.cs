using assms.entities.GeneralResponse;
using assms.entities.Request;
using assms.entities.Response.AssetResponse;

namespace assms.api.DAL.Services.AssetService;

public interface IAssetService
{
    Task<BaseActionResponse<IEnumerable<AssetRowModel>>> GetAllAsync();
    Task<BaseActionResponse<IEnumerable<AssetRowModel>>> GetAllByDateAsync(DateTime date);
    Task<BaseActionResponse<int>> CreateAsync(AssetRequest request);
    Task<BaseActionResponse<int>> UpdateAsync(AssetRequest request);
    Task<BaseActionResponse<int>> DeleteAsync(Guid id);
}