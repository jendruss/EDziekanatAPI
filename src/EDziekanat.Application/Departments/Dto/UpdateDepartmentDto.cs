using System;
using System.Collections.Generic;
using System.Text;

namespace EDziekanat.Application.Departments.Dto
{
    public class UpdateDepartmentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
