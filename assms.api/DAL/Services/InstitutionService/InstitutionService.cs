using System.ComponentModel;
using assms.api.Constants;
using assms.api.DAL.Repositories.InstitutionRepository;
using assms.entities;
using assms.entities.GeneralResponse;
using assms.entities.Request;
using assms.entities.Response.InstitutionsResponse;
using Serilog;

namespace assms.api.DAL.Services.InstitutionService;

public class InstitutionService (IInstitutionRepository institutionRepository ):IInstitutionService
{
    public async Task<BaseActionResponse<IEnumerable<InstitutionRowModel>>> GetAllAsync()
    {
        var response = await institutionRepository.GetAllAsync();
        Log.Information("Queried for records.");

        var institionList = response.ToList();

        return new BaseActionResponse<IEnumerable<InstitutionRowModel>>
        {
            Message = MessageConstants.Success(RecordType.GetAllByDate),
            Data = institionList,
            RowCount = institionList.Count,
            BranchCount = institionList.Sum(i=>i.BranchCount)
        };
    }
    
    public async Task<BaseActionResponse<IEnumerable<InstitutionRowModel>>> GetAllByDateAsync(DateTime date)
    {
        var utcDate = DateTime.SpecifyKind(date.Date, DateTimeKind.Utc);
        var response = await institutionRepository.GetAllByDateAsync(utcDate);
        Log.Information("Queried for records by {Date}.", utcDate);

        var institionList = response.ToList();

        return new BaseActionResponse<IEnumerable<InstitutionRowModel>>
        {
            Message = MessageConstants.Success(RecordType.GetAllByDate),
            Data = institionList,
            RowCount = institionList.Count,
            BranchCount = institionList.Sum(i=>i.BranchCount)
        };
    }
    
    public async Task<BaseActionResponse<int>> CreateAsync(InstitutionRequest request)
    {
        var response = await institutionRepository.CreateInstitutionAsync(request);
        Log.Information("{Institution} successfully created", request.Name);
        return new BaseActionResponse<int>
        {
            Message = MessageConstants.Success(RecordType.Save),
            Data = response
        };
    }

    public async Task<BaseActionResponse<int>> UpdateAsync(InstitutionRequest request)
    {
        var response = await institutionRepository.UpdateInstitutionAsync(request);
        Log.Information("{Institution} successfully updated", request.Id);
        return new BaseActionResponse<int>
        {
            Message = MessageConstants.Success(RecordType.Edit),
            Data = response
        };
    }

    public async Task<BaseActionResponse<int>> DeleteAsync(Guid id)
    {
        var response = await institutionRepository.DeleteInstitutionAsync(id);
        Log.Information("{Institution} successfully deleted", id);
        return new BaseActionResponse<int>
        {
            Message = MessageConstants.Success(RecordType.Delete),
            Data = response
        };
    }
}