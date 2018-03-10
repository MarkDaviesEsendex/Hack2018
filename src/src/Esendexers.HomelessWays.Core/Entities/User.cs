using Abp.Domain.Entities;

namespace Esendexers.HomelessWays.Entities
{
    public class User : Entity
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
