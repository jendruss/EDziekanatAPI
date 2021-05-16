using System;
using System.Collections.Generic;
using EDziekanat.Core.DeansOffices;
using EDziekanat.Core.Messages;
using Microsoft.AspNetCore.Identity;

namespace EDziekanat.Core.Users
{
    public class User : IdentityUser<Guid>
    {
        //todo: Avatar użytkownika?
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public virtual ICollection<Reservation> Reservations { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public Guid? DeansOfficeId { get; set; }
        public virtual DeansOffice DeansOffice { get; set; }

    }
}