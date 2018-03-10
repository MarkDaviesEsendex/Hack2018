using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Esendexers.HomelessWays.MultiTenancy.Dto;

namespace Esendexers.HomelessWays.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
