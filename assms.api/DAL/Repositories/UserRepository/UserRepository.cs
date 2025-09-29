namespace assms.api.DAL.Repositories.UserRepository;

public class UserRepository(IQueryHandler<UserModel> queryHandler) : IUserRepository
{
    public async Task<IEnumerable<UserRowModel>> GetAllAsync()
    {
        var response = await queryHandler.GetAllAsync(
            //( UserRowModel i) => i. Useres!,
            //( UserRowModel i) => i.Users!,
            //( UserRowModel i) => i.Assets!
        );

        return response.Select(x => new UserRowModel
        {
            Id = x.Id,
            FirstName =  x.FirstName,
            LastName = x.LastName,
            Email = x.Email,
            DisplayName = x.DisplayName,
            Phone = x.Phone,
            IsEmailConfirmed = x.IsEmailConfirmed,
            IsPhoneConfirmed = x.IsPhoneConfirmed,
            InstitutionId = x.InstitutionId,
            BranchId = x.BranchId,
            IsActive = x.IsActive,
            CreatedAt = x.CreatedAt,
            UpdatedAt = x.UpdatedAt,
        }).ToList();
    }

    // public async Task<IEnumerable<UserRowModel>> GetAllByInstitutionAsync(UserRequest request)
    // {
    //     var response = await queryHandler.GetAllByInstitutionAsync(request.InstitutionId
    //         //( UserRowModel i) => i. Useres!,
    //         //( UserRowModel i) => i.Users!,
    //         //( UserRowModel i) => i.Assets!
    //     );
    //
    //     return response.Select(x => new UserRowModel
    //     {
    //         Id = x.Id,
    //         FirstName =  x.FirstName,
    //         LastName = x.LastName,
    //         Email = x.Email,
    //         DisplayName = x.DisplayName,
    //         Phone = x.Phone,
    //         IsEmailConfirmed = x.IsEmailConfirmed,
    //         IsPhoneConfirmed = x.IsPhoneConfirmed,
    //         InstitutionId = x.InstitutionId,
    //         BranchId = x.BranchId,
    //         RoleId = x.RoleId,
    //         IsActive = x.IsActive,
    //         CreatedAt = x.CreatedAt,
    //         UpdatedAt = x.UpdatedAt,
    //     }).ToList();
    // }

    public async Task<IEnumerable<UserRowModel>> GetAllByDateAsync(DateTime date)
    {
        var response = await queryHandler.GetAllByDateAsync(date);
        return response.Select(x => new UserRowModel
        {
            Id = x.Id,
            FirstName =  x.FirstName,
            LastName = x.LastName,
            Email = x.Email,
            DisplayName = x.DisplayName,
            Phone = x.Phone,
            IsEmailConfirmed = x.IsEmailConfirmed,
            IsPhoneConfirmed = x.IsPhoneConfirmed,
            InstitutionId = x.InstitutionId,
            BranchId = x.BranchId,
            IsActive = x.IsActive,
            CreatedAt = x.CreatedAt,
            UpdatedAt = x.UpdatedAt,
        });
    }


    public async Task<int> CreateUserAsync(UserRequest request)
    {
        var exists = await queryHandler.ExistsAsync(e =>
            EF.Functions.ILike(e.Email, request.Email) &&
            EF.Functions.ILike(e.DisplayName, request.DisplayName) &&
            EF.Functions.ILike(e.BranchId.ToString(), request.BranchId.ToString()) &&
            EF.Functions.ILike(e.InstitutionId.ToString(), request.InstitutionId.ToString()));

        if (exists)
            throw new Exception(" User already exists.");

        return await queryHandler.CreateAsync(new UserModel
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            DisplayName = request.DisplayName,
            Phone = request.Phone,
            IsEmailConfirmed = false,
            IsPhoneConfirmed = false,
            InstitutionId = request.InstitutionId,
            BranchId = request.BranchId,
            IsActive = false,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
        });
    }

    public async Task<int> UpdateUserAsync(UserRequest request)
    {
        var row = await GetRowDataAsync(request.Id);
        
        if (row is null)
            throw new Exception(MessageConstants.NotFoundRecord);

        row.FirstName = request.FirstName;
        row.LastName = request.LastName;
        row.Email = request.Email;
        row.DisplayName = request.DisplayName;
        row.Phone = request.Phone;
        row.IsEmailConfirmed = false;
        row.IsPhoneConfirmed = false;
        row.InstitutionId = request.InstitutionId;
        row.BranchId = request.BranchId;
        row.IsActive = request.IsActive;
        row.CreatedAt = request.CreatedAt;
        row.UpdatedAt = DateTime.UtcNow;

        return await queryHandler.UpdateAsync(row);
    }

    public async Task<UserResponse> GetUserDataAsync(Guid rowId)
    {
        var row = await GetRowDataAsync(rowId);

        if (row is null)
            throw new KeyNotFoundException(MessageConstants.NotFoundRecord);

        return new UserResponse
        {
            Id = row.Id,
            FirstName =  row.FirstName,
            LastName = row.LastName,
            Email = row.Email,
            DisplayName = row.DisplayName,
            Phone = row.Phone,
            IsEmailConfirmed = row.IsEmailConfirmed,
            IsPhoneConfirmed = row.IsPhoneConfirmed,
            InstitutionId = row.InstitutionId,
            BranchId = row.BranchId,
            IsActive = row.IsActive,
        };
    }

    public async Task<int> DeleteUserAsync(Guid rowId) =>
        await queryHandler.DeleteAsync(rowId);

    private async Task<UserModel?> GetRowDataAsync(Guid rowId) =>
        await queryHandler.GetByIdAsync(rowId);
}