using System.Collections.Generic;
using System.Threading.Tasks;
using EDziekanat.Application.Permissions;
using EDziekanat.Application.Permissions.Dto;
using Microsoft.AspNetCore.Mvc;
using EDziekanat.Web.Core.Controllers;

namespace EDziekanat.Web.Api.Controller.Permissions
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : AuthorizedController
    {
        private readonly IPermissionAppService _permissionAppService;

        public PermissionsController(IPermissionAppService permissionAppService)
        {
            _permissionAppService = permissionAppService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PermissionDto>>> GetPermissions(string userNameOrEmail)
        {
            return Ok(await _permissionAppService.GetGrantedPermissionsAsync(userNameOrEmail));
        }
    }
}