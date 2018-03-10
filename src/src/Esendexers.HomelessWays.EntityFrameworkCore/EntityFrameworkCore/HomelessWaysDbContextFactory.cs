using Esendexers.HomelessWays.Configuration;
using Esendexers.HomelessWays.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Esendexers.HomelessWays.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class HomelessWaysDbContextFactory : IDesignTimeDbContextFactory<HomelessWaysDbContext>
    {
        public HomelessWaysDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<HomelessWaysDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(HomelessWaysConsts.ConnectionStringName)
            );

            return new HomelessWaysDbContext(builder.Options);
        }
    }
}