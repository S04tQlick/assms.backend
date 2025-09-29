namespace assms.api.DAL.Repositories.AuthRepository;

public class AuthRepository(
    IQueryHandler<UserModel> queryHandler,
    IOptions<JwtSettings> jwtSettings,
    IConnectionMultiplexer redis) : IAuthRepository
{
    private readonly JwtSettings _jwtSettings = jwtSettings.Value;

    public async Task<AuthActionResponse> LoginAsync(LoginRequest request)
    {
        var user = await queryHandler.FirstOrDefaultAsync(
            e => e.Email == request.Email,
            q => q.Include(u => u.UserRoleModel)!
        );

        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            return null!;

        var accessToken = GenerateJwtToken(user);
        var refreshToken = Guid.NewGuid().ToString();
        
        var db =redis.GetDatabase();
        await db.StringSetAsync($"refresh:{user.Id}", refreshToken,
            TimeSpan.FromDays(_jwtSettings.RefreshTokenExpirationDays));

        return (new AuthActionResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            UserId = user.Id,
            UserRoleId = user.UserRoleModel!.FirstOrDefault()!.RoleId
        });
    }
    
    private string GenerateJwtToken(UserModel user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.Role, user.UserRoleModel!.FirstOrDefault()!.RoleId.ToString()),
            new Claim("InstitutionId", user.InstitutionId.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _jwtSettings.Issuer,
            _jwtSettings.Audience,
            claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpirationMinutes),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}