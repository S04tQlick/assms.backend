namespace assms.api.DAL.Repositories.CustomAuthorization;

public class DynamicAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options) : DefaultAuthorizationPolicyProvider(options)
{
    public override async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        // Check if the policy already exists
        var policy = await base.GetPolicyAsync(policyName);
        if (policy != null) return policy;

        // Automatically create a policy based on the policy name
        var newPolicy = new AuthorizationPolicyBuilder()
            .AddRequirements(new RoleRequirement(policyName))
            .Build();

        return newPolicy;
    }
}