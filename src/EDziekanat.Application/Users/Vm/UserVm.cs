using System;
using System.Collections.Generic;
using System.Text;
using EDziekanat.Application.Dto;

namespace EDziekanat.Application.Users.Vm
{
    public class UserVm
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
