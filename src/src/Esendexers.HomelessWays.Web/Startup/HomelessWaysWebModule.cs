using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Esendexers.HomelessWays.Configuration;
using Esendexers.HomelessWays.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Esendexers.HomelessWays.Web.Startup
{
    [DependsOn(
        typeof(HomelessWaysApplicationModule), 
        typeof(HomelessWaysEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class HomelessWaysWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public HomelessWaysWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(HomelessWaysConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<HomelessWaysNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(HomelessWaysApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HomelessWaysWebModule).GetAssembly());
        }
    }
}