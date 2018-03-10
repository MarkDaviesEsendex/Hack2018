using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Esendexers.HomelessWays.EntityFrameworkCore
{
    [DependsOn(
        typeof(HomelessWaysCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class HomelessWaysEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HomelessWaysEntityFrameworkCoreModule).GetAssembly());
        }
    }
}