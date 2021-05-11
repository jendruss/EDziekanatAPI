using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EDziekanat.Application.Departments.Dto;
using EDziekanat.Core.Departments;
using EDziekanat.EntityFramework;
using Microsoft.AspNetCore.Http;

namespace EDziekanat.Application.Departments
{
    public class DepartmentService : IDepartmentService
    {
        private readonly EDziekanatDbContext _context;
        private readonly IMapper _mapper;

        public DepartmentService(EDziekanatDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Department> AddDepartmentAsync(CreateOrUpdateDepartmentDto departmentDto)
        {
            var department = _mapper.Map<Department>(departmentDto);
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department;
        }
    }
}
