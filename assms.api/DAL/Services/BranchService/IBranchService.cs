using assms.entities.Request;
using assms.entities.Response.BranchResponse;

namespace assms.api.DAL.Services.BranchService;

public interface IBranchService
{
    Task<BranchActionResponse<IEnumerable<BranchRowModel>>> GetAllAsync();
    Task<BranchActionResponse<IEnumerable<BranchRowModel>>> GetAllByDateAsync(DateTime date);
    Task<BranchActionResponse<int>> CreateAsync(BranchRequest request);
    Task<BranchActionResponse<int>> UpdateAsync(BranchRequest request);
    Task<BranchActionResponse<int>> DeleteAsync(Guid id);
}