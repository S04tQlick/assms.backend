using System.Text.Json.Serialization;

namespace assms.entities.Response.SanityResponse;

public class SanityUploadResponse
{
    [JsonPropertyName("document")]
    public SanityDocument Document { get; set; } = new();
}