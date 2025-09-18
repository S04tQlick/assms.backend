namespace assms.entities.DTOs.UserDtos;

public class AuthResponseDto
{
    public required string AccessToken { get; set; }
    public required string RefreshToken { get; set; }
    public Guid UserId { get; set; }
    public string? Role { get; set; }
}