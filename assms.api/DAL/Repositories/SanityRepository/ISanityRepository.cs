using assms.entities.Response.SanityResponse;

namespace assms.api.DAL.Repositories.SanityRepository;

public interface ISanityRepository
{
    Task<SanityUploadResponse?> CreateSanityUploadAsync(SanityUploadRequest request);
}