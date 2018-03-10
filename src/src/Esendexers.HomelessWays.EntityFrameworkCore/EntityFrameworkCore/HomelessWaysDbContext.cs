using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Esendexers.HomelessWays.Authorization.Roles;
using Esendexers.HomelessWays.Authorization.Users;
using Esendexers.HomelessWays.MultiTenancy;

namespace Esendexers.HomelessWays.EntityFrameworkCore
{
    public class HomelessWaysDbContext : AbpZeroDbContext<Tenant, Role, User, HomelessWaysDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public HomelessWaysDbContext(DbContextOptions<HomelessWaysDbContext> options)
            : base(options)
        {
        }
    }
}
