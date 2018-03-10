using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Esendexers.HomelessWays.Controllers
{
    public abstract class HomelessWaysControllerBase: AbpController
    {
        protected HomelessWaysControllerBase()
        {
            LocalizationSourceName = HomelessWaysConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
