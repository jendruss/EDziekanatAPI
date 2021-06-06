using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using EDziekanat.Core.DeansOffices;
using EDziekanat.Core.Users;

namespace EDziekanat.Core.Messages
{
    public class Message : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Text { get; set; }
        public DateTime SendDate { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public Guid DeansOfficeId { get; set; }
        public virtual DeansOffice DeansOffice { get; set; }
    }
}
