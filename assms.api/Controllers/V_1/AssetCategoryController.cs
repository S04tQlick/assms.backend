using assms.api.Constants;
using assms.api.DAL.Services.AssetCategoryService;
using assms.entities.GeneralResponse;
using assms.entities.Request;
using assms.entities.Response.AssetCategoryResponse;

namespace assms.api.Controllers.V_1;

[ApiController]
[ApiVersion(1)]
[Route("api/v{version:apiVersion}/[Controller]")]
public class AssetCategoryController(IAssetCategoryService assetCategoryService) : ControllerBase
{
    [HttpGet]
    public async Task<BaseActionResponse<IEnumerable<AssetCategoryRowModel>>> GetAll()
    {
        Log.Information("Querying AssetCategory service");
        return await assetCategoryService.GetAllAsync();
    }

    [HttpGet]
    [Route(ControllerConstants.GetByDateRoute)]
    public async Task<BaseActionResponse<IEnumerable<AssetCategoryRowModel>>> GetByDate(DateTime date)
    {
        Log.Information("Querying AssetCategory service by date", date);
        return await assetCategoryService.GetAllByDateAsync(date);
    }

    [HttpPost]
    public async Task<CreatedResult> CreateAsync(AssetCategoryRequest request)
    {
        Log.Information("{AssetCategory} added to database.", request.Id);
        var res = await assetCategoryService.CreateAsync(request);
        return Created(nameof(CreateAsync), res);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(AssetCategoryRequest request)
    {
        Log.Information("{AssetCategory} updated in database.", request.Id);
        await assetCategoryService.UpdateAsync(request);
        return NoContent();
    }
}