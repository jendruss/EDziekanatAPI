using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EDziekanat.Application.Departments.Dto;
using EDziekanat.Application.Departments.Vm;
using EDziekanat.Core.Departments;

namespace EDziekanat.Application.Departments
{
    public interface IDepartmentService
    {
        Task<Department> AddDepartmentAsync(CreateDepartmentDto departmentDto);
        Task<List<DepartmentVm>> GetAllDepartmentsAsync();
        Task<DepartmentVm> GetDepartmentByIdAsync(Guid id);
        Task UpdateDepartment(UpdateDepartmentDto department);
        Task<Department> DeleteDepartment(Guid id);
    }
}
