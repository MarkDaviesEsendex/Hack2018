using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Esendexers.HomelessWays.Configuration;

namespace Esendexers.HomelessWays.Web.Startup
{
    [DependsOn(typeof(HomelessWaysWebCoreModule))]
    public class HomelessWaysWebMvcModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public HomelessWaysWebMvcModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<HomelessWaysNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HomelessWaysWebMvcModule).GetAssembly());
        }
    }
}
