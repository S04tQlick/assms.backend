using Microsoft.AspNetCore.Http;

namespace assms.entities.Request;

public class SanityUploadRequest
{
    public IFormFile? File  { get; set; }
}