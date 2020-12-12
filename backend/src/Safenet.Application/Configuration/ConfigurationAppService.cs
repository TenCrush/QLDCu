using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Safenet.Configuration.Dto;

namespace Safenet.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : SafenetAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
