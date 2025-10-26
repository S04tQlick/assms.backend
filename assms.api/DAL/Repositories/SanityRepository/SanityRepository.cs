using System.Net.Http.Headers;
using assms.entities.Response.SanityResponse;

namespace assms.api.DAL.Repositories.SanityRepository;

public class SanityRepository(IHttpClientFactory clientFactory) : ISanityRepository
{
    public async Task<SanityUploadResponse?> CreateSanityUploadAsync(SanityUploadRequest request)
    {
        var file = request.File;

        if (file == null || file.Length == 0)
            throw new ArgumentException("File not selected");

        var sanityProjectId = Environment.GetEnvironmentVariable("SANITY_PROJECT_ID");
        var sanityDataset = Environment.GetEnvironmentVariable("SANITY_PROJECT_DATASET");
        var sanityToken = Environment.GetEnvironmentVariable("SANITY_PROJECT_API_TOKEN");
        var sanityProjectVersion = Environment.GetEnvironmentVariable("SANITY_PROJECT_VERSION");

        if (string.IsNullOrEmpty(sanityProjectId) ||
            string.IsNullOrEmpty(sanityDataset) ||
            string.IsNullOrEmpty(sanityToken))
        {
            throw new InvalidOperationException("Sanity configuration is missing");
        }

        var uploadUrl = $"https://{sanityProjectId}.api.sanity.io/v{sanityProjectVersion}/assets/images/{sanityDataset}";

        var client = clientFactory.CreateClient();
        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", sanityToken);

        await using var fileStream = file.OpenReadStream();
        using var content = new StreamContent(fileStream);
        content.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

        var response = await client.PostAsync(uploadUrl, content);
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Sanity upload failed: {error}");
        }

        return await response.Content.ReadFromJsonAsync<SanityUploadResponse>();
    }
}