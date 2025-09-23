using assms.api.Constants;
using assms.api.DAL.Repositories.BranchRepository;
using assms.entities;
using assms.entities.Request;
using assms.entities.Response.BranchResponse;
using Serilog;

namespace assms.api.DAL.Services.BranchService;

public class BranchService(IBranchRepository branchRepository) : IBranchService
{
    public async Task<BranchActionResponse<IEnumerable<BranchRowModel>>> GetAllAsync()
    {
        IEnumerable<BranchRowModel> response = await branchRepository.GetAllAsync();
        Log.Information("Queried for records.");

        var branchList = response.ToList();

        return new BranchActionResponse<IEnumerable<BranchRowModel>>
        {
            Message = MessageConstants.Success(RecordType.GetAllByDate),
            Data = branchList,
            RowCount = branchList.Count,
        };
    }
    
    public async Task<BranchActionResponse<IEnumerable<BranchRowModel>>> GetAllByDateAsync(DateTime date)
    {
        var utcDate = DateTime.SpecifyKind(date.Date, DateTimeKind.Utc);
        IEnumerable<BranchRowModel> response = await branchRepository.GetAllByDateAsync(utcDate);
        Log.Information("Queried for records by {Date}.", utcDate);

        var branchList = response.ToList();

        return new BranchActionResponse<IEnumerable<BranchRowModel>>
        {
            Message = MessageConstants.Success(RecordType.GetAllByDate),
            Data = branchList,
            RowCount = branchList.Count
        };
    }
    
    
    
    
    public async Task<BranchActionResponse<int>> CreateAsync(BranchRequest request)
    {
        int response = await branchRepository.CreateBranchAsync(request);
        Log.Information("{Branch} successfully created", request.Name);
        return new BranchActionResponse<int>
        {
            Message = MessageConstants.Success(RecordType.Save),
            Data = response
        };
    }

    public async Task<BranchActionResponse<int>> UpdateAsync(BranchRequest request)
    {
        int response = await branchRepository.UpdateBranchAsync(request);
        Log.Information("{Institution} successfully updated {Branch}", request.InstitutionId,request.Id);
        return new BranchActionResponse<int>
        {
            Message = MessageConstants.Success(RecordType.Edit),
            Data = response
        };
    }

    public async Task<BranchActionResponse<int>> DeleteAsync(Guid id)
    {
        int response = await branchRepository.DeleteBranchAsync(id);
        Log.Information("{Branch} successfully deleted", id);
        return new BranchActionResponse<int>
        {
            Message = MessageConstants.Success(RecordType.Delete),
            Data = response
        };
    }
}