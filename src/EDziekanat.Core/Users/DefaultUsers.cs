using System;
using System.Globalization;
using System.Collections.Generic;

namespace EDziekanat.Core.Users
{
    public class DefaultUsers
    {
        public static List<User> All()
        {
            return new List<User>
            {
                Admin,
                Employee,
                Student
            };
        }

        public static readonly User Admin = new User
        {
            Id = new Guid("C41A7761-6645-4E2C-B99D-F9E767B9AC77"),
            UserName = AdminUserName,
            Email = AdminUserEmail,
            EmailConfirmed = true,
            NormalizedEmail = AdminUserEmail.ToUpper(CultureInfo.GetCultureInfo("en_US")),
            NormalizedUserName = AdminUserName.ToUpper(CultureInfo.GetCultureInfo("en_US")),
            AccessFailedCount = 5,
            PasswordHash = PasswordHashFor123Qwe,
            FirstName = AdminUserName,
            LastName = AdminUserName
        };

        public static readonly User Employee = new User
        {
            Id = new Guid("4B6D9E45-626D-489A-A8CF-D32D36583AF4"),
            UserName = EmployeeUserName,
            Email = EmployeeUserEmail,
            EmailConfirmed = true,
            NormalizedEmail = EmployeeUserEmail.ToUpper(CultureInfo.GetCultureInfo("en_US")),
            NormalizedUserName = EmployeeUserName.ToUpper(CultureInfo.GetCultureInfo("en_US")),
            AccessFailedCount = 5,
            PasswordHash = PasswordHashFor123Qwe
        };

        public static readonly User Student = new User
        {
            Id = new Guid("065E903E-6F7B-42B8-B807-0C4197F9D1BC"),
            UserName = StudentUserName,
            Email = StudentUserEmail,
            EmailConfirmed = true,
            NormalizedEmail = StudentUserEmail.ToUpper(CultureInfo.GetCultureInfo("en_US")),
            NormalizedUserName = StudentUserName.ToUpper(CultureInfo.GetCultureInfo("en_US")),
            AccessFailedCount = 5,
            PasswordHash = PasswordHashFor123Qwe
        };

        private const string PasswordHashFor123Qwe = "AM4OLBpptxBYmM79lGOX9egzZk3vIQU3d/gFCJzaBjAPXzYIK3tQ2N7X4fcrHtElTw=="; //123qwe

        private const string AdminUserName = "Admin";
        private const string AdminUserEmail = "admin@mail.com";

        private const string EmployeeUserName = "Pracownik dziekanatu";
        private const string EmployeeUserEmail = "employee@mail.com";
        
        private const string StudentUserName = "Student";
        private const string StudentUserEmail = "student@mail.com";
    }
}
