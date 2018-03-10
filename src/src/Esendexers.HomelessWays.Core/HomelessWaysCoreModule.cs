using Abp.Modules;
using Abp.Reflection.Extensions;
using Esendexers.HomelessWays.Localization;

namespace Esendexers.HomelessWays
{
    public class HomelessWaysCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            HomelessWaysLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HomelessWaysCoreModule).GetAssembly());
        }
    }
}