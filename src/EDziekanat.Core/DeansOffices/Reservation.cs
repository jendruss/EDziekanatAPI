﻿using System;
using EDziekanat.Core.Users;

namespace EDziekanat.Core.DeansOffices
{
    public class Reservation : BaseEntity
    {
        public DateTime Date { get; set; }

        public Guid DeansOfficeId { get; set; }
        public virtual DeansOffice DeansOffice { get; set; }

        public Guid? StudentId { get; set; }
        public virtual User Student { get; set; }
    }
}
