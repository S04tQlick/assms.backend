namespace assms.entities.Response.UserResponse;


public class UserActionResponse<T>
{
    public required string Message { get; init; }
    public T? Data { get; set; }
    public int RowCount { get; set; }

    // Optionally include navigation collections if needed
    public int UserCount { get; set; }
} 
