using Abp.Application.Services;

namespace Esendexers.HomelessWays
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class HomelessWaysAppServiceBase : ApplicationService
    {
        protected HomelessWaysAppServiceBase()
        {
            LocalizationSourceName = HomelessWaysConsts.LocalizationSourceName;
        }
    }
}