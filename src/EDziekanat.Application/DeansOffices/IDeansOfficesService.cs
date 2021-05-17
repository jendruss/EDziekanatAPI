using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EDziekanat.Application.DeansOffices.Vm;
using EDziekanat.Core.DeansOffices;

namespace EDziekanat.Application.DeansOffices
{
    public interface IDeansOfficesService
    {
        Task<List<DeansOfficeVm>> GetDeansOfficesByDepartmentId(Guid id);
    }
}
