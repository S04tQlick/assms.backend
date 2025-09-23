using assms.entities.Request;
using assms.entities.Response.BranchResponse;

namespace assms.api.DAL.Repositories.BranchRepository;

public interface IBranchRepository
{
    Task<IEnumerable<BranchRowModel>> GetAllAsync();
    Task<IEnumerable<BranchRowModel>> GetAllByDateAsync(DateTime date);
    Task<int> CreateBranchAsync(BranchRequest request);
    Task<int> UpdateBranchAsync(BranchRequest request);
    Task<int> DeleteBranchAsync(Guid rowId);
}