using Abp.AspNetCore.Mvc.Controllers;

namespace Esendexers.HomelessWays.Web.Controllers
{
    public abstract class HomelessWaysControllerBase: AbpController
    {
        protected HomelessWaysControllerBase()
        {
            LocalizationSourceName = HomelessWaysConsts.LocalizationSourceName;
        }
    }
}