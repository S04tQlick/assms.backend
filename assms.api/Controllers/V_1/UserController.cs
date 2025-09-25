using assms.api.Constants;
using assms.api.DAL.Services.UserService;
using assms.entities.GeneralResponse;
using assms.entities.Request;
using assms.entities.Response.UserResponse;

namespace assms.api.Controllers.V_1;

[ApiController]
[ApiVersion(1)]
[Route("api/v{version:apiVersion}/[controller]")]
public class UserController (IUserService userService) : ControllerBase
{
    // [HttpGet]
    // [Route(ControllerConstants.GetByInstitutionIdRoute)]
    // public async Task<ActionResult<BaseActionResponse<IEnumerable<UserRowModel>>>>  GetAll(UserRequest request)
    // {
    //     Log.Information("Querying {Institution} service by date",request.InstitutionId);
    //     return await userService.GetAllByInstitutionAsync(request);
    // }

    [HttpPost]
    public async Task<ActionResult<UserRowModel>> CreateAsync(UserRequest request)
    {
        Log.Information("{Institution} added to database.", request.Id);
        BaseActionResponse<int> res= await userService.CreateAsync(request);
        return Created(nameof(CreateAsync), res);
    }

    [HttpPut]
    public async Task<ActionResult<UserRowModel>> UpdateAsync(UserRequest request)
    {
        Log.Information("{Institution} updated to database.", request.Id);
        BaseActionResponse<int>res= await userService.UpdateAsync(request);
        return NoContent();
    }
}