using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Esendexers.HomelessWays.Configuration;
using Esendexers.HomelessWays.EntityFrameworkCore;
using Esendexers.HomelessWays.Migrator.DependencyInjection;

namespace Esendexers.HomelessWays.Migrator
{
    [DependsOn(typeof(HomelessWaysEntityFrameworkModule))]
    public class HomelessWaysMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public HomelessWaysMigratorModule(HomelessWaysEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(HomelessWaysMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                HomelessWaysConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HomelessWaysMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
