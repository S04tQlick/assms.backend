namespace assms.api.DAL.Services.AssetTypeService;

public class AssetTypeService(IAssetTypeRepository assetTypeRepository) : IAssetTypeService
{
    public async Task<BaseActionResponse<IEnumerable<AssetTypeRowModel>>> GetAllAsync()
    {
        var response = await assetTypeRepository.GetAllAsync();
        Log.Information("Queried for records.");
        var responseList = response.ToList();
        return new BaseActionResponse<IEnumerable<AssetTypeRowModel>>
        {
            Message = MessageConstants.Success(RecordTypeEnum.GetAll),
            Data = responseList,
            RowCount = responseList.Count,
        };
    }

    public async Task<BaseActionResponse<AssetTypeRowModel>> GetByIdAsync(Guid id)
    {
        var response = await assetTypeRepository.GetByIdAsync(id);
        Log.Information("Queried for records by {id}.", id);

        return new BaseActionResponse<AssetTypeRowModel>
        {
            Message = MessageConstants.Success(RecordTypeEnum.GetById),
            Data = response,
        };
    }

    public async Task<BaseActionResponse<IEnumerable<AssetTypeRowModel>>> GetAllByDateAsync(DateTime date)
    {
        var utcDate = DateTime.SpecifyKind(date.Date, DateTimeKind.Utc);
        var response = await assetTypeRepository.GetAllByDateAsync(utcDate);
        Log.Information("Queried for records by {Date}.", utcDate);

        var responseList = response.ToList();

        return new BaseActionResponse<IEnumerable<AssetTypeRowModel>>
        {
            Message = MessageConstants.Success(RecordTypeEnum.GetAllByDate),
            Data = responseList,
            RowCount = responseList.Count,
        };
    }

    public async Task<BaseActionResponse<int>> CreateAsync(AssetTypeRequest request)
    {
        var response = await assetTypeRepository.CreateAssetTypeAsync(request);
        Log.Information("{AssetType} successfully created", request.Id);
        return new BaseActionResponse<int>
        {
            Message = MessageConstants.Success(RecordTypeEnum.Save),
            Data = response
        };
    }

    public async Task<BaseActionResponse<int>> UpdateAsync(AssetTypeRequest request)
    {
        var response = await assetTypeRepository.UpdateAssetTypeAsync(request);
        Log.Information("{AssetType} successfully updated", request.Id);
        return new BaseActionResponse<int>
        {
            Message = MessageConstants.Success(RecordTypeEnum.Edit),
            Data = response
        };
    }

    public async Task<BaseActionResponse<int>> DeleteAsync(Guid id)
    {
        var response = await assetTypeRepository.DeleteAssetTypeAsync(id);
        Log.Information("{AssetType} successfully deleted", id);
        return new BaseActionResponse<int>
        {
            Message = MessageConstants.Success(RecordTypeEnum.Delete),
            Data = response
        };
    }
}