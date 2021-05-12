using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDziekanat.Application.Departments.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EDziekanat.Core.Departments;
using EDziekanat.EntityFramework;
using EDziekanat.Application.Departments;
using EDziekanat.Application.Departments.Vm;
using EDziekanat.Core.Permissions;
using EDziekanat.Web.Core.Controllers;
using Microsoft.AspNetCore.Authorization;

namespace EDziekanat.Web.Api.Controller.Departments
{   
    public class DepartmentsController : BaseController //: AdminController
    {
        private readonly EDziekanatDbContext _context;
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(EDziekanatDbContext context, IDepartmentService departmentService)
        {
            _context = context;
            _departmentService = departmentService;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentVm>>> GetDepartments()
        {
            return await _departmentService.GetAllDepartmentsAsync();
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentVm>> GetDepartment(Guid id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        //[Authorize(Policy = DefaultPermissions.PermissionNameForAdministration)]
        public async Task<IActionResult> UpdateDepartment(UpdateDepartmentDto department)
        {
            try
            {
                await _departmentService.UpdateDepartment(department);
            }
            catch(Exception ex)
            {
                NotFound(ex);
            }
            
           return NoContent();
        }

        // POST: api/Departments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        //[Authorize(Policy = DefaultPermissions.PermissionNameForAdministration)]
        public async Task<ActionResult<Department>> CreateDepartment(CreateDepartmentDto departmentDto)
        {
            var department = await _departmentService.AddDepartmentAsync(departmentDto);
            
            return CreatedAtAction("GetDepartment", new { id = department.Id }, department);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        //[Authorize(Policy = DefaultPermissions.PermissionNameForAdministration)]
        public async Task<ActionResult<Department>> DeleteDepartment(Guid id)
        {
            var department = await _departmentService.DeleteDepartment(id);
            if (department == null)
            {
                return NotFound();
            }

            return department;
        }
    }
}
