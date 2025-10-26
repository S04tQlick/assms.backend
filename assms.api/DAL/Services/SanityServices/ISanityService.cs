namespace assms.api.DAL.Services.SanityServices;

public interface ISanityService
{
    Task<BaseActionResponse<object>> CreateAsync(SanityUploadRequest request);
}