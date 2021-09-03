using Abp.Authorization;
using Projeto.AspNet.Authorization.Roles;
using Projeto.AspNet.Authorization.Users;

namespace Projeto.AspNet.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
