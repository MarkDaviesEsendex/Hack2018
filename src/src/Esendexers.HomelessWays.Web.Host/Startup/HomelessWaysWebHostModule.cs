using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Esendexers.HomelessWays.Configuration;

namespace Esendexers.HomelessWays.Web.Host.Startup
{
    [DependsOn(
       typeof(HomelessWaysWebCoreModule))]
    public class HomelessWaysWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public HomelessWaysWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HomelessWaysWebHostModule).GetAssembly());
        }
    }
}
