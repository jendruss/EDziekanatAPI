using EDziekanat.Application.Dto;

namespace EDziekanat.Application.Roles.Dto
{
    public class RoleListInput : PagedListInput
    {
        public RoleListInput()
        {
            SortBy = "Name";
        }
    }
}