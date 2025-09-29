namespace assms.api.DAL.Services.BranchService;

public interface IBranchService
{
    Task<BaseActionResponse<IEnumerable<BranchRowModel>>> GetAllAsync();
    Task<BaseActionResponse<IEnumerable<BranchRowModel>>> GetAllByDateAsync(DateTime date);
    Task<BaseActionResponse<int>> CreateAsync(BranchRequest request);
    Task<BaseActionResponse<int>> UpdateAsync(BranchRequest request);
    Task<BaseActionResponse<int>> DeleteAsync(Guid id);
}