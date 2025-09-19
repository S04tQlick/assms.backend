using assms.entities.Request.InstitutionsRequest;
using assms.entities.Response.InstitutionsResponse;

namespace assms.api.DAL.Services.InstitutionService;

public interface IInstitutionService
{
    Task<InstitutionActionResponse<int>> CreateAsync(InstitutionRequest request);
    Task<InstitutionActionResponse<int>> UpdateAsync(Guid id,InstitutionRequest request);
    Task<InstitutionActionResponse<int>> DeleteAsync(Guid id);
    Task<InstitutionActionResponse<IEnumerable<InstitutionRowModel>>> GetAllByDateAsync(DateTime date);
}