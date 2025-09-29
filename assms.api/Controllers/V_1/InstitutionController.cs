namespace assms.api.Controllers.V_1;

[ApiController]
[ApiVersion(1)]
[Route("api/v{version:apiVersion}/[Controller]")]
[Authorize(Policy = $"{nameof(UserRolesEnum.SystemAdmin)}")]
public class InstitutionController(IInstitutionService institutionService) : ControllerBase
{
    [HttpGet]
    public async Task<BaseActionResponse<IEnumerable<InstitutionRowModel>>> GetAll()
    {
        Log.Information("Querying Institution service");
        return await institutionService.GetAllAsync();
    }

    [HttpGet]
    [Route(ControllerConstants.GetByDateRoute)]
    public async Task<BaseActionResponse<IEnumerable<InstitutionRowModel>>> GetByDate(DateTime date)
    {
        Log.Information("Querying Institution service by date", date);
        return await institutionService.GetAllByDateAsync(date);
    }

    [HttpPost]
    public async Task<CreatedResult> CreateAsync(InstitutionRequest request)
    {
        Log.Information("{Institution} added to database.", request.Id);
        var res = await institutionService.CreateAsync(request);
        return Created(nameof(CreateAsync), res);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(InstitutionRequest request)
    {
        Log.Information("{Institution} updated in database.", request.Id);
        await institutionService.UpdateAsync(request);
        return NoContent();
    }
}