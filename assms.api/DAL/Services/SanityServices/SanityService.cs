using assms.api.DAL.Repositories.SanityRepository;

namespace assms.api.DAL.Services.SanityServices;

public class SanityService (ISanityRepository sanityRepository) :ISanityService
{
    public async Task<BaseActionResponse<object>> CreateAsync(SanityUploadRequest request)
    {
        var response = await sanityRepository.CreateSanityUploadAsync(request);
        Log.Information("{Image} Successfully Created",request);
        return new BaseActionResponse<object>
        {
            Message = MessageConstants.Success(RecordTypeEnum.Save),
            Data = response
        };
    }
}