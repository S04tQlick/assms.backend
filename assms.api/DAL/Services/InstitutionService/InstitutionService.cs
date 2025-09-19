using System.ComponentModel;
using assms.api.Constants;
using assms.api.DAL.Repositories.InstitutionRepository;
using assms.entities;
using assms.entities.Request.InstitutionsRequest;
using assms.entities.Response.InstitutionsResponse;
using Serilog;

namespace assms.api.DAL.Services.InstitutionService;

public class InstitutionService (IInstitutionRepository institutionRepository ):IInstitutionService
{
    public async Task<InstitutionActionResponse<int>> CreateAsync(InstitutionRequest request)
    {
        int response = await institutionRepository.CreateInstitutionAsync(request);
        Log.Information("{Institution} successfully created", request.Name);
        return new InstitutionActionResponse<int>
        {
            Message = MessageConstants.Success(RecordType.Save),
            Data = response
        };
    }

    public async Task<InstitutionActionResponse<int>> UpdateAsync(Guid id, InstitutionRequest request)
    {
        int response = await institutionRepository.UpdateInstitutionAsync(id);
        Log.Information("{Institution} successfully updated", request.Name);
        return new InstitutionActionResponse<int>
        {
            Message = MessageConstants.Success(RecordType.Edit),
            Data = response
        };
    }

    public async Task<InstitutionActionResponse<int>> DeleteAsync(Guid id)
    {
        int response = await institutionRepository.DeleteInstitutionAsync(id);
        Log.Information("{Institution} successfully deleted", id);
        return new InstitutionActionResponse<int>
        {
            Message = MessageConstants.Success(RecordType.Delete),
            Data = response
        };
    }

    public async Task<InstitutionActionResponse<IEnumerable<InstitutionRowModel>>> GetAllByDateAsync(DateTime date)
    {
        var utcDate = DateTime.SpecifyKind(date.Date, DateTimeKind.Utc);
        IEnumerable<InstitutionRowModel> response= await institutionRepository.GetAllByDateAsync(utcDate);
        Log.Information("Queried for records by {Date}.",utcDate);
        
        var institionList =response.ToList();
        
        return new InstitutionActionResponse<IEnumerable<InstitutionRowModel>>
        {
            Message = MessageConstants.Success(RecordType.GetAllByDate),
            Data = institionList,
            RowCount = institionList.Count
        };
    }
}