namespace assms.api.DAL.Services.AuthServices;

public interface IAuthService
{
    Task<BaseActionResponse<AuthActionResponse>> LoginAsync(LoginRequest request);
    Task<AuthActionResponse> CreateAsync(LoginRequest request);
    Task<AuthActionResponse> RefreshTokenAsync(string refreshToken);
    Task LogoutAsync(Guid userId);
}