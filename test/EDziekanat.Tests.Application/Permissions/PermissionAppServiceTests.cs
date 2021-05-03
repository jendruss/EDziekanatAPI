using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using EDziekanat.Application.Permissions;
using EDziekanat.Core.Permissions;
using EDziekanat.Core.Users;
using Xunit;

namespace EDziekanat.Tests.Application.Permissions
{
    public class PermissionAppServiceTests : ApplicationTestBase
    {
        private readonly IPermissionAppService _permissionAppService;

        public PermissionAppServiceTests()
        {
            _permissionAppService = ServiceProvider.GetService<IPermissionAppService>();
        }

        [Fact]
        public async Task Should_Permission_Granted_To_User()
        {
            var isPermissionGranted =
                await _permissionAppService.IsUserGrantedToPermissionAsync(ContextUser.Identity.Name, DefaultPermissions.MemberAccess.Name);

            Assert.True(isPermissionGranted);
        }

        [Fact]
        public async Task Should_Not_Permission_Granted_To_User()
        {
            var isPermissionNotGranted =
                await _permissionAppService.IsUserGrantedToPermissionAsync(null, DefaultPermissions.MemberAccess.Name);

            Assert.False(isPermissionNotGranted);
        }

        [Fact]
        public async Task Should_Get_Granted_Permissions()
        {
            var grantedPermissions =
                await _permissionAppService.GetGrantedPermissionsAsync(DefaultUsers.TestAdmin.UserName);

            Assert.True(grantedPermissions.Any());
        }
    }
}