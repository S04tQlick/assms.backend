using Asp.Versioning;
using assms.api.Constants;
using assms.api.DAL.Services.InstitutionService;
using assms.entities.Request.InstitutionsRequest;
using assms.entities.Response.InstitutionsResponse;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace assms.api.Controllers.V_1;

[ApiVersion(1)]
[Route("api/v{version:apiVersion}/[Controller]")]
[ApiController]

public class InstitutionController(IInstitutionService institutionService) : ControllerBase
{
    [HttpPost]
    public async Task<CreatedResult> CreateAsync(InstitutionRequest request)
    {
        Log.Information("{Institution} added to database.", request.Name);
        InstitutionActionResponse<int> res = await institutionService.CreateAsync(request);
        return Created(nameof(CreateAsync), res);
    }
}
