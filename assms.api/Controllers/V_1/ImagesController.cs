using assms.api.DAL.Services.SanityServices;
using assms.entities.Response.SanityResponse;

namespace assms.api.Controllers.V_1;

[ApiController]
[ApiVersion(1)]
[Route("api/v{version:apiVersion}/[Controller]")]
public class ImagesController (ISanityService sanityService, IHttpClientFactory clientFactory) : ControllerBase
{
    [HttpPost("upload-image")]
    public async Task<IActionResult> CreateAsync([FromForm] SanityUploadRequest request)
    {
        Log.Information("Uploading image for file: {FileName}", request.File?.FileName);
        var res = await sanityService.CreateAsync(request);
        return Created(nameof(CreateAsync), res);
    }
}