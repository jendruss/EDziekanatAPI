using System;
using System.Collections.Generic;
using System.Text;

namespace EDziekanat.Core.DeansOffices
{
    public class Operation : BaseEntity
    {
        public string Name { get; set; }

        public Guid DeansOfficeId { get; set; }
        public virtual DeansOffice DeansOffice { get; set; }
    }
}
