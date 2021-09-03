using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Projeto.AspNet.EntityFrameworkCore;
using Projeto.AspNet.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Projeto.AspNet.Web.Tests
{
    [DependsOn(
        typeof(AspNetWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class AspNetWebTestModule : AbpModule
    {
        public AspNetWebTestModule(AspNetEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AspNetWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(AspNetWebMvcModule).Assembly);
        }
    }
}