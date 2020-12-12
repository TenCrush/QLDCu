using System.Threading.Tasks;
using Safenet.Configuration.Dto;

namespace Safenet.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
