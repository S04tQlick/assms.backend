using assms.entities.GeneralResponse;
using assms.entities.Request;
using assms.entities.Response.AuthResponse;
using LoginRequest = Microsoft.AspNetCore.Identity.Data.LoginRequest;

namespace assms.api.DAL.Services.AuthServices;

public interface IAuthService
{
    Task<BaseActionResponse<AuthActionResponse>> LoginAsync(LoginRequest request);
    Task<AuthActionResponse> CreateAsync(LoginRequest request);
    Task<AuthActionResponse> RefreshTokenAsync(string refreshToken);
    Task LogoutAsync(Guid userId);
}