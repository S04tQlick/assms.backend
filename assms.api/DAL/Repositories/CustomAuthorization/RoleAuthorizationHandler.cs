namespace assms.api.DAL.Repositories.CustomAuthorization;

public class RoleAuthorizationHandler(ApplicationDbContext db) : AuthorizationHandler<RoleRequirement>
{
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
    {
        var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null) return;

        var userRoleNames = await db.UserRoleModel
            .Where(ur => ur.UserId == Guid.Parse(userId))
            .Select(ur => ur.Role!.RoleName) 
            .ToListAsync();

        if (requirement.RequiredRoles.Any(r => userRoleNames.Contains(r)))
            context.Succeed(requirement);
    }
}