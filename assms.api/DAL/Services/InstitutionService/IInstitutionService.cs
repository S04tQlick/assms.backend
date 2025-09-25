using assms.entities.GeneralResponse;
using assms.entities.Request;
using assms.entities.Response.InstitutionsResponse;

namespace assms.api.DAL.Services.InstitutionService;

public interface IInstitutionService
{
    Task<BaseActionResponse<IEnumerable<InstitutionRowModel>>> GetAllAsync();
    Task<BaseActionResponse<IEnumerable<InstitutionRowModel>>> GetAllByDateAsync(DateTime date);
    Task<BaseActionResponse<int>> CreateAsync(InstitutionRequest request);
    Task<BaseActionResponse<int>> UpdateAsync(InstitutionRequest request);
    Task<BaseActionResponse<int>> DeleteAsync(Guid id);
}