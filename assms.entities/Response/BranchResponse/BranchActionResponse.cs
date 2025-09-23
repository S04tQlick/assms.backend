namespace assms.entities.Response.BranchResponse;


public class BranchActionResponse<T>
{
    public required string Message { get; init; }
    public T? Data { get; set; }
    public int RowCount { get; set; }

    // Optionally include navigation collections if needed
    public int UserCount { get; set; }
    public int AssetCount { get; set; }
} 
