using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Projeto.AspNet.Configuration;

namespace Projeto.AspNet.Web.Host.Startup
{
    [DependsOn(
       typeof(AspNetWebCoreModule))]
    public class AspNetWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AspNetWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AspNetWebHostModule).GetAssembly());
        }
    }
}
