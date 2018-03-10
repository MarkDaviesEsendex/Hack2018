using Microsoft.EntityFrameworkCore;

namespace Esendexers.HomelessWays.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<HomelessWaysDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for HomelessWaysDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}
