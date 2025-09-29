namespace assms.api.DAL.Repositories.CustomAuthorization;

public class RoleRequirement(params string[] roles) : IAuthorizationRequirement
{
    public string[] RequiredRoles { get; } = roles;
}