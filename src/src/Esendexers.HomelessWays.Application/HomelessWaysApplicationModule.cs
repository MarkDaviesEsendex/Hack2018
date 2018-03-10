using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Esendexers.HomelessWays.Authorization;

namespace Esendexers.HomelessWays
{
    [DependsOn(
        typeof(HomelessWaysCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class HomelessWaysApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<HomelessWaysAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(HomelessWaysApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
