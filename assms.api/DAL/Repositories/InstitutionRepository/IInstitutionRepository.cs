using assms.entities.Models;
using assms.entities.Request.InstitutionsRequest;
using assms.entities.Response.InstitutionsResponse;

namespace assms.api.DAL.Repositories.InstitutionRepository;

public interface IInstitutionRepository
{
    Task<IEnumerable<InstitutionRowModel>> GetAllByDateAsync(DateTime date);
    Task<int> CreateInstitutionAsync(InstitutionRequest request);
    Task<int> UpdateInstitutionAsync(Guid rowId);
    //Task<InstitutionResponse> GetInstitutionDataAsync(Guid rowId);
    Task<int> DeleteInstitutionAsync(Guid rowId);
}