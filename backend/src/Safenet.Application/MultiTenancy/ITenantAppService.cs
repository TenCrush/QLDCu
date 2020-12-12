using Abp.Application.Services;
using Safenet.MultiTenancy.Dto;

namespace Safenet.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

