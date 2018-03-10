using Abp.Domain.Entities;

namespace Esendexers.HomelessWays.Entities
{
    public class User : Entity
    {
        public virtual string Email { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
    }
}
