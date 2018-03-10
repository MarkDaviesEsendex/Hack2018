using System.Collections.Generic;
using Esendexers.HomelessWays.Roles.Dto;
using Esendexers.HomelessWays.Users.Dto;

namespace Esendexers.HomelessWays.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
