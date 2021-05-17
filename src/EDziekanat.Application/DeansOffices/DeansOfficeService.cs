using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EDziekanat.Application.DeansOffices.Vm;
using EDziekanat.Application.Departments.Vm;
using EDziekanat.Core.DeansOffices;
using EDziekanat.Core.Departments;
using EDziekanat.EntityFramework;
using EDziekanat.Utilities.Extensions.Collections;
using Microsoft.EntityFrameworkCore;

namespace EDziekanat.Application.DeansOffices
{
    public class DeansOfficeService : IDeansOfficesService
    {
        private readonly EDziekanatDbContext _context;
        private readonly IMapper _mapper;

        public DeansOfficeService(EDziekanatDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<DeansOfficeVm>> GetDeansOfficesByDepartmentId(Guid id)
        {
            var deansOffices = await _context.DeansOffices.Where(d=>d.DepartmentId==id).ToListAsync();
            return _mapper.Map<List<DeansOffice>, List<DeansOfficeVm>>(deansOffices);
        }
    }
}
