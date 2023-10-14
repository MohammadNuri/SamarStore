using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using SamarStore.Application.Interfaces.Context;

namespace EndPoint.Site.CustomFilter
{
    public class RoleAuthorizationFilter : IAuthorizationFilter
    {
        private readonly IDataBaseContext _context;
        private readonly string _role;

        public RoleAuthorizationFilter(IDataBaseContext context, string role)
        {
            _context = context;
            _role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = _context.Users.SingleOrDefault(u => u.FullName == context.HttpContext.User.Identity.Name);

            if (user == null || !_context.UserInRoles.Any(ur => ur.UserId == user.Id && ur.RoleId == 1))
            {
                context.Result = new ViewResult
                {
                    ViewName = "AccessDenied" // Customize the view name as needed
                };
            }
        }
    }
}
