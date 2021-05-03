using System.Threading.Tasks;
using EDziekanat.Application.Permissions;
using Microsoft.AspNetCore.Authorization;

namespace EDziekanat.Web.Core.Authentication
{
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly IPermissionAppService _permissionApp;

        public PermissionHandler(IPermissionAppService permissionApp)
        {
            _permissionApp = permissionApp;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (context.User == null || !context.User.Identity.IsAuthenticated)
            {
                context.Fail();
                return;
            }

            var hasPermission = await _permissionApp.IsUserGrantedToPermissionAsync(context.User.Identity.Name, requirement.Permission.Name);
            if (hasPermission)
            {
                context.Succeed(requirement);
            }
        }
    }
}
