using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Esendexers.HomelessWays.Configuration.Dto;

namespace Esendexers.HomelessWays.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : HomelessWaysAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
