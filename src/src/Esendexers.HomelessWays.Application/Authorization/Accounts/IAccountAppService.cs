using System.Threading.Tasks;
using Abp.Application.Services;
using Esendexers.HomelessWays.Authorization.Accounts.Dto;

namespace Esendexers.HomelessWays.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
