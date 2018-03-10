using Abp.Domain.Entities;

namespace Esendexers.HomelessWays.Entities
{
    public class User : Entity<uint>
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
