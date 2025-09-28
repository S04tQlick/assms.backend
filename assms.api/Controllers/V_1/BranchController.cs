using assms.api.Constants;
using assms.api.DAL.Services.BranchService;
using assms.entities.GeneralResponse;
using assms.entities.Request;
using assms.entities.Response.BranchResponse;

namespace assms.api.Controllers.V_1;

[ApiController]
[ApiVersion(1)]
[Route("api/v{version:apiVersion}/[Controller]")]
public class BranchController(IBranchService branchService) : ControllerBase
{
    [HttpGet]
    public async Task<BaseActionResponse<IEnumerable<BranchRowModel>>> GetAll()
    {
        Log.Information("Querying Institution service");
        return await branchService.GetAllAsync();
    }

    [HttpGet]
    [Route(ControllerConstants.GetByDateRoute)]
    public async Task<BaseActionResponse<IEnumerable<BranchRowModel>>> GetByDate(DateTime date)
    {
        Log.Information("Querying Institution service by date", date);
        return await branchService.GetAllByDateAsync(date);
    }

    [HttpPost]
    public async Task<CreatedResult> CreateAsync(BranchRequest request)
    {
        Log.Information("{Branch} added to database.", request.Name);
        var res = await branchService.CreateAsync(request);
        return Created(nameof(CreateAsync), res);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(BranchRequest request)
    {
        Log.Information("{Institution} updated to {Branch} database.", request.InstitutionId, request.Id);
        await branchService.UpdateAsync(request);
        return NoContent();
    }
}