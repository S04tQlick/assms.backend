using assms.api.Constants;
using assms.api.DAL.Repositories.UserRepository;
using assms.entities;
using assms.entities.GeneralResponse;
using assms.entities.Request;
using assms.entities.Response.UserResponse;

namespace assms.api.DAL.Services.UserService;

public class UserService (IUserRepository  userRepository ):IUserService
{
    public async Task< BaseActionResponse<IEnumerable< UserRowModel>>> GetAllAsync()
    {
        var response = await  userRepository.GetAllAsync();
        Log.Information("Queried for records.");

        var userList = response.ToList();

        return new  BaseActionResponse<IEnumerable< UserRowModel>>
        {
            Message = MessageConstants.Success(RecordType.GetAllByDate),
            Data = userList,
            RowCount = userList.Count,
            UserCount =  userList.Sum(i=>i.UserCount)
        };
    }

    // public async Task<BaseActionResponse<IEnumerable<UserRowModel>>> GetAllByInstitutionAsync(UserRequest request)
    // {
    //     var  response = await userRepository.GetAllByInstitutionAsync(request.InstitutionId);
    //     Log.Information("Queried for {Institution} records.",request.InstitutionId);
    //     
    //     var userList = response.ToList();
    //
    //     return new  BaseActionResponse<IEnumerable< UserRowModel>>
    //     {
    //         Message = MessageConstants.Success(RecordType.GetAllByDate),
    //         Data = userList,
    //         RowCount = userList.Count,
    //         UserCount =  userList.Sum(i=>i.UserCount)
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
            Message = MessageConstants.Success(RecordType.GetAllByDate),
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
            Message = MessageConstants.Success(RecordType.Save),
            Data = response
        };
    }

    public async Task< BaseActionResponse<int>> UpdateAsync( UserRequest request)
    {
        var response = await  userRepository.UpdateUserAsync(request);
        Log.Information("{ User} successfully updated", request.Id);
        return new  BaseActionResponse<int>
        {
            Message = MessageConstants.Success(RecordType.Edit),
            Data = response
        };
    }

    public async Task< BaseActionResponse<int>> DeleteAsync(Guid id)
    {
        var response = await  userRepository.DeleteUserAsync(id);
        Log.Information("{ User} successfully deleted", id);
        return new  BaseActionResponse<int>
        {
            Message = MessageConstants.Success(RecordType.Delete),
            Data = response
        };
    }
}