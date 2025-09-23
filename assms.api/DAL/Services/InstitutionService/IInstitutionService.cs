using assms.entities.Request;
using assms.entities.Response.InstitutionsResponse;

namespace assms.api.DAL.Services.InstitutionService;

public interface IInstitutionService
{
    Task<InstitutionActionResponse<IEnumerable<InstitutionRowModel>>> GetAllAsync();
    Task<InstitutionActionResponse<IEnumerable<InstitutionRowModel>>> GetAllByDateAsync(DateTime date);
    Task<InstitutionActionResponse<int>> CreateAsync(InstitutionRequest request);
    Task<InstitutionActionResponse<int>> UpdateAsync(InstitutionRequest request);
    Task<InstitutionActionResponse<int>> DeleteAsync(Guid id);
}