using System.Threading.Tasks;
using Abp.Application.Services;
using Safenet.Sessions.Dto;

namespace Safenet.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
