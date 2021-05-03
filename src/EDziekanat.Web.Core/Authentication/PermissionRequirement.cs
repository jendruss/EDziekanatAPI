using Microsoft.AspNetCore.Authorization;
using EDziekanat.Core.Permissions;

namespace EDziekanat.Web.Core.Authentication
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public PermissionRequirement(Permission permission)
        {
            Permission = permission;
        }

        public Permission Permission { get; }
    }
}
