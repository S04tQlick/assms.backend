using assms.api.Constants;
using assms.api.DAL.Repositories.VendorRepository;
using assms.entities.Enums;
using assms.entities.GeneralResponse;
using assms.entities.Request;
using assms.entities.Response.VendorResponse;

namespace assms.api.DAL.Services.VendorService;

public class VendorService(IVendorRepository vendorRepository) : IVendorService
{
    public async Task<BaseActionResponse<IEnumerable<VendorRowModel>>> GetAllAsync()
    {
        var response = await vendorRepository.GetAllAsync();
        Log.Information("Queried for records.");

        var responseList = response.ToList();

        return new BaseActionResponse<IEnumerable<VendorRowModel>>
        {
            Message = MessageConstants.Success(RecordTypeEnum.GetAll),
            Data = responseList,
            RowCount = responseList.Count,
        };
    }

    public async Task<BaseActionResponse<IEnumerable<VendorRowModel>>> GetAllByDateAsync(DateTime date)
    {
        var utcDate = DateTime.SpecifyKind(date.Date, DateTimeKind.Utc);
        var response = await vendorRepository.GetAllByDateAsync(utcDate);
        Log.Information("Queried for records by {Date}.", utcDate);

        var responseList = response.ToList();

        return new BaseActionResponse<IEnumerable<VendorRowModel>>
        {
            Message = MessageConstants.Success(RecordTypeEnum.GetAllByDate),
            Data = responseList,
            RowCount = responseList.Count,
        };
    }

    public async Task<BaseActionResponse<int>> CreateAsync(VendorRequest request)
    {
        var response = await vendorRepository.CreateVendorAsync(request);
        Log.Information("{Vendor} successfully created", request.Id);
        return new BaseActionResponse<int>
        {
            Message = MessageConstants.Success(RecordTypeEnum.Save),
            Data = response
        };
    }

    public async Task<BaseActionResponse<int>> UpdateAsync(VendorRequest request)
    {
        var response = await vendorRepository.UpdateVendorAsync(request);
        Log.Information("{Vendor} successfully updated", request.Id);
        return new BaseActionResponse<int>
        {
            Message = MessageConstants.Success(RecordTypeEnum.Edit),
            Data = response
        };
    }

    public async Task<BaseActionResponse<int>> DeleteAsync(Guid id)
    {
        var response = await vendorRepository.DeleteVendorAsync(id);
        Log.Information("{Vendor} successfully deleted", id);
        return new BaseActionResponse<int>
        {
            Message = MessageConstants.Success(RecordTypeEnum.Delete),
            Data = response
        };
    }
}