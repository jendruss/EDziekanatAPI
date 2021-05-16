using System;
using System.Collections.Generic;
using System.Text;
using EDziekanat.Core.Departments;
using EDziekanat.Core.Messages;
using EDziekanat.Core.Users;

namespace EDziekanat.Core.DeansOffices
{
    public class DeansOffice : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
