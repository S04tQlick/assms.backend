using assms.entities.GeneralResponse;
using assms.entities.Request;
using assms.entities.Response.UserResponse;

namespace assms.api.DAL.Services.UserService;

public interface IUserService
{
    Task<BaseActionResponse<IEnumerable<UserRowModel>>> GetAllAsync();
    Task<BaseActionResponse<IEnumerable<UserRowModel>>> GetAllByDateAsync(DateTime date);
    Task<BaseActionResponse<int>> CreateAsync(UserRequest request);
    Task<BaseActionResponse<int>> UpdateAsync(UserRequest request);
    Task<BaseActionResponse<int>> DeleteAsync(Guid id);
}