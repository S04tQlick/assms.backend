using System.Text;

namespace assms.test.Helpers;

public abstract class TestOperations
{
    public static T? Deserialize<T>(string content) where T : class => 
        JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
    
    public static StringContent SetRequestBody<T>(T model) =>
        new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
}