namespace assms.api.DAL.Repositories.InstitutionRepository;

public class InstitutionRepository(IQueryHandler<InstitutionModel> queryHandler) : IInstitutionRepository
{
    public async Task<IEnumerable<InstitutionRowModel>> GetAllAsync()
    {
        var response = await queryHandler.GetAllAsync(
            (InstitutionModel i) => i.Branches!,
            (InstitutionModel i) => i.Users!,
            (InstitutionModel i) => i.Assets!
        );

        return response.Select(x => new InstitutionRowModel
        {
            InstitutionId = x.Id,
            Name = x.Name,
            Country = x.Country,
            Region = x.Region,
            City = x.City,
            Address = x.Address,
            LogoUrl = x.LogoUrl,
            IsActive = x.IsActive,
            SubscriptionExpiresAt = x.SubscriptionExpiresAt ?? DateTime.MinValue,
            BranchCount = x.Branches?.Count ?? 0,
            UserCount = x.Users?.Count ?? 0,
            AssetCount = x.Assets?.Count ?? 0
        }).ToList();
    }

    public async Task<IEnumerable<InstitutionRowModel>> GetAllByDateAsync(DateTime date)
    {
        var response = await queryHandler.GetAllByDateAsync(
            date,
            (InstitutionModel i) => i.Branches!,
            (InstitutionModel i) => i.Users!,
            (InstitutionModel i) => i.Assets!
        );

        return response.Select(x => new InstitutionRowModel
        {
            InstitutionId = x.Id,
            Name = x.Name,
            Country = x.Country,
            Region = x.Region,
            City = x.City,
            Address = x.Address,
            LogoUrl = x.LogoUrl,
            IsActive = x.IsActive,
            SubscriptionExpiresAt = x.SubscriptionExpiresAt ?? DateTime.MinValue,
            BranchCount = x.Branches?.Count ?? 0,
            UserCount = x.Users?.Count ?? 0,
            AssetCount = x.Assets?.Count ?? 0
        }).ToList();
    }

    public async Task<InstitutionResponse> GetInstitutionDataAsync(Guid rowId)
    {
        var row = await GetRowDataAsync(rowId);

        if (row is null)
            throw new KeyNotFoundException(MessageConstants.NotFoundRecord);

        return new InstitutionResponse
        {
            Name = row.Name,
            Country = row.Country,
            Region = row.Region,
            City = row.City,
            Address = row.Address,
            LogoUrl = row.LogoUrl
        };
    }

    public async Task<int> CreateInstitutionAsync(InstitutionRequest request)
    {
        var exists = await queryHandler.ExistsAsync(e =>
            EF.Functions.ILike(e.Name, request.Name) &&
            EF.Functions.ILike(e.City, request.City) &&
            EF.Functions.ILike(e.Region, request.Region) &&
            EF.Functions.ILike(e.Country, request.Country));

        if (exists)
            throw new Exception("Institution already exists.");

        return await queryHandler.CreateAsync(new InstitutionModel
        {
            Name = request.Name,
            Country = request.Country,
            Region = request.Region,
            City = request.City,
            Address = request.Address,
            LogoUrl = request.LogoUrl,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            SubscriptionExpiresAt = DateTime.UtcNow.AddYears(1),
            IsActive = true
        });
    }

    public async Task<int> UpdateInstitutionAsync(InstitutionRequest request)
    {
        var row = await GetRowDataAsync(request.Id);
        if (row is null)
            throw new Exception(MessageConstants.NotFoundRecord);

        row.Name = request.Name;
        row.Country = request.Country;
        row.Region = request.Region;
        row.City = request.City;
        row.Address = request.Address;
        row.LogoUrl = request.LogoUrl;
        row.UpdatedAt = DateTime.UtcNow;
        row.SubscriptionExpiresAt = request.SubscriptionExpiresAt;
        row.IsActive = request.IsActive;

        return await queryHandler.UpdateAsync(row);
    }

    public async Task<int> DeleteInstitutionAsync(Guid rowId) =>
        await queryHandler.DeleteAsync(rowId);

    private async Task<InstitutionModel?> GetRowDataAsync(Guid rowId) =>
        await queryHandler.GetByIdAsync(rowId);
}