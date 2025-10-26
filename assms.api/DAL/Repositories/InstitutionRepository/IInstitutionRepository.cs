namespace assms.api.DAL.Repositories.InstitutionRepository;

public interface IInstitutionRepository
{
    Task<IEnumerable<InstitutionRowModel>> GetAllAsync();
    Task<IEnumerable<InstitutionRowModel>> GetAllByDateAsync(DateTime date);
    Task<InstitutionRowModel> GetByIdAsync(Guid id);
    Task<int> CreateInstitutionAsync(InstitutionRequest request);
    Task<int> UpdateInstitutionAsync(InstitutionRequest request);
    Task<int> DeleteInstitutionAsync(Guid rowId);
}