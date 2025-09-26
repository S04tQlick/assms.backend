using assms.entities.Request;
using assms.entities.Response.AuthResponse;
using assms.entities.Response.BranchResponse;
using LoginRequest = Microsoft.AspNetCore.Identity.Data.LoginRequest;

namespace assms.api.DAL.Repositories.AuthRepository;

public interface IAuthRepository
{
    //Task<IEnumerable<BranchRowModel>> GetAllAsync();
    //Task<IEnumerable<BranchRowModel>> GetAllByDateAsync(DateTime date);
    Task<AuthActionResponse> LoginAsync(LoginRequest request);
    //Task<int> UpdateBranchAsync(BranchRequest request);
    //Task<int> DeleteBranchAsync(Guid rowId);
}