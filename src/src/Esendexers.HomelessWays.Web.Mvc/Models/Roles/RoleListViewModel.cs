using System.Collections.Generic;
using Esendexers.HomelessWays.Roles.Dto;

namespace Esendexers.HomelessWays.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
