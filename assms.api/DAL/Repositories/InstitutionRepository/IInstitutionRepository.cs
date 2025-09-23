using assms.entities.Models;
using assms.entities.Request;
using assms.entities.Response.InstitutionsResponse;

namespace assms.api.DAL.Repositories.InstitutionRepository;

public interface IInstitutionRepository
{
    Task<IEnumerable<InstitutionRowModel>> GetAllAsync();
    Task<IEnumerable<InstitutionRowModel>> GetAllByDateAsync(DateTime date);
    Task<int> CreateInstitutionAsync(InstitutionRequest request);
    Task<int> UpdateInstitutionAsync(InstitutionRequest request);
    Task<int> DeleteInstitutionAsync(Guid rowId);
}