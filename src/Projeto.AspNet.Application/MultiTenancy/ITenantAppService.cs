using Abp.Application.Services;
using Projeto.AspNet.MultiTenancy.Dto;

namespace Projeto.AspNet.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

