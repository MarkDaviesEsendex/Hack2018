using System.Threading.Tasks;
using Abp.Application.Services;
using Esendexers.HomelessWays.Sessions.Dto;

namespace Esendexers.HomelessWays.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
