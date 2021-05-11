using System.Linq;
using EDziekanat.Core.Permissions;
using EDziekanat.Core.Roles;
using EDziekanat.Core.Users;

namespace EDziekanat.EntityFramework
{
    public class SeedData
    {
        #region BuildData
        public static User[] BuildApplicationUsers()
        {
            return DefaultUsers.All().ToArray();
        }

        public static Role[] BuildApplicationRoles()
        {
            return DefaultRoles.All().ToArray();
        }

        public static UserRole[] BuildApplicationUserRoles()
        {
            return new[]
            {
                //admin role to admin user
                new UserRole
                {
                    RoleId = DefaultRoles.Admin.Id,
                    UserId = DefaultUsers.Admin.Id
                },
                //employee role to employee user
                new UserRole
                {
                    RoleId = DefaultRoles.Employee.Id,
                    UserId = DefaultUsers.Employee.Id
                },
                //student role to student user
                new UserRole
                {
                    RoleId = DefaultRoles.Student.Id,
                    UserId = DefaultUsers.Student.Id
                }
            };
        }

        public static Permission[] BuildPermissions()
        {
            return DefaultPermissions.All().ToArray();
        }

        public static RolePermission[] BuildRolePermissions()
        {
            //grant all permissions to admin role
            var rolePermissions = DefaultPermissions.All().Select(p =>
                new RolePermission
                {
                    PermissionId = p.Id,
                    RoleId = DefaultRoles.Admin.Id
                }).ToList();

            //grant member access permission to member role
            rolePermissions.Add(new RolePermission
            {
                PermissionId = DefaultPermissions.MemberAccess.Id,
                RoleId = DefaultRoles.Employee.Id
            });

            return rolePermissions.ToArray();
        }
        #endregion
    }
}
