using Abp.Domain.Entities;

namespace Esendexers.HomelessWays.Entities
{
    public class Tag : Entity<uint>
    {
        public string Name { get; set; }
    }
}
