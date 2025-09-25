using System.Reflection;

namespace assms.api.Constants;

public static class ControllerConstants
{
    public const string HealthRoute = "health";
    public const string GetByDateRoute = "{date}";
    public const string GetByIdRoute = "{rowId}";
    public const string GetByInstitutionIdRoute = "{InstitutionId}";
    //public const string GetByInstitutionIdRoute = "{rowId}/{parentId}";
    public static string HealthMessage =>
        $"Application is running healthy from {Assembly.GetExecutingAssembly().GetName().Name}.";
}