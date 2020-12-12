using System.Threading.Tasks;
using Abp.Application.Services;
using Safenet.Authorization.Accounts.Dto;

namespace Safenet.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
