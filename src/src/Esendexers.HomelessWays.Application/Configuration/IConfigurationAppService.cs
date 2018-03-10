using System.Threading.Tasks;
using Esendexers.HomelessWays.Configuration.Dto;

namespace Esendexers.HomelessWays.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
