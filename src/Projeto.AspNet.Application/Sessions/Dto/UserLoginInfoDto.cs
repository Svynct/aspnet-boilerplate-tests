using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Projeto.AspNet.Authorization.Users;

namespace Projeto.AspNet.Sessions.Dto
{
    [AutoMapFrom(typeof(User))]
    public class UserLoginInfoDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }
    }
}
