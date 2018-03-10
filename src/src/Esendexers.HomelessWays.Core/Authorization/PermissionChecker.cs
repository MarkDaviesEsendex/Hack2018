using Abp.Authorization;
using Esendexers.HomelessWays.Authorization.Roles;
using Esendexers.HomelessWays.Authorization.Users;

namespace Esendexers.HomelessWays.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
