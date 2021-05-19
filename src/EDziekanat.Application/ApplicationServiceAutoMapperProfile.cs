using AutoMapper;
using EDziekanat.Application.DeansOffices.Vm;
using EDziekanat.Application.Departments.Dto;
using EDziekanat.Application.Departments.Vm;
using EDziekanat.Application.Permissions.Dto;
using EDziekanat.Application.Roles.Dto;
using EDziekanat.Application.Users.Dto;
using EDziekanat.Core.DeansOffices;
using EDziekanat.Core.Departments;
using EDziekanat.Core.Permissions;
using EDziekanat.Core.Roles;
using EDziekanat.Core.Users;

namespace EDziekanat.Application
{
    public class ApplicationServiceAutoMapperProfile : Profile
    {
        public ApplicationServiceAutoMapperProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(u => u.Password, opt => opt.Ignore());
            
            CreateMap<User, UserListOutput>();
            CreateMap<Permission, PermissionDto>();
            CreateMap<Role, RoleDto>();
            CreateMap<Role, RoleListOutput>();

            CreateMap<CreateDepartmentDto, Department>();
            CreateMap<Department, DepartmentVm>();

            CreateMap<DeansOffice, DeansOfficeVm>();

            CreateMap<Reservation, ReservationVm>();
        }
    }
}