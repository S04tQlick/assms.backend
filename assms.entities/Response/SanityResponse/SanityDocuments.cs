using System.Text.Json.Serialization;

namespace assms.entities.Response.SanityResponse;

public class SanityDocument
{
    [JsonPropertyName("_id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("_type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;

    [JsonPropertyName("originalFilename")]
    public string OriginalFilename { get; set; } = string.Empty;

    [JsonPropertyName("size")]
    public int Size { get; set; }

    [JsonPropertyName("mimeType")]
    public string MimeType { get; set; } = string.Empty;
}