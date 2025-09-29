namespace assms.api.DAL.Services.AuthServices;

public class AuthService(IAuthRepository authRepository) : IAuthService
{
    public async Task<BaseActionResponse<AuthActionResponse>> LoginAsync(LoginRequest request)
    {
        var response = await authRepository.LoginAsync(request);
        Log.Information("{User} attempts to login", request.Email);
        return new BaseActionResponse<AuthActionResponse>
        {
            Message = MessageConstants.Success(RecordTypeEnum.LogIn),
            Data = response
        };
    }

    public Task<AuthActionResponse> CreateAsync(LoginRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<AuthActionResponse> RefreshTokenAsync(string refreshToken)
    {
        throw new NotImplementedException();
    }

    public Task LogoutAsync(Guid userId)
    {
        throw new NotImplementedException();
    }
}






// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Claims;
// using System.Text;
// using assms.api.DAL.DatabaseContext;
// using assms.entities.Config;
// using assms.entities.GeneralResponse;
// using assms.entities.Models;
// using assms.entities.Response.AuthResponse;
// using Microsoft.AspNetCore.Identity.Data;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Options;
// using Microsoft.IdentityModel.Tokens;
// using StackExchange.Redis;
//
// 
//
// public class AuthService(ApplicationDbContext ctx, IOptions<JwtSettings> jwtSettings, IConnectionMultiplexer redis) : IAuthService
// {
//     private readonly JwtSettings _jwtSettings = jwtSettings.Value;
//
//     public async Task<AuthActionResponse<int>> CreateAsync(LoginRequest request)
//     {
//         var response = await authRepository.CreateBranchAsync(request);
//         Log.Information("{Branch} successfully created", request.Name);
//         return new AuthActionResponse<int>
//         {
//             Message = MessageConstants.Success(RecordType.Save),
//             Data = response
//         };
//     }
//     
//     
//     // public async Task<AuthActionResponse<int>> LoginAsync(LoginRequest request)
//     // {
//     //     // var user = await ctx.UserModel
//     //     //     .Include(u => u.UserRoleModel)
//     //     //     .FirstOrDefaultAsync(x => x.Email == request.Email);
//     //     
//     //     var user = await ctx.UserModel.Include(u=>u.UserRoleModel).FirstOrDefaultAsync(u => u.Email == request.Email);
//     //
//     //     if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
//     //         return null;
//     //
//     //     var accessToken = GenerateJwtToken(user);
//     //     var refreshToken = Guid.NewGuid().ToString();
//     //
//     //     var db = redis.GetDatabase();
//     //     await db.StringSetAsync($"refresh:{user.Id}", refreshToken,
//     //         TimeSpan.FromDays(_jwtSettings.RefreshTokenExpirationDays));
//     //
//     //     return new AuthActionResponse<int>
//     //     {
//     //         AccessToken = await accessToken,
//     //         RefreshToken = refreshToken,
//     //         UserId = user.Id,
//     //         UserRoleId = user.UserRoleModel!.FirstOrDefault()!.RoleId
//     //     };
//     // }
//     //
//     // public async Task<AuthActionResponse<int>> CreateAsync(LoginRequest request)
//     // {
//     //     var user = await ctx.UserModel.Include(u=>u.UserRoleModel).FirstOrDefaultAsync(u => u.Email == request.Email);
//     //
//     //     if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
//     //         return null;
//     //
//     //     var accessToken = GenerateJwtToken(user);
//     //     var refreshToken = Guid.NewGuid().ToString();
//     //
//     //     var db = redis.GetDatabase();
//     //     await db.StringSetAsync($"refresh:{user.Id}", refreshToken,
//     //         TimeSpan.FromDays(_jwtSettings.RefreshTokenExpirationDays));
//     //
//     //     return new AuthActionResponse<int>
//     //     {
//     //         AccessToken = await accessToken,
//     //         RefreshToken = refreshToken,
//     //         UserId = user.Id,
//     //         UserRoleId = user.UserRoleModel!.FirstOrDefault()!.RoleId
//     //     };
//     // }
//     //
//     // public async Task<BaseActionResponse<int>> CreateAsync(LoginRequest request)
//     // {
//     //     var response = await branchRepository.CreateBranchAsync(request);
//     //     Log.Information("{Branch} successfully created", request.Name);
//     //     return new BaseActionResponse<int>
//     //     {
//     //         Message = MessageConstants.Success(RecordType.Save),
//     //         Data = response
//     //     };
//     // }
//     //
//     //
//     //
//     //
//     //
//     // public async Task<AuthActionResponse<int>> RefreshTokenAsync(string refreshToken)
//     // {
//     //     var db = redis.GetDatabase();
//     //     var keys = ctx.UserModel.Select(u => u.Id).ToList();
//     //
//     //     foreach (var userId in keys)
//     //     {
//     //         var stored = await db.StringGetAsync($"refresh:{userId}");
//     //         if (!stored.HasValue || stored.ToString() != refreshToken) continue;
//     //         var user = await ctx.UserModel.Include(u=>u.UserRoleModel).FirstOrDefaultAsync(u => u.Id == userId);
//     //         if (user == null) return null;
//     //
//     //         var newAccessToken = GenerateJwtToken(user);
//     //         var newRefreshToken = Guid.NewGuid().ToString();
//     //
//     //         await db.StringSetAsync($"refresh:{user.Id}", newRefreshToken,
//     //             TimeSpan.FromDays(_jwtSettings.RefreshTokenExpirationDays));
//     //
//     //         return new AuthActionResponse<int>
//     //         {
//     //             AccessToken = await newAccessToken,
//     //             RefreshToken = newRefreshToken,
//     //             UserId = user.Id,
//     //             UserRoleId = user.UserRoleModel!.First().RoleId
//     //         };
//     //     }
//     //     return null;
//     // }
//     //
//     // public async Task LogoutAsync(Guid userId)
//     // {
//     //     var db = redis.GetDatabase();
//     //     await db.KeyDeleteAsync($"refresh:{userId}");
//     // }
//     //
//     // private async Task<string> GenerateJwtToken(UserModel user)
//     // {
//     //     var userRole = await ctx.UserRoleModel.FirstOrDefaultAsync(u => u.UserId == user.Id);
//     //     var claims = new[]
//     //     {
//     //         new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
//     //         new Claim(JwtRegisteredClaimNames.Email, user.Email),
//     //         new Claim(ClaimTypes.Role, userRole!.RoleId.ToString()),
//     //         new Claim("InstitutionId", user.InstitutionId.ToString())
//     //     };
//     //
//     //     var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret));
//     //     var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
//     //
//     //     var token = new JwtSecurityToken(
//     //         _jwtSettings.Issuer,
//     //         _jwtSettings.Audience,
//     //         claims,
//     //         expires: DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpirationMinutes),
//     //         signingCredentials: creds);
//     //
//     //     return new JwtSecurityTokenHandler().WriteToken(token);
//     // }
// }