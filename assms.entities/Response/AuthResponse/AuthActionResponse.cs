namespace assms.entities.Response.AuthResponse;

public class AuthActionResponse
{
    public required string AccessToken { get; set; }
    public required string RefreshToken { get; set; }
    public Guid UserId { get; set; }
    public Guid UserRoleId { get; set; }
}