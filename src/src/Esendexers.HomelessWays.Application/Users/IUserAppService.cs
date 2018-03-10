using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Esendexers.HomelessWays.Roles.Dto;
using Esendexers.HomelessWays.Users.Dto;

namespace Esendexers.HomelessWays.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
