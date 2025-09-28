using assms.api.Constants;
using assms.api.DAL.Services.AssetService;
using assms.entities.GeneralResponse;
using assms.entities.Request;
using assms.entities.Response.AssetResponse;

namespace assms.api.Controllers.V_1;

[ApiController]
[ApiVersion(1)]
[Route("api/v{version:apiVersion}/[Controller]")]
public class AssetController(IAssetService assetService) : ControllerBase
{
    [HttpGet]
    public async Task<BaseActionResponse<IEnumerable<AssetRowModel>>> GetAll()
    {
        Log.Information("Querying Asset service");
        return await assetService.GetAllAsync();
    }

    [HttpGet]
    [Route(ControllerConstants.GetByDateRoute)]
    public async Task<BaseActionResponse<IEnumerable<AssetRowModel>>> GetByDate(DateTime date)
    {
        Log.Information("Querying Asset service by date", date);
        return await assetService.GetAllByDateAsync(date);
    }

    [HttpPost]
    public async Task<CreatedResult> CreateAsync(AssetRequest request)
    {
        Log.Information("{Asset} added to database.", request.Id);
        var res = await assetService.CreateAsync(request);
        return Created(nameof(CreateAsync), res);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(AssetRequest request)
    {
        Log.Information("{Asset} updated in database.", request.Id);
        await assetService.UpdateAsync(request);
        return NoContent();
    }
}