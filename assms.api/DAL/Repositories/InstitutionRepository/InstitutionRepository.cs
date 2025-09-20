using assms.api.Constants;
using assms.api.DAL.QueryHandlers;
using assms.entities.Models;
using assms.entities.Request.InstitutionsRequest;
using assms.entities.Response.InstitutionsResponse;
using Microsoft.EntityFrameworkCore;

namespace assms.api.DAL.Repositories.InstitutionRepository;

public class InstitutionRepository(IQueryHandler<InstitutionModel> queryHandler) : IInstitutionRepository
{
    public async Task<IEnumerable<InstitutionRowModel>> GetAllByDateAsync(DateTime date)
    {
        var response = await queryHandler.GetAllByDateAsync(date);
        return response.Select(x => new InstitutionRowModel
        {
            //Id = x.Id,
            Name = x.Name,
            Country = x.Country,
            Region = x.Region,
            City = x.City,
            Address = x.Address,
            LogoUrl = x.LogoUrl,
            CreatedAt =   x.CreatedAt,
            UpdatedAt =   x.UpdatedAt,
        });
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
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            SubscriptionExpiresAt = DateTime.UtcNow.AddYears(1),
            IsActive = true,
        });
    }





    public async Task<int> UpdateInstitutionAsync(Guid id)
    {
        var response = await GetRowDataAsync(id);
       if (response is null) 
           throw new Exception(MessageConstants.NotFoundRecord);
       
       var institutionModel = new InstitutionModel
       {
           Id = response.Id,
           Name = response.Name,
           Country = response.Country,
           Region = response.Region,
           City = response.City,
           Address = response.Address,
           LogoUrl = response.LogoUrl,
           IsActive = response.IsActive,
           CreatedAt = response.CreatedAt,
           UpdatedAt = response.UpdatedAt,
           SubscriptionExpiresAt = response.SubscriptionExpiresAt,
           Latitude = response.Latitude,
           Longitude = response.Longitude,
       };

       return await queryHandler.UpdateAsync(institutionModel);
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
            LogoUrl = row.LogoUrl,
        };
    }

    public async Task<int> DeleteInstitutionAsync(Guid rowId) =>
        await queryHandler.DeleteAsync(rowId);

    private async Task<InstitutionModel?> GetRowDataAsync(Guid rowId) =>
        await queryHandler.GetByIdAsync(rowId);


    // private async Task<InstitutionModel?> GetRowDataAsync(string name, string city, string country)
    // {
    //     return await ctx.Institutions
    //         .AsNoTracking() // we just want to check, not track entity
    //         .FirstOrDefaultAsync(i =>
    //             i.Name.ToLower() == name.ToLower() &&
    //             i.City.ToLower() == city.ToLower() &&
    //             i.Country.ToLower() == country.ToLower());
    // }

}