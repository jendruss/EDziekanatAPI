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

        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public virtual ICollection<Reservation> Reservations { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public Guid? DeansOfficeId { get; set; } // NULL jeżeli to Student lub Admin, a więc dziekanat przypisany jeżeli jest to pracownik Employee
        public virtual DeansOffice DeansOffice { get; set; }

    }
}