using Abp.EntityFrameworkCore;
using Esendexers.HomelessWays.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Esendexers.HomelessWays.EntityFrameworkCore
{
    public class HomelessWaysDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Incident> Incidents { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<IncidentTag> IncidentTags { get; set; }

        public HomelessWaysDbContext(DbContextOptions<HomelessWaysDbContext> options) 
            : base(options)
        {

        }
    }
}
