using Abp.Application.Services.Dto;

namespace Projeto.AspNet.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

