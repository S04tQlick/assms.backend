using assms.entities.Response.InstitutionsResponse;
using assms.test.Fixtures;

namespace assms.test.Helpers;

public abstract class InstitionOperations(ApplicationFixture fixture)
{
    protected async Task<InstitutionActionResponse<IEnumerable<InstitutionRowModel>>?> GetAttendanceByDateAsync(string date)
    {
        var response = await fixture.Client.GetAsync(ApiPath.SetInstitutionControllerRoute(date));
        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadAsStringAsync();
        return TestOperations.Deserialize<InstitutionActionResponse<IEnumerable<InstitutionRowModel>>>(content);
    }
}