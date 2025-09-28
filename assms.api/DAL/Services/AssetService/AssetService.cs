using assms.api.Constants;
using assms.api.DAL.Repositories.AssetRepository;
using assms.entities;
using assms.entities.Enums;
using assms.entities.GeneralResponse;
using assms.entities.Request;
using assms.entities.Response.AssetResponse;

namespace assms.api.DAL.Services.AssetService;

public class AssetService (IAssetRepository assetRepository ):IAssetService
{
    public async Task<BaseActionResponse<IEnumerable<AssetRowModel>>> GetAllAsync()
    {
        var response = await assetRepository.GetAllAsync();
        Log.Information("Queried for records.");

        var responseList = response.ToList();

        return new BaseActionResponse<IEnumerable<AssetRowModel>>
        {
            Message = MessageConstants.Success(RecordTypeEnum.GetAll),
            Data = responseList,
            RowCount = responseList.Count,
            BranchCount = responseList.Sum(i=>i.BranchCount)
        };
    }
    
    public async Task<BaseActionResponse<IEnumerable<AssetRowModel>>> GetAllByDateAsync(DateTime date)
    {
        var utcDate = DateTime.SpecifyKind(date.Date, DateTimeKind.Utc);
        var response = await assetRepository.GetAllByDateAsync(utcDate);
        Log.Information("Queried for records by {Date}.", utcDate);

        var responseList = response.ToList();

        return new BaseActionResponse<IEnumerable<AssetRowModel>>
        {
            Message = MessageConstants.Success(RecordTypeEnum.GetAllByDate),
            Data = responseList,
            RowCount = responseList.Count,
            BranchCount = responseList.Sum(i=>i.BranchCount)
        };
    }
    
    public async Task<BaseActionResponse<int>> CreateAsync(AssetRequest request)
    {
        var response = await assetRepository.CreateAssetAsync(request);
        Log.Information("{Asset} successfully created", request.Id);
        return new BaseActionResponse<int>
        {
            Message = MessageConstants.Success(RecordTypeEnum.Save),
            Data = response
        };
    }

    public async Task<BaseActionResponse<int>> UpdateAsync(AssetRequest request)
    {
        var response = await assetRepository.UpdateAssetAsync(request);
        Log.Information("{Asset} successfully updated", request.Id);
        return new BaseActionResponse<int>
        {
            Message = MessageConstants.Success(RecordTypeEnum.Edit),
            Data = response
        };
    }

    public async Task<BaseActionResponse<int>> DeleteAsync(Guid id)
    {
        var response = await assetRepository.DeleteAssetAsync(id);
        Log.Information("{Asset} successfully deleted", id);
        return new BaseActionResponse<int>
        {
            Message = MessageConstants.Success(RecordTypeEnum.Delete),
            Data = response
        };
    }
}