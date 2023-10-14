using Microsoft.AspNetCore.Authorization;

namespace EndPoint.Site.CustomFilter
{
    public class CustomAuthorizationPolicyProvider : IAuthorizationPolicyProvider
    {
        private const string POLICY_PREFIX = "RoleAuthorize";

        private readonly ILogger<CustomAuthorizationPolicyProvider> _logger;

        public CustomAuthorizationPolicyProvider(ILogger<CustomAuthorizationPolicyProvider> logger)
        {
            _logger = logger;
        }

        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            if (policyName.StartsWith(POLICY_PREFIX, StringComparison.OrdinalIgnoreCase))
            {
                var roleName = policyName.Substring(POLICY_PREFIX.Length);
                var policy = new AuthorizationPolicyBuilder()
                    .RequireRole(roleName)
                    .Build();
                return Task.FromResult(policy);
            }

            _logger.LogWarning($"No policy found for {policyName}");
            return Task.FromResult<AuthorizationPolicy>(null);
        }

        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            var defaultPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
            return Task.FromResult(defaultPolicy);
        }

        public Task<AuthorizationPolicy> GetFallbackPolicyAsync()
        {
            var fallbackPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
            return Task.FromResult(fallbackPolicy);
        }
    }
}
