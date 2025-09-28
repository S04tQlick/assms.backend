using assms.api.Constants;
using assms.api.DAL.Repositories.AssetCategoryRepository;
using assms.entities;
using assms.entities.Enums;
using assms.entities.GeneralResponse;
using assms.entities.Request;
using assms.entities.Response.AssetCategoryResponse;

namespace assms.api.DAL.Services.AssetCategoryService;

public class AssetCategoryService(IAssetCategoryRepository assetCategoryRepository) : IAssetCategoryService
{
    public async Task<BaseActionResponse<IEnumerable<AssetCategoryRowModel>>> GetAllAsync()
    {
        var response = await assetCategoryRepository.GetAllAsync();
        Log.Information("Queried for records.");

        var responseList = response.ToList();

        return new BaseActionResponse<IEnumerable<AssetCategoryRowModel>>
        {
            Message = MessageConstants.Success(RecordTypeEnum.GetAll),
            Data = responseList,
            RowCount = responseList.Count,
        };
    }

    public async Task<BaseActionResponse<IEnumerable<AssetCategoryRowModel>>> GetAllByDateAsync(DateTime date)
    {
        var utcDate = DateTime.SpecifyKind(date.Date, DateTimeKind.Utc);
        var response = await assetCategoryRepository.GetAllByDateAsync(utcDate);
        Log.Information("Queried for records by {Date}.", utcDate);

        var responseList = response.ToList();

        return new BaseActionResponse<IEnumerable<AssetCategoryRowModel>>
        {
            Message = MessageConstants.Success(RecordTypeEnum.GetAllByDate),
            Data = responseList,
            RowCount = responseList.Count,
        };
    }

    public async Task<BaseActionResponse<int>> CreateAsync(AssetCategoryRequest request)
    {
        var response = await assetCategoryRepository.CreateAssetCategoryAsync(request);
        Log.Information("{AssetCategory} successfully created", request.Id);
        return new BaseActionResponse<int>
        {
            Message = MessageConstants.Success(RecordTypeEnum.Save),
            Data = response
        };
    }

    public async Task<BaseActionResponse<int>> UpdateAsync(AssetCategoryRequest request)
    {
        var response = await assetCategoryRepository.UpdateAssetCategoryAsync(request);
        Log.Information("{AssetCategory} successfully updated", request.Id);
        return new BaseActionResponse<int>
        {
            Message = MessageConstants.Success(RecordTypeEnum.Edit),
            Data = response
        };
    }

    public async Task<BaseActionResponse<int>> DeleteAsync(Guid id)
    {
        var response = await assetCategoryRepository.DeleteAssetCategoryAsync(id);
        Log.Information("{AssetCategory} successfully deleted", id);
        return new BaseActionResponse<int>
        {
            Message = MessageConstants.Success(RecordTypeEnum.Delete),
            Data = response
        };
    }
}