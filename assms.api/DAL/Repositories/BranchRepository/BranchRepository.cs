namespace assms.api.DAL.Repositories.BranchRepository;

public class BranchRepository(IQueryHandler<BranchModel> queryHandler) : IBranchRepository
{
    public async Task<IEnumerable<BranchRowModel>> GetAllAsync()
    {
        var response = await queryHandler.GetAllAsync(
            //(BranchRowModel i) => i.Branches!,
            //(BranchRowModel i) => i.Users!,
            //(BranchRowModel i) => i.Assets!
        );

        return response.Select(x => new BranchRowModel
        {
            Id = x.Id,
            Name = x.Name,
            Country = x.Country,
            Region = x.Region,
            City = x.City,
            Address = x.Address,
            InstitutionId = x.InstitutionId,
            IsActive = x.IsActive,
            CreatedAt = x.CreatedAt,
            UpdatedAt = x.UpdatedAt,
        }).ToList();
    }

    public async Task<IEnumerable<BranchRowModel>> GetAllByDateAsync(DateTime date)
    {
        var response = await queryHandler.GetAllByDateAsync(date);
        return response.Select(x => new BranchRowModel
        {
            Id = x.Id,
            Name = x.Name,
            Country = x.Country,
            Region = x.Region,
            City = x.City,
            Address = x.Address,
            InstitutionId = x.InstitutionId,
            IsActive = x.IsActive,
            CreatedAt =   x.CreatedAt,
            UpdatedAt =   x.UpdatedAt,
        });
    }

    public async Task<int> CreateBranchAsync(BranchRequest request)
    {
        var exists = await queryHandler.ExistsAsync(e =>
            EF.Functions.ILike(e.Name, request.Name) &&
            EF.Functions.ILike(e.City, request.City) &&
            EF.Functions.ILike(e.Region, request.Region) &&
            EF.Functions.ILike(e.Country, request.Country) &&
            EF.Functions.ILike(e.InstitutionId.ToString(), request.InstitutionId.ToString()));
       
        if (exists)
            throw new Exception("Branch already exists.");

        return await queryHandler.CreateAsync(new BranchModel
        {
            Name = request.Name,
            Country = request.Country,
            Region = request.Region,
            City = request.City,
            Address = request.Address,
            InstitutionId = request.InstitutionId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            IsActive = true,
        });
    }

    public async Task<int> UpdateBranchAsync(BranchRequest request)
    {
        var row = await GetRowDataAsync(request.Id);
        if (row is null)
            throw new Exception(MessageConstants.NotFoundRecord);

        row.Id = request.Id;
        row.Name = request.Name;
        row.Country = request.Country;
        row.Region = request.Region;
        row.City = request.City;
        row.Address = request.Address;
        row.CreatedAt = request.CreatedAt;
        row.UpdatedAt = DateTime.UtcNow;
        row.Latitude = request.Latitude;
        row.Longitude = request.Longitude;
        row.IsActive = request.IsActive;
        row.InstitutionId = request.InstitutionId;

        return await queryHandler.UpdateAsync(row);
    }

    public async Task<BranchResponse> GetBranchDataAsync(Guid rowId)
    {
        var row = await GetRowDataAsync(rowId);

        if (row is null)
            throw new KeyNotFoundException(MessageConstants.NotFoundRecord);

        return new BranchResponse
        {
            Name = row.Name,
            Country = row.Country,
            Region = row.Region,
            City = row.City,
            Address = row.Address,
        };
    }

    public async Task<int> DeleteBranchAsync(Guid rowId) =>
        await queryHandler.DeleteAsync(rowId);

    private async Task<BranchModel?> GetRowDataAsync(Guid rowId) =>
        await queryHandler.GetByIdAsync(rowId);
}