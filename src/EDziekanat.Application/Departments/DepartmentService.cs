using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EDziekanat.Application.Departments.Dto;
using EDziekanat.Application.Departments.Vm;
using EDziekanat.Core.Departments;
using EDziekanat.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Department> AddDepartmentAsync(CreateDepartmentDto departmentDto)
        {
            var department = _mapper.Map<Department>(departmentDto);
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<Department> DeleteDepartment(Guid id)
        {
            var deletedDepartment = await _context.Departments.FindAsync(id);
            if (deletedDepartment == null)
                return deletedDepartment;
            _context.Departments.Remove(deletedDepartment);
            await _context.SaveChangesAsync();

            return deletedDepartment;
        }

        public async Task<List<DepartmentVm>> GetAllDepartmentsAsync()
        {
            var departments = await _context.Departments.Include(d=>d.DeansOffices).ToListAsync();
            return _mapper.Map<List<Department>, List<DepartmentVm>>(departments);
        }

        public async Task<DepartmentVm> GetDepartmentByIdAsync(Guid id)
        {
            var department = await _context.Departments.FindAsync(id);
            return _mapper.Map<Department,DepartmentVm>(department);
        }

        public async Task UpdateDepartment(UpdateDepartmentDto departmentDto)
        {
            var departmentToUpdate = await _context.Departments.FindAsync(departmentDto.Id);

            if (departmentToUpdate == null)
            {
                throw new Exception("Department with specified id not found");
            }

            if (!string.IsNullOrWhiteSpace(departmentDto.Name))
                departmentToUpdate.Name = departmentDto.Name;
            if (!string.IsNullOrWhiteSpace(departmentDto.Address))
                departmentToUpdate.Address = departmentDto.Address;

            await _context.SaveChangesAsync();
        }


    }
}
