using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Esendexers.HomelessWays
{
    [DependsOn(
        typeof(HomelessWaysCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class HomelessWaysApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HomelessWaysApplicationModule).GetAssembly());
        }
    }
}