using Abp.AspNetCore.Mvc.ViewComponents;

namespace Esendexers.HomelessWays.Web.Views
{
    public abstract class HomelessWaysViewComponent : AbpViewComponent
    {
        protected HomelessWaysViewComponent()
        {
            LocalizationSourceName = HomelessWaysConsts.LocalizationSourceName;
        }
    }
}
