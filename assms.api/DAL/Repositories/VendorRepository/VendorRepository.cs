namespace assms.api.DAL.Repositories.VendorRepository;

public class VendorRepository(IQueryHandler<VendorModel> queryHandler) : IVendorRepository
{
    public async Task<IEnumerable<VendorRowModel>> GetAllAsync()
    {
        var response = await queryHandler.GetAllAsync(
            (VendorModel i) => i.Assets!
        );

        return response.Select(x => new VendorRowModel
        {
            Id = x.Id,
            Name= x.Name,
            ContactName= x.ContactName,
            ContactPhone= x.ContactPhone,
            ContactEmail= x.ContactEmail,
            Address= x.Address,
            CreatedAt = x.CreatedAt,
            UpdatedAt = x.UpdatedAt,
        }).ToList();
    }

    public async Task<IEnumerable<VendorRowModel>> GetAllByDateAsync(DateTime date)
    {
        var response = await queryHandler.GetAllByDateAsync(
            date,
            (VendorModel i) => i.Assets!
        );

        return response.Select(x => new VendorRowModel
        {
            Id = x.Id,
            Name= x.Name,
            ContactName= x.ContactName,
            ContactPhone= x.ContactPhone,
            ContactEmail= x.ContactEmail,
            Address= x.Address,
            CreatedAt = x.CreatedAt,
            UpdatedAt = x.UpdatedAt,
        }).ToList();
    }

    public async Task<VendorResponse> GetVendorDataAsync(Guid rowId)
    {
        var row = await GetRowDataAsync(rowId);

        if (row is null)
            throw new KeyNotFoundException(MessageConstants.NotFoundRecord);

        return new VendorResponse
        {
            Name= row.Name,
            ContactName= row.ContactName,
            ContactPhone= row.ContactPhone,
            ContactEmail= row.ContactEmail,
            Address= row.Address,
        };
    }

    public async Task<int> CreateVendorAsync(VendorRequest request)
    {
        var exists = await queryHandler.ExistsAsync(e =>
            EF.Functions.ILike(e.Name, request.Name) &&
            EF.Functions.ILike(e.ContactEmail, request.ContactEmail));

        if (exists)
            throw new Exception("Vendor already exists.");

        return await queryHandler.CreateAsync(new VendorModel
        {
            Name = request.Name,
            ContactName = request.ContactName, 
            ContactPhone = request.ContactPhone, 
            ContactEmail= request.ContactEmail,
            Address= request.Address,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        });
    }

    public async Task<int> UpdateVendorAsync(VendorRequest request)
    {
        var row = await GetRowDataAsync(request.Id);
        if (row is null)
            throw new Exception(MessageConstants.NotFoundRecord);

        row.Name = request.Name;
        row.ContactName = request.ContactName;
        row.ContactPhone = request.ContactPhone;
        row.ContactEmail = request.ContactEmail;
        row.Address = request.Address;
        row.UpdatedAt = DateTime.UtcNow;

        return await queryHandler.UpdateAsync(row);
    }

    public async Task<int> DeleteVendorAsync(Guid rowId) =>
        await queryHandler.DeleteAsync(rowId);

    private async Task<VendorModel?> GetRowDataAsync(Guid rowId) =>
        await queryHandler.GetByIdAsync(rowId);
}