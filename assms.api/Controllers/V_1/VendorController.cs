using assms.api.Constants;
using assms.api.DAL.Services.VendorService;
using assms.entities.GeneralResponse;
using assms.entities.Request;
using assms.entities.Response.VendorResponse;

namespace assms.api.Controllers.V_1;

[ApiController]
[ApiVersion(1)]
[Route("api/v{version:apiVersion}/[Controller]")]
public class VendorController(IVendorService vendorService) : ControllerBase
{
    [HttpGet]
    public async Task<BaseActionResponse<IEnumerable<VendorRowModel>>> GetAll()
    {
        Log.Information("Querying Vendor service");
        return await vendorService.GetAllAsync();
    }

    [HttpGet]
    [Route(ControllerConstants.GetByDateRoute)]
    public async Task<BaseActionResponse<IEnumerable<VendorRowModel>>> GetByDate(DateTime date)
    {
        Log.Information("Querying Vendor service by date", date);
        return await vendorService.GetAllByDateAsync(date);
    }

    [HttpPost]
    public async Task<CreatedResult> CreateAsync(VendorRequest request)
    {
        Log.Information("{Vendor} added to database.", request.Id);
        var res = await vendorService.CreateAsync(request);
        return Created(nameof(CreateAsync), res);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(VendorRequest request)
    {
        Log.Information("{Vendor} updated in database.", request.Id);
        await vendorService.UpdateAsync(request);
        return NoContent();
    }
}