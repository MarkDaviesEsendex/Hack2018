using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Esendexers.HomelessWays.Roles.Dto;

namespace Esendexers.HomelessWays.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();
    }
}
