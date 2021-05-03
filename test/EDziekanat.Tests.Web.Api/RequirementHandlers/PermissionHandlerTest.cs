using System.Collections.Generic;
using System.Threading.Tasks;
using EDziekanat.Web.Core.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using EDziekanat.Application.Permissions;
using EDziekanat.Core.Permissions;
using Xunit;

namespace EDziekanat.Tests.Web.Api.RequirementHandlers
{
    public class PermissionHandlerTest : ApiTestBase
    {
        [Fact]
        public async Task Should_Handle_Permission()
        {
            var permissionAppService = ServiceProvider.GetService<IPermissionAppService>();

            var requirements = new List<PermissionRequirement>
            {
                new PermissionRequirement(DefaultPermissions.MemberAccess)
            };
            var authorizationHandlerContext = new AuthorizationHandlerContext(requirements, ContextUser, null);
            var permissionHandler = new PermissionHandler(permissionAppService);
            await permissionHandler.HandleAsync(authorizationHandlerContext);

            Assert.True(authorizationHandlerContext.HasSucceeded);
        }

        [Fact]
        public async Task Should_Not_Handle_Permission_With_Null_User()
        {
            var permissionAppService = ServiceProvider.GetService<IPermissionAppService>();

            var requirements = new List<PermissionRequirement>
            {
                new PermissionRequirement(DefaultPermissions.MemberAccess)
            };
            var authorizationHandlerContext = new AuthorizationHandlerContext(requirements, null, null);
            var permissionHandler = new PermissionHandler(permissionAppService);
            await permissionHandler.HandleAsync(authorizationHandlerContext);

            Assert.True(authorizationHandlerContext.HasFailed);
        }
    }
}
