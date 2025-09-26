using assms.api.DAL.Services.AuthServices;
using assms.entities.GeneralResponse;
using assms.entities.Response.AuthResponse;
using Microsoft.AspNetCore.Identity.Data;

namespace assms.api.Controllers.V_1;

[ApiController]
[ApiVersion(1)]
[Route("api/v{version:apiVersion}/[Controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<CreatedResult> LoginAsync(LoginRequest request)
    {
        Log.Information("{Branch} added to database.", request.Email);
        BaseActionResponse<AuthActionResponse> res = await authService.LoginAsync(request);
        return Created(nameof(LoginAsync), res);
    }
    
    // [HttpPost("login")]
    // public async Task<ActionResult<BaseActionResponse<AuthResponse>>> LoginAsync([FromBody] LoginRequest request)
    // {
    //     Log.Information("{User} attemped to login to database.", request.Email);
    //     BaseActionResponse <in> res = await authService.LoginAsync(request);
    //     // var result = await authService.LoginAsync(request);
    //     // if (result == null)
    //     //     return Unauthorized(new BaseActionResponse<AuthResponse> { Success = false, Message = "Invalid credentials" });
    //     // return Ok(new BaseActionResponse<AuthResponse> { Data = result });
    // }





}