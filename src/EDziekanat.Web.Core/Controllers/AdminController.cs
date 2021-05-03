using Microsoft.AspNetCore.Authorization;
using EDziekanat.Core.Permissions;

namespace EDziekanat.Web.Core.Controllers
{
    [Authorize(Policy = DefaultPermissions.PermissionNameForAdministration)]
    public class AdminController : BaseController
    {

    }
}