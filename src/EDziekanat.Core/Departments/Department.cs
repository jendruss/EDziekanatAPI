using System;
using System.Collections.Generic;
using System.Text;
using EDziekanat.Core.DeansOffices;

namespace EDziekanat.Core.Departments
{
    public class Department : BaseEntity
    {
        //todo: Logo wydziału?

        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<DeansOffice> DeansOffices { get; set; }
    }
}
