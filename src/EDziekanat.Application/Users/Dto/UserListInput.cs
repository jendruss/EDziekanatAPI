using EDziekanat.Application.Dto;

namespace EDziekanat.Application.Users.Dto
{
    public class UserListInput : PagedListInput
    {
        public UserListInput()
        {
            SortBy = "UserName";
        }
    }
}