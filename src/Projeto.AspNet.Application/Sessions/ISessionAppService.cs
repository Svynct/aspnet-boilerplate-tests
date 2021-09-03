using System.Threading.Tasks;
using Abp.Application.Services;
using Projeto.AspNet.Sessions.Dto;

namespace Projeto.AspNet.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
