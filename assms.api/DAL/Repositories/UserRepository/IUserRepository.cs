using assms.entities.Request;
using assms.entities.Response.BranchResponse;
using assms.entities.Response.UserResponse;

namespace assms.api.DAL.Repositories.UserRepository;

public interface IUserRepository
{
    Task<IEnumerable<UserRowModel>> GetAllAsync();
    //Task<IEnumerable<UserRowModel>> GetAllByInstitutionAsync(UserRequest request);
    Task<IEnumerable<UserRowModel>> GetAllByDateAsync(DateTime date);
    Task<int> CreateUserAsync(UserRequest request);
    Task<int> UpdateUserAsync(UserRequest request);
    Task<int> DeleteUserAsync(Guid rowId);
}