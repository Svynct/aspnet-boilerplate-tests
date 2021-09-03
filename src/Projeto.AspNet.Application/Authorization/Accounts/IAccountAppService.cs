using System.Threading.Tasks;
using Abp.Application.Services;
using Projeto.AspNet.Authorization.Accounts.Dto;

namespace Projeto.AspNet.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
