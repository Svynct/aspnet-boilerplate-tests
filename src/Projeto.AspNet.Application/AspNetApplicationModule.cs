using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Projeto.AspNet.Authorization;

namespace Projeto.AspNet
{
    [DependsOn(
        typeof(AspNetCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AspNetApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AspNetAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AspNetApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
