using System.Threading.Tasks;
using EDziekanat.Application.Departments.Dto;
using EDziekanat.Core.Departments;

namespace EDziekanat.Application.Departments
{
    public interface IDepartmentService
    {
        Task<Department> AddDepartmentAsync(CreateOrUpdateDepartmentDto departmentDto);
    }
}
