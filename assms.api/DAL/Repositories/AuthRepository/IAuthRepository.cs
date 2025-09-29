namespace assms.api.DAL.Repositories.AuthRepository;

public interface IAuthRepository
{
    //Task<IEnumerable<BranchRowModel>> GetAllAsync();
    //Task<IEnumerable<BranchRowModel>> GetAllByDateAsync(DateTime date);
    Task<AuthActionResponse> LoginAsync(LoginRequest request);
    //Task<int> UpdateBranchAsync(BranchRequest request);
    //Task<int> DeleteBranchAsync(Guid rowId);
}