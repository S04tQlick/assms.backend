namespace assms.api.Controllers.V_1;

[ApiController]
[ApiVersion(1)]
[Route("api/v{version:apiVersion}/[Controller]")]
//[Authorize(Policy = $"{nameof(UserRolesEnum.SystemAdmin)}")]
public class AssetTypesController(IAssetTypeService assetTypeService) : ControllerBase
{
    [HttpGet]
    public async Task<BaseActionResponse<IEnumerable<AssetTypeRowModel>>> GetAll()
    {
        Log.Information("Querying AssetType service");
        return await assetTypeService.GetAllAsync();
    }

    [HttpGet]
    [Route(ControllerConstants.GetByIdRoute)]
    public async Task<BaseActionResponse<AssetTypeRowModel>> GetById(Guid rowId)
    {
        Log.Information("Querying Institution service by rowId", rowId);
        return await assetTypeService.GetByIdAsync(rowId);
    }

    [HttpGet]
    [Route(ControllerConstants.GetByDateRoute)]
    public async Task<BaseActionResponse<IEnumerable<AssetTypeRowModel>>> GetByDate(DateTime date)
    {
        Log.Information("Querying AssetType service by date", date);
        return await assetTypeService.GetAllByDateAsync(date);
    }

    [HttpPost]
    public async Task<CreatedResult> CreateAsync(AssetTypeRequest request)
    {
        Log.Information("{AssetType} added to database.", request.Id);
        var res = await assetTypeService.CreateAsync(request);
        return Created(nameof(CreateAsync), res);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(AssetTypeRequest request)
    {
        Log.Information("{AssetType} updated in database.", request.Id);
        await assetTypeService.UpdateAsync(request);
        return NoContent();
    }
}