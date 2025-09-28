using assms.entities.GeneralResponse;
using assms.entities.Response.InstitutionsResponse;
using assms.entities.Response.VendorResponse;
using assms.test.Fixtures;

namespace assms.test.Helpers;

public abstract class GeneralOperations(ApplicationFixture fixture)
{
    protected async Task<BaseActionResponse<IEnumerable<T>>?> SetGenericControllerRoute<T>(string dataTable, string date)
    {
        var response = await fixture.Client.GetAsync(ApiPath.SetGenericControllerRoute(dataTable, date));
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return TestOperations.Deserialize<BaseActionResponse<IEnumerable<T>>>(content);
    }
    
    protected async Task<BaseActionResponse<IEnumerable<InstitutionRowModel>>?> GetInstitutionByDateAsync(string date)
    {
        var response = await fixture.Client.GetAsync(ApiPath.SetInstitutionControllerRoute(date));
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return TestOperations.Deserialize<BaseActionResponse<IEnumerable<InstitutionRowModel>>>(content);
    }
    
    protected async Task<BaseActionResponse<IEnumerable<VendorRowModel>>?> GetVendorByDateAsync(string date)
    {
        var response = await fixture.Client.GetAsync(ApiPath.SetVendorControllerRoute(date));
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return TestOperations.Deserialize<BaseActionResponse<IEnumerable<VendorRowModel>>>(content);
    }
}