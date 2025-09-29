namespace assms.api.DAL.Repositories.VendorRepository;

public interface IVendorRepository
{
    Task<IEnumerable<VendorRowModel>> GetAllAsync();
    Task<IEnumerable<VendorRowModel>> GetAllByDateAsync(DateTime date);
    Task<int> CreateVendorAsync(VendorRequest request);
    Task<int> UpdateVendorAsync(VendorRequest request);
    Task<int> DeleteVendorAsync(Guid rowId);
}