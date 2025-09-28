namespace assms.test.Helpers;

public static class ApiPath
{
    public static string SetGenericControllerRoute(string dataTable, string? route = "") =>
        $"api/v1/{dataTable}/{route}";
    
    public static string SetInstitutionControllerRoute(string? route = "") =>
        $"api/v1/Institution/{route}";
    public static string SetBranchControllerRoute(string? route = "") =>
        $"api/v1/Branch/{route}";
    public static string SetVendorControllerRoute(string? route = "") =>
        $"api/v1/Vendor/{route}";
}