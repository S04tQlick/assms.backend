using assms.entities.GeneralResponse;
using assms.entities.Request;
using assms.entities.Response.VendorResponse;

namespace assms.api.DAL.Services.VendorService;

public interface IVendorService
{
    Task<BaseActionResponse<IEnumerable<VendorRowModel>>> GetAllAsync();
    Task<BaseActionResponse<IEnumerable<VendorRowModel>>> GetAllByDateAsync(DateTime date);
    Task<BaseActionResponse<int>> CreateAsync(VendorRequest request);
    Task<BaseActionResponse<int>> UpdateAsync(VendorRequest request);
    Task<BaseActionResponse<int>> DeleteAsync(Guid id);
}