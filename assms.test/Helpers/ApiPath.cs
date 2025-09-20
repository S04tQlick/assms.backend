namespace assms.test.Helpers;

public static class ApiPath
{
    public static string SetInstitutionControllerRoute(string? route = "") =>
        $"api/v1/Institution/{route}";
}