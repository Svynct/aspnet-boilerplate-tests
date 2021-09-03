using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Projeto.AspNet.Authorization.Users;
using Projeto.AspNet.Roles.Dto;
using Projeto.AspNet.Users.Dto;

namespace Projeto.AspNet.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task DeActivate(EntityDto<long> user);
        Task Activate(EntityDto<long> user);
        Task<ListResultDto<RoleDto>> GetRoles();
        Task ChangeLanguage(ChangeUserLanguageDto input);
        Task DeleteAsync(EntityDto<long> input);
        Task<User> GetEntityById(long id);

        Task<bool> ChangePassword(ChangePasswordDto input);
        Task<bool> ResetPassword(ResetPasswordDto input);
    }
}
