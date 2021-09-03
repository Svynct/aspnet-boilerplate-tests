using System.Threading.Tasks;
using Projeto.AspNet.Configuration.Dto;

namespace Projeto.AspNet.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
