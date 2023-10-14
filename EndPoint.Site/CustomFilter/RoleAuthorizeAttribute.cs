using Microsoft.AspNetCore.Authorization;

namespace EndPoint.Site.CustomFilter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class RoleAuthorizeAttribute : AuthorizeAttribute
    {
        public RoleAuthorizeAttribute(string role)
        {
            Roles = role;
        }
    }
}
