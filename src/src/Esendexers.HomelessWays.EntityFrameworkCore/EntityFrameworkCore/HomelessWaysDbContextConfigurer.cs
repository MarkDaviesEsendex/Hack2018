using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Esendexers.HomelessWays.EntityFrameworkCore
{
    public static class HomelessWaysDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<HomelessWaysDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<HomelessWaysDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
