using System;

namespace EDziekanat.Application.Dto.Account
{
    public class RegisterInput
    {
        public string Login { get; set; } // UserName
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public Guid DeansOfficeId { get; set; } // Guid
    }
}
