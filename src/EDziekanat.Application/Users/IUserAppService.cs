using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using EDziekanat.Application.Users.Dto;
using EDziekanat.Utilities.Collections;

namespace EDziekanat.Application.Users
{
    public interface IUserAppService
    {
        Task<IPagedList<UserListOutput>> GetUsersAsync(UserListInput input);

        Task<GetUserForCreateOrUpdateOutput> GetUserForCreateOrUpdateAsync(Guid id);

        Task<IdentityResult> AddUserAsync(CreateOrUpdateUserInput input);

        Task<IdentityResult> EditUserAsync(CreateOrUpdateUserInput input);
        
        Task<IdentityResult> RemoveUserAsync(Guid id);
    }
}