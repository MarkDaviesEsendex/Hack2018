using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Esendexers.HomelessWays.Configuration;
using Esendexers.HomelessWays.Web;

namespace Esendexers.HomelessWays.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class HomelessWaysDbContextFactory : IDesignTimeDbContextFactory<HomelessWaysDbContext>
    {
        public HomelessWaysDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<HomelessWaysDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            HomelessWaysDbContextConfigurer.Configure(builder, configuration.GetConnectionString(HomelessWaysConsts.ConnectionStringName));

            return new HomelessWaysDbContext(builder.Options);
        }
    }
}
