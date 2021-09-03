using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Projeto.AspNet.Configuration.Dto;

namespace Projeto.AspNet.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AspNetAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
