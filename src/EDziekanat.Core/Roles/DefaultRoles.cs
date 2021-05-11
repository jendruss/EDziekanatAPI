using System;
using System.Collections.Generic;
using System.Globalization;

namespace EDziekanat.Core.Roles
{
    public static class DefaultRoles
    {
        public static List<Role> All()
        {
            return new List<Role>
            {
                Admin,
                Employee,
                Student
            };
        }

        public static readonly Role Admin = new Role
        {
            Id = new Guid("F22BCE18-06EC-474A-B9AF-A9DE2A7B8263"),
            Name = RoleNameForAdmin,
            NormalizedName = RoleNameForAdmin.ToUpper(CultureInfo.GetCultureInfo("en_US")),
            IsSystemDefault = true
        };

        public static readonly Role Employee = new Role
        {
            Id = new Guid("11D14A89-3A93-4D39-A94F-82B823F0D4CE"),
            Name = RoleNameForEmployee,
            NormalizedName = RoleNameForEmployee.ToUpper(CultureInfo.GetCultureInfo("en_US")),
            IsSystemDefault = true
        };

        public static readonly Role Student = new Role
        {
            Id = new Guid("A8856D4E-779C-4A49-8378-6B584C3D38FB"),
            Name = RoleNameForStudent,
            NormalizedName = RoleNameForStudent.ToUpper(CultureInfo.GetCultureInfo("en_US")),
            IsSystemDefault = true
        };

        private const string RoleNameForAdmin = "Admin";
        private const string RoleNameForEmployee = "Employee";
        private const string RoleNameForStudent = "Student";
    }
}
