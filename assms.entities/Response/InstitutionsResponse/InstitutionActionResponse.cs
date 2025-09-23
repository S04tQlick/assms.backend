using assms.entities.Models;
using assms.entities.Response.BranchResponse;

namespace assms.entities.Response.InstitutionsResponse;


public class InstitutionActionResponse<T>
{
    public required string Message { get; init; }
    public T? Data { get; set; }
    public int RowCount { get; set; }

    // Optionally include navigation collections if needed
    public int BranchCount { get; set; }
    public int UserCount { get; set; }
    public int AssetCount { get; set; }
} 
