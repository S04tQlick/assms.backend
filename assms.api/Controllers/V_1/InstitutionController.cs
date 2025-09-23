using Asp.Versioning;
using assms.api.Constants;
using assms.api.DAL.Services.InstitutionService;
using assms.entities.Request;
using assms.entities.Response.InstitutionsResponse;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace assms.api.Controllers.V_1;

[ApiController]
[ApiVersion(1)]
[Route("api/v{version:apiVersion}/[Controller]")]
public class InstitutionController(IInstitutionService institutionService) : ControllerBase
{
    [HttpGet]
    public async Task<InstitutionActionResponse<IEnumerable<InstitutionRowModel>>> GetAll()
    {
        Log.Information("Querying Institution service");
        return await institutionService.GetAllAsync();
    }
    
    [HttpGet]
    [Route(ControllerConstants.GetByDateRoute)]
    public async Task<InstitutionActionResponse<IEnumerable<InstitutionRowModel>>> GetByDate(DateTime date)
    {
        Log.Information("Querying Institution service by date", date);
        return await institutionService.GetAllByDateAsync(date);
    }
    
    [HttpPost]
    public async Task<CreatedResult> CreateAsync(InstitutionRequest request)
    {
        Log.Information("{Institution} added to database.", request.Name);
        InstitutionActionResponse<int> res = await institutionService.CreateAsync(request);
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
