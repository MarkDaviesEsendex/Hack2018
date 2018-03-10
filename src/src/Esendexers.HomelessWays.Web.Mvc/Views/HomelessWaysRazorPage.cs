using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace Esendexers.HomelessWays.Web.Views
{
    public abstract class HomelessWaysRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected HomelessWaysRazorPage()
        {
            LocalizationSourceName = HomelessWaysConsts.LocalizationSourceName;
        }
    }
}
