namespace assms.api.DAL.Services.UserService;

public class UserService (IUserRepository  userRepository ):IUserService
{
    public async Task< BaseActionResponse<IEnumerable< UserRowModel>>> GetAllAsync()
    {
        var response = await  userRepository.GetAllAsync();
        Log.Information("Queried for records.");

        var responseList = response.ToList();

        return new  BaseActionResponse<IEnumerable< UserRowModel>>
        {
            Message = MessageConstants.Success(RecordTypeEnum.GetAllByDate),
            Data = responseList,
            RowCount = responseList.Count,
            UserCount =  responseList.Sum(i=>i.UserCount)
        };
    }

    // public async Task<BaseActionResponse<IEnumerable<UserRowModel>>> GetAllByInstitutionAsync(UserRequest request)
    // {
    //     var  response = await userRepository.GetAllByInstitutionAsync(request.InstitutionId);
    //     Log.Information("Queried for {Institution} records.",request.InstitutionId);
    //     
    //     var responseList = response.ToList();
    //
    //     return new  BaseActionResponse<IEnumerable< UserRowModel>>
    //     {
    //         Message = MessageConstants.Success(RecordType.GetAllByDate),
    //         Data = responseList,
    //         RowCount = responseList.Count,
    //         UserCount =  responseList.Sum(i=>i.UserCount)
    //     };
    // }

    public async Task< BaseActionResponse<IEnumerable< UserRowModel>>> GetAllByDateAsync(DateTime date)
    {
        var utcDate = DateTime.SpecifyKind(date.Date, DateTimeKind.Utc);
        var response = await  userRepository.GetAllByDateAsync(utcDate);
        Log.Information("Queried for records by {Date}.", utcDate);

        var branchList = response.ToList();

        return new  BaseActionResponse<IEnumerable< UserRowModel>>
        {
            Message = MessageConstants.Success(RecordTypeEnum.GetAllByDate),
            Data = branchList,
            RowCount = branchList.Count,
            UserCount =  branchList.Sum(i=>i.UserCount)
        };
    }

    public async Task<BaseActionResponse<int>> CreateAsync(UserRequest request)
    {
        var response = await userRepository.CreateUserAsync(request);
        Log.Information("{ User} successfully created", request.Email);
        return new BaseActionResponse<int>
        {
            Message = MessageConstants.Success(RecordTypeEnum.Save),
            Data = response
        };
    }

    public async Task< BaseActionResponse<int>> UpdateAsync( UserRequest request)
    {
        var response = await  userRepository.UpdateUserAsync(request);
        Log.Information("{ User} successfully updated", request.Id);
        return new  BaseActionResponse<int>
        {
            Message = MessageConstants.Success(RecordTypeEnum.Edit),
            Data = response
        };
    }

    public async Task< BaseActionResponse<int>> DeleteAsync(Guid id)
    {
        var response = await  userRepository.DeleteUserAsync(id);
        Log.Information("{ User} successfully deleted", id);
        return new  BaseActionResponse<int>
        {
            Message = MessageConstants.Success(RecordTypeEnum.Delete),
            Data = response
        };
    }
}