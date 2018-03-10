using System.Collections.Generic;
using System.Linq;
using Esendexers.HomelessWays.Roles.Dto;
using Esendexers.HomelessWays.Users.Dto;

namespace Esendexers.HomelessWays.Web.Models.Users
{
    public class EditUserModalViewModel
    {
        public UserDto User { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }

        public bool UserIsInRole(RoleDto role)
        {
            return User.RoleNames != null && User.RoleNames.Any(r => r == role.NormalizedName);
        }
    }
}
