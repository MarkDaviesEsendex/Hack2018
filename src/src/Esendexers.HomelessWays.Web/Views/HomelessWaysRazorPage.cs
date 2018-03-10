using Abp.AspNetCore.Mvc.Views;

namespace Esendexers.HomelessWays.Web.Views
{
    public abstract class HomelessWaysRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected HomelessWaysRazorPage()
        {
            LocalizationSourceName = HomelessWaysConsts.LocalizationSourceName;
        }
    }
}
