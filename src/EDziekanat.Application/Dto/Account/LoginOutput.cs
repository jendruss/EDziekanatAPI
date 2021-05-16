using EDziekanat.Application.Users.Dto;

namespace EDziekanat.Application.Dto.Account
{
    public class LoginOutput
    {
        public GetUserForCreateOrUpdateOutput User { get; set; }
        public string Token { get; set; }
    }
}
