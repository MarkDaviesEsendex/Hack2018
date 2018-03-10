using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Esendexers.HomelessWays.EntityFrameworkCore
{
    public class HomelessWaysDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...

        public HomelessWaysDbContext(DbContextOptions<HomelessWaysDbContext> options) 
            : base(options)
        {

        }
    }
}
