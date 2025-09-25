using assms.entities.GeneralResponse;
using assms.entities.Response.InstitutionsResponse;
using assms.test.Fixtures;

namespace assms.test.Helpers;

public abstract class InstitionOperations(ApplicationFixture fixture)
{
    protected async Task<BaseActionResponse<IEnumerable<InstitutionRowModel>>?> GetInstitutionByDateAsync(string date)
    {
        var response = await fixture.Client.GetAsync(ApiPath.SetInstitutionControllerRoute(date));
        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadAsStringAsync();
        return TestOperations.Deserialize<BaseActionResponse<IEnumerable<InstitutionRowModel>>>(content);
    }
}