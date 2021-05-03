using System.Collections.Generic;
using System.Threading.Tasks;
using EDziekanat.Application.Permissions.Dto;
using EDziekanat.Core.Permissions;

namespace EDziekanat.Application.Permissions
{
    public interface IPermissionAppService
    {
        Task<IEnumerable<PermissionDto>> GetGrantedPermissionsAsync(string userNameOrEmail);

        Task<bool> IsUserGrantedToPermissionAsync(string userNameOrEmail, string permissionName);

        void InitializePermissions(List<Permission> permissions);
    }
}