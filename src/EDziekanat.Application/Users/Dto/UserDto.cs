using System;
using EDziekanat.Application.Dto;

namespace EDziekanat.Application.Users.Dto
{
    public class UserDto : EntityDto
    {
        public Guid DeansOfficeId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}