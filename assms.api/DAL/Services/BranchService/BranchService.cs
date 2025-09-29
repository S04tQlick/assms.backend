namespace assms.api.DAL.Services.BranchService;

public class BranchService(IBranchRepository branchRepository) : IBranchService
{
    public async Task<BaseActionResponse<IEnumerable<BranchRowModel>>> GetAllAsync()
    {
        var response = await branchRepository.GetAllAsync();
        Log.Information("Queried for records.");

        var responseList = response.ToList();

        return new BaseActionResponse<IEnumerable<BranchRowModel>>
        {
            Message = MessageConstants.Success(RecordTypeEnum.GetAll),
            Data = responseList,
            RowCount = responseList.Count,
        };
    }
    
    public async Task<BaseActionResponse<IEnumerable<BranchRowModel>>> GetAllByDateAsync(DateTime date)
    {
        var utcDate = DateTime.SpecifyKind(date.Date, DateTimeKind.Utc);
        var response = await branchRepository.GetAllByDateAsync(utcDate);
        Log.Information("Queried for records by {Date}.", utcDate);

        var responseList = response.ToList();

        return new BaseActionResponse<IEnumerable<BranchRowModel>>
        {
            Message = MessageConstants.Success(RecordTypeEnum.GetAllByDate),
            Data = responseList,
            RowCount = responseList.Count
        };
    }
   
    public async Task<BaseActionResponse<int>> CreateAsync(BranchRequest request)
    {
        var response = await branchRepository.CreateBranchAsync(request);
        Log.Information("{Branch} successfully created", request.Id);
        return new BaseActionResponse<int>
        {
            Message = MessageConstants.Success(RecordTypeEnum.Save),
            Data = response
        };
    }

    public async Task<BaseActionResponse<int>> UpdateAsync(BranchRequest request)
    {
        var response = await branchRepository.UpdateBranchAsync(request);
        Log.Information("{Institution} successfully updated {Branch}", request.InstitutionId,request.Id);
        return new BaseActionResponse<int>
        {
            Message = MessageConstants.Success(RecordTypeEnum.Edit),
            Data = response
        };
    }

    public async Task<BaseActionResponse<int>> DeleteAsync(Guid id)
    {
        var response = await branchRepository.DeleteBranchAsync(id);
        Log.Information("{Branch} successfully deleted", id);
        return new BaseActionResponse<int>
        {
            Message = MessageConstants.Success(RecordTypeEnum.Delete),
            Data = response
        };
    }
}