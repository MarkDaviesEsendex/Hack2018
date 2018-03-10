using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Esendexers.HomelessWays.Web.Startup;
namespace Esendexers.HomelessWays.Web.Tests
{
    [DependsOn(
        typeof(HomelessWaysWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class HomelessWaysWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HomelessWaysWebTestModule).GetAssembly());
        }
    }
}