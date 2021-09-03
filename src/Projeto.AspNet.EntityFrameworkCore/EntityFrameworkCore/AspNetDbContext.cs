using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Projeto.AspNet.Authorization.Roles;
using Projeto.AspNet.Authorization.Users;
using Projeto.AspNet.MultiTenancy;

namespace Projeto.AspNet.EntityFrameworkCore
{
    public class AspNetDbContext : AbpZeroDbContext<Tenant, Role, User, AspNetDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public AspNetDbContext(DbContextOptions<AspNetDbContext> options)
            : base(options)
        {
        }
    }
}
