using EDziekanat.Application.Dto;

namespace EDziekanat.Application.Users.Dto
{
    public class UserListOutput : PagedListOutput
    {
        public string UserName { get; set; }

        public string Email { get; set; }
    }
}