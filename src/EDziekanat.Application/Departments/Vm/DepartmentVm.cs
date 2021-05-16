using System;
using System.Collections.Generic;
using System.Text;
using EDziekanat.Application.DeansOffices.Vm;

namespace EDziekanat.Application.Departments.Vm
{
    public class DepartmentVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<DeansOfficeVm> DeansOffices { get; set; }
    }
}
