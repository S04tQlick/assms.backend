namespace assms.api.DAL.Services.InstitutionService;

public class InstitutionService (IInstitutionRepository institutionRepository ):IInstitutionService
{
    public async Task<BaseActionResponse<IEnumerable<InstitutionRowModel>>> GetAllAsync()
    {
        var response = await institutionRepository.GetAllAsync();
        Log.Information("Queried for records.");

        var responseList = response.ToList();

        return new BaseActionResponse<IEnumerable<InstitutionRowModel>>
        {
            Message = MessageConstants.Success(RecordTypeEnum.GetAll),
            Data = responseList,
            RowCount = responseList.Count,
            BranchCount = responseList.Sum(i=>i.BranchCount)
        };
    }

    public async Task<BaseActionResponse<InstitutionRowModel>> GetByIdAsync(Guid id)
    {
        var response = await institutionRepository.GetByIdAsync(id);
        Log.Information("Queried for records by {id}.", id);

        return new BaseActionResponse<InstitutionRowModel>
        {
            Message = MessageConstants.Success(RecordTypeEnum.GetById),
            Data = response,
            BranchCount = response.BranchCount
        };
    }

    public async Task<BaseActionResponse<IEnumerable<InstitutionRowModel>>> GetAllByDateAsync(DateTime date)
    {
        var utcDate = DateTime.SpecifyKind(date.Date, DateTimeKind.Utc);
        var response = await institutionRepository.GetAllByDateAsync(utcDate);
        Log.Information("Queried for records by {Date}.", utcDate);

        var responseList = response.ToList();

        return new BaseActionResponse<IEnumerable<InstitutionRowModel>>
        {
            Message = MessageConstants.Success(RecordTypeEnum.GetAllByDate),
            Data = responseList,
            RowCount = responseList.Count,
            BranchCount = responseList.Sum(i=>i.BranchCount)
        };
    }
    
    public async Task<BaseActionResponse<int>> CreateAsync(InstitutionRequest request)
    {
        var response = await institutionRepository.CreateInstitutionAsync(request);
        Log.Information("{Institution} successfully created", request.Id);
        return new BaseActionResponse<int>
        {
            Message = MessageConstants.Success(RecordTypeEnum.Save),
            Data = response
        };
    }

    public async Task<BaseActionResponse<int>> UpdateAsync(InstitutionRequest request)
    {
        var response = await institutionRepository.UpdateInstitutionAsync(request);
        Log.Information("{Institution} successfully updated", request.Id);
        return new BaseActionResponse<int>
        {
            Message = MessageConstants.Success(RecordTypeEnum.Edit),
            Data = response
        };
    }

    public async Task<BaseActionResponse<int>> DeleteAsync(Guid id)
    {
        var response = await institutionRepository.DeleteInstitutionAsync(id);
        Log.Information("{Institution} successfully deleted", id);
        return new BaseActionResponse<int>
        {
            Message = MessageConstants.Success(RecordTypeEnum.Delete),
            Data = response
        };
    }
}